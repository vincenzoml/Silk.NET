using Aliquip.Sandbox;

using var sandbox = Sandbox.Create();

var cube = sandbox.AddPrimitive(Primitive.Cube, 0, 1, 0);
var quad = sandbox.AddPrimitive(Primitive.Quad, 1, 0, 0);
quad.Position = new(3, 0, 0);
var sphere1 = sandbox.AddPrimitive(Primitive.Sphere, 0, 0, 1);
sphere1.Position = new(0, 3, 0);

sandbox.Run();
