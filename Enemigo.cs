using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hola "+ collision.gameObject.tag);
        Destroy(collision.gameObject);
        if (collision.gameObject.tag=="Player") {
            //Pantalla de Game Over
        }
    }

}
