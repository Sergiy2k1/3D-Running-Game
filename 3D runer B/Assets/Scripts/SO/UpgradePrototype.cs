using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "UpgradePrototype", menuName = "Runner/UpgradePrototype")]
public class UpgradePrototype : ScriptableObject
{
    public int MaxLevel => Levels?.Count ?? 0;
    public string Name;
    public string Description;
    public Sprite Sprite;

    public List<UpgradeLevelInfo> Levels;

    [Serializable]
    public class UpgradeLevelInfo
    {
        public int Price;
        public int EffectiveValue;
    }
}


