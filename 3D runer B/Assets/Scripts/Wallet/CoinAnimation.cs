using System.Collections;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    private bool rotayCoin;
    private void Start()
    {
        rotayCoin = false;
        StartCoroutine(timer());
    }
    private void Update()
    {
        if (rotayCoin)
        {
            transform.Rotate(new Vector3(0, 150 * Time.deltaTime, 0));
        }
    }
    IEnumerator timer()
    {
        float ran = Random.Range(0, 1f);
        yield return new WaitForSeconds(ran);
        rotayCoin = true;
    }
}
