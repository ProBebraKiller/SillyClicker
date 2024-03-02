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

    [SerializeField] private ClickerCatSlot[] ASlot;

    [Serializable] private class ClickerCatSlot
    {
        public int price;
        public int catAmount;
        public int multiplier = 1;
        public int priceIncrease;
        public Animator CatAnim;
        public TextMeshProUGUI TextPrice;
        

        public Animator CatWorkerAnim;
        public TextMeshProUGUI CatWorkerTextPrice;

        public void Upgrade()
        {
            ClickingScript.cookies -= price;
            catAmount++;
            price = price + (catAmount * priceIncrease);
            ClickingScript.CookiePerClick += multiplier;
        }
    }

    [Serializable] private class CatSlot
    {
        public int price;
        public int catAmount;
        public int multiplier = 1;
        public int priceIncrease;
        public Animator CatAnim;
        public TextMeshProUGUI TextPrice;

        public void Upgrade()
        {
            ClickingScript.cookies -= price;
            catAmount++;
            price = price + (catAmount * priceIncrease);
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
            Slot[id].TextPrice.text = Slot[id].price.ToString() + " Sillines";
            Slot[id].CatAnim.SetTrigger("ClickBack");
            Slot[id].CatAnim.SetTrigger("Click");
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

    public void UpgradeCatClicker(int id)
    {
        if (ASlot[id].price <= ClickingScript.cookies)
        {
            ASlot[id].Upgrade();
            ASlot[id].TextPrice.text = ASlot[id].price.ToString() + " Sillines";
            ASlot[id].CatAnim.SetTrigger("ClickBack");
            ASlot[id].CatAnim.SetTrigger("Click");
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
        CatWorkerTextPrice = GameObject.Find("CatWorker").transform.Find("CatPrice").GetComponent<TextMeshProUGUI>();
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
