using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TransitionScript : MonoBehaviour
{
    [SerializeField] bool MovingToUpgrades = false;
    [SerializeField] bool MovingToMain = false;
    [SerializeField] float speed = 0.3f;
    [SerializeField] GameObject Areas;
    public Vector3 velocity = Vector3.zero;
    public void MoveToUpgrade()
    {
        if(MovingToMain!=true) MovingToUpgrades = true;
    }
    public void MoveToMain()
    {
        if(MovingToUpgrades!=true) MovingToMain = true;
    } 
    void Start()
    {
        Areas = GameObject.Find("Areas");
    }

    void Update()
    {
        if (MovingToUpgrades)
        {
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, new Vector3(1141, 0, 0), ref velocity, speed);
            if (transform.localPosition.x > 1140.5f)
            {
                MovingToUpgrades = false;
            }
        }
        if(MovingToMain)
        {
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, new Vector3(0, 0, 0), ref velocity, speed);
            if (transform.localPosition.x < 0.5f)
            {
                MovingToMain = false;
            }
        }   
    }
}