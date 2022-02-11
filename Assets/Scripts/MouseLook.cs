using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script can be found in the Component section under RPG Game/Character/MosueLook
[AddComponentMenu("RPG Game/Character/MosueLook")]
public class MouseLook : MonoBehaviour
{
    public enum RotationalAxis
    {
        MouseX,
        MouseY
    }
    [Header("Rotation")]
    public RotationalAxis axis;
    [Header("Sensitivity")]
    [Range(0, 500)]
    public float sensitivity = 100f;
    [Header("RotationClamp")]
    public float minY = -60f;
    public float maxY = 60f;
    //diplay private varibalr with m_variableName
    private float m_rotY;
    public bool invert;

    // Start is called before the first frame update
    void Start()
    {
        //lock cursor in middle of screen
        Cursor.lockState = CursorLockMode.Locked;
        //hide cursor from view
        Cursor.visible = false;
        if (GetComponent<Rigidbody>())
        {
            //set rigd bodys freeze rotation to true
            GetComponent<Rigidbody>().freezeRotation = true;

        }
        //if the object is the camera
        if (GetComponent<Camera>())
        {
            axis = RotationalAxis.MouseY;
        }
    }

    // Update is called once per frame
    void Update()
    {
        #region Mouse X
        axis = RotationalAxis.MouseX;
        //if we are rotating on the X
        if (axis == RotationalAxis.MouseX)
        {
            //transform the rotation on our game objects Y by our mouse X time X sensitivity
            transform.Rotate(0, Input.GetAxis("Mouse X")*sensitivity,0);
            
        }

        #endregion
        #region Mouse Y
        else
        { 
            //rotation Y is pulse equals mouse input for Mosue Y time Y sensitivity
            m_rotY += (Input.GetAxis("Mouse Y") * sensitivity);
            //the rotation Y is clamped using Mathf and we are clamping the y rotation to the Y min and max
            m_rotY = Mathf.Clamp(m_rotY, minY, maxY);
            //transform local position to the next vector
            if (invert)
            {
                transform.localEulerAngles = new Vector3(m_rotY, 0, 0);
            }
            else
            {
                transform.localEulerAngles = new Vector3(-m_rotY, 0, 0);
            }

            #endregion

        }
    }
}
