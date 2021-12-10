using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneColliderManager : MonoBehaviour
{
    [SerializeField] private float timerInSeconds;
    [SerializeField] private string sceneToLoad;
    private float timeLeft;

    public void Start()
    {
        timeLeft = timerInSeconds;
    }
    public void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            timeLeft -= Time.deltaTime;
            Debug.Log(timeLeft);
            if (timeLeft <= 0f)
            {
                MoveScene();
            }
        }
    }

    void MoveScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            timeLeft = timerInSeconds;
            Debug.Log(timeLeft);
        }
    }

    public void OnTriggerEnter(Collider coll)
    {
        Debug.Log(coll.gameObject.name);
    }
}