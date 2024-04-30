using Godot;
using System;
public partial class scene_event_bus_autoload : Node
{
	// Called when the node enters the scene tree for the first time.
	[Signal]
	public delegate void ToTitleMenuEventHandler();
	[Signal]
	public delegate void ToGameSceneEventHandler();
	[Signal]
	public delegate void StormCycledEventHandler();
	public override void _Ready() 
	{
		GD.Print("hello");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	


}
