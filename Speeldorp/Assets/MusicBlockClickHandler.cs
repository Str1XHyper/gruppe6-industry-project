using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MusicBlockClickHandler : MonoBehaviour
{
    [SerializeField] private Camera main;
    [SerializeField] private GameObject selectedBlock;

    public void Start()
    {

        selectedBlock = null;
    }

    // Will eventually be changed to use new input system
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = main.ScreenPointToRay(Input.mousePosition);
            Debug.Log(ray.origin);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.CompareTag("SoundBlock"))
                {
                    if (selectedBlock != null)
                    {
                        Destroy(hit.transform.parent.GetChild(hit.transform.parent.childCount -1).gameObject);
                    }
                    var block = Instantiate(selectedBlock, hit.transform.position, Quaternion.identity);
                    hit.transform.gameObject.GetComponent<BoxCollider>().enabled = false;
                    hit.transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    block.transform.SetParent(hit.transform.parent);
                }
            }
        }
    }
    public void SelectBlock(GameObject block)
    {
        selectedBlock = block;
    }
}
