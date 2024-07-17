using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraRig))] //to ensure only CameraRig objects get this class
public class MousePOV : MonoBehaviour
{
    public float XSensitivity = 2f;
    public float YSensitivity = 2f;
    public bool clampVerticalRotation = true;
    public float MinimumX = -90F;
    public float MaximumX = 90F;
    public bool smooth;
    public float smoothTime = 5f;


    private Quaternion yAxisMouse;
    private Quaternion xAxisMouse;

    private CameraRig rig2; //to talk directly between this class(mouse work) and camera

    void Start()
    {
        rig2 = GetComponent<CameraRig>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && (Input.GetAxis ("Mouse X") != 0 || Input.GetAxis ("Mouse Y") != 0))
        {
            if(GameManager.myInstance.ivCanvas.gameObject.activeInHierarchy)
            {
                return;
            }
            yAxisMouse = rig2.yAxis.localRotation;
            xAxisMouse = rig2.xAxis.localRotation;
            LookRotation();
        }
    }

    public void LookRotation()
    {
        float yRot = Input.GetAxis("Mouse X") * XSensitivity;
        float xRot = Input.GetAxis("Mouse Y") * YSensitivity;

        yAxisMouse *= Quaternion.Euler(0f, yRot, 0f);
        xAxisMouse *= Quaternion.Euler(-xRot, 0f, 0f);

        if (clampVerticalRotation)
            xAxisMouse = ClampRotationAroundXAxis(xAxisMouse);

        if (smooth)
        {
            rig2.yAxis.localRotation = Quaternion.Slerp(rig2.yAxis.localRotation, yAxisMouse,
                smoothTime * Time.deltaTime);
            rig2.xAxis.localRotation = Quaternion.Slerp(rig2.xAxis.localRotation, xAxisMouse,
                smoothTime * Time.deltaTime);
        }
        else
        {
            rig2.yAxis.localRotation = yAxisMouse;
            rig2.xAxis.localRotation = xAxisMouse;
        }        
    }  

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}
