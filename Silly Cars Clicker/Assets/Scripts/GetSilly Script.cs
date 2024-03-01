using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetSillyScript : MonoBehaviour
{
    AudioSource GetSillyMusic;
    Material SillyCatMaterial;
    Material ParticleMaterial;
    public float OneGetSillyTimer = 5.0f;
    public float GetSillyTimer = 5.0f;
    public static bool IsGetSilly = false;
    TextMeshProUGUI TimerText;

    public void activateGetSilly()
    {
        if (!IsGetSilly)
        { 
            IsGetSilly = true;
            print("GetSilly Enabled");
            GetSillyMusic.Play();
            SillyCatMaterial.SetColor("_EmissionColor", Color.yellow);
            ParticleMaterial.SetColor("_EmissionColor", Color.yellow);
        }
        else
        {
            GetSillyTimer += OneGetSillyTimer;
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

    void Start()
    {
        SillyCatMaterial = GameObject.Find("FirstSillyCat").GetComponent<SpriteRenderer>().material;
        ParticleMaterial = GameObject.Find("CatParticle").GetComponent<ParticleSystem>().GetComponent<Renderer>().material;
        GetSillyMusic = GameObject.Find("Button").GetComponent<AudioSource>();
        TimerText = GameObject.Find("GetSillyTimer").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (IsGetSilly)
        {
            if(GetSillyTimer > 0)
            {
                GetSillyTimer -= Time.deltaTime;
                TimerText.text = GetSillyTimer.ToString();
            }
            else
            {
                deactivateGetSilly();
            }
            
        }
    }
}
