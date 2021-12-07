using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicBlockSelector : MonoBehaviour
{
    public MusicBlockClickHandler MusicBlockClickHandler;
    public GameObject BlockToSelect;
    void Start()
    {
        GetComponent<MeshRenderer>().material = BlockToSelect.GetComponent<MeshRenderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 200 * Time.deltaTime, 0));

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.transform.gameObject == gameObject)
                {
                    MusicBlockClickHandler.SelectBlock(BlockToSelect);
                    Debug.Log($"Current block is {BlockToSelect.name}");
                }
            }
        }

    }
}
