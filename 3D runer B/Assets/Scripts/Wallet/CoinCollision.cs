using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    public delegate void CoinDestroyDelegate(GameObject coin);
    public static event CoinDestroyDelegate CoinDestroyEvent;

    public delegate void CoinCollectChangeDelegate(int coin);
    public static CoinCollectChangeDelegate CoinCollectChangeEvent;

    private int _coin = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<EconomicController>(out EconomicController wallet))
        {
            CoinDestroyEvent.Invoke(gameObject);
            CoinCollectChangeEvent.Invoke(_coin);
        }
    }
}
