using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    #region Singleton
    public static CameraManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }
    #endregion

    [SerializeField]
    private List<CinemachineVirtualCamera> vCams;

    public void setTarget(GameObject target)
    {
        foreach (CinemachineVirtualCamera vCam in vCams)
        {
            vCam.m_Follow = target.transform;
        }
    }
}
