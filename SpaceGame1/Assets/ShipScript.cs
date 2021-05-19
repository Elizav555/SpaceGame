using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public GameObject LaserGun;
    public GameObject RightGun;
    public GameObject LeftGun;
    public GameObject LaserShot;
    public GameObject PlayerExplosion;
    float nextShotTime;
    public float shotDelay;
    public float speed;
    public float tilt;
    public float xMin, xMax, zMin, zMax;
    Rigidbody Ship;


    // Start is called before the first frame update
    void Start()
    {
        Ship = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.IsStarted())
        {
            return;
        }


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;


        Ship.rotation = Quaternion.Euler(tilt * Ship.velocity.z, 0, -Ship.velocity.x * tilt);


        float correctX = Mathf.Clamp(Ship.position.x, xMin, xMax);
        float correctZ = Mathf.Clamp(Ship.position.z, zMin, zMax);

        Ship.position = new Vector3(correctX, 0, correctZ);

        if (Time.time > nextShotTime && Input.GetButton("Fire1") || Input.GetKeyUp(KeyCode.Space))
        {
            GameController.Immune = false;
            Instantiate(LaserShot, LaserGun.transform.position, Quaternion.identity);
            Instantiate(LaserShot, LeftGun.transform.position, Quaternion.identity);
            Instantiate(LaserShot, RightGun.transform.position, Quaternion.identity);
            nextShotTime = shotDelay + Time.time;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyShot"))
        {
            Destroy(other.gameObject);
            if (!GameController.Immune)
            {
                Instantiate(PlayerExplosion, other.transform.position, Quaternion.identity);
                GameController.health--;
                GameController.PlayerIsDead();
            }
        }
    }
}