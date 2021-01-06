using System.Numerics;
using Aliquip.Sandbox;

using var sandbox = Sandbox.Create();

for (int i = 0; i < 30; i++)
{
    for (int j = 0; j < 30; j++)
    {
        for (int k = 0; k < 30; k++)
        {
            var cube = sandbox.AddPrimitive(Primitive.Cube, 0, 1, 0);
            cube.Position = new Vector3(i * 2, j * 2, k * 2);
        }
    }
}

sandbox.Run();
