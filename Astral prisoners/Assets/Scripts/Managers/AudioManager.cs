using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
// Creating Audio Database ------------------------------

    // zmienna ktora ustala czy zachowac ten sam AudioManager pomiedzy scenami
    //public string sceneType;

    public Sound[] sounds;

    //public static AudioManager instance; 

    
    public void Awake()
    {
        
        // Jezeli masz zmienic AudioManagera
        //if(instance == null || instance.sceneType != this.sceneType) instance = this;

        //DontDestroyOnLoad(gameObject);
    
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.mixer;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        //CheckInstance();
    }

    /*
    public bool CheckInstance() // Funkcja sprawdza czy ten konkretny AudioManager ma sie usunac czy zostac
    {
        if(instance != this) Destroy(gameObject);
        return true;
    }
    */


// Play Functions -------------------------------------

    public void Play(string name)
    {   
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){Debug.LogWarning("Nie odnaleziono dzwieku: " + name); return;}
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){Debug.LogWarning("Nie odnaleziono dzwieku: " + name); return;}
        s.source.Stop();
    }

    public void Pause (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){Debug.LogWarning("Nie odnaleziono dzwieku: " + name); return;}
        s.source.Pause();
    }

    public void UnPause (string name)
    {
	   Sound s = Array.Find(sounds, sound => sound.name == name);
       if(s == null){Debug.LogWarning("Nie odnaleziono dzwieku: " + name); return;}
	   s.source.UnPause();
    }

// Audio Mixers --------------------------------------

    public AudioMixer musicMixer;
    public AudioMixer effectsMixer;


    public void MusicVolume (float sliderValue)
    {
        musicMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue)*20);
    }

    public void EffectsVolume (float sliderValue)
    {
        effectsMixer.SetFloat("EffectsVolume", Mathf.Log10(sliderValue)*20);
    }




}
