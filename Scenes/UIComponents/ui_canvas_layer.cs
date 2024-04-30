using Godot;
using System;

public partial class ui_canvas_layer : CanvasLayer
{
	// Called when the
	// node enters the scene tree for the first time.
	//private scene_event_bus_autoload SEB;
	[Export]
	private PackedScene PackedPauseSplash;
	private Node PauseSplash;

    public override void _Ready()
	{
		PackedPauseSplash = ResourceLoader.Load<PackedScene>("res://Scenes/GameScreens/loading_screen.tscn");
    scene_event_bus_autoload SEB = GetNode<scene_event_bus_autoload>("/root/SceneEventBusAutoload");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
/*
    public override void _Input(InputEvent Inevent)
    {
		if (Input.IsActionJustPressed("")) { }
    }
*/
}
