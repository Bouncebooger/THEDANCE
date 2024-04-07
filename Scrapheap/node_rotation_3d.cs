using Godot;
using System;

public partial class node_rotation_3d : Node
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	private float rotationClamp; //Place in player settings
	public override void _Ready()
	{
	}

	public node_rotation_3d()
	{
		rotationClamp = 70;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void RotateNode<T>(T nodeinput, float rotateX = 0.0f, float rotateY = 0.0f) where T :  Node3D
	{
		nodeinput.RotateY(-rotateX);
		nodeinput.RotateX(-rotateY);
		//It is put in after because this describes the change between x and y not the final amount
		nodeinput.Position = nodeinput.Position with { X = Mathf.Clamp(nodeinput.Rotation.X, -Mathf.DegToRad(rotationClamp), Mathf.DegToRad(rotationClamp)) };
	}

	//public Vector2 
	/*public void RotateNodeClamped<T>(T nodeinput, float rotateX= 0.0f, float rotateY = 0.0f)
	{

	}
	*/

	//On fov/settings change, update values
}
