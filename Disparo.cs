using UnityEngine;

public class Disparo : MonoBehaviour
{
    public int damage = 5;
    float TiempoAutoDestruccion = 3f;
    public float velocidad = 30f;
    public int rebotes = 0;

    public GameObject explosion;

    void Start() {
        Destroy(gameObject, TiempoAutoDestruccion);
    }

    void Update() {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable") && !other.isTrigger) {

            if (other.gameObject.tag == "Marciano") {
                Score.pun += 100;
                Instantiate(explosion, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
            }

            if (other.gameObject.tag == "Player") {
                other.GetComponent<Muerte>().Dead();
            }

            if (rebotes == 0) {
                Destroy(gameObject);
            }
            else {
                float angulo = Random.Range(0, 360);

                this.transform.Rotate(Vector3.right, angulo, Space.World);
                rebotes--;
            }
        }
    }
}
