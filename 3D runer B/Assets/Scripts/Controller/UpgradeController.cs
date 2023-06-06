using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    private List<UpgradeBase> _appliedUpgrades = new List<UpgradeBase>();

    public void Upgrade(UpgradePrototype prototype)
    {
        var upgrade = _appliedUpgrades.FirstOrDefault(x => x.Prototype == prototype);
        if (upgrade == null)
        {
            upgrade = GetUpgradePrototype(prototype);
            _appliedUpgrades.Add(upgrade);
        }
        else
        {
            upgrade.LevelUp();

        }
        upgrade.Apply();

        Debug.Log(upgrade.Level);
    }

    public int GetUpgredeLevel(UpgradePrototype prototype)
    {

        var upgrade = _appliedUpgrades.FirstOrDefault(x => x.Prototype == prototype);

        return upgrade?.Level ?? 0;
    }

    private UpgradeBase GetUpgradePrototype(UpgradePrototype prototype)
    {
        switch (prototype.name)
        {
            case "MagnetUpgrade":
                return new MagnetUpgrade(prototype);
            case "MultiplierUpgrade":
                return new MultiplierUpgrade(prototype);
            case "ScoreMultiplier":
                return new ScoreMultiplierUpgrade(prototype);
        }
        Debug.LogError("Unknow upgrade prototype");
        return null;
    }
}
