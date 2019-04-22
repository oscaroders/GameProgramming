using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

/// <summary>
/// Base class for all characters in game; Player and Enemy
/// </summary>
public class Character {

    private int health;
    private int numberOfGatheredParasites;

    /// <summary>
    /// Character constructor
    /// </summary>
    /// <param name="health">Health of character</param>
    public Character( int health ) {
        this.health = health;
    }

    public void Fire() {

    }

    public void GatherParasites() {

    }

    public void Die() {

    }
}