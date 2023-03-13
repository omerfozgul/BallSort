using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TubeControl : MonoBehaviour, IPointerDownHandler
{
    public event Action<TubeControl> OnPointerDown;
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData) {
        PlayerPrefs.SetString("CurrentBeherTag", this.tag);
        OnPointerDown?.Invoke(this);
    }
}
