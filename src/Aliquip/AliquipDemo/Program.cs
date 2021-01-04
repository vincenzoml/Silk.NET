using Aliquip.Sandbox;

using var sandbox = Sandbox.Create();

sandbox.AddPrimitive(Primitive.Cube, 0, 1, 0);
var quad = sandbox.AddPrimitive(Primitive.Quad, 1, 0, 0);
quad.Position = new(3, 0, 0);

sandbox.Run();
