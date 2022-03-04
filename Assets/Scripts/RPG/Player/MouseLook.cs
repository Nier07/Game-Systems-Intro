using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("RPG/Player/Mouse Look")]

public class MouseLook : MonoBehaviour
{
    #region Variables
    public enum RotationalAxis
    {
        MouseX,
        MouseY
    }

    [Header("Rotation Variables")]
    public RotationalAxis axis = RotationalAxis.MouseX;
    [Range(0, 500)]
    public float sensitivity = 100;
    public float minY = -60, maxY = 60;
    private float _rotY;
    #endregion

    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (GetComponent<Camera>())
        {
            axis = RotationalAxis.MouseY;
        }
    }
    void Update()
    {
        if (GameManager.gamePlayStates == GamePlayStates.Game)
        {
            #region Mouse X
            if (axis == RotationalAxis.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime, 0);
            }
            #endregion
            #region Mouse Y
            else
            {
                _rotY += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
                _rotY = Mathf.Clamp(_rotY, minY, maxY);
                transform.localEulerAngles = new Vector3(-_rotY, 0, 0);
            }
            #endregion
        }
    }
}

