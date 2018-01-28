using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance = null;

    public static AudioManager getInstance() { return _instance; }

    private System.Random _randomiser = new System.Random();

    void Awake()
    {
        if (_instance != null)
            throw new System.Exception("AudioManager is a singleton!");

        _instance = this;
    }

    public void playOnce(AudioClip sound, float volume = 1.0f)
    {
        if (sound != null)
        {
            AudioSource source = null;
            try
            {
                source = _sources[sound.name];
            }
            catch (KeyNotFoundException)
            {
                source = gameObject.AddComponent<AudioSource>();
                source.playOnAwake = false;
                source.loop = false;
                source.clip = sound;
                source.volume = volume;
                _sources.Add(sound.name, source);
            }
            source.Play();
        }
    }

    public void playOneOfTheseOnce(AudioClip[] sounds, float volume = 1.0f)
    {
        if (sounds.Length == 0)
            throw new UnityException("No sounds");

        int playThisOne = _randomiser.Next(0, sounds.Length - 1);

        playOnce(sounds[playThisOne], volume);

    }

    public void play(AudioClip sound, float volume = 1.0f)
    {
        if (sound != null && !_sources.ContainsKey(sound.name))
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = sound;
            source.loop = true;
            source.playOnAwake = false;
            source.volume = volume;

            source.Play();

            _sources.Add(sound.name, source);
        }
    }

    public void stop(AudioClip sound)
    {
        if (sound != null && _sources.ContainsKey(sound.name))
        {
            AudioSource source = _sources[sound.name];
            source.Stop();
            _sources.Remove(sound.name);
            Destroy(source);
        }
    }

    /*mapping clip name to source*/
    private Dictionary<string, AudioSource> _sources = new Dictionary<string, AudioSource>();


}