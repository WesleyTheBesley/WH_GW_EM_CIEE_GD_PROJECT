using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class AudioSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public TMP_Text volumeLabel;

    void Start()
    {
        float volume = PlayerPrefs.GetFloat("Volume", 0.75f);
        volumeSlider.value = volume;
        SetVolume(volume);
    }

    public void SetVolume(float volume)
    {
        if (volume <= 1f)
        {
            audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
            volumeLabel.text = "Volume";
        }
        else
        {
            audioMixer.SetFloat("MasterVolume", (volume - 1f) * 50f);
            volumeLabel.text = "Volume (This is a bad idea.)";
        }

        PlayerPrefs.SetFloat("Volume", volume);
    }
}