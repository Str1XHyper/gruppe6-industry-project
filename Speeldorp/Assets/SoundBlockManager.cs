using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBlockManager : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private List<AudioClip> clips;
    [SerializeField] private AudioSource audioSource;

    void Awake()
    {
        GetComponent<MeshRenderer>().materials[0] = material;
    }

    public void PlaySound()
    {
        audioSource.clip = clips[Random.Range(0, clips.Count)];
        audioSource.Play();
    }
}
