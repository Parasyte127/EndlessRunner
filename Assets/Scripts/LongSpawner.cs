using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;

    float timeToNextSpawn;
    float timeSinceLastSpawn = 0.0f;

    public float minSpawnTime = 3.0f;
    public float maxSpawnTime = 10.0f;

    public GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
        timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(mainCamera.transform.position.x + 12.0f, transform.position.y, transform.position.z);

        timeSinceLastSpawn = timeSinceLastSpawn + Time.deltaTime;

        if (timeSinceLastSpawn  > timeToNextSpawn)
        {
            int selection = Random.Range(0, objectsToSpawn.Length);

            Instantiate(objectsToSpawn[selection], transform.position, Quaternion.identity);

            timeToNextSpawn = Random.Range(maxSpawnTime, maxSpawnTime);
            timeSinceLastSpawn = 0.0f;
        }
    }
}
