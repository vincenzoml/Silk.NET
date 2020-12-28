// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Microsoft.Extensions.Configuration;
using Silk.NET.Input;
using Silk.NET.Maths;

namespace Aliquip
{
    internal sealed class CameraProvider : ICameraProvider, IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly ISwapchainProvider _swapchainProvider;
        private readonly IInputContext _inputContext;
        private readonly IWindowProvider _windowProvider;
        private readonly float _fov;
        private readonly IDisposable _subscription;
        private readonly float _speed;
        private Vector3D<float> _position;

        public Matrix4X4<float> ViewMatrix
            => Matrix4X4.CreateLookAt(_position, new(0, 0, 0), Vector3D<float>.UnitZ);

        public Matrix4X4<float> ProjectionMatrix 
        => Matrix4X4.CreatePerspectiveFieldOfView
        (
            _fov,
            (float) _swapchainProvider.SwapchainExtent.Width /
            (float) _swapchainProvider.SwapchainExtent.Height, 0.1f, 1000f
        );

        public CameraProvider(IConfiguration configuration, ISwapchainProvider swapchainProvider, IInputContext inputContext, IWindowProvider windowProvider)
        {
            _configuration = configuration;
            _swapchainProvider = swapchainProvider;
            _inputContext = inputContext;
            _windowProvider = windowProvider;

            if (!int.TryParse(_configuration["FieldOfView"], out var intFov))
                intFov = 45;
            _fov = intFov * MathF.PI / 180f;
            
            if (!float.TryParse(_configuration["CameraSpeed"], out _speed))
                _speed = .1f;

            _position = new(2f, 2f, 2f);
            
            _windowProvider.Window.Update += Update;
        }

        public void Dispose()
        {
            _windowProvider.Window.Update -= Update;
        }

        private void Update(double obj)
        {
            if (_inputContext.Keyboards[0].IsKeyPressed(Key.S))
            {
                _position += Vector3D<float>.UnitX * _speed;
            }

            if (_inputContext.Keyboards[0].IsKeyPressed(Key.W))
            {
                _position -= Vector3D<float>.UnitX * _speed;
            }
            
            if (_inputContext.Keyboards[0].IsKeyPressed(Key.A))
            {
                _position += Vector3D<float>.UnitY * _speed;
            }

            if (_inputContext.Keyboards[0].IsKeyPressed(Key.D))
            {
                _position -= Vector3D<float>.UnitY * _speed;
            }
            
            if (_inputContext.Keyboards[0].IsKeyPressed(Key.Space))
            {
                _position += Vector3D<float>.UnitZ * _speed;
            }

            if (_inputContext.Keyboards[0].IsKeyPressed(Key.ControlLeft))
            {
                _position -= Vector3D<float>.UnitZ * _speed;
            }
        }
    }
}
