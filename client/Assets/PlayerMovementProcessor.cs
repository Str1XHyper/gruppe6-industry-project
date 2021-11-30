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
        Ray ray = mainCam.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            transform.position =
                Vector3.MoveTowards(transform.position, new Vector3(hit.point.x, transform.position.y, transform.position.z), 0.2f);
        }
    }
}
