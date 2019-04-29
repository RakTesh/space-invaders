using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<Muerte>().Dead();
        }
    }
}
