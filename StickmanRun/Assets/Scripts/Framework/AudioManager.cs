// ================================================
// File: AudioManager.cs
// Version: 1.0.1
// Desc: Singleton. Do not attach to Gameobject.
// ================================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager 
{
    // Data members.
    private static AudioManager instance;

    private Dictionary<string, AudioClip> audioClips;

    // Properties.
    public Dictionary<string, AudioClip> AudioClips
    {
        get { return audioClips; }
    }

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AudioManager();
            }

            return instance;
        }
    }

    public void Play(AudioSource audioSource, string name, bool loop = true)
    {
        if (!audioSource.isPlaying)
        {
            if (audioClips.ContainsKey(name))
            {
                AudioClip audioClip = audioClips[name];
                
                audioSource.clip = audioClip;

                audioSource.loop = loop;
                
                audioSource.Play();
            }
        }
    }

    public void PlayOneShot(AudioSource audioSource, string name)
    {
        if(audioClips.ContainsKey(name))
        {
            AudioClip audioClip = audioClips[name];
            
            audioSource.PlayOneShot(audioClip);
        }
    }

    public void PlayOneShot(AudioSource audioSource, string name, float volumeScale)
    {
        if (audioClips.ContainsKey(name))
        {
            AudioClip audioClip = audioClips[name];
                
            audioSource.PlayOneShot(audioClip, volumeScale);
        }
    }

    public void LoadSong(string name)
    {
        // If we already have a reference.
        if(audioClips.ContainsKey(name))
        {
            return;
        }

        string path = @"Audio/Songs/" + name;
        
        // Load AudioClip assets.
        AudioClip audioClip = Resources.Load( 
            path, 
            typeof(AudioClip)) as AudioClip;

        if (audioClip == null)
        {
            Debug.LogError("AudioManager.cs: Unable to load \"" + name + "\".");
        }
        else
        {
            // Store in Dictionary.
            audioClips.Add(name, audioClip);
        }
    }

    public void LoadSound(string name)
    {
        // If we already have a reference.
        if (audioClips.ContainsKey(name))
        {
            return;
        }

        string path = @"Audio/Sounds/" + name;

        // Load AudioClip assets.
        AudioClip audioClip = Resources.Load(
            path,
            typeof(AudioClip)) as AudioClip;

        if (audioClip == null)
        {
            Debug.LogError("AudioManager.cs: Unable to load \"" + name + "\".");
        }
        else
        {
            // Store in Dictionary.
            audioClips.Add(name, audioClip);
        }
    }

    // Ctor.
    private AudioManager()
    {
        // Instantiate Dictionary.
        audioClips = new Dictionary<string, AudioClip>();
    }
}
