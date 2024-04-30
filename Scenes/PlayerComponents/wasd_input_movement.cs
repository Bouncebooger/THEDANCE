using Godot;
using System;

//This Gets input, tells parent, got input, then parent tells sibling move me using this input
public partial class wasd_input_movement : Node
{
	[Signal]
	public delegate void MovementAxesEventHandler(float xaxis,float yaxis);
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Input(InputEvent Inevent)
	{
		EmitSignal(SignalName.MovementAxes,
			Input.GetAxis("MoveLeft", "MoveRight"), 
			Input.GetAxis("MoveForward", "MoveBackward"));
		

	}
}
