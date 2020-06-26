using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour
{
    public Animator animator;

    public static SceneFade instance;

    void Awake()
    {
        instance = this;
    }

    public void Fade()
    {
        animator.Play("Fade_In");
    }

    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }
}
