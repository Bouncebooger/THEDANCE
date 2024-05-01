using Godot;
using System;

public partial class mouse_input_handler : Node
{
	// Called when the node enters the scene tree for the first time.
	[Signal]
	public delegate void mousemotionEventHandler(float deltaX,float deltaY);

	[Signal]
	public delegate void LmousejustpressedEventHandler(Vector2 clickpos);

	
	public override void _Ready()
	{
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public override void _Input(InputEvent @inputevent)
	{
		if (@inputevent is InputEventMouseMotion mousemoved )
		{
		//	GD.Print("Hello");
			EmitSignal(SignalName.mousemotion, mousemoved.Relative.X, mousemoved.Relative.Y);
		}
		if (inputevent is InputEventMouseButton mouseclick)
		{
			if (mouseclick.IsActionPressed("TogglePlacement"))
			{
				EmitSignal(SignalName.Lmousejustpressed, mouseclick.GlobalPosition);
			}
		}
	}
	

	
}
