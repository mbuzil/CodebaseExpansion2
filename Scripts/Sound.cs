using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    //Raw clip that is to be played
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;

    //Whether or not the sound will loop on end
    public bool loop;

    public bool playAtStart;

    [HideInInspector]
    //AudioSource component that will play the sound
    public AudioSource source;
}
