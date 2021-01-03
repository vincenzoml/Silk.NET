using Aliquip;
using Aliquip.Sandbox;
using Silk.NET.Maths;

using var sandbox = Sandbox.Create();

var scene = sandbox.Scene3D;
for (int x = -10; x < 10; x++)
{
    for (int y = -10; y < 10; y++)
    {
        scene.AddObject(sandbox.Instantiate<Simple3DFileObject>("viking_room", Matrix4X4.CreateTranslation(x, y, 0f)));
    }
}

sandbox.Run();
