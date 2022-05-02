using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("GameStart");
    }

    public void PlayMars()
    {
        SceneManager.LoadScene("MarsRocketLand");
    }

    public void PlayUranus()
    {
        SceneManager.LoadScene("UranusRocketLand");
    }

    public void PlayPluto() 
    {
        SceneManager.LoadScene("PlutoRocketLand");
    }
    
    public void QuitGame()
    {
        Debug.Log("QUIT");
        SceneManager.LoadScene("Quit");
    }
}
