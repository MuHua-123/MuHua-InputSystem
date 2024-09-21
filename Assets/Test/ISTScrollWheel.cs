using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua.InputSystem;

public class ISTScrollWheel : MonoBehaviour {
    public Transform target;
    private void Awake() {
        ISScrollWheel.Find(true).OnScroll += ISTScrollWheel_OnScroll;
    }
    private void OnDestroy() {
        ISScrollWheel.Find(false).OnScroll += ISTScrollWheel_OnScroll;
    }
    private void ISTScrollWheel_OnScroll(float obj) {
        float localScale = target.localScale.x;
        float size = Mathf.Max(1, localScale + obj);
        target.localScale = new Vector3(size, size, size);
    }
}
