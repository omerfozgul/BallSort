using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TubeView : MonoBehaviour {
    [SerializeField] private Image tubeImage;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform topOfTubeRectTransform;
    
    public RectTransform RectTransform { get => rectTransform;}
    public RectTransform TopOfTubeRectTransform { get => topOfTubeRectTransform;}
    public GameObject TubeGameObject {get => rectTransform.gameObject;}
    
}