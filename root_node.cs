using Godot;
using System;

public partial class root_node : Node
{
	// Called when the node enters the scene tree for the first time.
	//NOTE ADD NODE SWITCHING THAT IS INDEPENDENT OF TYPE 

	public Node LoadingScreen;
	public Node WorldScreen;
	public Node MainMenu;
	//public Node MainMenuScreen;
	public override void _Ready()
	{
		LoadingScreen = ResourceLoader.Load<PackedScene>("res://GameScreens/loading_screen.tscn").Instantiate();
		AddChild(LoadingScreen);
		MainMenu = GetNode("/root/RootNode/MainMenu");
         scene_event_bus_autoload SEB = GetNode<scene_event_bus_autoload>("/root/SceneEventBusAutoload");
       // LoadiScreen = ResourceLoader.Load<PackedScene>("res://GameScreens/loading_screen.tscn").Instantiate();
        SEB.ToTitleMenu += SwitchToTitleScreen;
		SEB.ToGameScene += SwitchToWorldScreen;
			

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void SwitchToTitleScreen()
	{
		GD.Print("Signal Received");
		GetNode<Node2D>("/root/RootNode/LoadingScreen").Visible = true;
		RemoveChild(WorldScreen);

       
		AddChild(MainMenu);
        GetNode<Node2D>("/root/RootNode/LoadingScreen").Visible = false;

    }

	
	public void SwitchToWorldScreen()
	{
        GetNode<Node2D>("/root/RootNode/LoadingScreen").Visible = true;
        RemoveChild(MainMenu);

        WorldScreen = ResourceLoader.Load<PackedScene>("res://GameScreens/endless_library.tscn").Instantiate();
        AddChild(WorldScreen);
        GetNode<Node2D>("/root/RootNode/LoadingScreen").Visible = false;
    }



}
