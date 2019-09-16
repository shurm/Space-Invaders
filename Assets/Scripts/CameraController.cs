using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera main;

    public Camera bottomCam;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            SwitchCameraView();
        }
    }

    public void SwitchCameraView()
    {
        if (main.enabled)
        {
            main.enabled = false;
            bottomCam.enabled = true;
        }
        else
        {
            main.enabled = true;
            bottomCam.enabled = false;
        }
    }
}
