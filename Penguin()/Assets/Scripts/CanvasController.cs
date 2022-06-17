using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{

    // front facing UI
    public GameObject canvas;
    public GameObject QuitButton;
    // public GameObject OnePlayerButton;
    // public GameObject TwoPlayerButton;
    public GameObject OptionsButton;
    public GameObject MainPanel;
    public GameObject NamePanel;

    // Multiplayer UI elements

    // Options UI elements
    // public GameObject OptionsBackButton;
    // public GameObject OptionsResetButton;
    // public GameObject OptionsApplyButton;
    public GameObject OptionsMusicSlider;
    public GameObject OptionsFXSlider;

    // Start is called before the first frame update
    void Start()
    {
        OptionsMusicSlider.GetComponent<Slider>().value = 0.8f;
        OptionsFXSlider.GetComponent<Slider>().value = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Play the main scene in single player mode
    /// </summary>
    public void OnePlayer()
    {
        
        // honestly, this just needs to be another scene manager. But it probably needs the internet access removed from the game.
        // Best to fake the process and yada yada until there is more work done on it later. There won't be an initial player
        // base large enough to register a concern for the sake of this presentation. Maybe the code should fake the appID in NormCore
        // until we find a better way to do this.
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Play the main scene in multiplayer mode
    /// </summary>
    public void TwoPlayer()
    {
        // activate the UI for Normcore and multiplayer, deactivate the other UI
        // OnePlayerButton.SetActive(false);
        // TwoPlayerButton.SetActive(false);
        MainPanel.SetActive(false);
        OptionsButton.SetActive(false);
        
        // activate the UI for Normcore and multiplayer, deactivate the other UI
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Change the sound output of the game.
    /// Stretches include adding the teleportation option for accessibility
    /// </summary>
    public void Options()
    {
        // activate the UI for options, deactivate the upper level AI
        // OnePlayerButton.SetActive(false);
        // TwoPlayerButton.SetActive(false);
        MainPanel.SetActive(false);
        OptionsButton.SetActive(true);
        // NamePanel.SetActive(false);
    }

    public void OptionsBack()
    {
        // deactivate the UI for options, activate the upper level AI
        MainPanel.SetActive(true);
        // NamePanel.SetActive(true);
        OptionsButton.SetActive(false);
    }

    public void OptionsReset()
    {
        // reset the options to default
        OptionsMusicSlider.GetComponent<Slider>().value = 0.8f;
        OptionsFXSlider.GetComponent<Slider>().value = 0.8f;
    }

    public void OptionsApply()
    {
        // save the Music and FX slider values to PlayerPrefs
        PlayerPrefs.SetFloat("MusicVolume", OptionsMusicSlider.GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("FXVolume", OptionsFXSlider.GetComponent<Slider>().value);
        OptionsBack();
    }

    public void NameSubmit()
    {
        // get the name from the input field
        string name = NamePanel.GetComponentInChildren<InputField>().text;
        // set the name in the player prefs
        PlayerPrefs.SetString("PlayerName", name);
    }

    /// <summary>
    /// make a keyboard input field for the player to enter their name
    /// </summary>
    public void Name()
    {
        // present a keyboard to the user
        TouchScreenKeyboard.Open("");
        // save input from enter key into NameSubmit()
        NamePanel.GetComponentInChildren<InputField>().onEndEdit.AddListener(delegate { NameSubmit(); });
    }
}
