using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua.InputSystem;

public class ISTScrollWheelEvent : MonoBehaviour {
    public Transform target;
    public ISTScrollWheelEvent() {
        ISControl.ScrollWheel(true, ISControlScrollWheel, false);
    }
    private void ISControlScrollWheel(float obj) {
        float localScale = target.localScale.x;
        float size = Mathf.Max(1, localScale + obj);
        target.localScale = new Vector3(size, size, size);
    }
}
