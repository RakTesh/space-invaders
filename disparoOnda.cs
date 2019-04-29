using UnityEngine;
using System.Collections;

public class disparoOnda : MonoBehaviour
{

    public float MoveSpeed = 1.0f;
    public int rebotes = 2;

    public float frequencia = 200.0f;  
    public float magnitud = 50.5f;
    public float tiempoVida = 3f;
    private Vector3 axis;
    private float f = 0;
    private Vector3 pos;



    void Start()
    {
        pos = transform.position;
        Destroy(gameObject, tiempoVida);
        axis = transform.up;  
    }

    void Update()
    {
        f += 0.01f;
        pos += transform.forward * Time.deltaTime * 0.3f * MoveSpeed;
        transform.position =  pos + axis * Mathf.Sin(f * f * frequencia) * magnitud;
    }
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Soy la puta bala e chocado con esto "+ other.gameObject.layer+" de nombre "+ other.tag+" La capa shotable es "+ LayerMask.NameToLayer("Shootable"));
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable") && !other.isTrigger)
        {
            Destroy(other.gameObject);

            /*EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage, Vector3.zero);
            }*/
            if (rebotes == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                float angulo = Random.Range(60, 90);

                this.transform.Rotate(Vector3.right, angulo, Space.World);
                rebotes--;
            }
        }
    }
}