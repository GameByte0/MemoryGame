using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleController : MonoBehaviour
{
    [SerializeField] private GameObject _fire;
    

    public IEnumerator Glow(float time)
    {
        gameObject.transform.localScale = Vector3.one* 0.5f;
        yield return new WaitForSeconds(time);
        gameObject.transform.localScale = Vector3.one;
        yield return new WaitForSeconds(0.2f);
    }
}
