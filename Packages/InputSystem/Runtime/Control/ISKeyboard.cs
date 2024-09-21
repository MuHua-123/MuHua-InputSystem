using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua.InputSystem {
    /// <summary> 键盘输入模块 </summary>
    public class ISKeyboard {
        public event Action OnDown;
        public event Action OnPress;
        public event Action OnUp;

        internal bool IsDown;
        internal readonly KeyCode KeyCode;
        internal Action Down => () => OnDown?.Invoke();
        internal Action Press => () => OnPress?.Invoke();
        internal Action Up => () => OnUp?.Invoke();
        internal ISKeyboard(KeyCode keyCode) {
            KeyCode = keyCode;
            ISModel.I.KeyboardDic.Add(keyCode, this);
        }

        /// <summary> 查找键盘输入模块 </summary>
        public static ISKeyboard FindKeyboard(KeyCode keyCode) {
            if (ISModel.I.KeyboardDic.TryGetValue(keyCode, out ISKeyboard keyboard)) { return keyboard; }
            else { return new ISKeyboard(keyCode); }
        }
    }
}