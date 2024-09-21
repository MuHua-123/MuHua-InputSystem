using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua.InputSystem {
    /// <summary> 鼠标输入模块(在UI上不执行) </summary>
    public class ISMouseOver {
        public event Action OnDown;
        public event Action OnPress;
        public event Action OnUp;

        internal bool IsDown;
        internal readonly int Index;
        internal Action Down => () => OnDown?.Invoke();
        internal Action Press => () => OnPress?.Invoke();
        internal Action Up => () => OnUp?.Invoke();
        internal ISMouseOver(int index) {
            Index = index;
            ISModel.I.MouseOverDic.Add(index, this);
        }

        /// <summary> 查找鼠标输入模块(在UI上不执行) </summary>
        public static ISMouseOver Find(ISMouseID mouseID) {
            return Find((int)mouseID);
        }
        /// <summary> 查找鼠标输入模块(在UI上不执行) </summary>
        public static ISMouseOver Find(int index) {
            if (ISModel.I.MouseOverDic.TryGetValue(index, out ISMouseOver mouse)) { return mouse; }
            else { return new ISMouseOver(index); }
        }
    }
}
