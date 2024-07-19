using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandleController : MonoBehaviour
{
    [SerializeField] private GameObject _fire;

    private void OnEnable()
    {
        GameEvents.OnBlackOutStartedEvent += OnBlackOutStartedEventHandler;
    }
    private void OnDisable()
    {
        GameEvents.OnBlackOutStartedEvent -= OnBlackOutStartedEventHandler;
    }
    public IEnumerator Glow(float time)
    {
        _fire.SetActive(true);
        yield return new WaitForSeconds(time);
        _fire.SetActive(false);
        yield return new WaitForSeconds(0.2f);
    }
    private void OnBlackOutStartedEventHandler()
    {
        gameObject.GetComponent<Image>().DOFade(0, 2f);
    }
}
