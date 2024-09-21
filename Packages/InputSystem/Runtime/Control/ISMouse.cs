using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua.InputSystem {
    /// <summary> 鼠标输入模块 </summary>
    public class ISMouse {
        public event Action OnDown;
        public event Action OnPress;
        public event Action OnUp;

        internal bool IsDown;
        internal readonly int Index;
        internal Action Down => () => OnDown?.Invoke();
        internal Action Press => () => OnPress?.Invoke();
        internal Action Up => () => OnUp?.Invoke();
        internal ISMouse(int index) {
            Index = index;
            ISModel.I.MouseDic.Add(index, this);
        }

        /// <summary> 查找鼠标输入模块 </summary>
        public static ISMouse Find(ISMouseID mouseID) {
            return Find((int)mouseID);
        }
        /// <summary> 查找鼠标输入模块 </summary>
        public static ISMouse Find(int index) {
            if (ISModel.I.MouseDic.TryGetValue(index, out ISMouse mouse)) { return mouse; }
            else { return new ISMouse(index); }
        }
    }
}