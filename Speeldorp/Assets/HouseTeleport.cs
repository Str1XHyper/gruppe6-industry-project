using Cinemachine;
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
            newActiveCam.m_Priority += 2;
        }
    }
}
