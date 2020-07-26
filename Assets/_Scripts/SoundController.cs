using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public enum Type
    {
        Coin,
        Gas,
        Obstacle
    }

    [System.Serializable]
    public class SoundName
    {
        public Type type;
        public AudioClip clip;
        public AudioSource source;
    }

    public SoundName[] soundNames;

    public void Play(Type soundType)
    {
        foreach(SoundName soundName in soundNames)
        {
            if (soundName.type == soundType)
            {
                soundName.source.clip = soundName.clip;
                soundName.source.Play();
                break;
            }
        }
    }
}
