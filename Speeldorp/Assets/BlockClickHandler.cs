using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlockClickHandler : MonoBehaviour
{
    Camera camera;
    private GameObject currentTarget;
    public Rigidbody targetRigidBody;
    private bool isHolding = false;
    private PhotonView photonView;


    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (InputManager.instance.GetBlockInteractStart() && !isHolding)
        {
            SelectBlockToMove();
        }

        if (currentTarget != null)
        {
            MoveTarget();
        }

        if (currentTarget != null && !InputManager.instance.GetBlockInteractHolding())
        {
            StopMoving();
        }
    }

    private void SelectBlockToMove()
    {
        Ray ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("Movable") && hit.transform.GetComponent<Movable>().Available == true)
            {
                photonView = hit.transform.GetComponent<PhotonView>();

                if (photonView.IsMine)
                {
                    StartMovingBlock(hit);
                }
                else
                {
                    //Request Takeover
                    photonView.TransferOwnership(PhotonNetwork.LocalPlayer.ActorNumber);
                    StartMovingBlock(hit);
                }

            }
        }
    }

    private void StartMovingBlock(RaycastHit hit)
    {
        currentTarget = hit.transform.gameObject;
        targetRigidBody = currentTarget.GetComponent<Rigidbody>();
        targetRigidBody.velocity = Vector3.zero;
        targetRigidBody.useGravity = false;
        isHolding = true;
        hit.transform.GetComponent<Movable>().SetAvailableFalse();
        Debug.Log("Available: " + hit.transform.GetComponent<Movable>().Available);
    }

    private void StopMoving()
    {
        currentTarget.GetComponent<Movable>().SetAvailableTrue();
        Debug.Log("Available: " + currentTarget.transform.GetComponent<Movable>().Available);
        targetRigidBody.useGravity = true;
        targetRigidBody.velocity = Vector3.zero;
        targetRigidBody = null;
        currentTarget = null;
        isHolding = false;
    }

    private void MoveTarget()
    {
        Vector3 newPosition = new Vector3(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x, Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y, 0);
        currentTarget.GetComponent<Movable>().UpdatePosition(newPosition);
    }
}
