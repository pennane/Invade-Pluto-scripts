using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitanController : MonoBehaviour
{
    private Animator animator;
    public readonly int defaultTarget = 8;
    public readonly int easyModeTarget = 3;
    public int target;
    public int count;
    public bool dead;
    public Slider slider;
    public Gradient gradient;
    public Image fill;


    void Start()
    {
        dead = false;
        animator = GetComponent<Animator>();
        if (PlayerPrefs.GetInt("easyMode") == 1)
        {
            target = easyModeTarget;
        }
        else
        {
            target = defaultTarget;
        }

        count = 0;
        slider.value=target-count;
        slider.maxValue=target;
        fill.color = gradient.Evaluate(0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            other.gameObject.SetActive(false);

            count++;
            slider.value=target-count;
            fill.color = gradient.Evaluate(slider.normalizedValue);
            HandleCountChange();
        }
    }

    void HandleCountChange()
    {
        if (count >= target)
        {
            animator.Play("Death");
            dead = true;
            SceneManager.LoadScene("TimothyDead");
        }
    }
}
