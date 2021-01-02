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

namespace Silk.NET.Vulkan.VMA
{
    [NativeName("Name", "VmaDefragmentationPassInfo")]
    public unsafe partial struct DefragmentationPassInfo
    {
        public DefragmentationPassInfo
        (
            uint? moveCount = null,
            DefragmentationPassMoveInfo* pMoves = null
        ) : this()
        {
            if (moveCount is not null)
            {
                MoveCount = moveCount.Value;
            }

            if (pMoves is not null)
            {
                PMoves = pMoves;
            }
        }


        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "moveCount")]
        public uint MoveCount;

        [NativeName("Type", "VmaDefragmentationPassMoveInfo * _Nonnull")]
        [NativeName("Type.Name", "VmaDefragmentationPassMoveInfo * _Nonnull")]
        [NativeName("Name", "pMoves")]
        public DefragmentationPassMoveInfo* PMoves;
    }
}
