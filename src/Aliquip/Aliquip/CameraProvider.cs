// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Microsoft.Extensions.Configuration;
using Silk.NET.Maths;

namespace Aliquip
{
    internal sealed class CameraProvider : ICameraProvider
    {
        private readonly IConfiguration _configuration;
        private readonly ISwapchainProvider _swapchainProvider;
        private readonly float _fov;
        private Vector3D<float> _position;

        public Matrix4X4<float> ViewMatrix
            => Matrix4X4.CreateLookAt(_position, new(0, 0, 0), Vector3D<float>.UnitZ);

        public Matrix4X4<float> ProjectionMatrix 
        => Matrix4X4.CreatePerspectiveFieldOfView
        (
            _fov,
            (float) _swapchainProvider.SwapchainExtent.Width /
            (float) _swapchainProvider.SwapchainExtent.Height, 0.1f, 10f
        );

        public CameraProvider(IConfiguration configuration, ISwapchainProvider swapchainProvider)
        {
            _configuration = configuration;
            _swapchainProvider = swapchainProvider;
            
            if (!int.TryParse(_configuration["FieldOfView"], out var intFov))
                intFov = 45;
            _fov = intFov * MathF.PI / 180f;

            _position = new(2f, 2f, 2f);
        }
    }
}
