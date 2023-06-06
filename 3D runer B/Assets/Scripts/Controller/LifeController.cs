using System.Collections;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    private void Start()
    {
        CollisionDetector.OnCollisionDeathEvent += CollisionObstacle;
    }
    private IEnumerator DeathÂelay()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Death");
    }

    private void CollisionObstacle(GameObject gameObject)
    {
        PlayerController.isplay = false;
        AudioManager.Instance.PlaySFX("Hit");
        StartCoroutine(DeathÂelay());   
    }

    private void OnDisable()
    {
        CollisionDetector.OnCollisionDeathEvent -= CollisionObstacle;
    }
}
