using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLazerShot : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);

    }

    // Update is called once per frame
    void Update()
    {
    }
}