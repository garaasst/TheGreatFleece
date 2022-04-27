using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("AudioManager is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    [SerializeField]
    private AudioSource voiceOver;

    public void PlayVoiceOver(AudioClip clip)
    {
        voiceOver.clip = clip;
        voiceOver.Play();
    }

}
