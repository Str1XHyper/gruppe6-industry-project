using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    public bool Available { get; private set; } = true;

    public void UpdatePosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    public void SetAvailableTrue()
    {
        Available = true;
    }

    public void SetAvailableFalse()
    {
        Available = false;
    }
}
