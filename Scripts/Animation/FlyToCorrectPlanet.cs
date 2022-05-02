using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyToCorrectPlanet : MonoBehaviour
{
    public int waitSeconds;
    private string levelId;
    void Start()
    {
         levelId = PlayerPrefs.GetString("levelId");
       

        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(waitSeconds);
        switch (levelId)
        {
            case "mars":
                SceneManager.LoadScene("UranusRocketLand");
                break;
            case "uranus":
                SceneManager.LoadScene("PlutoRocketLand");
                break;
            default:
                SceneManager.LoadScene("MainMenu");
                break;
        }
    }
}
