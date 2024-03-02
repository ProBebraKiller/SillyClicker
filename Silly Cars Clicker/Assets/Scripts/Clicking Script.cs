using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickingScript : MonoBehaviour
{
    public static TextMeshProUGUI CookiesText;
    public static int cookies = 0;
    public static int CookiePerClick = 1;
    static System.Random random = new System.Random();
    [SerializeField] Animator anim;
    [SerializeField] AudioSource CatMeow;
    [SerializeField] ParticleSystem CatParticle;
    public void OnClicking()
    {
        if (!GetSillyScript.IsGetSilly)
        {
            cookies += CookiePerClick;
            anim.SetTrigger("ClickBack");
            anim.SetTrigger("Click");
        }
        else 
        { 
            cookies += CookiePerClick * 9;
            anim.SetTrigger("GetSillyBack");
            anim.SetTrigger("GetSillyClick"+random.Next(1,3));
        }
        CookiesText.text = cookies.ToString();
        CatMeow.Play();
        CatParticle.Play();
    }
    void Start()
    {
        CatParticle = GameObject.Find("CatParticle").GetComponent<ParticleSystem>();
        CatMeow = GameObject.Find("SillyCarButton").GetComponent<AudioSource>();
        anim = GameObject.Find("FirstSillyCat").GetComponent<Animator>();
        CookiesText = GameObject.Find("CookiesAmountText").GetComponent<TextMeshProUGUI>();
    }
}
