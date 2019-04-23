using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

/// <summary>
/// Base class for all characters in game; Player and Enemy
/// </summary>
public class Character {

    public int Health {
        get;
        set;
    }
    public int NumberOfGatheredParasites {
        get;
        set;
    }
    public int NumberOfAttackingParasites {
        get;
        set;
    }

    /// <summary>
    /// Character constructor
    /// </summary>
    /// <param name="health">Health of character</param>
    public Character( int health ) {
        Health = health;
    }



    public void Fire() {

    }

    public void GatherParasites() {

    }
}