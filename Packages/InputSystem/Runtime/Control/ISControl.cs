using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua.InputSystem {
    public static class ISControl {
        /// <summary> 鼠标输入模块 </summary>
        public static ISMouseEvent Mouse(ISType type, ISMouseID id, Action execute, bool isException = true) {
            return new ISMouseEvent(type, (int)id, false, execute, isException);
        }
        /// <summary> 鼠标输入模块 </summary>
        public static ISMouseEvent Mouse(ISType type, int index, Action execute, bool isException = true) {
            return new ISMouseEvent(type, index, false, execute, isException);
        }

        /// <summary> 鼠标输入模块(在UI上不执行Down和Press) </summary>
        public static ISMouseEvent MouseOver(ISType type, ISMouseID id, Action execute, bool isException = true) {
            return new ISMouseEvent(type, (int)id, true, execute, isException);
        }
        /// <summary> 鼠标输入模块(在UI上不执行Down和Press) </summary>
        public static ISMouseEvent MouseOver(ISType type, int index, Action execute, bool isException = true) {
            return new ISMouseEvent(type, index, true, execute, isException);
        }

        /// <summary> 查找鼠标滚轮输入模块(IsOver == true 在UI上不执行) </summary>
        public static ISScrollWheelEvent ScrollWheel(bool isOver, Action<float> execute, bool isException = true) {
            return new ISScrollWheelEvent(isOver, execute, isException);
        }

        /// <summary> 键盘输入模块 </summary>
        public static ISKeyboardEvent Keyboard(ISType type, KeyCode keyCode, Action execute, bool isException = true) {
            return new ISKeyboardEvent(type, keyCode, execute, isException);
        }
    }
}