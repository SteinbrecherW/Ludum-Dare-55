using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeInBehavior : MonoBehaviour
{
    public static FadeInBehavior Instance;

    Animator _anim;
    [SerializeField] Animator _titleTextAnim;

    IEnumerator SplashScr;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    void Start()
    {
        _anim = GetComponent<Animator>();

        SplashScr = SplashScreen();
        StartCoroutine(SplashScr);
    }

    public void FadeIn()
    {
        _anim.Play("Base Layer.MakeVisible", 0, 0);
    }

    public void FadeOut()
    {
        _anim.Play("Base Layer.MakeDisappear", 0, 0);
    }

    IEnumerator SplashScreen()
    {
        _titleTextAnim.Play("Base Layer.MakeVisible", 0, 0);
        yield return new WaitForSeconds(1);
        _titleTextAnim.Play("Base Layer.MakeDisappear", 0, 0);

        FadeOut();
    }
}
