using UnityEngine;
using UnityEngine.UI;

public class VolumeUIController : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider, _sfxSlider;
    [SerializeField] private GameObject offMusic, offSound;

    private int _defoultVolume;

    private bool _isOffMusic;
    private bool _isOffSound;

    private void Awake()
    {
        _defoultVolume = PlayerPrefs.GetInt(GlobalConstant.DEFOULT_VOLUME);
    }

    private void OnEnable()
    {
        if (_defoultVolume == 0)
        {
            PlayerPrefs.SetFloat(GlobalConstant.MUSIC_VOLUME, 1);
            PlayerPrefs.SetFloat(GlobalConstant.SFX_VOLUME, 1);
            PlayerPrefs.SetInt(GlobalConstant.DEFOULT_VOLUME, 1);
        }
        _musicSlider.value = PlayerPrefs.GetFloat(GlobalConstant.MUSIC_VOLUME);
        _sfxSlider.value = PlayerPrefs.GetFloat(GlobalConstant.SFX_VOLUME);
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
        _isOffMusic = !_isOffMusic;

        if (_isOffMusic)
        {
            offMusic.SetActive(true);
        }
        else
        {
            offMusic.SetActive(false);
        }
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
        _isOffSound = !_isOffSound;

        if (_isOffSound)
        {
            offSound.SetActive(true);
        }
        else
        {
            offSound.SetActive(false);
        }
    }


    public void MusicVolume()
    {
        PlayerPrefs.SetFloat(GlobalConstant.MUSIC_VOLUME, _musicSlider.value);
    }

    public void SFXVolume()
    {
        PlayerPrefs.SetFloat(GlobalConstant.SFX_VOLUME, _sfxSlider.value);
    }


    public void SaveMusicVolume()
    {
        AudioManager.Instance.MusicVolume(PlayerPrefs.GetFloat(GlobalConstant.MUSIC_VOLUME));
    }


    public void SaveSFXVolume()
    {
        AudioManager.Instance.SFXVolume(PlayerPrefs.GetFloat(GlobalConstant.SFX_VOLUME));
    }
}