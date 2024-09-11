using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua.InputSystem {
    public class ISScrollWheel {
        public bool IsOver;
        public event Action<float> OnScroll;

        public Action<float> Scroll => (value) => OnScroll?.Invoke(value);
    }
}