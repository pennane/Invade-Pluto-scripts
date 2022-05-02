using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class JerryCanCounter : MonoBehaviour
{
    public GameObject winTextObject;
    public Slider slider;
    public float count;
    public Gradient gradient;
    public Image fill;

    public readonly int defaultTarget = 10;
    public readonly int easyModeTarget = 3;
    public int target;
    private bool easyMode;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("easyMode") == 1)
        {
            target = easyModeTarget;
            easyMode = true;
        } else
        {
            target = defaultTarget;
            easyMode = false;
        }

        count = 0;
        slider.value = count;
        slider.maxValue=target;

        SetCountText();

        winTextObject.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            count++;
            slider.value = count;
            fill.color = gradient.Evaluate(1f);

            SetCountText();
        }
    }

    void SetCountText()
    {
 
        if (count >= target)
        {
            winTextObject.SetActive(true);
        }
    }
}
