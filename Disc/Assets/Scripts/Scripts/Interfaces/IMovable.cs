using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

/// <summary>
/// Interface for Actors that moves; Character and Parasites
/// </summary>
public interface IMovable {

    /// <summary>
    /// Used to calculate movment in two directions
    /// </summary>
    /// <param name="position">Original position</param>
    /// <param name="direction">Direction to move. in <values>+1 to -1</values></param>
    /// /// <param name="magnitude">How much the position should move</param>
    /// <returns>Returns a new position as Vector3</returns>
    void Move( float direction );

    /// <summary>
    /// Used to calcualte Jump
    /// </summary>
    /// <param name="position">Original position</param>
    /// <returns>Returns a new position as Vector3</returns>
    void Jump();
}