using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject panelMuerte;
    public GameObject panelRanking;
    public GameObject panelRestart;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) &&  !panelMuerte.activeSelf && !panelRanking.activeSelf && !panelRestart.activeSelf)
        {
            if (!gameIsPaused)
            {
                
                Pause();
                
            }
            else{
                Continue();
            }
        }


      /*  if(panelMuerte.activeSelf || panelRanking.activeSelf || panelRestart.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }*/

        
    }

    public void Continue()

    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }


    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;

    }
}
