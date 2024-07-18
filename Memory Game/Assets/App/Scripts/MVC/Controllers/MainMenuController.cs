using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private MainMenuView _view ;

    private void OnEnable()
    {
        //onMainMenuEvent
        UIEvents.OnMainMenuEvent += OnMainMenuEventHandler;
    }
    private void OnDisable()
    {
        UIEvents.OnMainMenuEvent -= OnMainMenuEventHandler;
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

    public void StartGame()
    {
        UIEvents.RiseOnModeSelectMenuEvent();
        _view.gameObject.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenSettingMenu()
    {
        //rise settingmenu event;
    }

    private void OnMainMenuEventHandler()
    {
        _view.gameObject.SetActive(true);
    }
}
