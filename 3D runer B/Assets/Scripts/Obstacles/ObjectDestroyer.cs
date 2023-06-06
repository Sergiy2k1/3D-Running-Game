using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    void Start()
    {
        MultiplierBonus.MultiplierCollisionEvent += CollisionGameObject;
        CoinCollision.CoinDestroyEvent += CollisionGameObject;
        MagnetBonus.MagnetCollisionEvent += CollisionGameObject;
    }

    void OnDestroy()
    {
        CoinCollision.CoinDestroyEvent -= CollisionGameObject;
        MultiplierBonus.MultiplierCollisionEvent -= CollisionGameObject;
        MagnetBonus.MagnetCollisionEvent -= CollisionGameObject;
    }

    void CollisionGameObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
