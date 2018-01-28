using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance = null;

    public static AudioManager getInstance() { return _instance; }

    void Awake()
    {
        if (_instance != null)
            throw new System.Exception("AudioManager is a singleton!");

        _instance = this;
    }

    public void playOnce(AudioClip sound)
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
                _sources.Add(sound.name, source);
            }
            
            source.Play();
        }
    }

    public void play(AudioClip sound)
    {
        if (sound != null && !_sources.ContainsKey(sound.name))
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = sound;
            source.loop = true;
            source.playOnAwake = false;

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