using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSelect : MonoBehaviour, ISelectHandler
{
    public PauseController pauseController;
    public string textInfo;

    public void OnSelect(BaseEventData eventData)
    {
        pauseController.UpdateSelectedButton(this.gameObject, textInfo);
    }
}
