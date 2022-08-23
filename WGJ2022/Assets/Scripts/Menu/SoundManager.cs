using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _clickButton;
    [SerializeField] private GameObject _sfx;
    [SerializeField] private GameObject _music;
    [SerializeField] private AudioSource _audioMusic;

    private bool _isSFX = true;
    private bool _isMusic = true;
    private AudioSource _source;
    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayClickButton()
    {
        if (_isSFX)
        {
            _source.PlayOneShot(_clickButton);
        }
    }

    public void ChangeSFXMusic(int i)
    {
        if (i == 0)
        {
            _isSFX = !_isSFX;
            _sfx.SetActive(_isSFX);
            StaticSave.sfxActive = _isSFX;
        }
        else
        {
            _isMusic = !_isMusic;
            _music.SetActive(_isMusic);
            StaticSave.musicActive = _isMusic;
            if (!_isMusic)
            {
                _audioMusic.Stop();
            }
            else
            {
                _audioMusic.Play();
            }
        }
    }
}
