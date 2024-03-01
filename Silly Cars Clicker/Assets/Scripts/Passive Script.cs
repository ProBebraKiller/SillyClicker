using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveScript : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("passiveEarning", 1f, 1f);
    }

    void passiveEarning()
    {
        ClickingScript.cookies += BuyScript.CatWorkerAmount;


        ClickingScript.CookiesText.text = ClickingScript.cookies.ToString();
    }

    void Update()
    {

    }
}
