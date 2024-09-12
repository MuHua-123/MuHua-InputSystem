using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua.InputSystem;

public class ISTMouseEvent : MonoBehaviour {
    public Transform target;
    public ISMouseID mouse;
    private Vector3 mousePosition;
    private Vector3 originalPosition; 
    public ISTMouseEvent() {
        ISControl.Mouse(ISType.Down, mouse, ISTMouseEventOnDown, false);
        ISControl.Mouse(ISType.Press, mouse, ISTMouseEventOnPress, false);
    }
    private void ISTMouseEventOnDown() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        originalPosition = target.position;
    }
    private void ISTMouseEventOnPress() {
        Vector3 v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 offset = mousePosition - v3;
        Vector3 position = originalPosition - offset;
        target.position = Vector3.Lerp(target.position, position, Time.deltaTime * 10);
    }
}
