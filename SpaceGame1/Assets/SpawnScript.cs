using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject Asteroid;
    public GameObject Player;
    public float minDelay, maxDelay;
    public float minSpeed, maxSpeed;
    float nextLaunchTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextLaunchTime)
        {
            GameObject launchedAsteroid = Instantiate(Asteroid, transform.position, Quaternion.identity);
            float speed = Random.Range(minSpeed, maxSpeed);
            if (Random.Range(0, 10) == 5)
            {
                launchedAsteroid.transform.LookAt(Player.transform.position);
                launchedAsteroid.GetComponent<Rigidbody>().velocity = launchedAsteroid.transform.forward * speed;
            }
            else
            {
                float spread = Random.Range(-30, 30);
                launchedAsteroid.GetComponent<Rigidbody>().velocity = Quaternion.Euler(0,spread,0) * transform.forward * speed;
            }
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
