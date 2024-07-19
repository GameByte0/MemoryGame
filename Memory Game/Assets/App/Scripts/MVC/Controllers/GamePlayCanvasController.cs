using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class GamePlayCanvasController : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _pauseMenuPanel;
    [SerializeField] private GameObject _blackOutPanel;
    [SerializeField] private TMPro.TMP_Text _timer;
    private bool _isPaused;
    private float _passedTime=0;


    private void OnEnable()
    {
        UIEvents.OnGameOverEvent += OnGameOverEventHandler;
        GameEvents.OnBlackOutStartedEvent += OnBlackOutStartedEventHandler;
    }
    private void OnDisable()
    {
        UIEvents.OnGameOverEvent -= OnGameOverEventHandler;
        GameEvents.OnBlackOutStartedEvent -= OnBlackOutStartedEventHandler;
    }
    private void Update()
    {
        StartTimer();
    }
    private void StartTimer()
    {
        _passedTime += Time.deltaTime;
        _timer.text = _passedTime.ToString("F1");
    }

    public void PauseGame()
    {
        if (_isPaused)
        {
            _isPaused = false;
            Time.timeScale = 1;
            _pauseMenuPanel.SetActive(false);
        }
        else
        {_pauseMenuPanel.SetActive(true);
            _isPaused = true;
            Time.timeScale = 0;
        }
    }
    public void ExitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    private void OnGameOverEventHandler()
    {
        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);
    }
    private void OnBlackOutStartedEventHandler()
    {
        _blackOutPanel.SetActive(true);
        _blackOutPanel.GetComponent<Image>().DOFade(1,2f); 
    }
}
