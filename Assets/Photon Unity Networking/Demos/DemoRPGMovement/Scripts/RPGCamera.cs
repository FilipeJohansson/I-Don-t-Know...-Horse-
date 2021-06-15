using UnityEngine;
using System.Collections;

public class RPGCamera : MonoBehaviour
{
    public Transform Target;

    Transform m_CameraTransform;

    void Start()
    {
        m_CameraTransform = transform.GetChild( 0 );
    }

    void LateUpdate()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        if( Target == null )
        {
            return;
        }

        transform.position = Target.transform.position;
    }
}
