using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    public CameraState CameraState;

    [SerializeField]
    private CinemachineVirtualCamera _fpsCamera;

    [SerializeField]
    private CinemachineFreeLook _tpsCamera;

    [SerializeField]
    private InputManager _inputManager;

    public Action OnChangePerspective;

    private void Start()
    {
        _inputManager.OnChangePOV += SwitchCamera;
    }

    private void OnDestroy()
    {
        _inputManager.OnChangePOV -= SwitchCamera;
    }

    public void setFPSClampedCamera(bool isClamped, Vector3 playerRotation)
    {
        CinemachinePOV pov = _fpsCamera.GetCinemachineComponent<CinemachinePOV>();
        if (isClamped)
        {
            pov.m_HorizontalAxis.m_Wrap = false;
            pov.m_HorizontalAxis.m_MinValue = playerRotation.y - 45;
            pov.m_HorizontalAxis.m_MaxValue = playerRotation.y + 45;
        }
        else
        {
            pov.m_HorizontalAxis.m_MinValue = -180;
            pov.m_HorizontalAxis.m_MaxValue = 180;
            pov.m_HorizontalAxis.m_Wrap = true;
        }
    }

    public void SwitchCamera()
    {
        if (CameraState == CameraState.ThirdPerson)
        {
            CameraState = CameraState.FirstPerson;
            _tpsCamera.gameObject.SetActive(false);
            _fpsCamera.gameObject.SetActive(true);
        }
        else
        {
            CameraState = CameraState.ThirdPerson;
            _tpsCamera.gameObject.SetActive(true);
            _fpsCamera.gameObject.SetActive(false);
        }
        OnChangePerspective();
    }

    public void SetTPSFieldOfView(float fieldOfView)
    {
        _tpsCamera.m_Lens.FieldOfView = fieldOfView;
    }
}
