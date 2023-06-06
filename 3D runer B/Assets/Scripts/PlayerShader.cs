using UnityEngine;

public class PlayerShader : MonoBehaviour
{
    [SerializeField] private  Transform _playerTaget;

    void Update()
    {

        if (PlayerController.isplay)
        {
            if (_playerTaget.transform.position.y > 6f)
            {
                transform.position = new Vector3(_playerTaget.transform.position.x, 6.45f, _playerTaget.transform.position.z);

            }
            if ((_playerTaget.transform.position.y <= 4f))
            {
                transform.position = new Vector3(_playerTaget.transform.position.x, 1.01f, _playerTaget.transform.position.z);
            }
        }
    }
}
