// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.OpenGLES
{
    [NativeName("Name", "ProgramFormat")]
    public enum ProgramFormat : int
    {
        [NativeName("Name", "GL_PROGRAM_FORMAT_ASCII_ARB")]
        ProgramFormatAsciiArb = 0x8875,
    }
}
