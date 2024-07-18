using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombinationController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _candles;

    [SerializeField] private List<int> _currentCombination;

    [SerializeField] private List<int> _playerInput;

    [Header("CombinationParams")]
    private readonly int _defaultCombnationLength = 3;

    private int _currentCombinationLength;

    private void OnEnable()
    {
        RegisterButtonEvents();
    }
    private void OnDisable()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        _currentCombinationLength = _defaultCombnationLength;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void RegisterButtonEvents()//registering to every button an event which help to recive pressed candle's index;
    {
        for (int i = 0; i <= _candles.Count-1; i++)
        {
            Debug.Log(i);
            int index = i;
            _candles[i].GetComponent<Button>().onClick.AddListener(delegate { ReciveInput(index); });
            
        }
    }
    private void ReciveInput(int index)
    {
        Debug.Log("Hello");
        _playerInput.Add(index);
        CheckPlayerInput();
    }

    [Button]
    private void GenerateCombination()// Random Generation of Combination;
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
        ButtonInteraction(false);
        StartCoroutine(Show());
    }
    private IEnumerator Show()
    {
        foreach (var item in _currentCombination)
        {
           yield return StartCoroutine( _candles[item].GetComponent<CandleController>().Glow(1f));
           
        }
        ButtonInteraction(true);    
    }
    private void ButtonInteraction(bool canInteract)// On/off button interaction
    {
        foreach (GameObject candle in _candles)
        {
            candle.GetComponent<Button>().interactable = canInteract;
        }
    }

    private void CheckPlayerInput()
    {
        for (int i = 0; i <= _playerInput.Count-1; i++)
        {
            if (!_currentCombination[i].Equals(_playerInput[i]))
            {
                Debug.Log("False");
                break;
            }
        }
    }
}
