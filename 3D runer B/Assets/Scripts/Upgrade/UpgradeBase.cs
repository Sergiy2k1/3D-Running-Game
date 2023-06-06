public class UpgradeBase 
{
    public int Level { get; private set; } = 1;
    public float LevlSliderValue { get; private set; } = 0.17f;
    

    public UpgradePrototype Prototype { get; }


    public UpgradeBase(UpgradePrototype prototype)
    {
        Prototype = prototype;
    }

    public void LevelUp()
    {
        if (Level >= Prototype.MaxLevel)
        {
            return;
        }
        Level++;
        LevlSliderValue += 0.16f;
    }

    public virtual void Apply()
    {

    }
}
