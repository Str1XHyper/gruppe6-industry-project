using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementProcessor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputProcessor inputProcessor;

    private Camera mainCam = null;

    void Start()
    {
        mainCam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if (inputProcessor.screenPressed)
        {
            Move();
        }
    }

    private void Move()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            transform.position =
                Vector3.MoveTowards(transform.position, new Vector3(touch.position.x, transform.position.y, transform.position.z), 0.1f);
        }
        else
        {
            Ray ray = mainCam.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, new Vector3(hit.point.x, transform.position.y, transform.position.z), 0.1f);
            }
        }
    }
}