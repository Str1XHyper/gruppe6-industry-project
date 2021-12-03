using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockClickHandler : MonoBehaviour
{
    Camera camera;
    public GameObject currentTarget;
    public Rigidbody targetRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // the object identified by hit.transform was clicked
                // do whatever you want
                Debug.Log(hit);
                if (hit.transform.CompareTag("Movable"))
                {
                    //Destroy(hit.transform.gameObject);
                    //PhotonNetwork.Destroy(hit.transform.gameObject);
                    currentTarget = hit.transform.gameObject;
                    targetRigidBody = currentTarget.GetComponent<Rigidbody>();
                    targetRigidBody.velocity = Vector3.zero;
                    targetRigidBody.useGravity = false;
                }
                
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            targetRigidBody.useGravity = true;
            targetRigidBody.velocity = Vector3.zero;
            targetRigidBody = null;
            currentTarget = null;
        }

        if(currentTarget != null)
        {
            Debug.Log(targetRigidBody.useGravity);
            MoveTarget();
        }
        
    }

    private void MoveTarget()
    {

        Vector3 newPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        currentTarget.GetComponent<Movable>().UpdatePosition(newPosition);
    }
}
