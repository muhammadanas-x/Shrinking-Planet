using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour
{

    private float currentTimer = 0f;
    private float sphereRadius = 15.42f;
    public float spawnTimer = 1f;
    public GameObject rocketPrefab;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimer > spawnTimer)
        {

            Vector3 randomDir = Random.onUnitSphere * sphereRadius;

            Vector3 origin = Vector3.zero;

            GameObject rocket = Instantiate(rocketPrefab, randomDir, Quaternion.identity);
            rocket.GetComponent<Rocket>().setInitialDirection((origin - randomDir).normalized);

            spawnTimer -= Time.deltaTime;
            currentTimer = 0f;
        }
        else
        {
            currentTimer += Time.deltaTime;
        }
    }


}
