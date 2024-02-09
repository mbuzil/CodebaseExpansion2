using Unity.Audio;
using System;
using UnityEngine;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    //Responsible for keeping all sounds and music to be played
    //"FindObjectOfType<AudioManager>.PlayMusic(songName)" for music
    //"FindObjectOfType<AudioManager>.PlaySound(soundName)" for sfx
    public Sound[] music;
    public Sound[] sounds;

    //Used to make sure only one instance of AudioManager exists at a time.
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }      

        DontDestroyOnLoad(gameObject);
        
        foreach (Sound m in music)
        {
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.clip;

            m.source.volume = m.volume;
            m.source.loop = m.loop;
        }

        //Sets the AudioSource component parameters to be the same of each Sound object in sounds
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    public void Start()
    {
        foreach (Sound m in music)
        {
            if (m.playAtStart == true)
                PlayMusic(m.name);
        }
    }

    public void PlaySound (string soundName)
    {
        //Finds sound with in sounds that matches to soundName and plays it
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning($"Sound \"{soundName}\" was not found!");
            return;
        }
        s.source.Play();
    }

    public void PlayMusic (string musicName)
    {
        Sound s = Array.Find(music, song => song.name == musicName);
        if (s == null)
        {
            Debug.LogWarning($"Song \"{musicName}\" was not found!");
            return;
        }

        foreach (Sound m in music)
        {
            m.source.Stop();
        }

        s.source.Play();
    }

    public void Stop (string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning($"Sound \"{soundName}\" was not found!");
            return;
        }
        s.source.Stop();
    }
}
