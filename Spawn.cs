using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] enemigo;
    [SerializeField] float tiempoEntreEnemigo;

    void Start() {
        tiempoEntreEnemigo = DificultySelector.dificultyLevel == DificultyLevel.Hard ? .75f : 1.25f;
        StartCoroutine(GenerarEnemigo());
    }

    IEnumerator GenerarEnemigo() {
        yield return new WaitForSeconds(tiempoEntreEnemigo);
        int random = Random.Range(0, enemigo.Length);
        if (transform.position != GameObject.FindGameObjectWithTag("Player").transform.position)
            Instantiate(enemigo[random], transform.position, transform.rotation);
        StartCoroutine("GenerarEnemigo");
    }
}
