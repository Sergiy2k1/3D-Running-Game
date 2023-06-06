using UnityEngine;

public class MagnetBonus : MonoBehaviour
{
    public delegate void MagnetDestroyDelegate(GameObject gameObject);
    public static event MagnetDestroyDelegate MagnetCollisionEvent;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EconomicController>(out EconomicController wallet))
        {
            MagnetCollisionEvent.Invoke(gameObject);


        }
    }
}
