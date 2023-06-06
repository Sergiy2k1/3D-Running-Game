using UnityEngine;

public class MultiplierUpgrade : UpgradeBase
{
    public MultiplierUpgrade(UpgradePrototype prototype) : base(prototype)
    {

    }

    public override void Apply()
    {
        base.Apply();
        GameObject.FindObjectOfType<MultiplierController>().MultiplierTime = Prototype.Levels[Level].EffectiveValue;
        GameObject.FindObjectOfType<UIManager>().MultiplierLevelSlider.value = LevlSliderValue;

    }

}
