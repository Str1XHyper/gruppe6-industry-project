using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class MoveCloud : MonoBehaviour
{
    public enum CloudLayer
    {
        Front = 3,
        Mid = 2,
        Back = 1,
    }
    private Rigidbody rb;
    public CloudLayer Layer = CloudLayer.Front;
    private void Start()
    {
        rb.useGravity = false;
        rb.velocity = new Vector3((int)Layer * 0.2f, 0, 0);
        GetComponent<SpriteRenderer>().sortingOrder = (int)Layer;
    }
    private void Awake()
    {
        GetComponent<BoxCollider>().size = new Vector3(0.1f, 0.1f, 0.1f);
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }
}
