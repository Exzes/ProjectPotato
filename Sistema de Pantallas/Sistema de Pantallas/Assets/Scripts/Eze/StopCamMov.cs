using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class StopCamMov : MonoBehaviour
{
    [SerializeField] Cinemachine.CinemachineFreeLook freeLookCam;

    private void Start()
    {
        freeLookCam = GetComponent<Cinemachine.CinemachineFreeLook>();
    }

    private void Update()
    {
        if (!PlayManager.Instance.canPlayerMove)
        {
            CameraMovement(true);
            return;
        }
        else
        {
            CameraMovement(false);
        }
    }


    private void CameraMovement(bool isLocked)
    {
        if (isLocked)
        {
            // Bloquear movimiento
            freeLookCam.m_XAxis.m_InputAxisName = ""; // Eliminar input horizontal
            freeLookCam.m_YAxis.m_InputAxisName = ""; // Eliminar input vertical
            freeLookCam.m_XAxis.m_MaxSpeed = 0; // Velocidad horizontal a 0
            freeLookCam.m_YAxis.m_MaxSpeed = 0; // Velocidad vertical a 0
        }
        else
        {
            freeLookCam.m_XAxis.m_InputAxisName = "Mouse X";
            freeLookCam.m_YAxis.m_InputAxisName = "Mouse Y";
            freeLookCam.m_XAxis.m_MaxSpeed = 300;
            freeLookCam.m_YAxis.m_MaxSpeed = 2;
        }
    }

}
