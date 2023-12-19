using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;
using Unity.VisualScripting.Antlr3.Runtime;

public class DoorObejct : MonoBehaviour, IInteraction
{
    public CinemachineVirtualCamera playerViCamera;
    public CinemachineVirtualCamera aisleViCamera;

    public DoorData DoorData;
    public ItemData KeyObj;

    public DoorAction doorAction;

    /// <summary>
    /// Door ?ㅻ툕?앺듃???대쫫 ?쒖떆
    /// </summary>
    /// <returns></returns>
    public string GetInteractPrompt()
    {
        return string.Format("{0}", DoorData.displayName);
    }

    /// <summary>
    /// door????곹샇?묒슜
    /// </summary>
    public void OnInteract()
    {
        Debug.Log("상호작용 중");
        if (doorAction.needKey)
        {
            Debug.Log("열쇠가 필요합니다");
            if (doorAction.isOpen)
            {
                Debug.Log("문이 열려있습니다");
                doorAction.ToggleDoor();
            }
            else
            {
                Debug.Log("문이 닫혀있습니다");
                if (Inventory.instance.HasItems(KeyObj) == true)
                {
                    doorAction.OpenDoor();
                }
            }
        }
        else
        {
            Debug.Log("열쇠가 필요하지 않습니다");
            doorAction.ToggleDoor();
        }
        // door open
        //임시
        //gameObject.SetActive(false);

        //doorAction.ToggleDoor();

        //if (playerViCamera != null && aisleViCamera != null)
        //{
        //    CinemachineController.Instance.OnChangedCineMachinePriority(aisleViCamera.Name, playerViCamera.Name);

        //    Invoke("InvokeController", 5f);
        //}

        // StartCoroutine(DealayCoroutineController());

    }


    private void InvokeController()
    {
        CinemachineController.Instance.OnChangedCineMachinePriority(playerViCamera.Name, aisleViCamera.Name);
        Debug.Log("인보크 작동");
        //aisleViCamera.gameObject.SetActive(false);
    }

    //private IEnumerator DealayCoroutineController()
    //{
    //    yield return new WaitForSecondsRealtime(5f);

    //    aisleViCamera.gameObject.SetActive(false);


    //    Debug.Log("돌아와");

    //}

}
