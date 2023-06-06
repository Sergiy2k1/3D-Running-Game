using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetUpgrade : UpgradeBase
{
    public MagnetUpgrade(UpgradePrototype prototype) : base(prototype)
    {

    }

    public override void Apply()
    {
        base.Apply();
        //.Instance.PlaySFX("Upgrade");
        GameObject.FindObjectOfType<MagnetDetector>().MagnetTime = Prototype.Levels[Level].EffectiveValue;
        GameObject.FindObjectOfType<UIManager>().MagnetLevelSlider.value = LevlSliderValue;
    }
}
