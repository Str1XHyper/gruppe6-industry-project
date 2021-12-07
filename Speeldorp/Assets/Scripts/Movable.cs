using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    public void UpdatePosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
}
