using UnityEngine;

public class CollisionDetector : MonoBehaviour
{

    public delegate void CollisionDeathDelegate(GameObject obstacle);

    public static  event CollisionDeathDelegate OnCollisionDeathEvent;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            OnCollisionDeathEvent.Invoke(gameObject);
            PlayerController.isplay = false;
        }
    }
}
