// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using Silk.NET.Core;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;

#pragma warning disable 1591

namespace Silk.NET.Direct3D12
{
    [NativeName("Name", "D3D12_META_COMMAND_DESC")]
    public unsafe partial struct MetaCommandDesc
    {
        public MetaCommandDesc
        (
            Guid? id = null,
            char* name = null,
            GraphicsStates? initializationDirtyState = null,
            GraphicsStates? executionDirtyState = null
        ) : this()
        {
            if (id is not null)
            {
                Id = id.Value;
            }

            if (name is not null)
            {
                Name = name;
            }

            if (initializationDirtyState is not null)
            {
                InitializationDirtyState = initializationDirtyState.Value;
            }

            if (executionDirtyState is not null)
            {
                ExecutionDirtyState = executionDirtyState.Value;
            }
        }


        [NativeName("Type", "GUID")]
        [NativeName("Type.Name", "GUID")]
        [NativeName("Name", "Id")]
        public Guid Id;

        [NativeName("Type", "LPCWSTR")]
        [NativeName("Type.Name", "LPCWSTR")]
        [NativeName("Name", "Name")]
        public char* Name;

        [NativeName("Type", "D3D12_GRAPHICS_STATES")]
        [NativeName("Type.Name", "D3D12_GRAPHICS_STATES")]
        [NativeName("Name", "InitializationDirtyState")]
        public GraphicsStates InitializationDirtyState;

        [NativeName("Type", "D3D12_GRAPHICS_STATES")]
        [NativeName("Type.Name", "D3D12_GRAPHICS_STATES")]
        [NativeName("Name", "ExecutionDirtyState")]
        public GraphicsStates ExecutionDirtyState;
    }
}
