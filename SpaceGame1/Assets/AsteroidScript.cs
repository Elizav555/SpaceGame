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
<<<<<<< HEAD
        if (other.CompareTag("Asteroid"))
=======
        if (other.tag == "Asteroid")
>>>>>>> a8ac47740170d74f6333f2a4b7f9d81f61b4d9aa
        {
            return;
        }
        Instantiate(AsteroidExplosion, transform.position, Quaternion.identity);
        if (other.CompareTag("Player"))
        {
            if (!GameController.Immune)
            {
                Instantiate(PlayerExplosion, other.transform.position, Quaternion.identity);
                GameController.health--;
                GameController.PlayerIsDead();
            }
        }
        else
        {
            GameController.increaseScore(+10);
            Destroy(other.gameObject);
        }
        Destroy(gameObject);

    }
}