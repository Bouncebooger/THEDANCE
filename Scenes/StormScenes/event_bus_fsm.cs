using Godot;
using System;
using System.Collections.Generic;

//This is icky and should be replaced if states have multiple 
//events, as a generic storm_state class can provide the same with less redundancy;
public partial class event_bus_fsm : virtual_state_machine_class
{
    // Called when the node enters the scene tree for the first time.

    private scene_event_bus_autoload SEB;
    public override void _Ready()
    {
         SEB = GetNode<scene_event_bus_autoload>("/root/SceneEventBusAutoload");
        StateList = new Dictionary<string, virtual_state_class>();
        foreach (Node node in GetChildren())
        {
            if (node is virtual_state_class s)
            {
                StateList[node.Name] = s;
                s.fsm = this;
                s.ReadyState();
                s.ExitState();
            }
        }
        CurrentState = GetNode<virtual_state_class>(InitState);
        CurrentState.EnterState();
    }
    public override void Transition(string targetkey)
	{
		if (!StateList.ContainsKey(targetkey) || CurrentState == StateList[targetkey])
		{
			return;
		}
		CurrentState.ExitState();
        SEB.EmitSignal(scene_event_bus_autoload.SignalName.StormCycled);
		CurrentState = StateList[targetkey];
		CurrentState.EnterState();
	}
}
