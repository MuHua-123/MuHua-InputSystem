using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua.InputSystem {
    internal class ISMouse {
        public int Index;
        public bool IsDown;
        public event Action OnDown;
        public event Action OnPress;
        public event Action OnUp;

        public Action Down => () => OnDown?.Invoke();
        public Action Press => () => OnPress?.Invoke();
        public Action Up => () => OnUp?.Invoke();
    }
}