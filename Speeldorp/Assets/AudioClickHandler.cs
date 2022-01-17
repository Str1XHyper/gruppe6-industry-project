using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AudioClickHandler : MonoBehaviour
{
    [SerializeField] private AudioSource source;

    void Update()   
    {
        if (InputManager.instance.GetScreenPressed())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("SoundBlock"))
                {
                    hit.collider.GetComponent<CollisionClickHandler>().EmitRPC();
                }
            }
        }
    }

}
