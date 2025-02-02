using LeaderboardCreatorDemo;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameRunning = true;
    public float gameSpeed = 10f;
    public int score = 0;
    public int highscore = 0;
    public int coins = 0;
    public string username;
    public TMP_InputField nameText;

    public bool doubleJump;
    public bool doubleOwned;

    public bool invincibility;
    public bool inviOwned;

    public bool slowMo;
    public bool slowOwned;

    public float sensitivity = 50;

    public bool fogMove = true;

    public GameObject gameOverScreen;
    public GameObject newHighScoreText;

    public float MusicVolume = 0;
    public float effectsVolume = 0;

    public AudioMixer audioMixer;

    public Board leaderboard;

    public void Start()
    {
        load();
        if (gameOverScreen != null && newHighScoreText != null)
        {
            gameOverScreen.SetActive(false);
            newHighScoreText.SetActive(false);
        }
        Time.timeScale = 1f;
        setMusic(MusicVolume);
        setEffects(effectsVolume);

        if (invincibility)
        { 
            score = 4000;
            gameSpeed = 46f;
        }
        nameText.text = username;
        Debug.LogError(username);
        leaderboard.UploadEntry(username);
    }

    public void Save() 
    {
        SaveSystem.SaveFiles(this);
    }

    public void load() 
    {
        if (SaveSystem.LoadPlayer() != null)
        {
            PlayerData data = SaveSystem.LoadPlayer();
            highscore = data.highscore;
            coins = data.coins;
            sensitivity = data.sensitivity;
            doubleOwned = data.doubleOwned;
            doubleJump = data.doubleJump;
            slowMo = data.slowMo;
            slowOwned = data.slowOwned;
            invincibility = data.invincibility;
            inviOwned = data.inviOwned;
            effectsVolume = data.effectsVolume;
            MusicVolume = data.MusicVolume;
            username = data.username;
        }
        else
        {
            sensitivity = 50;
        }
    }


    public void EndGame()
    {
        if (gameRunning)
        {
            gameRunning = false;
            if (score > highscore) 
            {
                highscore = score;
                newHighScoreText.SetActive(true);
            }
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
            Save();
        }
    }

    public void AddCoins(int points)
    {
        coins += points;
        score += 100;
    }

    private void Update()
    {
        if (RenderSettings.fogEndDistance < 250 && fogMove)
        {
            RenderSettings.fogEndDistance += 15 * Time.deltaTime;
        }

        if (gameRunning && SceneManager.GetActiveScene().buildIndex == 1)
        {
            gameSpeed += 0.2f * Time.deltaTime;
        }
        
        if (!gameRunning && SceneManager.GetActiveScene().buildIndex == 1 && Input.GetButtonDown("Fire1")) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        audioMixer.SetFloat("MusicPitch", Time.timeScale);
        audioMixer.SetFloat("EffectsPitch", Time.timeScale);

    }

    private void FixedUpdate()
    {
        if (gameRunning && SceneManager.GetActiveScene().buildIndex == 1) 
        { 
            score++;
        }
    }

    public void setSensitivity(float sens)
    {
        sensitivity = sens;
    }
    public void setMusic(float volume)
    { 
        MusicVolume = volume;
        audioMixer.SetFloat("MusicVolume", volume);
    }
    public void setEffects(float volume)
    { 
        effectsVolume = volume;
        audioMixer.SetFloat("EffectsVolume", volume);
    }
    public void setName(string Name)
    {
        username = Name;
    }

}
