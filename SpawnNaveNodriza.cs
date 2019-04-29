using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNaveNodriza : MonoBehaviour
{
    [SerializeField] GameObject nave;
    public float tiempoEntreEnemigo = 10f;
    float timer;

    void Start()
    {
        StartCoroutine(GenerarEnemigo());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    IEnumerator GenerarEnemigo()
    {
        yield return new WaitForSeconds(tiempoEntreEnemigo);
        Instantiate(nave, this.transform.position, nave.transform.rotation);
        StartCoroutine("GenerarEnemigo");
    }
}
