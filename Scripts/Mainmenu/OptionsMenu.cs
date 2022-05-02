using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject volume;
    private GameObject easyMode;
    private Slider volumeSlider;
    private Toggle easyModeToggle;
    void Start()
    {
        int storedEasyMode = PlayerPrefs.GetInt("easyMode");
        bool easyModeValue;

        if (storedEasyMode == 1)
        {
            easyModeValue = true;
        } else if (storedEasyMode == 0)
        {
            easyModeValue = false;
        } else
        {
            PlayerPrefs.SetFloat("easyMode", 0);
            easyModeValue = false;
        }

        easyMode = FindGameObjectInChildWithTag(gameObject, "EasyModeButton");
        easyModeToggle = easyMode.GetComponent<Toggle>();
        easyModeToggle.isOn = easyModeValue;

        float storedVolume = PlayerPrefs.GetFloat("volume");
        float volumeValue;
        if (float.IsNaN(storedVolume))
        {
            volumeValue = 1f;
        }
        else
        {
            volumeValue = storedVolume;
        }

        volume = FindGameObjectInChildWithTag(gameObject, "VolumeSlider");
        volumeSlider = volume.GetComponent<Slider>();
        volumeSlider.value = volumeValue;

        var go = GameObject.Find("BackgroundMusic");
        var audioSource = go.GetComponent<AudioSource>();
        audioSource.volume = volumeValue;


        volumeSlider.onValueChanged.AddListener(delegate { VolumeValueChangeCheck(); });
    }

    public void EasyModeStateChange()
    {
        bool newValue = easyModeToggle.isOn;
        if (newValue)
        {
            PlayerPrefs.SetInt("easyMode", 1);
        } else
        {
            PlayerPrefs.SetInt("easyMode", 0);
        }
    }

    // Update is called once per frame
    public void VolumeValueChangeCheck()
    {

        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        var go = GameObject.Find("BackgroundMusic");
        var audioSource = go.GetComponent<AudioSource>();
        audioSource.volume = volumeSlider.value;
    }

    public static GameObject FindGameObjectInChildWithTag(GameObject parent, string tag)
    {
        Transform t = parent.transform;

        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).gameObject.tag == tag)
            {
                return t.GetChild(i).gameObject;
            }

        }

        return null;
    }

}
