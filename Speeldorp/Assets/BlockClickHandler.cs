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
            Ray ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Movable"))
                {
                    currentTarget = hit.transform.gameObject;
                    targetRigidBody = currentTarget.GetComponent<Rigidbody>();
                    targetRigidBody.velocity = Vector3.zero;
                    targetRigidBody.useGravity = false;
                    isHolding = true;
                }

            }
        }

        if (currentTarget != null)
        {
            MoveTarget();
        }

        if (currentTarget != null && !InputManager.instance.GetBlockInteractHolding())
        {
            targetRigidBody.useGravity = true;
            targetRigidBody.velocity = Vector3.zero;
            targetRigidBody = null;
            currentTarget = null;
            isHolding = false;
        }
    }

    private void MoveTarget()
    {
        Vector3 newPosition = new Vector3(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x, Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y, 0);
        currentTarget.GetComponent<Movable>().UpdatePosition(newPosition);
    }
}
