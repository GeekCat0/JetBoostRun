using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldGrabber : MonoBehaviour
{
    public float sensitivity;
    public float MusicVolume;
    public float EffectsVolume;

    public Slider sens;
    public Slider music;
    public Slider effects;
    

    public void CheckSettings()
    {
        sensitivity = FindObjectOfType<GameManager>().sensitivity;
        MusicVolume = FindObjectOfType<GameManager>().MusicVolume;
        EffectsVolume = FindObjectOfType<GameManager>().effectsVolume;

        sens.value = sensitivity;
        music.value = MusicVolume;
        effects.value = EffectsVolume;
    }

    
}
