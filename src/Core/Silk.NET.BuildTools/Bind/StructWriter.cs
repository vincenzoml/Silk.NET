// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Humanizer;
using Silk.NET.BuildTools.Common;
using Silk.NET.BuildTools.Common.Builders;
using Silk.NET.BuildTools.Common.Functions;
using Silk.NET.BuildTools.Common.Structs;
using Silk.NET.BuildTools.Cpp;
using Type = Silk.NET.BuildTools.Common.Functions.Type;

namespace Silk.NET.BuildTools.Bind
{
    public static class StructWriter
    {
        /// <summary>
        /// Writes this struct to a file.
        /// </summary>
        /// <param name="struct">The enum to write.</param>
        /// <param name="file">The file to write to.</param>
        /// <param name="profile">The subsystem containing this enum.</param>
        /// <param name="project">The project containing this enum.</param>
        public static void WriteStruct(this Struct @struct, string file, Profile profile, Project project, BindState task)
        {
            if (@struct.Attributes.IsBuildToolsIntrinsic(out var args))
            {
                WriteBuildToolsIntrinsic(@struct, file, profile, project, task, args);
                return;
            }
        
            var sw = new StreamWriter(file);
            sw.WriteLine(task.LicenseText());
            sw.WriteLine();
            sw.WriteCoreUsings();
            sw.WriteLine();
            sw.WriteLine("#pragma warning disable 1591");
            sw.WriteLine();
            var ns = project.IsRoot ? task.Task.Namespace : task.Task.ExtensionsNamespace;
            sw.WriteLine($"namespace {ns}{project.Namespace}");
            sw.WriteLine("{");
            foreach (var attr in @struct.Attributes)
            {
                if (attr.Name == "BuildToolsIntrinsic")
                {
                    continue;
                }
                
                sw.WriteLine($"    {attr}");
            }

            sw.WriteLine($"    [NativeName(\"Name\", \"{@struct.NativeName}\")]");
            sw.WriteLine($"    public unsafe partial struct {@struct.Name}");
            sw.WriteLine("    {");
            foreach (var comBase in @struct.ComBases)
            {
                var asSuffix = comBase.Split('.').Last();
                asSuffix = (asSuffix.StartsWith('I') ? asSuffix.Substring(1) : comBase);
                asSuffix = asSuffix.StartsWith(task.Task.FunctionPrefix)
                    ? asSuffix.Substring(task.Task.FunctionPrefix.Length)
                    : asSuffix;
                var fromSuffix = @struct.Name.Split('.').Last();
                fromSuffix = (fromSuffix.StartsWith('I') ? fromSuffix.Substring(1) : comBase);
                fromSuffix = fromSuffix.StartsWith(task.Task.FunctionPrefix)
                    ? fromSuffix.Substring(task.Task.FunctionPrefix.Length)
                    : fromSuffix;
                sw.WriteLine($"        public static implicit operator {comBase}({@struct.Name} val)");
                sw.WriteLine($"            => Unsafe.As<{@struct.Name}, {comBase}>(ref val);");
                sw.WriteLine();
                if (@struct.Functions.Any(x => x.Signature.Name.Equals("QueryInterface")))
                {
                    sw.WriteLine($"        public static explicit operator {@struct.Name}({comBase} val)");
                    sw.WriteLine($"            => From{fromSuffix}(in val);");
                    sw.WriteLine();
                    sw.WriteLine($"        public readonly ref {comBase} As{asSuffix}()");
                    sw.WriteLine("        {");
                    // yes i know this is unsafe and that there's a good reason why struct members can't return themselves
                    // by reference, but this should work well enough.
                    sw.WriteLine("#if NETSTANDARD2_1 || NET5_0 || NETCOREAPP3_1");
                    sw.WriteLine($"            return ref Unsafe.As<{@struct.Name}, {comBase}>");
                    sw.WriteLine($"            (");
                    sw.WriteLine($"                ref MemoryMarshal.GetReference");
                    sw.WriteLine($"                (");
                    sw.WriteLine($"                    MemoryMarshal.CreateSpan");
                    sw.WriteLine($"                    (");
                    sw.WriteLine($"                        ref Unsafe.AsRef(in this),");
                    sw.WriteLine($"                        1");
                    sw.WriteLine($"                    )");
                    sw.WriteLine($"                )");
                    sw.WriteLine($"            );");
                    sw.WriteLine("#else");
                    sw.WriteLine($"            fixed ({@struct.Name}* @this = &this)");
                    sw.WriteLine($"            {{");
                    sw.WriteLine($"                return ref *({comBase}*) @this;");
                    sw.WriteLine($"            }}");
                    sw.WriteLine("#endif");
                    sw.WriteLine("        }");
                    sw.WriteLine();
                    sw.WriteLine($"        public static ref {@struct.Name} From{fromSuffix}(in {comBase} @this)");
                    sw.WriteLine("        {");
                    sw.WriteLine($"            {@struct.Name}* ret = default;");
                    sw.WriteLine($"            SilkMarshal.ThrowHResult");
                    sw.WriteLine($"            (");
                    sw.WriteLine($"                @this.QueryInterface");
                    sw.WriteLine($"                (");
                    sw.WriteLine($"                    ref SilkMarshal.GuidOf<{@struct.Name}>(),");
                    sw.WriteLine($"                    (void**) &ret");
                    sw.WriteLine($"                )");
                    sw.WriteLine($"            );");
                    sw.WriteLine();
                    sw.WriteLine($"            return ref *ret;");
                    sw.WriteLine("        }");
                    sw.WriteLine();
                }
            }
            
            if (@struct.Fields.Any(x => x.Count is null))
            {
                sw.WriteLine($"        public {@struct.Name}");
                sw.WriteLine( "        (");
                var first = true;
                foreach (var field in @struct.Fields)
                {
                    if (!(field.Count is null))
                        continue; // I've chosen not to initialize multi-count fields from ctors.
                    var argName = field.Name[0].ToString().ToLower() + field.Name.Substring(1);
                    argName = Utilities.CSharpKeywords.Contains(argName) ? $"@{argName}" : argName;
                    if (!first)
                    {
                        sw.WriteLine(",");
                    }
                    else
                    {
                        first = false;
                    }

                    var nullable = field.Type.ToString().Contains('*') ? null : "?";
                    sw.Write($"            {field.Type}{nullable} {argName} = {field.DefaultAssignment ?? "null"}");
                }

                sw.WriteLine();
                sw.WriteLine("        ) : this()");
                sw.WriteLine("        {");
                first = true;
                foreach (var field in @struct.Fields)
                {
                    if (!(field.Count is null))
                        continue; // I've chosen not to initialize multi-count fields from ctors.
                    var argName = field.Name[0].ToString().ToLower() + field.Name.Substring(1);
                    argName = Utilities.CSharpKeywords.Contains(argName) ? $"@{argName}" : argName;
                    if (!first)
                    {
                        sw.WriteLine();
                    }
                    else
                    {
                        first = false;
                    }

                    sw.WriteLine($"            if ({argName} is not null)");
                    sw.WriteLine("            {");

                    var value = field.Type.ToString().Contains('*') ? null : ".Value";
                    sw.WriteLine($"                {field.Name} = {argName}{value};");
                    sw.WriteLine("            }");
                }

                sw.WriteLine("        }");
                sw.WriteLine();
            }

            foreach (var structField in @struct.Fields)
            {
                if (!(structField.Count is null))
                {
                    var @const = structField.Count.IsConstant
                        ? profile.Projects.SelectMany(x => x.Value.Classes.SelectMany(y => y.Constants))
                            .FirstOrDefault(x => x.NativeName == structField.Count.ConstantName)
                            ?
                            .Value ?? profile.Projects.SelectMany
                                (x => x.Value.Enums.SelectMany(y => y.Tokens))
                            .FirstOrDefault(x => x.NativeName == structField.Count.ConstantName)
                            ?.Value ??
                        throw new InvalidDataException("Couldn't find constant referenced")
                        : null;
                    var count = structField.Count.IsConstant
                        ? int.TryParse(@const, out var result) || int.TryParse
                            (@const, NumberStyles.HexNumber, null, out result) ? result
                        : 1
                        : structField.Count.IsStatic
                            ? structField.Count.StaticCount
                            : 1;
                    if (!Field.FixedCapableTypes.Contains(structField.Type.Name))
                    {
                        var typeFixup09072020 = new TypeSignatureBuilder(structField.Type).WithIndirectionLevel
                            (structField.Type.IndirectionLevels - 1).Build();
                        sw.WriteLine($"        {structField.Doc}");
                        foreach (var attr in structField.Attributes)
                        {
                            sw.WriteLine($"        {attr}");
                        }

                        sw.WriteLine($"        [NativeName(\"Type\", \"{structField.NativeType}\")]");
                        sw.WriteLine($"        [NativeName(\"Type.Name\", \"{structField.Type.OriginalName}\")]");
                        sw.WriteLine($"        [NativeName(\"Name\", \"{structField.NativeName}\")]");
                        sw.WriteLine($"        public {structField.Name}Buffer {structField.Name};");
                        sw.WriteLine();
                        sw.WriteLine($"        public struct {structField.Name}Buffer");
                        sw.WriteLine("        {");
                        for (var i = 0; i < count; i++)
                        {
                            sw.WriteLine($"            public {typeFixup09072020} Element{i};");
                        }
                        
                        sw.WriteLine($"            public ref {typeFixup09072020} this[int index]");
                        sw.WriteLine("            {");
                        sw.WriteLine("                get");
                        sw.WriteLine("                {");
                        sw.WriteLine($"                    if (index > {count - 1} || index < 0)");
                        sw.WriteLine("                    {");
                        sw.WriteLine("                        throw new ArgumentOutOfRangeException(nameof(index));");
                        sw.WriteLine("                    }");
                        sw.WriteLine();
                        sw.WriteLine($"                    fixed ({typeFixup09072020}* ptr = &Element0)");
                        sw.WriteLine("                    {");
                        sw.WriteLine("                        return ref ptr[index];");
                        sw.WriteLine("                    }");
                        sw.WriteLine("                }");
                        sw.WriteLine("            }");
                        if (!typeFixup09072020.IsPointer)
                        {
                            sw.WriteLine();
                            sw.WriteLine("#if NETSTANDARD2_1");
                            sw.WriteLine($"            public Span<{typeFixup09072020}> AsSpan()");
                            sw.WriteLine($"                => MemoryMarshal.CreateSpan(ref Element0, {count});");
                            sw.WriteLine("#endif");
                        }

                        sw.WriteLine("        }");
                        sw.WriteLine();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(structField.Doc))
                        {
                            sw.WriteLine($"        {structField.Doc}");
                        }

                        var typeFixup09072020 = new TypeSignatureBuilder(structField.Type).WithIndirectionLevel
                            //(structField.Type.IndirectionLevels - 1).Build();
                            (0).Build();

                        foreach (var attr in structField.Attributes)
                        {
                            sw.WriteLine($"        {attr}");
                        }

                        sw.WriteLine($"        [NativeName(\"Type\", \"{structField.NativeType}\")]");
                        sw.WriteLine($"        [NativeName(\"Type.Name\", \"{structField.Type.OriginalName}\")]");
                        sw.WriteLine($"        [NativeName(\"Name\", \"{structField.NativeName}\")]");
                        sw.WriteLine($"        public fixed {typeFixup09072020} {structField.Name}[{count}];");
                    }
                }
                else
                {
                    sw.WriteLine(structField.Doc);
                    foreach (var attr in structField.Attributes)
                    {
                        sw.WriteLine($"        {attr}");
                    }

                    sw.WriteLine($"        [NativeName(\"Type\", \"{structField.NativeType}\")]");
                    sw.WriteLine($"        [NativeName(\"Type.Name\", \"{structField.Type.OriginalName}\")]");
                    sw.WriteLine($"        [NativeName(\"Name\", \"{structField.NativeName}\")]");
                    if (structField.Type.IsFunctionPointer)
                    {
                        var camel = structField.Name.Camelize();
                        sw.WriteLine($"        public {structField.Type} {structField.Name}");
                        sw.WriteLine($"        {{");
                        sw.WriteLine($"            get => ({structField.Type}) _{camel};");
                        sw.WriteLine($"            set => _{camel} = value;");
                        sw.WriteLine($"        }}");
                        sw.WriteLine();
                        sw.WriteLine($"        private void* _{camel};");
                    }
                    else
                    {
                        sw.WriteLine($"        public {structField.Type} {structField.Name};");
                    }
                }
            }

