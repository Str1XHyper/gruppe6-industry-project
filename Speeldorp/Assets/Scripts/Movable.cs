using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Movable : MonoBehaviour
{
    PhotonView photonView;
    public bool Available { get; private set; } = true;

    private void Awake()
    {
        photonView = PhotonView.Get(this);
    }

    public void UpdatePosition(Vector3 newPosition)
    {
        transform.position = newPosition;
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
}
