using System.Threading.Tasks;
using Aliquip.Sandbox;
using Silk.NET.Maths;

using var sandbox = Sandbox.Create();

var quad = sandbox.AddPrimitive(Primitives.Quad);

sandbox.Run(
    async () =>
    {
        while (true)
        {
            await Task.Delay(1);
            quad.Position += Vector3D<float>.UnitX / 1000;
        }
    });
