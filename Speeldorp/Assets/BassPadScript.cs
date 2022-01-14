using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassPadScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }

}
