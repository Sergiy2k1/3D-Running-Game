using System.Collections;
using UnityEngine;

public class MultiplierController : MonoBehaviour
{
    public delegate void MultiplierBonusUIDelegate(int multiplierTime);
    public static event MultiplierBonusUIDelegate MultiplierBonusUIEvent;
    
    public ScoreCounter ScoreCounter;

    public int MultiplierTime = 12;
    public int CurrentScorePerSecond = 1;

    private int BonuScorePerSecond => CurrentScorePerSecond * 2;

    private void Start()
    {
        MultiplierBonus.MultiplierCollisionEvent += ActiveMultiplierBonus;
    }

    private void OnDisable()
    {
        MultiplierBonus.MultiplierCollisionEvent -= ActiveMultiplierBonus;
    }
    private void ActiveMultiplierBonus(GameObject gameObject)
    {
        StartCoroutine(MultiplierBonusCorutine());
    }


    private IEnumerator MultiplierBonusCorutine()
    {
        MultiplierBonusUIEvent.Invoke(MultiplierTime);
        ScoreCounter.ScorePerSecond = BonuScorePerSecond;
        yield return new WaitForSeconds(MultiplierTime);
        ScoreCounter.ScorePerSecond = CurrentScorePerSecond;
    }
}
