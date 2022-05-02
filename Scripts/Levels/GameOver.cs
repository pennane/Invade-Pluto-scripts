using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private GameObject canvasObject;
    void Start()
    {
        canvasObject = GameObject.FindWithTag("EndScreen");
        Hide();
    }

    public void Show()
    {
        Time.timeScale = 0;
        canvasObject.SetActive(true);
    }
    public void Hide()
    {
        Time.timeScale = 1;
        canvasObject.SetActive(false);
    }


}
