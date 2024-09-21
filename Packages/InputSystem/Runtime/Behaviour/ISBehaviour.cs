using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MuHua.InputSystem {
    public class ISBehaviour : MonoBehaviour {
        private Dictionary<int, ISMouse> MouseDic => ISModel.I.MouseDic;
        private Dictionary<int, ISMouseOver> MouseOverDic => ISModel.I.MouseOverDic;
        private Dictionary<bool, ISScrollWheel> ScrollWheelDic => ISModel.I.ScrollWheelDic;
        private Dictionary<KeyCode, ISKeyboard> KeyboardDic => ISModel.I.KeyboardDic;
        
        private bool IsEventSystem {
            get { return EventSystem.current != null; }
        }
        private bool IsPointerOverGameObject {
#if UNITY_STANDALONE
            //电脑平台
            get { return EventSystem.current.IsPointerOverGameObject(); }
#elif UNITY_WEBGL
        //WebGL平台
        get { return EventSystem.current.IsPointerOverGameObject(); }
#elif UNITY_ANDROID
        //安卓平台
        get { return EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId); }
#elif UNITY_IOS
        //苹果平台
        get { return EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId); }
#endif
        }
        private void Update() {
            foreach (KeyValuePair<int, ISMouse> item in MouseDic) {
                UpdateMouseInput(item.Key, item.Value);
            }
            foreach (KeyValuePair<int, ISMouseOver> item in MouseOverDic) {
                UpdateMouseOverInput(item.Key, item.Value);
            }
            foreach (KeyValuePair<bool, ISScrollWheel> item in ScrollWheelDic) {
                float scrollWheelValue = Input.GetAxis("Mouse ScrollWheel");
                UpdateScrollWheelInput(scrollWheelValue, item.Key, item.Value);
            }
            foreach (KeyValuePair<KeyCode, ISKeyboard> item in KeyboardDic) {
                UpdateKeyboardInput(item.Key, item.Value);
            }
        }
        private void UpdateMouseInput(int index, ISMouse mouse) {
            if (Input.GetMouseButtonUp(index)) { mouse.Up(); mouse.IsDown = false; }
            if (mouse.IsDown) { mouse.Press(); }
            if (Input.GetMouseButtonDown(index)) { mouse.Down(); mouse.IsDown = true; }
        }
        private void UpdateMouseOverInput(int index, ISMouseOver mouse) {
            if (Input.GetMouseButtonUp(index)) { mouse.Up(); mouse.IsDown = false; }
            if (IsEventSystem && IsPointerOverGameObject) { return; }
            if (mouse.IsDown) { mouse.Press(); }
            if (Input.GetMouseButtonDown(index)) { mouse.Down(); mouse.IsDown = true; }
        }
        private void UpdateScrollWheelInput(float scrollWheelValue, bool IsOver, ISScrollWheel scrollWheel) {
            if (IsEventSystem && IsPointerOverGameObject && IsOver) { return; }
            scrollWheel.Scroll(scrollWheelValue);
        }
        private void UpdateKeyboardInput(KeyCode keyCode, ISKeyboard keyboard) {
            if (Input.GetKeyDown(keyCode)) { keyboard.Down(); keyboard.IsDown = false; }
            if (keyboard.IsDown) { keyboard.Press(); }
            if (Input.GetKeyUp(keyCode)) { keyboard.Up(); keyboard.IsDown = true; }
        }
    }
}