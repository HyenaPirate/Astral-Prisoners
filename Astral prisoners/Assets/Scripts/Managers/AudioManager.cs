using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
// Creating Audio Database ------------------------------

    public Sound[] sounds;

    //public static AudioManager instance;

    void Awake()
    {
        /*
        if(instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        */

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.mixer;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

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
