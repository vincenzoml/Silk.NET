using Aliquip.Sandbox;
using Silk.NET.Maths;

using var sandbox = Sandbox.Create();

sandbox.AddPrimitive(Primitive.Cube, new(146, 100, 214));
var quad = sandbox.AddPrimitive(Primitive.Quad, new(146, 100, 214));
quad.Position += Vector3D<float>.UnitX * 5;

sandbox.Run();
