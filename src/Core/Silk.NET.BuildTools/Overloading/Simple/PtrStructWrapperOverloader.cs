// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System.Linq;
using System.Runtime.InteropServices;
using Silk.NET.BuildTools.Common;
using Silk.NET.BuildTools.Common.Builders;
using Silk.NET.BuildTools.Common.Functions;

namespace Silk.NET.BuildTools.Overloading
{
    public class PtrStructWrapperOverloader : ISimpleParameterOverloader, ISimpleReturnOverloader
    {
        public bool TryGetParameterVariant(Parameter parameter, out Parameter varied, Project core, Function function)
        {
            varied = null;
            if (function.Convention == CallingConvention.FastCall || function.Convention == CallingConvention.ThisCall)
            {
                return false;
            }

            if (parameter.Type.IsPointer)
            {
                var s = core.Structs.FirstOrDefault(x => x.Name == parameter.Type.Name);
                if (s is null)
                {
                    return false;
                }
                
                varied = new ParameterSignatureBuilder(parameter).WithType(new TypeSignatureBuilder())
            }

            return false;
        }

        public bool TryGetReturnTypeVariant(Type returnType, out Type varied, Project core, Function function)
        {
            throw new System.NotImplementedException();
        }
    }
}
