using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private GameObject[] players;
    [SerializeField] private GameObject[] playersMoney;
    [SerializeField] private GameObject[] chairs;
    [SerializeField] private GameObject[,] cards;
    [SerializeField] private Chair[] chairsData;
    [SerializeField] private Text botOrHumanText; 
    public int currentPlayer;
    private const int ChairsCount = 7;
    
    private void InitFields()
    {
        const int cardsInHand = 2;
        players = new GameObject[ChairsCount];
        playersMoney = new GameObject[ChairsCount];
        chairs = new GameObject[ChairsCount];
        cards = new GameObject[ChairsCount, cardsInHand];
        chairsData = new Chair[ChairsCount];
        for (var i = 0; i < ChairsCount; ++i)
        {
            var playerName = "Player" + i;
            players[i] = GameObject.Find(playerName);
            players[i].SetActive(false);

            var playerMoneyName = "P" + i + "Money";
            playersMoney[i] = GameObject.Find(playerMoneyName);
            playersMoney[i].SetActive(false);

            var chairName = "Chair" + i;
            chairs[i] = GameObject.Find(chairName);

            var cardName = "P" + i + "Card";
            cards[i, 0] = GameObject.Find(cardName + "0");
            cards[i, 0].SetActive(false);
            cards[i, 1] = GameObject.Find(cardName + "1");
            cards[i, 1].SetActive(false);
            
            chairsData[i] = chairs[i].GetComponentInChildren<Chair>();
        }

        currentPlayer = 0;

        botOrHumanText = GameObject.Find("BotOrHuman").GetComponentInChildren<Text>();
    }

    private void Start()
    {
        InitFields();
    }

    public void SelectPlayerTypeButton()
    {
        botOrHumanText.text = (currentPlayer + 1).ToString();
        switch (chairsData[currentPlayer].amIHuman)
        {
            case null:
                chairsData[currentPlayer].amIHuman = true;
                botOrHumanText.text += ": Human";
                break;
            case true:
                chairsData[currentPlayer].amIHuman = false;
                botOrHumanText.text += ": Bot";
                break;
            case false:
                chairsData[currentPlayer].amIHuman = null;
                botOrHumanText.text += ": ?";
                break;
        }
    }

    public void StartButton()
    {
        // Check for minimum count of players
        var activePlayersCount = 0;
        for (var i = 0; i < ChairsCount; ++i)
        {
            if (chairsData[i].amIHuman != null)
                ++activePlayersCount;
        }
        if (activePlayersCount < 2)
            return;
        
        for (var i = 0; i < ChairsCount; ++i)
        {
            chairs[i].SetActive(false);
            if (chairsData[i].amIHuman == null) continue;
            players[i].SetActive(true);
            playersMoney[i].SetActive(true);
            cards[i, 0].SetActive(true);
            cards[i, 1].SetActive(true);
        }
        GameObject.Find("SettingsPanel").SetActive(false);
    }
}
