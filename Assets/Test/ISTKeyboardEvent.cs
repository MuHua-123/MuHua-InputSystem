using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua.InputSystem;

public class ISTKeyboardEvent : MonoBehaviour {
    private readonly ISKeyboardEvent keyboardEvent;
    public ISTKeyboardEvent() {
        keyboardEvent = ISControl.Keyboard(ISType.Down, KeyCode.K, ISControlKeyboard, false);
    }
    private void ISControlKeyboard() {
        if (this == null) { keyboardEvent.Release(); return; }
        Debug.Log("sssskkkkkkkkkkkkk");
    }
}
