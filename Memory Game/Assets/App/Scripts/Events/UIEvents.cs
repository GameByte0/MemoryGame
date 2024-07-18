using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIEvents
{
    public delegate void OnMenu();
    public static event OnMenu OnModeSelectMenuEvent , OnMainMenuEvent, OnSettingsMenuEvent;


    public static void RiseOnMainMenuEvent()
    {
        OnMainMenuEvent?.Invoke();
    }
    public static void RiseOnModeSelectMenuEvent()
    {
        OnModeSelectMenuEvent?.Invoke();
    }
    public static void RiseSettingsMenuEvent()
    {
        OnSettingsMenuEvent?.Invoke();
    }
}
