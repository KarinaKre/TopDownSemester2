using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class StateInfo 
{
    public string id;
    public string description; 
    public Sprite sprite;
    public int amount;
    public string name;
    
    public StateInfo(string id, int amount,Sprite sprite,string description)
    {
        this.id = id;
        this.amount = amount;
        this.sprite = sprite;
        this.description = description;
        //this.name = name;
    }
}
