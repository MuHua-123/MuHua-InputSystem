using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua.InputSystem {
    public class ISScrollWheelEvent {
        private readonly ISScrollWheel ScrollWheel;
        private readonly Action<float> Execute;
        private readonly bool IsException;
        public ISScrollWheelEvent(bool isOver, Action<float> execute, bool isException = true) {
            Execute = execute; IsException = isException;
            ScrollWheel = ISFindModel.FindMouseScrollWheel(isOver);
            ScrollWheel.OnScroll += ISScrollWheelEvent_Execute;
        }
        public void Release() {
            ScrollWheel.OnScroll -= ISScrollWheelEvent_Execute;
        }
        private void ISScrollWheelEvent_Execute(float obj) {
            try { Execute?.Invoke(obj); }
            catch (Exception exception) {
                Release();
                if (IsException) { Debug.LogException(exception); }
            }
        }
    }
}
