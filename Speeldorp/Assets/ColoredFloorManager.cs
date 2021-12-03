using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredFloorManager : MonoBehaviour
{
    public Material[] ColoredMaterials;
    void Start()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<ColoredBlock>().SetMaterials(ColoredMaterials);
            int index = Random.Range(0, ColoredMaterials.Length);
            child.GetComponent<ColoredBlock>().SetColor(index);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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
