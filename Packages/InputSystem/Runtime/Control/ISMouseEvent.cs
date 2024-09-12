using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua.InputSystem {
    public class ISMouseEvent {
        private readonly ISType Type;
        private readonly ISMouse Mouse;
        private readonly Action Execute; 
        private readonly bool IsException;
        public ISMouseEvent(ISType type, int index, bool isOver, Action execute, bool isException = true) {
            Type = type; Execute = execute; IsException = isException;

            if (!isOver) { Mouse = ISFindModel.FindMouse(index); }
            else { Mouse = ISFindModel.FindMouseOver(index); }

            if (Type == ISType.Down) { Mouse.OnDown += ISMouseEvent_Execute; }
            if (Type == ISType.Press) { Mouse.OnPress += ISMouseEvent_Execute; }
            if (Type == ISType.Up) { Mouse.OnUp += ISMouseEvent_Execute; }
        }
        public void Release() {
            if (Type == ISType.Down) { Mouse.OnDown -= ISMouseEvent_Execute; }
            if (Type == ISType.Press) { Mouse.OnPress -= ISMouseEvent_Execute; }
            if (Type == ISType.Up) { Mouse.OnUp -= ISMouseEvent_Execute; }
        }
        private void ISMouseEvent_Execute() {
            try { Execute?.Invoke(); }
            catch (Exception exception) {
                Release();
                if (IsException) { Debug.LogException(exception); }
            }
        }
    }
}
