using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    // Minimum and maximum volume in decibels
    private float minVolumeDb = -80f;
    private float maxVolumeDb = 1f;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            // Initialize volume to max
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        // Map the slider's value from [0, 1] to the desired range [-80, 1] in decibels
        float volumeDb = Mathf.Lerp(minVolumeDb, maxVolumeDb, volumeSlider.value);

        // Convert the volume from decibels to linear scale (0 to 1)
        float volumeLinear = Mathf.Pow(10, volumeDb / 20f);

        // Set the AudioListener volume
        AudioListener.volume = volumeLinear;

        // Save the volume setting
        Save();
    }

    private void Load()
    {
        float volumeDb = PlayerPrefs.GetFloat("musicVolume");

        // Map the loaded volume from [-80, 1] to [0, 1] for the slider
        float normalizedVolume = Mathf.InverseLerp(minVolumeDb, maxVolumeDb, volumeDb);
        volumeSlider.value = normalizedVolume;
    }

    private void Save()
    {
        // Get the current volume in linear scale (0 to 1)
        float volumeLinear = AudioListener.volume;

        // Convert the volume to decibels
        float volumeDb = 20f * Mathf.Log10(volumeLinear);

        // Save the volume setting
        PlayerPrefs.SetFloat("musicVolume", volumeDb);
    }
}
