using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartSetting : MonoBehaviour
{
    [SerializeField] private GameObject[] _players;
    [SerializeField] private GameObject[] _playersMoney;

    private void SetPlayersAndMoney()
    {
        _players = new GameObject[7];
        _players[0] = GameObject.Find("Player1");
        _players[0].SetActive(false);
        _players[0] = GameObject.Find("Player2");
        _players[0].SetActive(false);
        _players[0] = GameObject.Find("Player3");
        _players[0].SetActive(false);
        _players[0] = GameObject.Find("Player4");
        _players[0].SetActive(false);
        _players[0] = GameObject.Find("Player5");
        _players[0].SetActive(false);
        _players[0] = GameObject.Find("Player6");
        _players[0].SetActive(false);
        _players[0] = GameObject.Find("Player7");
        _players[0].SetActive(false);
        
        _playersMoney = new GameObject[7];
        _playersMoney[0] = GameObject.Find("P1Money");
        _playersMoney[0].SetActive(false);
        _playersMoney[1] = GameObject.Find("P2Money");
        _playersMoney[1].SetActive(false);
        _playersMoney[2] = GameObject.Find("P3Money");
        _playersMoney[2].SetActive(false);
        _playersMoney[3] = GameObject.Find("P4Money");
        _playersMoney[3].SetActive(false);
        _playersMoney[4] = GameObject.Find("P5Money");
        _playersMoney[4].SetActive(false);
        _playersMoney[5] = GameObject.Find("P6Money");
        _playersMoney[5].SetActive(false);
        _playersMoney[6] = GameObject.Find("P7Money");
        _playersMoney[6].SetActive(false);
    }
    
    void Start()
    {
        SetPlayersAndMoney();    
        
    }
    
    public void InitGame()
    {
        
    }
    
    void Update()
    {
        
    }
}
