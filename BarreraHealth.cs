using UnityEngine;

public class BarreraHealth : MonoBehaviour
{
    [SerializeField] int maximumHits;
    [SerializeField] int hitsTaken;
    private Color colorRandom;


    void Start() {
        hitsTaken = 0;
        maximumHits = DificultySelector.dificultyLevel == DificultyLevel.Hard ? 3 : 5;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Disparo") || other.gameObject.CompareTag("Marciano")) {
            colorRandom = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 0.0f);
            GameObject[] marcianos = GameObject.FindGameObjectsWithTag("Marciano");
            foreach (GameObject marciano in marcianos) {
                marciano.GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", colorRandom * 1.35f);
            }
            print("HIT EN LA BARRERA");
            hitsTaken++;
            Destroy(other.gameObject);
        }
    }

    void Update() {
        /**/
        if (hitsTaken == 0) {
            Color c = new Color(0f, 0.7749438f, 0f);
            GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", c * 1.4f);
        }
        else if (hitsTaken == 1) {
            Color c = new Color(0.7764706f, 0.6712875f, 0f);
            GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", c * 1.4f);
        }
        else {
            Color c = new Color(1f, 0f, 0f);
            GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", c * 1.4f);
        }//*/

        if (hitsTaken >= maximumHits) Destroy(gameObject);
    }
}
