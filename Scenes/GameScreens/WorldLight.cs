using Godot;
using System;

public partial class WorldLight : DirectionalLight3D
{
	// Called when the node enters the scene tree for the first time.
	//Temporary color holder 
	private Color SaltColor;
	private Color CalmColor;
	public override void _Ready()
	{
		SaltColor = new Color(0.46f, 0.46f, 0.112f);
		CalmColor = new Color(0.14f, 0.112f, 0.416f);
        scene_event_bus_autoload SEB = GetNode<scene_event_bus_autoload>("/root/SceneEventBusAutoload");
		SEB.StormCycled += StormHue; 
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void StormHue(string stormtype)
	{
		
		switch (stormtype)
		{
			case "CalmSky":
				this.LightColor = CalmColor;
                GD.Print( " calm color");
                break;

			case "SaltStorm":
				this.LightColor = SaltColor;
                GD.Print(" salts color");
                break;

			default :

				break;
		}

	}
}
