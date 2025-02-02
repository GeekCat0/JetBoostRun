using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData 
{
    public int coins = 0;
    public int highscore = 0;

    public bool doubleJump = false;
    public bool doubleOwned = false;
    public bool invincibility = false;
    public bool inviOwned = false;
    public bool slowMo = false;
    public bool slowOwned = false;

    public float MusicVolume = 0;
    public float effectsVolume = 0;
    public float sensitivity = 50;

    public string username;

    public PlayerData(GameManager gameManager)
    {
        coins = gameManager.coins;
        highscore = gameManager.highscore;
        sensitivity = gameManager.sensitivity;
        doubleJump = gameManager.doubleJump;
        invincibility = gameManager.invincibility;
        slowMo = gameManager.slowMo;
        doubleOwned = gameManager.doubleOwned;
        inviOwned = gameManager.inviOwned;
        slowOwned = gameManager.slowOwned;
        MusicVolume = gameManager.MusicVolume;
        effectsVolume = gameManager.effectsVolume;
        username = gameManager.username;
}

}
