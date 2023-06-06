using UnityEngine;

public class ObjectMovment : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    private bool _isMoving = false;

    private void Update()
    {
        if (_isMoving)
        {
            Moving();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            _isMoving = true;
        }
    }
    private void Moving()
    {
        transform.Translate(Vector3.forward * -_speed * Time.deltaTime);
    }
}
