using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitAndAnimateNext : MonoBehaviour
{
    public int waitSeconds;
    public string nextSceneName;
    void Start()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(nextSceneName);
    }
}
