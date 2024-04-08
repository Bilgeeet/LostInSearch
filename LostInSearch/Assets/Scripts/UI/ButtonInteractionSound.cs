using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonInteractionSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("entered");
        SoundManager.Instance.PlayMainSound(SoundManager.UISoundTypes.Click);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SoundManager.Instance.StopMainSound(SoundManager.UISoundTypes.Click);
    }
}
