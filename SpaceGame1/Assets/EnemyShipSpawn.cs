using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipSpawn : MonoBehaviour
{

    public GameObject EnemyShip;
    public GameObject Player;
    public float minDelay, maxDelay;
    public float minSpeed, maxSpeed;
    float nextLaunchTime,x;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.IsStarted())
        {
            return;
        }
        if (Time.time > nextLaunchTime)
        {
            x = Random.Range(-60, 60);
            GameObject launchedShip = Instantiate(EnemyShip, new Vector3(x, 0, 60), Quaternion.identity);
            float speed = Random.Range(minSpeed, maxSpeed);
            launchedShip.GetComponent<Rigidbody>().velocity = transform.forward * speed;
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
