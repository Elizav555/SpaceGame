using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipScript : MonoBehaviour
{
    public GameObject EnemyShipExplosion;
    public GameObject PlayerExplosion;
    public GameObject RightEnemyGun1;
    public GameObject LeftEnemyGun1;
    public GameObject RightEnemyGun;
    public GameObject LeftEnemyGun;
    public GameObject EnemyLaserShot;
    public float shotDelay;
    public float moveHorizontal;
    public float moveVertical;
    public float speed;
    float nextShotTime;

    void Start()
    {
        //Rigidbody EnemyShip = GetComponent<Rigidbody>();
        
    }

    void Update()
    {

        if (Time.time > nextShotTime)
        {
            Instantiate(EnemyLaserShot, RightEnemyGun1.transform.position, Quaternion.identity);
            Instantiate(EnemyLaserShot, LeftEnemyGun1.transform.position, Quaternion.identity);
            Instantiate(EnemyLaserShot, RightEnemyGun.transform.position, Quaternion.identity);
            Instantiate(EnemyLaserShot, LeftEnemyGun.transform.position, Quaternion.identity);
            nextShotTime = shotDelay + Time.time;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            return;
        }
        if (other.CompareTag("Player"))
        {
            Instantiate(EnemyShipExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            if (!GameController.Immune)
            {
                Instantiate(PlayerExplosion, other.transform.position, Quaternion.identity);
                GameController.health--;
                GameController.PlayerIsDead();
            }
            
        }
        if (other.CompareTag("LaserShot"))
        {
            Instantiate(EnemyShipExplosion, transform.position, Quaternion.identity);
            GameController.increaseScore(+25);
            Destroy(this.gameObject);
        }
    }
}
