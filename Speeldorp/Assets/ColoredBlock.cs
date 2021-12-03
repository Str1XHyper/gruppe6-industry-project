using Photon.Pun;
using System;
using UnityEngine;

public class ColoredBlock : MonoBehaviour
{
    PhotonView photonView;
    private Material[] materials;
    public int CurrentColor { get; private set; }

    private void Awake()
    {
        photonView = PhotonView.Get(this);
    }

    public void SetColor(int CurrentColor)
    {
        Debug.Log(materials.Length);
        photonView.RPC("ChangeMaterial", RpcTarget.All, CurrentColor);
    }

    public void SetMaterials(Material[] coloredMaterials)
    {
        materials = coloredMaterials;
    }

    [PunRPC]
    private void ChangeMaterial(int index)
    {
        CurrentColor = index;
        gameObject.GetComponent<Renderer>().material = materials[index];
    }
}
