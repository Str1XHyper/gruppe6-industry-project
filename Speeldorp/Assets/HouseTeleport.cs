using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTeleport : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera newActiveCam;
    [SerializeField]
    private Transform PlayerTPLocation;
    [SerializeField]
    private float newMinY, newMaxY;

    private bool isColliding;


    private void OnTriggerEnter(Collider other)
    {
        var photonView = other.GetComponent<PhotonView>();
        if (other.tag == "Player" && photonView.IsMine)
        {
            isColliding = true;
            StartCoroutine(SecondCheck(other));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var photonView = other.GetComponent<PhotonView>();
        if (other.tag == "Player" && photonView.IsMine)
        {
            isColliding = false;
            StopAllCoroutines();
        }
    }

    private IEnumerator SecondCheck(Collider other)
    {
        yield return new WaitForSeconds(1);
        var photonView = other.GetComponent<PhotonView>();
        if (isColliding && photonView.IsMine)
        {
            other.GetComponent<PlayerMovement>().SetPlayerLimits(newMinY, newMaxY);
            other.GetComponent<PlayerMovement>().StopAllCoroutines();
            var toggle = GetComponentInParent<ToggleUI>();
            if(toggle)
            {
                toggle.ToggleAC(toggle.toggle);
            }
            other.transform.position = PlayerTPLocation.position;
            newActiveCam.m_Priority += 2;

        }
    }
}
