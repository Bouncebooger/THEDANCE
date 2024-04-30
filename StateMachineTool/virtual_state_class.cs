using Godot;
using System;

[GlobalClass]
public partial class virtual_state_class : Node
{
	// Called when the node enters the scene tree for the first time.
	public virtual_state_machine_class fsm;
	public virtual void ReadyState()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public virtual void UpdateState(double delta)
	{
	}
	public virtual void PhysicsUpdateState(double delta)
	{

	}
    public virtual void EnterState()
    {

    }
    public virtual void ExitState()
    {

    }

}
