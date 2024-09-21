using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua.InputSystem {
    /// <summary> 鼠标滚轮输入模块 </summary>
    public class ISScrollWheel {
        public event Action<float> OnScroll;

        internal readonly bool IsOver;
        internal Action<float> Scroll => (value) => OnScroll?.Invoke(value);
        internal ISScrollWheel(bool isOver) {
            IsOver = isOver;
            ISModel.I.ScrollWheelDic.Add(isOver, this);
        }

        /// <summary> 查找鼠标滚轮输入模块(IsOver == true 在UI上不执行) </summary>
        public static ISScrollWheel Find(bool IsOver) {
            if (ISModel.I.ScrollWheelDic.TryGetValue(IsOver, out ISScrollWheel scrollWheel)) { return scrollWheel; }
            else { return new ISScrollWheel(IsOver); }
        }
    }
}