using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIdUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    public string levelId;
    void Start()
    {
        PlayerPrefs.SetString("levelId", levelId);
    }
}
