using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua.InputSystem {
    internal class ISModel {
        private static ISModel model;
        public static ISModel I {
            get { if (model == null) { model = new ISModel(); } return model; }
        }

        public Dictionary<int, ISMouse> MouseDictionary = new Dictionary<int, ISMouse>();
        public Dictionary<int, ISMouse> MouseOverDictionary = new Dictionary<int, ISMouse>();
        public Dictionary<bool, ISScrollWheel> ScrollWheelDictionary = new Dictionary<bool, ISScrollWheel>();
        public Dictionary<KeyCode, ISKeyboard> KeyboardDictionary = new Dictionary<KeyCode, ISKeyboard>();
    }
}