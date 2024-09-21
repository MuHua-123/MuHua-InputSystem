using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua.InputSystem {
    internal class ISModel {
        public static ISModel I => Instantiate();

        private static ISModel model;
        private static ISModel Instantiate() {
            return model == null ? model = new ISModel() : model;
        }

        public Dictionary<int, ISMouse> MouseDic = new Dictionary<int, ISMouse>();
        public Dictionary<int, ISMouseOver> MouseOverDic = new Dictionary<int, ISMouseOver>();
        public Dictionary<bool, ISScrollWheel> ScrollWheelDic = new Dictionary<bool, ISScrollWheel>();
        public Dictionary<KeyCode, ISKeyboard> KeyboardDic = new Dictionary<KeyCode, ISKeyboard>();
    }
}