using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NamePanel : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField namedTexto;
    List<Puntuacion> items = new List<Puntuacion>();
    public time tiempo;
    void Start()
    {
        items = SavePlayer.Load();
        if (items==null) {
            items = new List<Puntuacion>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OkButton() {
        //items.Clear();
        string name = namedTexto.text;
        Debug.Log(namedTexto.text.Length+" cAR");
        if (name.Length< 10) {

            for (int i= namedTexto.text.Length;i<10;i++) {
                name += " ";
            }
        }
        Debug.Log(name.Length + " cAR2");
        items.Add(new Puntuacion { nombre = name, tiempo = Mathf.Round(tiempo.GetComponent<time>().tiempo * 100f) / 100f, puntos = Score.pun});
        items.Sort();
        items.Reverse();
        SavePlayer.Save(items);
        Score.pun = 0;
        tiempo.tiempo = 0;
    }
}
