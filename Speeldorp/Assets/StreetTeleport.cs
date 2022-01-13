using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetTeleport : MonoBehaviour
{
    [SerializeField]
    public CinemachineVirtualCamera currentActiveCam;
    [SerializeField]
    private Transform PlayerTPLocation;
    [SerializeField]
    private float newMinY, newMaxY;

    private bool isColliding;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isColliding = true;
            StartCoroutine(SecondCheck(other));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isColliding = false;
            StopAllCoroutines();
        }
    }

    private IEnumerator SecondCheck(Collider other)
    {
        yield return new WaitForSeconds(1);
        if (isColliding)
        {
            other.GetComponent<PlayerMovement>().SetPlayerLimits(newMinY, newMaxY);
            other.GetComponent<PlayerMovement>().StopAllCoroutines();
            other.transform.position = PlayerTPLocation.position;
            currentActiveCam.m_Priority = 10;
        }
    }
}
