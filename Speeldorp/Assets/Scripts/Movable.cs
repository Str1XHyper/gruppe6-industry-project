using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Movable : MonoBehaviour
{
    PhotonView photonView;
    Rigidbody rb;
    public bool Available { get; private set; } = true;
    public float moveSpeedFactor;
    public float torque;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        photonView = PhotonView.Get(this);
    }

    public void UpdatePosition(Vector3 newPosition)
    {
        rb.velocity = Vector3.ClampMagnitude(newPosition - transform.position, 1f) * moveSpeedFactor;
    }

    public void SetAvailableTrue()
    {
        photonView.RPC("SetAvailableStatePun", RpcTarget.All, true);
    }

    public void SetAvailableFalse()
    {
        photonView.RPC("SetAvailableStatePun", RpcTarget.All, false);
    }

    [PunRPC]
    private void SetAvailableStatePun(bool state)
    {
        Available = state;
    }

    private void RotateObject()
    {
        float torqueDirectionAdjusted;
        if(rb.rotation.z > 0)
        {
            torqueDirectionAdjusted = torque;
        }
        else
        {
            torqueDirectionAdjusted = (0 - torque);
        }

        if (rb.rotation.z > 10)
        {

        }
        else if(rb.rotation.z < 10)
        {

        }
        else
        {
            rb.AddTorque(0, 0, 50 * torqueDirectionAdjusted);
        }
    }
}
