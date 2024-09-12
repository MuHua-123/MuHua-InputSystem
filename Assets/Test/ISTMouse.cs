using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua.InputSystem;

public class ISTMouse : MonoBehaviour {
    //public bool isOver;
    //public ISMouseID mouse;
    //private Vector3 mousePosition;
    //private Vector3 originalPosition;
    //private void Awake() {
    //    ISControl.MouseOver(mouse).OnDown += OSTMouseLeft_OnDown;
    //    ISControl.MouseOver(mouse).OnPress += OSTMouseLeft_OnPress;
    //    ISControl.MouseScrollWheel(isOver).OnScroll += OSTMouse_OnScroll;
    //}
    //private void OnDestroy() {
    //    ISControl.MouseOver(mouse).OnDown -= OSTMouseLeft_OnDown;
    //    ISControl.MouseOver(mouse).OnPress -= OSTMouseLeft_OnPress;
    //    ISControl.MouseScrollWheel(isOver).OnScroll -= OSTMouse_OnScroll;
    //}
    //private void OSTMouseLeft_OnDown() {
    //    try {
    //        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        originalPosition = transform.position;
    //    }
    //    catch (System.Exception exception) {
    //        Debug.LogException(exception);
    //        ISControl.MouseOver(mouse).OnDown -= OSTMouseLeft_OnDown;
    //    }
    //}
    //private void OSTMouseLeft_OnPress() {
    //    try {
    //        Vector3 v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        Vector3 offset = mousePosition - v3;
    //        Vector3 position = originalPosition - offset;
    //        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * 10);
    //    }
    //    catch (System.Exception) {
    //        ISControl.MouseOver(mouse).OnPress -= OSTMouseLeft_OnPress;
    //    }
    //}
    //private void OSTMouse_OnScroll(float obj) {
    //    try {
    //        float localScale = transform.localScale.x;
    //        float size = Mathf.Max(1, localScale + obj);
    //        transform.localScale = new Vector3(size, size, size);
    //    }
    //    catch (System.Exception) {
    //        ISControl.MouseScrollWheel(isOver).OnScroll -= OSTMouse_OnScroll;
    //    }
    //}
}
