using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStateNEW : MonoBehaviour
{
    public static event Action StateChanged; 

    [SerializeField]  private List<State> states;



    public State Get(string id)
    {
        foreach (State state in states)
        {
            if (state.id == id)
            {
                return state;
            }
        }

        return null;
    }

    public void Add(string id, int amount, bool invokeEvent = true)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            Debug.LogError("Id of state is empty.Make sure to give each state an id",this);
            return;
        }
        
        if(amount == 0)
        {
            Debug.LogError($"Trying to add 0 to id '{id}'.This will result in to change to the state",this);
        }


        State state = Get(id);

        if (state == null)
        {
            State newState = new State(id, amount);
            states.Add(newState);
        }
        else
        {
            state.amount += amount;
        }

        if (invokeEvent)
        {
            StateChanged?.Invoke();
        }
        
    }

    public void Add(State state, bool invokeEvent = true)
    {
        Add(state.id,state.amount, invokeEvent);
    }

    public void Add(List<State> states)
    {
        foreach (State state in states)
        {
            Add(state,false);
        }
        
        StateChanged?.Invoke();
    }
    
    
    
    
    //#todo Check Conditions
    
    
    
}



