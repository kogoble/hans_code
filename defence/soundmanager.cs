using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class soundmanager : MonoBehaviour
    {
    public AudioSource music;
    public Slider musicbutton;
    private void Start()
    {
        soundload();
    }

    public void setmusic(float volume) {
        music.volume = volume;
        musicbutton.value = volume;
    }

    public void soundsave() {
        PlayerPrefs.SetFloat("music_sound", music.volume);
        PlayerPrefs.Save();
    }
   public void soundload() {
       float sound_volume = PlayerPrefs.GetFloat("music_sound");

        setmusic(sound_volume);
    }
}
