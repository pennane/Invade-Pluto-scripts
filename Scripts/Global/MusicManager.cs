using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static string sceneName;
    private static string newSceneName;
    private GameObject storedGameObject;
    static MusicManager instance = null;
    void Awake()
    {
        newSceneName = SceneManager.GetActiveScene().name;
        if (string.IsNullOrEmpty(sceneName))
        {
            sceneName = newSceneName;
        }

        if (instance != null && Equals(sceneName, newSceneName) )
        {
            Destroy(gameObject);
        }
        else
        {
            if (instance && instance.storedGameObject)
            {
                Destroy(instance.storedGameObject);
            }

            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            storedGameObject = gameObject;

            AudioClip audioClip = GetComponent<AudioSource>().clip;
            var go = GameObject.Find("BackgroundMusic");
            var audioSource = go.GetComponent<AudioSource>();

            float storedVolume = PlayerPrefs.GetFloat("volume");
            float volume;
            if (float.IsNaN(storedVolume))
            {
                volume = 1f;
            } else
            {
                volume = storedVolume;
            }

            audioSource.clip = audioClip;
            audioSource.volume = volume;
            audioSource.Play();

        }

        sceneName = newSceneName;
    }

}

