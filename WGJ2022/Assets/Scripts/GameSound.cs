using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSound : MonoBehaviour
{
    [SerializeField] private AudioClip _clickButton;
    [SerializeField] private AudioClip _gameOverSound;
    [SerializeField] private AudioSource _audioMusic;
    private AudioSource _source;
    void Start()
    {
        _source = GetComponent<AudioSource>();
        if (!StaticSave.musicActive)
        {
            _audioMusic.Stop();
        }
    }

    public void CardsClick()
    {
        if (StaticSave.sfxActive)
        {
            _source.PlayOneShot(_clickButton);
        }
    }

    public void FinalSound()
    {
        if (StaticSave.sfxActive)
        {
            _audioMusic.Pause();
            _source.PlayOneShot(_gameOverSound);
        }
    }

    public void ReturnMusic()
    {
        if (StaticSave.musicActive)
        {
            _audioMusic.Play();
        }
    }

}
