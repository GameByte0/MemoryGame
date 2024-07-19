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

    private float _timeBetweenElements;

    private int _currentCombinationIndex;


    private int _gameModeIndex;
    private void OnEnable()
    {
        RegisterButtonEvents();
    }
    private void OnDisable()
    {
        ClearListenersOfButton();
    }
    private void Awake()
    {
        ApplyGameModeSettings();
    }
    void Start()
    {
        _currentCombinationLength = _defaultCombnationLength;
        GenerateCombination();
    }

    private void RegisterButtonEvents()//registering to every button an event which help to recive pressed candle's index;
    {
        for (int i = 0; i <= _candles.Count-1; i++)
        {
            int index = i;
            _candles[i].GetComponent<Button>().onClick.AddListener(delegate { ReciveInput(index); });
            
        }
    }
    private void ClearListenersOfButton()
    {
        foreach (GameObject candle in _candles)
        {
            
            candle.GetComponent<Button>().onClick.RemoveAllListeners(); 

        }
    }
    private void ReciveInput(int index)
    {
        //add click anim
        _playerInput.Add(index);
        ClickCandle(index);
        CheckPlayerInput(_playerInput.Count-1);
    }

    [Button]
    private void GenerateCombination()// Random Generation of Combination;
    {
        _playerInput.Clear();
        _currentCombination.Clear();
        for (int i = 0; i < _currentCombinationLength; i++)
        {
            _currentCombination.Add(Random.Range(0,_candles.Count));
        }
        _currentCombinationLength++;
        ShowCombination();
    }

    [Button]
    private void ShowCombination()
    {
        ButtonInteraction(false);
        StartCoroutine(Show());
    }
    private IEnumerator Show()
    {
        if (_gameModeIndex.Equals(1))
        {
        StartCoroutine(StartBlackOut());

        }

        yield return new WaitForSeconds(0.5f);
        foreach (var item in _currentCombination)
        {
           yield return StartCoroutine( _candles[item].GetComponentInChildren<CandleController>().Glow(_timeBetweenElements));
           
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

    private void CheckPlayerInput(int index)
    {
        if (index < 0)
        {
            Debug.Log("Unexpected Error");
            return;
        }
        if (!_playerInput[index].Equals(_currentCombination[index]))
        {
            Debug.Log("WRONG");
            UIEvents.RiseOnGameOverEvent();
            //activate game over panel;
        }
        else
        {
            if (_playerInput.Count.Equals(_currentCombination.Count))
            {
                //cleaning input for new batch and re-starting combination;
                GenerateCombination();
            }
            
        }

    }
    private void ApplyGameModeSettings() 
    {
        switch ((DifficultyLevel)GameManager.Instance.DifficultyLevel)
        {
            case DifficultyLevel.EASY:
                _timeBetweenElements = 1.5f;
                break;

            case DifficultyLevel.NORMAL:
                _timeBetweenElements = 1f;
             break;

            case DifficultyLevel.HARD:
                _timeBetweenElements = 0.5f;
            break;

            default:
                _timeBetweenElements = 1f;
                break;
        }

        Debug.Log((DifficultyLevel)GameManager.Instance.DifficultyLevel);
        switch ((GameMode)GameManager.Instance.GameMode)
        {
            case GameMode.CLASSIC:
                _gameModeIndex = 0;
                break;

            case GameMode.BLACKOUT:
                //start blackout
                _gameModeIndex = 1;
                break;

            default:
                _gameModeIndex = 0;
                break;
        }
        Debug.Log((GameMode)GameManager.Instance.GameMode);
    }

    private void ClickCandle(int index)
    {
        StartCoroutine(_candles[index].GetComponentInChildren<CandleController>().Glow(_timeBetweenElements/2));
    }
    private IEnumerator StartBlackOut()
    {
        GameEvents.RiseOnBlackOutStartedEvent();
        yield return new WaitForEndOfFrame();

    }
}
