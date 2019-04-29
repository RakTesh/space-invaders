using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muerte : MonoBehaviour
{
    public GameObject explosion;
    public GameObject death;
    public GameObject record;
    public GameObject tiempoCanvas;
    

    private float time;

    public void Dead()
    {
        Instantiate(explosion,this.transform.position,this.transform.rotation);
        Destroy(gameObject);
        

        GameObject[] spawn = GameObject.FindGameObjectsWithTag("Respawn");
        for (int i = 0; i < spawn.Length; i++)
        {
            spawn[i].SetActive(false);
        }

        time = Mathf.Round(tiempoCanvas.GetComponent<time>().tiempo * 100f) / 100f;
        tiempoCanvas.GetComponent<time>().enabled = false;

        record.SetActive(true);
    }
}
