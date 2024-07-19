using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public delegate void OnInputRecieved(int index);
    public static event OnInputRecieved OnInputRecievedEvent;

    public delegate void OnBlackOutStarted();
    public static event OnBlackOutStarted OnBlackOutStartedEvent;


    public static void RaiseOnInputRecievedEvent(int index)
    {
        OnInputRecievedEvent?.Invoke(index);
    }
    public static void RiseOnBlackOutStartedEvent()
    {
        OnBlackOutStartedEvent?.Invoke();
    }


}
