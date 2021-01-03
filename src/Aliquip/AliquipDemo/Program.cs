using Aliquip.Sandbox;
using Silk.NET.Maths;

using var sandbox = Sandbox.Create();

var obj = sandbox.AddPrimitive(Primitive.Quad, new(146, 100, 214));

sandbox.Run(
    () =>
    {
        obj.Position += Vector3D<float>.UnitX / 1000;
    });
