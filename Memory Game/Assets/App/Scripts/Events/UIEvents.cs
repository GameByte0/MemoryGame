using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIEvents
{
    public delegate void OnMenu();
    public static event OnMenu OnModeSelectMenuEvent , OnMainMenuEvent, OnSettingsMenuEvent;

    public delegate void OnGameOver();
    public static event OnGameOver OnGameOverEvent;


    public static void RiseOnMainMenuEvent()
    {
        OnMainMenuEvent?.Invoke();
    }
    public static void RiseOnModeSelectMenuEvent()
    {
        OnModeSelectMenuEvent?.Invoke();
    }
    public static void RiseOnSettingsMenuEvent()
    {
        OnSettingsMenuEvent?.Invoke();
    }
    public static void RiseOnGameOverEvent()
    {
        OnGameOverEvent?.Invoke();
    }
}
