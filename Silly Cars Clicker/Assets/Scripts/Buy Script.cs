using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;

public class BuyScript : MonoBehaviour
{
    [SerializeField] private Animator NotEnoughSillines; 
    TextMeshProUGUI CatWorkerTextPrice;
    AudioSource upgradeAudio;
    Animator CatWorkerAnim;
    [SerializeField] private CatSlot[] Slot;

    [Serializable] private class CatSlot
    {
        public int price;
        public int catAmount;

        public void Upgrade()
        {
            ClickingScript.cookies -= price;
            price = 100 + (catAmount * 50);
            catAmount++;
        }


        void passiveEarning()
        {
            ClickingScript.cookies += catAmount;
            ClickingScript.CookiesText.text = ClickingScript.cookies.ToString();
        }
    }

    public void UpgradeCatWorker(int id)
    {
        if (Slot[id].price < ClickingScript.cookies)
        {
            Slot[id].Upgrade();
            CatWorkerTextPrice.text = Slot[id].price.ToString() + " Sillines";
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
}
