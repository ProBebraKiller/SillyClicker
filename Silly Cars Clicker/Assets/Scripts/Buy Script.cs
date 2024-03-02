using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;

public class BuyScript : MonoBehaviour
{
    [SerializeField] private Animator NotEnoughSillines; 
    AudioSource upgradeAudio;
    [SerializeField] private CatSlot[] Slot;

    [Serializable] private class CatSlot
    {
        public int price;
        public int catAmount;
        public int multiplier = 1;
        public Animator CatWorkerAnim;
        public TextMeshProUGUI CatWorkerTextPrice;

        public void Upgrade()
        {
            ClickingScript.cookies -= price;
            catAmount++;
            price = price + (catAmount * 50);
            CatWorkerTextPrice.text = price.ToString() + " Sillines";
        }

        public void passiveEarning()
        {
            ClickingScript.cookies += catAmount * multiplier;
            ClickingScript.CookiesText.text = ClickingScript.cookies.ToString();
        }
    }

    public void UpgradeCatWorker(int id)
    {
        if (Slot[id].price <= ClickingScript.cookies)
        {
            Slot[id].Upgrade();
            Slot[id].CatWorkerAnim.SetTrigger("ClickBack");
            Slot[id].CatWorkerAnim.SetTrigger("Click");
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
        InvokeRepeating("PassiveEarning", 1f, 1f);
    }

    void PassiveEarning()
    {
        foreach(CatSlot slot in Slot)
        {
            slot.passiveEarning();
        }
    }
}
