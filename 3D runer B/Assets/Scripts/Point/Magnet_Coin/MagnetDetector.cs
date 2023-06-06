using System.Collections;
using UnityEngine;

public class MagnetDetector : MonoBehaviour
{
    public delegate void MagnetBonusUIDelegate(int magnetTime);
    public static event MagnetBonusUIDelegate MagnetBonusUIEvent;

    [SerializeField] private GameObject _magnetItem;
    private BoxCollider boxCollider;

    public int MagnetTime = 12;

    private void Start()
    {
        _magnetItem.GetComponent<MeshRenderer>().enabled = false;
        MagnetBonus.MagnetCollisionEvent += StartMoveCoinToPlayer;
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnDisable()
    {
        MagnetBonus.MagnetCollisionEvent -= StartMoveCoinToPlayer;
    }

    private void StartMoveCoinToPlayer(GameObject gameObject)
    {
        StartCoroutine(StartMoveCoinToPlayerCorutine());
    }

    private IEnumerator StartMoveCoinToPlayerCorutine ()
    {
        if(PlayerController.isplay)
        {
            _magnetItem.GetComponent<MeshRenderer>().enabled = true;
            boxCollider.enabled = true;
            MagnetBonusUIEvent.Invoke(MagnetTime);
            yield return new WaitForSeconds(MagnetTime);
            boxCollider.enabled = false;
            _magnetItem.GetComponent<MeshRenderer>().enabled = false;
        }
        
    }
}
