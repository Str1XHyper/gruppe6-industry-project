using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MusicBlockClickHandler : MonoBehaviour
{
    public List<GameObject> SoundBlocks;
    private int currentBlockCount;
    [SerializeField] private Camera main;
    private GameObject selectedBlock;

    public void Start()
    {
        currentBlockCount = -1;
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
                    if (currentBlockCount < SoundBlocks.Count - 1)
                    {
                        if (selectedBlock != null)
                        {
                            Destroy(selectedBlock);
                        }
                        currentBlockCount++;
                        var block = Instantiate(SoundBlocks[currentBlockCount], hit.transform.position, Quaternion.identity);
                        hit.transform.gameObject.GetComponent<BoxCollider>().enabled = false;
                        hit.transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
                        block.transform.SetParent(hit.transform.parent);
                        selectedBlock = block;
                    }
                }
            }
        }
    }
}
