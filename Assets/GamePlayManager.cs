using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public enum AudioType
    {
        BACKGROUND,
        DOOR_OPEN1,
        CRACKING_DOOR,
        DOOR_OPEN2,
        DOOR_CLOSE1,
        DOOR_CLOSE2,
        DOOR_CLOSE3,
        DOOR_FOLDING_OPEN,
        DOOR_FOLDING_CLOSE,
        WINDOW_OPEN,
        WINDOW_CLOSE,
        DOOR_BELL,
        DOOR_LOCK1,
        DOOR_LOCK2
    }

    public static GamePlayManager Instance { get; set; }
    
    public float backgroundAudioValue;
    public float soundEffectValue;
    AudioSource[] arrAudio;
    
    public int random;

    public int checkKeys = 4;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        arrAudio = GetComponents<AudioSource>();

        arrAudio[0].volume = (float)backgroundAudioValue / 100.0f;
        for(int i = 1; i < arrAudio.Length; i++)
        {
            arrAudio[i].volume = (float)soundEffectValue / 100.0f;
        }
    }

    void Update()
    {
        arrAudio[0].volume = (float)backgroundAudioValue / 100.0f;
    }
    
    
    public void changeBackGroundAudioValue(float _value)
    {
        backgroundAudioValue = _value;
    }

    public void changeSoundEffectValue(float _value)
    {
        soundEffectValue = _value;
    }
    
    public void ToggleOnAudio(AudioType type)
    {
        if (! arrAudio[(int)type].isPlaying)
            arrAudio[(int)type].Play();
    }

    public void ToggleOnAudio(int random)
    {
        if (! arrAudio[random].isPlaying)
            arrAudio[random].Play();
    }

    public void ToggleOffAudio(AudioType type)
    {
        if (arrAudio[(int)type].isPlaying)
            arrAudio[(int)type].Stop();
    }

    public void ToggleOffAudio(int random)
    {
        if (arrAudio[random].isPlaying)
            arrAudio[random].Stop();
    }

}
