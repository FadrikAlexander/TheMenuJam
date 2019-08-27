using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//The Script which controls the sounds mechanics
public class SoundController : MonoBehaviour
{
	//Change the Mute Key in the inspector 
    [SerializeField]
    KeyCode MuteKey = KeyCode.M;

    AudioSource[] AllAudioSources;

    void Awake()
    {
		//Finding all the AudioSource in the scene at the start of the game
        AllAudioSources = FindObjectsOfType<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(MuteKey))
            MuteGame();
    }

	//The Mute Function can be activated by pressing the muteKey or by a UI button
    public void MuteGame()
    {
		//Go Through all AudioSources and mute them
        foreach (AudioSource AS in AllAudioSources)
        {
            AS.mute = !AS.mute;
        }
    }

	//Change the sound Function can be called by buttons and Sliders to change the volume to all AudioSource
    public void ChangeSound(Slider slider)
    {
		//Go Through all AudioSources and change the volume
        foreach (AudioSource AS in AllAudioSources)
        {
            AS.volume = slider.value;
        }
    }
	
	//Override
    public void ChangeSound(float volume)
    {
		//Go Through all AudioSources and change the volume
        foreach (AudioSource AS in AllAudioSources)
        {
            AS.volume = volume;
        }
    }
}
