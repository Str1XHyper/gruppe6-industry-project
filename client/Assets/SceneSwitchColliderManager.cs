using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchColliderManager : MonoBehaviour
{
    [SerializeField] private float timerInSeconds;
    [SerializeField] private string sceneToLoad;
    public void OnTriggerStay(Collider coll)
    {
        Debug.Log(coll.gameObject.name);
        if (coll.gameObject.tag == "Player")
        {
            timerInSeconds -= Time.deltaTime;
            Debug.Log(timerInSeconds);
            if (timerInSeconds <= 0f)
            {
                MoveScene();
            }
        }
    }

    void MoveScene()
    { 
        SceneManager.LoadScene(sceneToLoad);
    }
}
