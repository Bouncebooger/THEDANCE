using Godot;
using System;

public partial class main : Node
{
    public Node LoadingScreen;
    public Node WorldScreen;
    public Node MainMenu;
    //public Node MainMenuScreen;
    public override void _Ready()
    {
        LoadingScreen = ResourceLoader.Load<PackedScene>("res://Scenes/GameScreens/loading_screen.tscn").Instantiate();
        AddChild(LoadingScreen);
        MainMenu = GetNode("/root/Main/MainMenu");
        scene_event_bus_autoload SEB = GetNode<scene_event_bus_autoload>("/root/SceneEventBusAutoload");
        // LoadiScreen = ResourceLoader.Load<PackedScene>("res://Scenes/GameScreens/loading_screen.tscn").Instantiate();
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
        GetNode<Node2D>("/root/Main/LoadingScreen").Visible = true;
        RemoveChild(WorldScreen);


        AddChild(MainMenu);
        GetNode<Node2D>("/root/Main/LoadingScreen").Visible = false;

    }


    public void SwitchToWorldScreen()
    {
        GetNode<Node2D>("/root/Main/LoadingScreen").Visible = true;
        RemoveChild(MainMenu);

        WorldScreen = ResourceLoader.Load<PackedScene>("res://Scenes/GameScreens/game_world.tscn").Instantiate();
        AddChild(WorldScreen);
        GetNode<Node2D>("/root/Main/LoadingScreen").Visible = false;
    }


}
