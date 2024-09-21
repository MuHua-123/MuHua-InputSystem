using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua.InputSystem;

public class ISTMouse : MonoBehaviour {
    public Transform target;
    public ISMouseID mouse;
    private Vector3 mousePosition;
    private Vector3 originalPosition;
    private void Awake() {
        ISMouseOver.Find(mouse).OnDown += ISTMouse_OnDown;
        ISMouseOver.Find(mouse).OnPress += ISTMouse_OnPress;
    }
    private void OnDestroy() {
        ISMouseOver.Find(mouse).OnDown -= ISTMouse_OnDown;
        ISMouseOver.Find(mouse).OnPress -= ISTMouse_OnPress;
    }

    private void ISTMouse_OnDown() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        originalPosition = target.position;
    }
    private void ISTMouse_OnPress() {
        Vector3 v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 offset = mousePosition - v3;
        Vector3 position = originalPosition - offset;
        target.position = Vector3.Lerp(target.position, position, Time.deltaTime * 10);
    }
}
