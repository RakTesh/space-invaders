using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour
{

    public Text cuenta;
    public Text score;
    
    [HideInInspector] public float tiempo=0;

    // Start is called before the first frame update
    void Start()
    {
        tiempo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        cuenta.text = ("Time Survived: " + Mathf.Round(tiempo * 100f) / 100f);
        score.text = "Score: "+ Score.pun;
    }
}
