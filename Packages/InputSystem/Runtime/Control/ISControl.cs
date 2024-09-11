using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua.InputSystem {
    public static class ISControl {
        private static Dictionary<int, ISMouse> MouseDictionary => ISModel.I.MouseDictionary;
        private static Dictionary<int, ISMouse> MouseOverDictionary => ISModel.I.MouseOverDictionary;
        private static Dictionary<bool, ISScrollWheel> ScrollWheelDictionary => ISModel.I.ScrollWheelDictionary;
        private static Dictionary<KeyCode, ISKeyboard> KeyboardDictionary => ISModel.I.KeyboardDictionary;

        /// <summary> 鼠标输入模块 </summary>
        public static ISMouse Mouse(ISMouseID mouseID) {
            return Mouse((int)mouseID);
        }
        /// <summary> 鼠标输入模块 </summary>
        public static ISMouse Mouse(int index) {
            if (MouseDictionary.TryGetValue(index, out ISMouse mouse)) { return mouse; }
            mouse = new ISMouse { Index = index };
            MouseDictionary.Add(index, mouse);
            return mouse;
        }

        /// <summary> 鼠标输入模块(在UI上不执行Down和Press) </summary>
        public static ISMouse MouseOver(ISMouseID mouseID) {
            return MouseOver((int)mouseID);
        }
        /// <summary> 鼠标输入模块(在UI上不执行Down和Press) </summary>
        public static ISMouse MouseOver(int index) {
            if (MouseOverDictionary.TryGetValue(index, out ISMouse mouse)) { return mouse; }
            mouse = new ISMouse { Index = index };
            MouseOverDictionary.Add(index, mouse);
            return mouse;
        }

        /// <summary> 鼠标滚轮输入模块(IsOver == true 在UI上不执行) </summary>
        public static ISScrollWheel MouseScrollWheel(bool IsOver) {
            if (ScrollWheelDictionary.TryGetValue(IsOver, out ISScrollWheel scrollWheel)) { return scrollWheel; }
            scrollWheel = new ISScrollWheel { IsOver = IsOver };
            ScrollWheelDictionary.Add(IsOver, scrollWheel);
            return scrollWheel;
        }

        /// <summary> 键盘输入模块 </summary>
        public static ISKeyboard Keyboard(KeyCode keyCode) {
            if (KeyboardDictionary.TryGetValue(keyCode, out ISKeyboard keyboard)) { return keyboard; }
            keyboard = new ISKeyboard { KeyCode = keyCode };
            KeyboardDictionary.Add(keyCode, keyboard);
            return keyboard;
        }
    }
}