using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;
    [SerializeField]
    private float lerpDuration;

    private PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            this.enabled = false;
        }
    }


    void Update()
    {
        if (InputManager.instance.GetScreenPressed())
        {
            StopAllCoroutines();
            Move();
        }
    }
    public void SetPlayerLimits(float minY, float maxY)
    {
        this.minY = minY;
        this.maxY = maxY;
    }

    private void Move()
    {
        Vector3 clickedLocation;
        if (Input.touchCount > 0)
        {
            clickedLocation = Camera.main.ScreenToWorldPoint(Touchscreen.current.position.ReadValue());
        }
        else
        {
            clickedLocation = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        }
        StartCoroutine(LerpOverTime(transform.position, new Vector3(clickedLocation.x, Mathf.Clamp(clickedLocation.y, minY, maxY), transform.position.z), lerpDuration));
    }


    IEnumerator LerpOverTime(Vector3 startPos, Vector3 endPos, float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, t / duration);
            yield return 0;
        }
        transform.position = endPos;
    }
}
