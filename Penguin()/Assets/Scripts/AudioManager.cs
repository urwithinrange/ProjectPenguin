using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

 public class AudioManager : MonoBehaviour
 {
 
    [SerializeField]
    private AudioMixer audioMixer;
 
    public static AudioManager instance;
    // [SerializeField] private Text ScoreTextText;

    // void Awake()
    // {
    //     if(AudioManager.instance == null)
    //     {
    //         DontDestroyOnLoad(gameObject);
    //         AudioManager.instance = this;
    //     }
    //     else
    //         Destroy(gameObject);
    // }
    void Start()
    {
        //Get the saved music volume, standard = 10f
        float music = PlayerPrefs.GetFloat("MusicVolume", 0f);
        float fx = PlayerPrefs.GetFloat("FXVolume", 0f);
 
        // ScoreTextText.text = "PlayerPref Float: " + fx;    
        //Set the music volume to the saved volume
        AdjustMusicVolume(music);
        AdjustFXVolume(fx);
    }
 
    public void AdjustMusicVolume(float volume)
    {
        //Update AudioMixer
        audioMixer.SetFloat("MusicVolume", volume);
        //Update PlayerPrefs "Music"
        PlayerPrefs.SetFloat("MusicVolume", volume);
        //Save changes
        PlayerPrefs.Save();
    }

    public void AdjustFXVolume(float volume)
    {
        //Update AudioMixer
        audioMixer.SetFloat("FXVolume", volume);
        //Update PlayerPrefs "FX"
        PlayerPrefs.SetFloat("FXVolume", volume);
        //Save changes
        PlayerPrefs.Save();
    }

    // public void AdjustMusicVolume(float volume)
    // {
    //     audioMixer.SetFloat("MusicVolume", volume);
    // }

    // public void AdjustFXVolume(float volume)
    // {
    //     audioMixer.SetFloat("FXVolume", volume);
    // }
}
