// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Numerics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;

namespace Aliquip
{
    internal sealed class CameraProvider : ICameraProvider, IDisposable
    {
        private readonly ISwapchainProvider _swapchainProvider;
        private readonly IWindowProvider _windowProvider;
        private readonly float _fov;
        private Vector3D<float> _position;
        private Vector3D<float> _cameraFront;
        private Vector2 _lastMousePos;
        private float _cameraYaw = -90f;
        private float _cameraPitch = 0f;
        private Vector3D<float> _cameraDirection = Vector3D<float>.Zero;
        private readonly IMouse _mouse;
        private readonly IKeyboard _keyboard;
        private bool _inputEnabled;

        private static readonly Vector3D<float> Up = Vector3D<float>.UnitY;

        public Matrix4X4<float> ViewMatrix
            => Matrix4X4.CreateLookAt(_position, _position + _cameraFront, Up);

        public Matrix4X4<float> ProjectionMatrix 
        => Matrix4X4.CreatePerspectiveFieldOfView
        (
            _fov,
            (float) _swapchainProvider.SwapchainExtent.Width /
            (float) _swapchainProvider.SwapchainExtent.Height, 0.1f, 1000f
        );

        public CameraProvider(IConfiguration configuration, ISwapchainProvider swapchainProvider, IInputContext inputContext, IWindowProvider windowProvider,
            ILogger<CameraProvider> logger)
        {
            _swapchainProvider = swapchainProvider;
            _windowProvider = windowProvider;

            _mouse = inputContext.Mice[0];
            _keyboard = inputContext.Keyboards[0];

            logger.LogInformation("Using Mouse: {name}", _mouse.Name);
            logger.LogInformation("Using Keyboard: {name}", _keyboard.Name);
            
            if (!int.TryParse(configuration["Field Of View"], out var intFov))
                intFov = 45;
            _fov = intFov * MathF.PI / 180f;
            
            // if (!float.TryParse(_configuration["Camera Speed"], out _speed))
            //     _speed = .1f;

            _position = new Vector3D<float>(2f, 0, 0);
            
            _windowProvider.Window.Update += Update;
            _cameraFront = default;

            _mouse.MouseMove += OnMouseMove;
            _mouse.Click += OnMouseClick;
            _inputEnabled = true;
            _windowProvider.Window.FocusChanged += OnFocusChanged;
            _windowProvider.Window.Center();
            _mouse.Cursor.CursorMode = CursorMode.Raw;
        }

        private void OnMouseClick(IMouse mouse, MouseButton button, Vector2 position)
        {
            _mouse.Cursor.CursorMode = CursorMode.Raw;
        }

        private void OnFocusChanged(bool newFocs)
        {
            _inputEnabled = newFocs;
            _lastMousePos = default;
        }

        private static float DegreesToRadians(float degrees)
        {
            return MathF.PI / 180f * degrees;
        }
        
        private void OnMouseMove(IMouse mouse, Vector2 position)
        {
            if (!_inputEnabled)
                return;
            
            var lookSensitivity = 0.1f;
            if (_lastMousePos == default) { _lastMousePos = position; }
            else
            {
                var xOffset = (position.X - _lastMousePos.X) * lookSensitivity;
                var yOffset = (position.Y - _lastMousePos.Y) * lookSensitivity;
                _lastMousePos = position;

                _cameraYaw += xOffset;
                _cameraPitch -= yOffset;

                //We don't want to be able to look behind us by going over our head or under our feet so make sure it stays within these bounds
                _cameraPitch = Math.Clamp(_cameraPitch, -89.0f, 89.0f);

                _cameraDirection.X = MathF.Cos(DegreesToRadians(_cameraYaw)) * MathF.Cos(DegreesToRadians(_cameraPitch));
                _cameraDirection.Y = MathF.Sin(DegreesToRadians(_cameraPitch));
                _cameraDirection.Z = MathF.Sin(DegreesToRadians(_cameraYaw)) * MathF.Cos(DegreesToRadians(_cameraPitch));
                _cameraFront = Vector3D.Normalize(_cameraDirection);
            }
        }

        public void Dispose()
        {
            _windowProvider.Window.Update -= Update;
            _mouse.MouseMove -= OnMouseMove;
            _mouse.Click -= OnMouseClick;
        }

        private void Update(double deltaTime)
        {
            if (!_inputEnabled)
                return;
            
            var moveSpeed = 2.5f * (float) deltaTime;

            if (_keyboard.IsKeyPressed(Key.W))
            {
                //Move forwards
                _position += moveSpeed * _cameraFront;
            }
            if (_keyboard.IsKeyPressed(Key.S))
            {
                //Move backwards
                _position -= moveSpeed * _cameraFront;
            }
            if (_keyboard.IsKeyPressed(Key.A))
            {
                //Move left
                _position -= Vector3D.Normalize(Vector3D.Cross(_cameraFront, Up)) * moveSpeed;
            }
            if (_keyboard.IsKeyPressed(Key.D))
            {
                //Move right
                _position += Vector3D.Normalize(Vector3D.Cross(_cameraFront, Up)) * moveSpeed;
            }
            if (_keyboard.IsKeyPressed(Key.Space))
            {
                //Move up
                _position += Up * moveSpeed;
            }
            if (_keyboard.IsKeyPressed(Key.ControlLeft))
            {
                //Move up
                _position -= Up * moveSpeed;
            }
            if (_keyboard.IsKeyPressed(Key.Escape))
            {
                // show cursor again
                _mouse.Cursor.CursorMode = CursorMode.Normal;
            }
        }
    }
}
