using Godot;
using System;

public partial class calm_sky_state : virtual_state_class
{
    // Called when the node enters the scene tree for the first time.
    private Timer stormtimer;
    public override void _Ready()
	{
        stormtimer = GetNode<Timer>("Timer");
        stormtimer.OneShot = true;
    }

    public override void EnterState()
    {
        stormtimer.Start();

    }
    public override void ExitState()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
    public void _on_timer_timeout()
    {
        GD.Print("Transitioned to salt!");
        fsm.Transition("SaltStorm");
		//GD.Print("Transitioned to salt!");

    }
}
