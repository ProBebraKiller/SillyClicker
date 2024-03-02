using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;

public class BuyScript : MonoBehaviour
{
    public static int CatWorkerAmount = 0;
    public static int CatWorkerPrice = 100;
    [SerializeField] private Animator NotEnoughSillines; 
    TextMeshProUGUI CatWorkerTextPrice;
    AudioSource upgradeAudio;
    Animator CatWorkerAnim;

    public void UpgradeCatWorker()
    {
        if (CatWorkerPrice < ClickingScript.cookies)
        {
            ClickingScript.cookies -= CatWorkerPrice;
            CatWorkerAmount++;
            CatWorkerPrice = 100 + (CatWorkerAmount * 50);
            CatWorkerTextPrice.text = CatWorkerPrice.ToString() + " Sillines";
            CatWorkerAnim.SetTrigger("ClickBack");
            CatWorkerAnim.SetTrigger("Click");
            upgradeAudio.Play();
            ClickingScript.CookiesText.text = ClickingScript.cookies.ToString();
        }
        else 
        {
            NotEnoughSillines.Play("NotEnoughAnim");
        }
    }
    
    
    void Start()
    {
        upgradeAudio = GameObject.Find("UpgradeArea").GetComponent<AudioSource>();
        CatWorkerAnim = GameObject.Find("CatWorker").GetComponent<Animator>();
        CatWorkerTextPrice = GameObject.Find("CatWorker").transform.Find("CatPrice").GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
    }
}
