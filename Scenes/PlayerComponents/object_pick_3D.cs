using Godot;
using System;

public partial class object_pick_3D : Node3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
	{

	}

    public  Godot.Collections.Dictionary PerspRayQuery(PhysicsRayQueryParameters3D funny)
	{

		var space = GetWorld3D().DirectSpaceState;
		return space.IntersectRay(funny);
	}
	
	

	

    //WANT THIS TO
    //TOGGLE ON FOR CONSTANT RAYCAST
    //CAST X times
    //Cast once



}
