using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelectionMenuController : MonoBehaviour
{
    [SerializeField] private ModeSelectionMenuView _view;

    private DifficultyLevel _difficultyLevel;

    private void OnEnable()
    {
        UIEvents.OnModeSelectMenuEvent += OnModeSelectMenuEventHandler;
    }
    private void OnDisable()
    {
        UIEvents.OnModeSelectMenuEvent -= OnModeSelectMenuEventHandler;
    }

    private void OnModeSelectMenuEventHandler()
    {
        _view.gameObject.SetActive(true);
    }

    public void ChangeDifficultyLevel(int level)
    {
        _difficultyLevel = (DifficultyLevel)level;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ReturnToMainMenu()
    {
        _view.gameObject.SetActive(false);
        UIEvents.RiseOnMainMenuEvent();
    }
}
