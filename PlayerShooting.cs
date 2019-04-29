using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bala;
    [SerializeField] GameObject punta;
    public float timeBetweenBullets = 0.2f;

    AudioSource audioData;
    int canShot;

    float timer;
    void Start() {
        audioData = GetComponent<AudioSource>();
        canShot = PlayerPrefs.GetInt("canShot", 1);
    }

    void Update() {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && canShot == 1) {
            audioData.Play(0);
            timer = 0;
            Instantiate(bala, punta.transform.position, punta.transform.rotation);
        }
    }
}
