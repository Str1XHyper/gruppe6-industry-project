using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClickHandler : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("SoundBlock"))
                {
                    StartCoroutine(hit.transform.gameObject.GetComponent<ParticleEmitter>().Emit());
                    source.clip = hit.transform.gameObject.GetComponent<CollisionClickHandler>().clip;
                    source.Play();
                }
            }
        }
    }
}
