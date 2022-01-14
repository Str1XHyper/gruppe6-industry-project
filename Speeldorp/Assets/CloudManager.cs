using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public GameObject[] FrontClouds;
    public GameObject[] MidClouds;
    public GameObject[] BackClouds;
    public bool IsSpawningClouds;

    [Header("Spawn Restrictions")]
    public float maxY;
    public float minY;


    private IEnumerator SpawnClouds(GameObject[] SpawnedArray, float timeMultiplier) 
    {
        while (IsSpawningClouds)  
        {
            float yOffset = Random.Range(minY, maxY);
            int index = Random.Range(1, SpawnedArray.Length);

            var temp = SpawnedArray[index];
            SpawnedArray[index] = SpawnedArray[0];
            SpawnedArray[0] = temp;

            Instantiate(SpawnedArray[0], transform.position+ new Vector3(0,yOffset,-timeMultiplier * 5), Quaternion.identity, transform);

            float timer = Random.Range(1f, 2f);
            yield return new WaitForSeconds(timer * timeMultiplier * 6);
        }
        yield return null;
    }
    private void Start()
    {
        StartCoroutine(SpawnClouds(FrontClouds, 1));
        StartCoroutine(SpawnClouds(MidClouds, 1.2f));
    //    StartCoroutine(SpawnClouds(BackClouds, 1.6f));
    }
}

