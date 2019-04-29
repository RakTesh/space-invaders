using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class volumeManager : MonoBehaviour
{
    // Start is called before the first frame update


    // Start is called before the first frame update
    public AudioMixer masterMixer;
    //public AudioMixer masterMixer;

    public void SetFXVolume(float volume)
    {
        masterMixer.SetFloat("sounds", volume);
    }
    public void SetMusicVolume(float volume)
    {
        masterMixer.SetFloat("music", volume);
    }

    void Start()
    {
        masterMixer.SetFloat("music", 0);
        masterMixer.SetFloat("sounds", 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
