using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
///  힌트 오브젝트 클래스
/// </summary>
public class HintObject : MonoBehaviour, IInteraction
{
    public HintData hintData;
    public Camera _changeCamera;
    public Camera _playerCamera;
    public CinemachineVirtualCamera hintObjViCamera;
    public CinemachineVirtualCamera playerViCamera;

    /// <summary>
    /// 힌트 오브젝트의 displayName return
    /// </summary>
    /// <returns></returns>
    public string GetInteractPrompt()
    {
        return string.Format("{0}", hintData.displayName);
    }

    /// <summary>
    /// 힌트오브젝트와 상호작용했을 시 
    /// </summary>
    public void OnInteract()
    {
        CinemachineController.Instance.OnChangedCineMachinePriority(hintObjViCamera.Name, playerViCamera.Name, false);

        //hintObjViCamera.MoveToTopOfPrioritySubqueue();
        //hintObjViCamera.Priority = 11;
        //playerViCamera.Priority = 10;

        //CamerController cameraController = FindObjectOfType<CamerController>();

        //if (cameraController != null)
        //{
        //    cameraController.ActivateCamera(_changeCamera);

        //}
    }

    public void NonInteract()
    {

        CinemachineController.Instance.OnChangedCineMachinePriority(playerViCamera.Name, hintObjViCamera.Name, true);

        //Debug.Log("????????");


        //hintObjViCamera.Priority = 10;
        //playerViCamera.Priority = 11;
        //playerViCamera.MoveToTopOfPrioritySubqueue();

        //CamerController cameraController = FindObjectOfType<CamerController>();

        //if (cameraController != null)
        //{
        //    cameraController.ActivateCamera(_playerCamera);

        //}
    }

}
