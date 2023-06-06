using UnityEngine;

public class ScoreMultiplierUpgrade : UpgradeBase
{
    public ScoreMultiplierUpgrade(UpgradePrototype prototype) : base(prototype)
    {

    }

    public override void Apply()
    {
        base.Apply();
        //.Instance.PlaySFX("Upgrade");
        GameObject.FindObjectOfType<MultiplierController>().CurrentScorePerSecond = Prototype.Levels[Level].EffectiveValue;
    }
}
