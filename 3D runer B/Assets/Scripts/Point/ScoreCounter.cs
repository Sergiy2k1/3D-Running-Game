using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public event Action<float> CurrentScoreChangedEvent;
    public event Action<int> BestScoreChangedEvent;

    public int ScorePerSecond = 1;

    private float _currentScore = 0;
    private int _bestScore;

    private void Awake()
    {
        LoadBestScore();
        CollisionDetector.OnCollisionDeathEvent += UpdateBestScore;
        Debug.Log("BestScore1 : " + _bestScore);
    }
    private void Start()
    {
        CollisionDetector.OnCollisionDeathEvent += UpdateBestScore;
    }

    private void Update()
    {
        if(PlayerController.isplay)
        {
            PointCount();
        }
    }

    private void OnDisable()
    {
        CollisionDetector.OnCollisionDeathEvent -= UpdateBestScore;
    }

    private void UpdateBestScore(GameObject gameObject)
    {
        if (_currentScore > _bestScore)
        {
            _bestScore = (int)_currentScore;
            BestScoreChangedEvent?.Invoke(_bestScore);
            SaveBestScore();
        }
    }

    private void LoadBestScore()
    {
        _bestScore = PlayerPrefs.GetInt(GlobalConstant.BEST_SCORE);
        BestScoreChangedEvent?.Invoke(_bestScore);
    }

    private void SaveBestScore()
    {
        PlayerPrefs.SetInt(GlobalConstant.BEST_SCORE, _bestScore);
        PlayerPrefs.Save();
    }

    public void PointCount()
    {
        
        _currentScore += ScorePerSecond * Time.timeScale;
        CurrentScoreChangedEvent?.Invoke(_currentScore);
    }

}
