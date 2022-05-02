using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool paused;
    private GameObject canvasObject;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        canvasObject = GameObject.FindWithTag("PauseCanvas");
        canvasObject.SetActive(false);
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (paused)
            {
                Unpause();
            } else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0;
        canvasObject.SetActive(true);
        paused = true;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        canvasObject.SetActive(false);
        paused = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
