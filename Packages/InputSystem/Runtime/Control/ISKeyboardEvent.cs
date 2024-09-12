using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua.InputSystem {
    public class ISKeyboardEvent {
        private readonly ISType Type;
        private readonly ISKeyboard Keyboard;
        private readonly Action Execute;
        private readonly bool IsException; 
        public ISKeyboardEvent(ISType type, KeyCode keyCode, Action execute, bool isException = true) {
            Type = type; Execute = execute; IsException = isException;
            Keyboard = ISFindModel.FindKeyboard(keyCode);
            if (Type == ISType.Down) { Keyboard.OnDown += ISKeyboardEvent_Execute; }
            if (Type == ISType.Press) { Keyboard.OnPress += ISKeyboardEvent_Execute; }
            if (Type == ISType.Up) { Keyboard.OnUp += ISKeyboardEvent_Execute; }
        }
        public void Release() {
            if (Type == ISType.Down) { Keyboard.OnDown -= ISKeyboardEvent_Execute; }
            if (Type == ISType.Press) { Keyboard.OnPress -= ISKeyboardEvent_Execute; }
            if (Type == ISType.Up) { Keyboard.OnUp -= ISKeyboardEvent_Execute; }
        }
        private void ISKeyboardEvent_Execute() {
            try { Execute?.Invoke(); }
            catch (Exception exception) {
                Release();
                if (IsException) { Debug.LogException(exception); }
            }
        }
    }
}