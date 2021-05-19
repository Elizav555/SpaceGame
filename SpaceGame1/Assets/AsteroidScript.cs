using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject AsteroidExplosion;
    public GameObject PlayerExplosion;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody Asteroid = GetComponent<Rigidbody>();
        Asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            return;
        }
        Instantiate(AsteroidExplosion, transform.position, Quaternion.identity);
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (!GameController.Immune)
            {
                Instantiate(PlayerExplosion, other.transform.position, Quaternion.identity);
                GameController.health--;
                GameController.PlayerIsDead();
            }
        }
        if (other.CompareTag("LaserShot"))
        {
            GameController.increaseScore(+10);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        

    }
}