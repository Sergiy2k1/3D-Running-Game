using System.Collections;
using TMPro;
using UnityEngine;

public class UIHud : MonoBehaviour
{
    [SerializeField] private EconomicController _wallet;
    [SerializeField] private ScoreCounter _scoreCounter;

    [SerializeField] private GameObject _magnetBonus;
    [SerializeField] private GameObject _multiplierBonus;
    [SerializeField] private GameObject _multiplierBar;
    [SerializeField] private GameObject _magnetBar;

    [SerializeField] private TextMeshProUGUI _currentCoinsText;
    [SerializeField] private TextMeshProUGUI _totalCoinsText;

    [SerializeField] private TextMeshProUGUI[] _scoreText = new TextMeshProUGUI[3];
    [SerializeField] private TextMeshProUGUI[] _bestScoreText = new TextMeshProUGUI[3];

    private void Awake()
    {
        _scoreCounter.BestScoreChangedEvent += OnBestScoreChanged;
    }
    private void OnEnable()
    {
        MultiplierController.MultiplierBonusUIEvent += ActiveMultiplierBonus;
        MagnetDetector.MagnetBonusUIEvent += ActiveMagnetBonus;
        _wallet.TotalCoinChangedEvent += OnTotalCoinChanged;
        _wallet.CurrentCoinChangedEvent += OnCurrentCoinChanged;
        _scoreCounter.CurrentScoreChangedEvent += OnCurrentScoreChange;
    }

    private void OnDisable()
    {
        MultiplierController.MultiplierBonusUIEvent -= ActiveMultiplierBonus;
        MagnetDetector.MagnetBonusUIEvent -= ActiveMagnetBonus;
        _wallet.TotalCoinChangedEvent -= OnTotalCoinChanged;
        _wallet.CurrentCoinChangedEvent -= OnCurrentCoinChanged;
        _scoreCounter.CurrentScoreChangedEvent -= OnCurrentScoreChange;
    }

    private void OnBestScoreChanged(int _bestScore)
    {
        for (int i = 0; i <= _scoreText.Length; i++)
        {
            _bestScoreText[i].text = _bestScore.ToString();
        }
    }

    private void OnTotalCoinChanged(int totalCoins)
    {
        _totalCoinsText.text = totalCoins.ToString();
    }

    private void OnCurrentCoinChanged(int currentCoins)
    {
        _currentCoinsText.text = currentCoins.ToString();
    }

    private void OnCurrentScoreChange(float currentScore)
    {
        int _currentPoints = (int)currentScore;
        for(int i = 0; i < _scoreText.Length; i++)
        {
            _scoreText[i].text = _currentPoints.ToString();
        }
    }

    private void ActiveMagnetBonus(int magnetTime)
    {
        StartCoroutine(ActiveMagnetBonusCorutine(magnetTime));       
    }


    private IEnumerator ActiveMagnetBonusCorutine(int _magnetTime)
    {
        _magnetBonus.SetActive(true);
        AnimateMagnetBar(_magnetTime);
        yield return new WaitForSeconds(_magnetTime);
        LeanTween.scaleX(_magnetBar, 1, .1f);
        _magnetBonus.SetActive(false);
    }
    private void ActiveMultiplierBonus(int multiplierTime)
    {
        StartCoroutine(ActiveMultiplierBonusCorutine(multiplierTime));
    }
    private IEnumerator ActiveMultiplierBonusCorutine(int _multiplierTime)
    {
        _multiplierBonus.SetActive(true);
        AnimateMultiplierBar(_multiplierTime);
        yield return new WaitForSeconds(_multiplierTime);
        LeanTween.scaleX(_multiplierBar, 1, .1f);
        _multiplierBonus.SetActive(false);
    }

    private void AnimateMagnetBar(int _time)
    {
        LeanTween.scaleX(_magnetBar, 0, _time);
        
    }
    private void AnimateMultiplierBar(int _time)
    {
        LeanTween.scaleX(_multiplierBar, 0, _time);
        
    }
}
