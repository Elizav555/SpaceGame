using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObjectsScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerExit(Collider collider)
    {
        Destroy(collider.gameObject);
    }
}
