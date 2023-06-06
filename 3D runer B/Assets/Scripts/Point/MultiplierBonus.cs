using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MultiplierBonus : MonoBehaviour
{
    public delegate void MultiplierDestroyDelegate(GameObject gameObject);
    public static event MultiplierDestroyDelegate MultiplierCollisionEvent;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EconomicController>(out EconomicController wallet))
        {
            MultiplierCollisionEvent.Invoke(gameObject);
        }
    }

}
