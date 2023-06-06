using UnityEngine;

public class StartGroundDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EconomicController>(out EconomicController wallet))
        {
            Destroy(gameObject, 3f);
        }
    }
}
