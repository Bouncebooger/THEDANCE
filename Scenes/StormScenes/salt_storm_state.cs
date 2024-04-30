using Godot;
using System;

public partial class salt_storm_state : virtual_state_class
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
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void UpdateState(double delta)
	{
	}

	 public void _on_timer_timeout()
	{
		fsm.Transition("CalmSky");
		GD.Print("transitioned to calm!");

	}
}
