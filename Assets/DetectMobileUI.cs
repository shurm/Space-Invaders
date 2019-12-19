using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMobileUI : MonoBehaviour
{
    public GameObject mobileUI;
    // Start is called before the first frame update
    void Start()
    {
        RuntimePlatform[] temp = {RuntimePlatform.WindowsPlayer, RuntimePlatform.LinuxPlayer, RuntimePlatform.OSXPlayer,
                                            RuntimePlatform.WebGLPlayer};

        List<RuntimePlatform> pc_platforms = new List<RuntimePlatform>();
        pc_platforms.AddRange(temp);

        if (pc_platforms.Contains(Application.platform))
            mobileUI.SetActive(false);
    }

    
}
