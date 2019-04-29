using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public GameObject bala;
    public GameObject balaEnemiga;
    public void LoadByIndex(int index) {
        SceneManager.LoadScene(index);
    }

    public void SelectDificulty(int dificulty) {
        switch (dificulty) {
            case 1:

                PlayerPrefs.SetInt("canShot", 1);
                if (bala != null) {
                    bala.GetComponent<Disparo>().rebotes = 1;
                    balaEnemiga.GetComponent<Disparo>().rebotes = 1;
                }
                DificultySelector.dificultyLevel = DificultyLevel.Hard;
                break;

            case 2:

                PlayerPrefs.SetInt("canShot", 1);
                if (bala != null) {
                    bala.GetComponent<Disparo>().rebotes = 0;
                    balaEnemiga.GetComponent<Disparo>().rebotes = 0;
                }
                DificultySelector.dificultyLevel = DificultyLevel.Casual;
                break;

            case 3:

                PlayerPrefs.SetInt("canShot", 0);
                DificultySelector.dificultyLevel = DificultyLevel.Child;
                break;

            default:
                DificultySelector.dificultyLevel = DificultyLevel.Casual;
                break;
        }
    }
}
