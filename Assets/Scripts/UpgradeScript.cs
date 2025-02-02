using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    bool doubleJump = false;
    bool doubleOwned = false;
    bool slowMo = false;
    bool slowOwned = false;
    bool invincibility = false;
    bool inviOwned = false;
    int doubleJumpPrice = 100;
    int slowMoPrice = 250;
    int invincibilityPrice = 500;

    public int coins = 0;

    public GameObject coinsText;

    public GameObject jumpPriceText;
    public GameObject slowPriceText;
    public GameObject invPriceText;


    public void UpdateText()
    {
        coinsText.GetComponentInChildren<TextMeshProUGUI>().text = coins.ToString();

        if (!doubleOwned)
        {
            jumpPriceText.GetComponentInChildren<TextMeshProUGUI>().text = doubleJumpPrice.ToString() + " coins";
        } else if (!doubleJump)
        {
            jumpPriceText.GetComponentInChildren<TextMeshProUGUI>().text = "disabled";
        } else
        {
            jumpPriceText.GetComponentInChildren<TextMeshProUGUI>().text = "enabled";
        }

        if (!slowOwned)
        {
            slowPriceText.GetComponentInChildren<TextMeshProUGUI>().text = slowMoPrice.ToString() + " coins";
        }
        else if (!slowMo)
        {
            slowPriceText.GetComponentInChildren<TextMeshProUGUI>().text = "disabled";
        } else
        {
            slowPriceText.GetComponentInChildren<TextMeshProUGUI>().text = "enabled";
        }

        if (!inviOwned)
        {
            invPriceText.GetComponentInChildren<TextMeshProUGUI>().text = invincibilityPrice.ToString() + " coins";
        }
        else if (!invincibility)
        {
            invPriceText.GetComponentInChildren<TextMeshProUGUI>().text = "disabled";
        } else
        {
            invPriceText.GetComponentInChildren<TextMeshProUGUI>().text = "enabled";
        }

    }

    public void getData() 
    {
        coins = FindObjectOfType<GameManager>().coins;
        doubleOwned = FindObjectOfType<GameManager>().doubleOwned;
        doubleJump = FindObjectOfType<GameManager>().doubleJump;
        slowOwned = FindObjectOfType<GameManager>().slowOwned;
        slowMo = FindObjectOfType<GameManager>().slowMo;
        inviOwned = FindObjectOfType<GameManager>().inviOwned;
        invincibility = FindObjectOfType<GameManager>().invincibility;
        UpdateText();
    }


    public void buyJump() 
    { 
        if (coins >= doubleJumpPrice && !doubleOwned)
        {
            coins -= doubleJumpPrice;
            doubleOwned = true;
            doubleJump = true;
            FindObjectOfType<GameManager>().doubleOwned = doubleOwned;
            FindObjectOfType<GameManager>().doubleJump = doubleJump;
            FindObjectOfType<GameManager>().coins = coins;
            FindObjectOfType<GameManager>().Save();
            UpdateText();
        }
        if (doubleOwned)
        {
            doubleJump = !doubleJump;
            FindObjectOfType<GameManager>().doubleJump = doubleJump;
            FindObjectOfType<GameManager>().Save();
            UpdateText();
        }
    }

    public void buySlowMo()
    {
        if (coins >= slowMoPrice && !slowOwned)
        {
            coins -= slowMoPrice;
            slowOwned = true;
            slowMo = true;
            FindObjectOfType<GameManager>().slowOwned = slowOwned;
            FindObjectOfType<GameManager>().slowMo = slowMo;
            FindObjectOfType<GameManager>().coins = coins;
            FindObjectOfType<GameManager>().Save();
            UpdateText();
        }
        if (slowOwned)
        {
            slowMo = !slowMo;
            FindObjectOfType<GameManager>().slowMo = slowMo;
            FindObjectOfType<GameManager>().Save();
            UpdateText();
        }
    }

    public void buyInvin()
    {
        if (coins >= invincibilityPrice && !inviOwned && FindObjectOfType<GameManager>().highscore >= 4000)
        {
            coins -= invincibilityPrice;
            inviOwned = true;
            invincibility = true;
            FindObjectOfType<GameManager>().inviOwned = inviOwned;
            FindObjectOfType<GameManager>().invincibility = invincibility;
            FindObjectOfType<GameManager>().coins = coins;
            FindObjectOfType<GameManager>().Save();
            UpdateText();
        }
        if (inviOwned)
        {
            invincibility = !invincibility;
            FindObjectOfType<GameManager>().invincibility = invincibility;
            FindObjectOfType<GameManager>().Save();
            UpdateText();
        }
    }
}
