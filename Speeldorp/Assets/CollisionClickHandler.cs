using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CollisionClickHandler : MonoBehaviour
{
    PhotonView photonView;
    public AudioClip clip;

    void Start()
    {
        photonView = PhotonView.Get(this);
    }
    public void EmitRPC()
    {
        photonView.RPC("EmitAudioVisuals", RpcTarget.All);
    }


    [PunRPC]
    public void EmitAudioVisuals()
    {
        StartCoroutine(GetComponent<ParticleEmitter>().Emit());
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
