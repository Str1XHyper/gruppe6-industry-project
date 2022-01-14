using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColoredFloorManager : MonoBehaviour
{
    public Material[] ColoredMaterials;
    void Start()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<ColoredBlock>().SetMaterials(ColoredMaterials);
            child.GetComponent<ColoredBlock>().SetColor(0);
        }
    }

    void Update()
    {
        if (InputManager.instance.GetBlockInteractStart() && InputManager.instance.GetBlockInteractHolding())
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag == "Colored Block")
                {
                    ColoredBlock coloredBlock = hit.collider.GetComponent<ColoredBlock>();
                    int currentColor = coloredBlock.CurrentColor;
                    if(currentColor == ColoredMaterials.Length - 1)
                    {
                        currentColor = -1;
                    }

                    coloredBlock.SetColor(currentColor + 1);
                }
            }
        }
    }
}
