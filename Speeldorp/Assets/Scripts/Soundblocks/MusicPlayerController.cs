using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MusicPlayerController : MonoBehaviour
{
    [SerializeField] private int length;
    [SerializeField] private Transform endPoint;
    [SerializeField] private Transform startPoint;
    [SerializeField] private float speed;
    private bool isPlaying = false;
    private List<GameObject> soundBlocks = new List<GameObject>();
    


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            isPlaying = !isPlaying;
        }

        if (isPlaying)
        {
            Play();
            if (transform.position.x == endPoint.position.x)
            {
                transform.position = new Vector3(startPoint.position.x, transform.position.y, transform.position.z);
                soundBlocks.RemoveRange(0, soundBlocks.Count);
            }
        }
    }

    void Play()
    {
        var ray = new Ray(transform.position, transform.TransformDirection(Vector3.down) * length);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(endPoint.position.x, transform.position.y, transform.position.z), speed);
        var hits = Physics.RaycastAll(ray);
        if (hits.Any())
        {
            foreach (var hit in hits)
            {
                if (hit.transform.CompareTag("SoundBlock") && !soundBlocks.Contains(hit.transform.gameObject))
                {
                    soundBlocks.Add(hit.transform.gameObject);
                    try
                    {
                        hit.transform.gameObject.GetComponent<SoundBlockManager>().PlaySound();
                    }

                    catch (NullReferenceException ex)
                    {

                    }
                }
            }
        }
    }
}
