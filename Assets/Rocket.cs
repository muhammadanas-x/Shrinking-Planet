using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{

    public float moveSpeed;
    private Vector3 dir;

    public ParticleSystem explosionPrefab; // Reference to the explosion particle system prefab

    // Start is called before the first frame update
    void Start()
    {
        explosionPrefab = GameObject.Find("Explosion Fire").GetComponent<ParticleSystem>();
    }

    public void setInitialDirection(Vector3 direction)
    {
        dir = direction;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * moveSpeed * Time.deltaTime;


        Quaternion targetRotation = Quaternion.LookRotation(Vector3.zero - transform.position) * Quaternion.Euler(90f,0f,0f);

        // Apply the rotation to the rocket
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }




    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("planet"))
        {

            Vector3 cp = collision.contacts[0].point;

            

            ParticleSystem explosionInstance = Instantiate(explosionPrefab, cp, Quaternion.identity);

            // Destroy the explosion particle system after a delay
            Destroy(explosionInstance.gameObject, 0.4f);
            Destroy(gameObject);
            
            
            
        }

        else if(collision.gameObject.CompareTag("player"))
        {
            SceneManager.LoadScene("Gameplay");
            
        }
    }
}
