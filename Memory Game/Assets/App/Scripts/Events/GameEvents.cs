using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public delegate void OnInputRecieved(int index);
    public static event OnInputRecieved OnInputRecievedEvent;



    public static void RaiseOnInputRecievedEvent(int index)
    {
        OnInputRecievedEvent?.Invoke(index);
    }


}
