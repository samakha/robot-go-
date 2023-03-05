using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    private int coin;

    [SerializeField] Text txtCoin;
 //   public Player player; 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void AddCoin(int value)
    {
        coin += value;
        SaveCoin();
        LoadCoin();

     //   player.playerColor.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    private void Start()
    {
        LoadCoin();
    }

    void LoadCoin()
    {
        coin = PlayerPrefs.GetInt("coin");
        txtCoin.text = coin.ToString();
    }

    void SaveCoin()
    {
        PlayerPrefs.SetInt("coin", coin);
    }
}
