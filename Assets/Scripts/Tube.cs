using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class Tube : MonoBehaviour, IPointerDownHandler{
    [SerializeField] private TubeView tubeView;
    private Stack<BallView> ballStack;
    public event Action<Tube> OnPointerDown;
    public TubeView TubeView { get => tubeView;}
    public Stack<BallView> getBallStack(){
        if(ballStack == null)
            ballStack = new Stack<BallView>();
        return ballStack;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData) {
        Debug.Log("Tube(" + this.tag + ") is clicked");
        PlayerPrefs.SetString("CurrentBeherTag", this.tag);
        OnPointerDown?.Invoke(this);
    }
}
