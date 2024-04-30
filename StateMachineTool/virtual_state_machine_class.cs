using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
//Credit to mina pecheux's basic fsm tutorial
public partial class virtual_state_machine_class : Node
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	protected NodePath InitState;
	protected virtual_state_class CurrentState;
	protected Dictionary<string, virtual_state_class> StateList;
	public override void _Ready()
	{
		StateList = new Dictionary<string, virtual_state_class>();
		foreach(Node node in GetChildren())
		{
			if (node is virtual_state_class s) {
				StateList[node.Name] = s;
				s.fsm= this;
				s.ReadyState();
				s.ExitState();
					}
		}
		CurrentState = GetNode<virtual_state_class>(InitState);
		CurrentState.EnterState();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public virtual void Transition(string targetkey)
	{
		if(!StateList.ContainsKey(targetkey)|| CurrentState == StateList[targetkey])
		{
			return;
		}
		CurrentState.ExitState();
		CurrentState = StateList[targetkey];
		CurrentState.EnterState();
	}
}
