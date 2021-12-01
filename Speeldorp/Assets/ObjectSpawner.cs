using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject item;

    // Start is called before the first frame update

    void Start()
    {
        PhotonNetwork.Instantiate(item.name, transform.position, Quaternion.identity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
