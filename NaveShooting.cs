using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveShooting : MonoBehaviour
{
    public GameObject bala;
    public GameObject punta;
    public float timeBetweenBullets = 0.2f;
    public float probabilidad;

    float timer;
    private float aleatorio;
    AudioSource audioData;
    int canShot;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        canShot = PlayerPrefs.GetInt("canShot", 1);
    }

    void FixedUpdate()
    {
        aleatorio = Random.Range(0f, 100f);
        timer += Time.deltaTime;

        if (timer >= timeBetweenBullets && aleatorio < probabilidad && canShot == 1)
        {
            audioData.Play(0);
            timer = 0;
            Instantiate(bala, punta.transform.position, punta.transform.rotation);
        }
    }
}
