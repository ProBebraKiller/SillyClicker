using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickingScript : MonoBehaviour
{
    public static TextMeshProUGUI CookiesText;
    public static int cookies = 0;
    public static int CookiePerClick = 1;
    static System.Random random = new System.Random();
    [SerializeField] Animator anim;
    [SerializeField] AudioSource CatMeow;
    [SerializeField] ParticleSystem CatParticle;
    [SerializeField] private AudioSource GetSillyMusic;
    [SerializeField] private Material SillyCatMaterial;
    [SerializeField] private Material ParticleMaterial;
    public float OneGetSillyTimer = 5.0f;
    public float GetSillyTimer = 5.0f;
    private int multiplier;
    public static bool IsGetSilly = false;
    [SerializeField] private TextMeshProUGUI TimerText;
    public Button button;

    private void Start()
    {
        CookiesText = gameObject.GetComponent<TextMeshProUGUI>();
        button.onClick.AddListener(() => activateGetSilly(9, 10f));
        SillyCatMaterial = GameObject.Find("FirstSillyCat").GetComponent<SpriteRenderer>().material;
        ParticleMaterial = GameObject.Find("CatParticle").GetComponent<ParticleSystem>().GetComponent<Renderer>().material;
    }

    public void OnClicking()
    {
        if (!IsGetSilly)
        {
            cookies += CookiePerClick;
            anim.SetTrigger("ClickBack");
            anim.SetTrigger("Click");
        }
        else 
        { 
            cookies += CookiePerClick * multiplier;
            anim.SetTrigger("GetSillyBack");
            anim.SetTrigger("GetSillyClick"+random.Next(1,3));
        }
        CookiesText.text = cookies.ToString();
        CatMeow.Play();
        CatParticle.Play();
    }

    public void activateGetSilly(int mult, float time)
    {
        if (!IsGetSilly)
        {
            if(mult > multiplier) multiplier = mult;
            GetSillyTimer = time;
            OneGetSillyTimer = time;
            IsGetSilly = true;
            print("GetSilly Enabled");
            GetSillyMusic.Play();
            SillyCatMaterial.SetColor("_EmissionColor", Color.yellow);
            ParticleMaterial.SetColor("_EmissionColor", Color.yellow);
        }
        else
        {
            GetSillyTimer += time;
        }
    }

    public void deactivateGetSilly()
    {
        IsGetSilly = false;
        print("GetSilly Disabled");
        GetSillyMusic.Stop();
        SillyCatMaterial.SetColor("_EmissionColor", Color.black);
        ParticleMaterial.SetColor("_EmissionColor", Color.black);
        GetSillyTimer = OneGetSillyTimer;
    }

    private void Update()
    {
        if (IsGetSilly)
        {
            if (GetSillyTimer > 0)
            {
                GetSillyTimer -= Time.deltaTime;
                TimerText.text = Mathf.RoundToInt(GetSillyTimer).ToString();
            }
            else
            {
                deactivateGetSilly();
            }
        }
    }
}