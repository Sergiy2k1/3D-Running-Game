using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] Transform  _playerTransform;
    [SerializeField] private float _moveSpeed = 17f;

    private bool isMoveToPlayer = false;

    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Magnet").transform;
    }
    private void Update()
    {
        if(isMoveToPlayer)
        {
            CoinMoveToPlayer();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MagnetDetector>(out MagnetDetector coin))
        {
            isMoveToPlayer = true;
        }
    }

    private void CoinMoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, _playerTransform.position,
            _moveSpeed * Time.deltaTime);
    }
}
