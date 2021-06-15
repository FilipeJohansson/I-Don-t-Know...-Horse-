using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour {

    public Transform Target;

    Transform m_CameraTransform;

    void Start() {
        m_CameraTransform = transform.GetChild(0);
    }

    void LateUpdate() {
        UpdatePosition();
    }

    void UpdatePosition() {
        if (Target == null) {
            return;
        }

        transform.position = Target.transform.position;
    }
}
