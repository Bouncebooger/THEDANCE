using Godot;
using System;

public partial class start_game_button : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _Pressed()
	{
        GetNode<scene_event_bus_autoload>("/root/SceneEventBusAutoload").EmitSignal(scene_event_bus_autoload.SignalName.ToGameScene);
    }
}
