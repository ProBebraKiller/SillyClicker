using TMPro;
using UnityEngine;

public class TransitionScript : MonoBehaviour
{
    [SerializeField] bool MovingToMain, MovingToUpgrades, MovingToUpgrades2;
    [SerializeField] float speed = 0.3f;
    [SerializeField] GameObject Areas, notEnoughSillyText;
    [SerializeField] TextMeshProUGUI notEnoughSillyAnimator;
    public Vector3 velocity = Vector3.zero;
    public void MoveToUpgrade()
    {
        if(MovingToMain!=true && MovingToUpgrades2!=true) MovingToUpgrades = true;
    }
    public void MoveToMain()
    {
        if(MovingToUpgrades!=true && MovingToUpgrades2!=true) MovingToMain = true;
    }
    public void MoveToUpgrade2()
    {
        if (MovingToUpgrades!=true && MovingToMain!=true) MovingToUpgrades2 = true;
    }

    void Update()
    {
        //Moving to Upgrades
        if (MovingToUpgrades)
        {
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, new Vector3(1135, 0, 0), ref velocity, speed);
            if (transform.localPosition.x > 1134.5f)
            {
                MovingToUpgrades = false;
                transform.localPosition = new Vector2(1135f, 0f);
            }
        }

        //Moving to main
        if(MovingToMain && transform.localPosition.x > 0f)
        {
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, new Vector3(0, 0, 0), ref velocity, speed);
            if (transform.localPosition.x < 0.5f)
            {
                MovingToMain = false;
                transform.localPosition = new Vector2(0f, 0f);
            }
        }
        if (MovingToMain && transform.localPosition.x < 0f)
        {
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, new Vector3(0, 0, 0), ref velocity, speed);
            if (transform.localPosition.x > -0.5f)
            {
                MovingToMain = false;
                transform.localPosition = new Vector2(0f, 0f);
            }
        }

        //Moving to upgrades 2
        if (MovingToUpgrades2)
        {
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, new Vector3(-1135, 0, 0), ref velocity, speed);
            if (transform.localPosition.x < -1134.5f)
            {
                MovingToUpgrades2 = false;
                transform.localPosition = new Vector2(-1135f, 0f);
            }
        }
    }
}