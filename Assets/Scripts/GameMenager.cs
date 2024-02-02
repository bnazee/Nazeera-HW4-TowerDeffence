using System;
using TMPro;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    public event Action OnGameStart;

    public static GameMenager Instance;

    [SerializeField] private TMP_Text _moneyTxt;

    private float _playerMoney;

    public float PlayerMoney { get => _playerMoney; set => _playerMoney = value; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        StartGame();

        _playerMoney = 20;
        UpdatePlayerMoney();
    }

    private void StartGame()
    {
        OnGameStart?.Invoke();
    }

    public void UpdatePlayerMoney()
    {
        _moneyTxt.text = $"{_playerMoney}$";
    }
}