using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_Off_PC_CameraAndUI : MonoBehaviour
{
    public CameraController cameraController;

    public Camera pC_Camera;
    public Camera mobile_Camera;

    public GameObject pC_UI;
    public GameObject mobile_UI;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject[][] looks = { new GameObject[] { pC_Camera.gameObject, pC_UI }, new GameObject[] { mobile_Camera.gameObject, mobile_UI } };
        foreach( GameObject [] gameObjects in looks)
        {
            foreach (GameObject g in gameObjects)
                g.SetActive(false);
        }

        //assume mobile look
        int lookIndex = 1;

        if (PlayingOnPC())
            lookIndex = 0;


        foreach (GameObject g in looks[lookIndex])
            g.SetActive(true);

    }

    private bool PlayingOnPC()
    {
        RuntimePlatform[] temp = {RuntimePlatform.WindowsPlayer, RuntimePlatform.LinuxPlayer, RuntimePlatform.OSXPlayer,
                                            RuntimePlatform.WebGLPlayer};

        List<RuntimePlatform> pc_platforms = new List<RuntimePlatform>();
        pc_platforms.AddRange(temp);

        if (pc_platforms.Contains(Application.platform))
            return true;
        return false;
    }

}
