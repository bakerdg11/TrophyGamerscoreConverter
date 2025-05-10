using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    public SoundManager soundManager;

    public Button beginButton;
    public Button calculateGamerscore;
    public Button resetButton;
    public Button exitButton;

    public GameObject trophyInputPanel;
    public TMP_InputField bronzeInput;
    public TMP_InputField silverInput;
    public TMP_InputField goldInput;

    public TMP_Text errorText;
    public TMP_Text yourGamerscoreIsText;
    public TMP_Text gamerscoreText;


    // Start is called before the first frame update
    void Start()
    {
        trophyInputPanel.SetActive(false);
        SetupButtonListeners();
    }



    private void SetupButtonListeners()
    {
        beginButton.onClick.AddListener(() =>
        {
            Advertisement.Banner.Hide();
            FindObjectOfType<InterstitialAds>().ShowAd();
            OpenTrophyPanel();
            soundManager.PlayBeginSound();
        });

        calculateGamerscore.onClick.AddListener(() =>
        {
            CalculateGamerscore();
        });

        resetButton.onClick.AddListener(() =>
        {
            ResetNumbers();
        });

        exitButton.onClick.AddListener(() =>
        {
            ExitGame();
        });
    }



    public void OpenTrophyPanel()
    {
        trophyInputPanel.SetActive(true);
    }



    public void CalculateGamerscore()
    {
        if (!string.IsNullOrEmpty(gamerscoreText.text))
        {
            return;
        }

        // Handles when a field is empty/blanc
        if (string.IsNullOrWhiteSpace(bronzeInput.text) ||
            string.IsNullOrWhiteSpace(silverInput.text) ||
            string.IsNullOrWhiteSpace(goldInput.text))
        {
            errorText.gameObject.SetActive(true);
            return;
        }
        else
        {
            soundManager.PlayCalculateSound();
            yourGamerscoreIsText.gameObject.SetActive(true);
            errorText.gameObject.SetActive(false);
        }

        int bronze = int.Parse(bronzeInput.text);
        int silver = int.Parse(silverInput.text);
        int gold = int.Parse(goldInput.text);

        int gamerscore = (bronze * 15) + (silver * 30) + (gold * 75);

        gamerscoreText.text = gamerscore.ToString();
    }



    public void ResetNumbers()
    {
        if (string.IsNullOrWhiteSpace(bronzeInput.text) &&
            string.IsNullOrWhiteSpace(silverInput.text) &&
            string.IsNullOrWhiteSpace(goldInput.text))
        {
            errorText.gameObject.SetActive(false);
        }
        else
        {
            soundManager.PlayResetSound();

            bronzeInput.text = "";
            silverInput.text = "";
            goldInput.text = "";

            errorText.gameObject.SetActive(false);
            yourGamerscoreIsText.gameObject.SetActive(false);
            gamerscoreText.text = "";

            if (Random.value < 0.5)
            {
                FindObjectOfType<InterstitialAds>().ShowAd();
            }
        }
    }



    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit button pressed");
    }


}
