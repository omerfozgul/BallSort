using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class Tube : MonoBehaviour, IPointerDownHandler{
    [SerializeField] private TubeView tubeView;
    private Stack<BallView> ballStack = new Stack<BallView>();
    public event Action<Tube> OnPointerDown;
    public TubeView TubeView { get => tubeView;}
    public Stack<BallView> BallStack { get => ballStack;}

    public Stack<BallView> getBallStack(){
        return ballStack;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData) {
        //bunu kaydetmeye gerek yok
        PlayerPrefs.SetString("CurrentBeherTag", this.tag);//burasi degistirilebilir mi?
        OnPointerDown?.Invoke(this);
    }
}
