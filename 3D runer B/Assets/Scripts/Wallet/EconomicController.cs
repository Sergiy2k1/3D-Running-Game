using System;
using UnityEngine;

public class EconomicController : MonoBehaviour
{
    public static EconomicController Instance;

    private int _currentCoin; // Монети зібранні під час ігри.
    private int _totalCoin; // Всі монети

    public event Action<int> CurrentCoinChangedEvent;
    public event Action<int> TotalCoinChangedEvent;

    public int Money
    {
        get { return _totalCoin; }
        set
        {
            _totalCoin = value;
            TotalCoinChangedEvent.Invoke(_totalCoin);
        }
    }

    private void Awake()
    {
        Instance = this;
        _totalCoin = PlayerPrefs.GetInt(GlobalConstant.TOTAL_COINS_KEY);
        TotalCoinChangedEvent.Invoke(_totalCoin);
    }

    private void Start()
    {
        Debug.Log("Total Coins on Start : " + _totalCoin);
        CollisionDetector.OnCollisionDeathEvent += UpdateTotalCois;
        CoinCollision.CoinCollectChangeEvent += PickUpCoin;
    }

    private void OnDisable()
    {
        CoinCollision.CoinCollectChangeEvent -= PickUpCoin;
        CollisionDetector.OnCollisionDeathEvent -= UpdateTotalCois;
    }
    
    public void PickUpCoin(int coin) 
    {
        _currentCoin++;
        AudioManager.Instance.PlaySFX("PickUpCoin");

        Debug.Log("total coin : " + _totalCoin);
        CurrentCoinChangedEvent?.Invoke(_currentCoin);
    }
    public void UpdateTotalCois(GameObject gameObject) 
    {
        _totalCoin += _currentCoin;
        SaveCoinValue();
        Debug.Log("Update TotalCoin: " + _totalCoin);
    }

    private void SaveCoinValue()
    {
        PlayerPrefs.SetInt(GlobalConstant.TOTAL_COINS_KEY, _totalCoin);
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        SaveCoinValue();
    }
}
