using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public delegate void PlayerDetectedDelegate(bool playerEnter);

    public static event PlayerDetectedDelegate OnPlayerDetectedEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            OnPlayerDetectedEvent.Invoke(true);
        }
    }
}
