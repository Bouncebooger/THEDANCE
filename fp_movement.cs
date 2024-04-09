using Godot;
using System;

public partial class fp_movement : Node
{
	[Export]
	private float MoveSpeed = 10;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void MoveRelative(CharacterBody3D nodetomove, float XAxis, float YAxis) 
	{
		var MoveDir = Vector3.Zero;
		nodetomove.Velocity = (nodetomove.GlobalBasis.Column0 * XAxis +nodetomove.GlobalBasis.Column2 * YAxis)*MoveSpeed;
		nodetomove.MoveAndSlide();
	}
}
