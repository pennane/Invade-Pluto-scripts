using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalTileListener : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinalTrigger"))
            
        {
            var levelId = PlayerPrefs.GetString("levelId");
            switch (levelId)
            {
                case "mars":
                    SceneManager.LoadScene("MarsRocketLaunch");
                    break;
                case "uranus":
                    SceneManager.LoadScene("UranusRocketLaunch");
                    break;
                default:
                    SceneManager.LoadScene("MainMenu");
                    break;
            }
            
        }
    }
}
