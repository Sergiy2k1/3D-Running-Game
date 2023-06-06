using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private GameObject _buttonBuy;
    [SerializeField] private UpgradePrototype _prototype;
    [SerializeField] private Shop _shop;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private TextMeshProUGUI[] _levelText;
    [SerializeField] private Image _image;

    public void UpdateLevelInfo()
    {
        var level = _shop.UpgradeController.GetUpgredeLevel(_prototype);
        var levelinfo = _prototype.Levels[level];

        if (level + 1 >= _prototype.Levels.Count)
        {
            _buttonBuy.SetActive(false);
            Destroy(_priceText);
            Debug.Log("max");
        }
        if(_levelText != null) 
        {
            for (int i = 0; i < _levelText.Length; i++)
            {
                _levelText[i].text =  $"{level + 1}";
            }  
        }
        
        _priceText.text = levelinfo.Price.ToString();
    }

    private void Start()
    {
        _nameText.text = _prototype.Name;
        _image.sprite = _prototype.Sprite;
    }
    private void Update()
    {
        UpdateLevelInfo();
    }

    private void OnEnable()
    {
        UpdateLevelInfo();
    }
}