            foreach (var function in @struct.Functions.Concat
                (ComVtblProcessor.GetHelperFunctions(@struct, profile.Projects["Core"])))
            {
                using (var sr = new StringReader(function.Signature.Doc))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        sw.WriteLine($"        {line}");
                    }
                }

                foreach (var attr in function.Signature.Attributes)
                {
                    sw.WriteLine($"        [{attr.Name}({string.Join(", ", attr.Arguments)})]");
                }

                using (var sr = new StringReader(function.Signature.ToString(null, accessibility: true, semicolon: false)))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        sw.WriteLine($"        {line}");
                    }
                }

                sw.WriteLine("        {");
                foreach (var line in function.Body)
                {
                    sw.WriteLine($"            {line}");
                }

                sw.WriteLine("        }");
                sw.WriteLine();
            }

            sw.WriteLine("    }");

            // don't apply the wrappers to COM
            if ((@struct.ComBases?.Count ?? 0) == 0)
            {
                WritePtrWrapper(sw, @struct, profile);
                if (@struct.Fields.Any(x => x.Type.IsPointer))
                {
                    WriteSafeWrapper(sw, @struct, profile);
                }
            }

            sw.WriteLine("}");
            sw.Flush();
            sw.Dispose();
        }

        public static void WriteBuildToolsIntrinsic(Struct @struct, string file, Profile profile, Project project, BindState task, List<string> args)
        {
            if (args[0] == "$PFN")
            {
                WriteFunctionPointerWrapper
                    (@struct, file, profile, project, task, args[1], args[2], Enum.Parse<CallingConvention>(args[3]));
            }
            else
            {
                throw new InvalidOperationException("Struct is not a valid intrinsic");
            }
        }

        public static void WritePtrWrapper(StreamWriter sw, Struct s, Profile profile)
        {
            sw.WriteLine($"    public unsafe partial struct {s.Name}Ptr : IDisposable");
            sw.WriteLine("    {");
            sw.WriteLine($"        public {s.Name}* Value;");
            sw.WriteLine($"        public static {s.Name}Ptr Allocate() => new {s.Name}Ptr");
            sw.WriteLine($"        {{");
            sw.WriteLine($"            Value = ({s.Name}*) SilkMarshal.Allocate(sizeof({s.Name}))");
            sw.WriteLine($"        }};");
            var free = new List<string>();
            WriteWrapperProperties(sw, s, profile, free, "Value->");
            sw.WriteLine("        public void Free()");
            sw.WriteLine("        {");
            foreach (var item in free)
            {
                sw.WriteLine($"            SilkMarshal.Free({item});");
            }

            sw.WriteLine("            SilkMarshal.Free((IntPtr) Value);");
            sw.WriteLine("        }");
            sw.WriteLine();
            sw.WriteLine("        public void Dispose() => Free();");
            sw.WriteLine("    }");
        }

        public static void WriteSafeWrapper(StreamWriter sw, Struct s, Profile profile)
        {
            sw.WriteLine($"    public unsafe partial struct {s.Name}Safe : IDisposable");
            sw.WriteLine("    {");
            sw.WriteLine($"        public {s.Name} Value;");
            var free = new List<string>();
            WriteWrapperProperties(sw, s, profile, free, "Value.");
            sw.WriteLine("        public void Free()");
            sw.WriteLine("        {");
            foreach (var item in free)
            {
                sw.WriteLine($"            SilkMarshal.Free({item});");
            }

            sw.WriteLine("        }");
            sw.WriteLine();
            sw.WriteLine("        public void Dispose() => Free();");
            sw.WriteLine("    }");
        }

        public static void WriteWrapperProperties
        (
            StreamWriter sw,
            Struct s,
            Profile profile,
            List<string> free,
            string accessor
        )
        {
            foreach (var field in s.Fields)
            {
                var @const = field.Count is null
                    ? null
                    : field.Count.IsConstant
                        ? profile.Projects.SelectMany(x => x.Value.Classes.SelectMany(y => y.Constants))
                            .FirstOrDefault(x => x.NativeName == field.Count.ConstantName)
                            ?
                            .Value ?? profile.Projects.SelectMany
                                (x => x.Value.Enums.SelectMany(y => y.Tokens))
                            .FirstOrDefault(x => x.NativeName == field.Count.ConstantName)
                            ?.Value ??
                        throw new InvalidDataException("Couldn't find constant referenced")
                        : null;
                var count = field.Count is null
                    ? 1
                    : field.Count.IsConstant
                        ? int.TryParse(@const, out var result) || int.TryParse
                            (@const, NumberStyles.HexNumber, null, out result) ? result
                        : 1
                        : field.Count.IsStatic
                            ? field.Count.StaticCount
                            : 1;
                if (field.Type.ToString() == "char*" || field.Type.ToString() == "byte*" ||
                    field.Type.ToString() == "GLchar*" || field.Type.ToString() == "GLbyte*" ||
                    field.Type.ToString() == "GLubyte*")
                {
                    sw.WriteLine($"        public string {field.Name}");
                    sw.WriteLine($"        {{");
                    sw.WriteLine($"            get => SilkMarshal.PtrToString((IntPtr) {accessor}{field.Name},");
                    sw.WriteLine($"                                           NativeStringEncoding.UTF8);");
                    sw.WriteLine($"            set => {accessor}{field.Name} = ({field.Type})");
                    sw.WriteLine($"                   SilkMarshal.StringToPtr(value, NativeStringEncoding.UTF8);");
                    sw.WriteLine($"        }}");
                    free.Add($"(IntPtr) {accessor}{field.Name}");
                }
                else if (field.Type.ToString() == "char**" || field.Type.ToString() == "byte**" ||
                         field.Type.ToString() == "GLchar**" || field.Type.ToString() == "GLbyte**" ||
                         field.Type.ToString() == "GLubyte**")
                {
                    sw.WriteLine($"        public string[] {field.Name}");
                    sw.WriteLine($"        {{");
                    sw.WriteLine($"            get => SilkMarshal.PtrToStringArray((IntPtr) {accessor}{field.Name},");
                    sw.WriteLine($"                                                NativeStringEncoding.UTF8);");
                    sw.WriteLine($"            set => {accessor}{field.Name} = ({field.Type})");
                    sw.WriteLine($"                   SilkMarshal.StringArrayToPtr(value, NativeStringEncoding.UTF8);");
                    sw.WriteLine($"        }}");
                    free.Add($"(IntPtr) {accessor}{field.Name}");
                }
                else if (field.Type.IndirectionLevels == 2 &&
                         profile.Projects.Any(x => x.Value.Structs.Any(y => y.Name == field.Type.Name)))
                {
                    sw.WriteLine($"        public Span<{field.Type.Name}Ptr> {field.Name}");
                    sw.WriteLine($"            => new Span<{field.Type.Name}Ptr>({accessor}{field.Name}, {count});");
                }
                else if (field.Type.IsFunctionPointer || field.Type.IndirectionLevels > 1)
                {
                    sw.WriteLine($"        public IntPtr {field.Name}");
                    sw.WriteLine($"        {{");
                    sw.WriteLine($"            get => (IntPtr) {accessor}{field.Name};");
                    sw.WriteLine($"            set => {accessor}{field.Name} = ({field.Type}) value;");
                    sw.WriteLine($"        }}");
                }
                else if (field.Type.IndirectionLevels == 1)
                {
                    sw.WriteLine($"        public Span<{field.Type.Name}> {field.Name}");
                    sw.WriteLine($"        {{");
                    sw.WriteLine($"            get => new Span<{field.Type.Name}>({accessor}{field.Name}, {count});");
                    sw.WriteLine($"            set => value.CopyTo({field.Name});");
                    sw.WriteLine($"        }}");
                }
                else if (profile.Projects.Any(x => x.Value.Structs.Any(y => y.Name == field.Type.Name)))
                {
                    sw.WriteLine($"        public {field.Type.Name}Safe {field.Name}");
                    sw.WriteLine($"        {{");
                    sw.WriteLine($"            get => {accessor}{field.Name};");
                    sw.WriteLine($"            set => {accessor}{field.Name} = value;");
                    sw.WriteLine($"        }}");
                }
                // TODO Handle PFN structs and generate methods for them if FunctionPointerSignature isn't null
                else
                {
                    sw.WriteLine($"        public {field.Type} {field.Name}");
                    sw.WriteLine($"        {{");
                    sw.WriteLine($"            get => {accessor}{field.Name};");
                    sw.WriteLine($"            set => {accessor}{field.Name} = value;");
                    sw.WriteLine($"        }}");
                }
                sw.WriteLine();
            }
        }

        public static void WriteFunctionPointerWrapper
        (
            Struct @struct,
            string file,
            Profile profile,
            Project project,
            BindState state,
            string delegateName,
            string pfnName,
            CallingConvention conv
        )
        {
            var coreProject = profile.Projects["Core"];
            var type = new Type
            {
                FunctionPointerSignature = new Function
                {
                    Name = delegateName, NativeName = pfnName.Substring(3),
                    Parameters = @struct.Fields.SkipLast(1).Select
                            ((x, i) => new Parameter {Name = $"arg{i}", Type = x.Type})
                        .ToList(),
                    ReturnType = @struct.Fields.LastOrDefault()?.Type ?? new Type{Name = "void"},
                    Convention = conv
                }
            };

            var fnPtrSig = type.FunctionPointerSignature.GetFunctionPointerSignature();
            using var sw = new StreamWriter(file);
            sw.WriteLine(state.LicenseText());
            sw.WriteLine();
            sw.WriteCoreUsings();
            sw.WriteLine();
            sw.WriteLine("#pragma warning disable 1591");
            sw.WriteLine();
            sw.WriteLine($"namespace {state.Task.Namespace}{coreProject.Namespace}");
            sw.WriteLine("{");
            sw.WriteLine($"    public unsafe readonly struct {pfnName} : IDisposable");
            sw.WriteLine("    {");
            sw.WriteLine("        private readonly void* _handle;");
            sw.WriteLine($"        public {fnPtrSig} Handle => ({fnPtrSig}) _handle;");
            sw.WriteLine($"        public {pfnName}");
            sw.WriteLine($"        (");
            sw.WriteLine($"            {fnPtrSig} ptr");
            sw.WriteLine($"        ) => _handle = ptr;");
            sw.WriteLine();
            sw.WriteLine($"        public {pfnName}");
            sw.WriteLine($"        (");
            sw.WriteLine($"             {delegateName} proc");
            sw.WriteLine($"        ) => _handle = (void*) SilkMarshal.DelegateToPtr(proc);");
            sw.WriteLine();
            sw.WriteLine($"        public static {pfnName} From({delegateName} proc) => new {pfnName}(proc);");
            sw.WriteLine($"        public void Dispose() => SilkMarshal.Free((IntPtr) _handle);");
            sw.WriteLine();
            sw.WriteLine($"        public static implicit operator IntPtr({pfnName} pfn) => (IntPtr) pfn.Handle;");
            sw.WriteLine($"        public static explicit operator {pfnName}(IntPtr pfn)");
            sw.WriteLine($"            => new {pfnName}(({fnPtrSig}) pfn);");
            sw.WriteLine();
            sw.WriteLine($"        public static implicit operator {pfnName}({delegateName} proc)");
            sw.WriteLine($"            => new {pfnName}(proc);");
            sw.WriteLine();
            sw.WriteLine($"        public static explicit operator {delegateName}({pfnName} pfn)");
            sw.WriteLine($"            => SilkMarshal.PtrToDelegate<{delegateName}>(pfn);");
            sw.WriteLine();
            sw.WriteLine($"        public static implicit operator {fnPtrSig}({pfnName} pfn) => pfn.Handle;");
            sw.WriteLine($"        public static implicit operator {pfnName}({fnPtrSig} ptr) => new {pfnName}(ptr);");
            sw.WriteLine("    }");
            sw.WriteLine();
            // type.FunctionPointerSignature.Name = delegateName;
            // type.FunctionPointerSignature.NativeName = $"{pfnName}";
            // type.Name = type.FunctionPointerSignature.NativeName;
            // type.IndirectionLevels--;
            using (var sr = new StringReader
                (type.FunctionPointerSignature.ToString(null, @delegate: true, semicolon: true, accessibility: true)))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    sw.WriteLine($"    {line}");
                }
            }

            sw.WriteLine("}");
            sw.WriteLine();
            sw.Flush();
        }
    }
}
