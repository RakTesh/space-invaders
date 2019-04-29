using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavaMovement : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        this.transform.position += Vector3.forward * speed;
        if (this.transform.position.z >= 1.2) speed *= -1;
        if (this.transform.position.z <= -3.7) speed *= -1;
    }
}
