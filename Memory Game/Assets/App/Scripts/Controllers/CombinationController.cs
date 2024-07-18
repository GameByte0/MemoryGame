using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _candles;

    [SerializeField] private List<int> _currentCombination;

    [SerializeField] private List<int> _playerInput;

    [Header("CombinationParams")]
    private readonly int _defaultCombnationLength = 3;

    private int _currentCombinationLength;


    // Start is called before the first frame update
    void Start()
    {
        _currentCombinationLength = _defaultCombnationLength;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Button]
    private void GenerateCombination()
    {
        _currentCombination.Clear();
        for (int i = 0; i < _currentCombinationLength; i++)
        {
            _currentCombination.Add(Random.Range(0,_candles.Count));
        }
        _currentCombinationLength++;
    }

    [Button]
    private void ShowCombination()
    {
        StartCoroutine(Show());
    }
    private IEnumerator Show()
    {
        foreach (var item in _currentCombination)
        {
           yield return StartCoroutine( _candles[item].GetComponent<CandleController>().Glow(1f));
           
        }
    }
}
