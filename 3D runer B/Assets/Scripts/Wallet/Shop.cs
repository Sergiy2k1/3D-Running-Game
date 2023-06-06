using UnityEngine;

public class Shop : MonoBehaviour
{
    public UpgradeController UpgradeController;
    [SerializeField] private EconomicController _economyController;

    public void Buy(UpgradePrototype prototype)
    {
        var level = UpgradeController.GetUpgredeLevel(prototype);
        var levelInfo = prototype.Levels[level];

        if (_economyController.Money < levelInfo.Price)
        {
            return;
        }

        _economyController.Money -= levelInfo.Price;
        UpgradeController.Upgrade(prototype);
        AudioManager.Instance.PlaySFX("Upgrade");
    }
}
