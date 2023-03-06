using UnityEngine;
using UnityEngine.UI;

public class BallView : MonoBehaviour
{
    [SerializeField] private Image ballImage;
    [SerializeField] private RectTransform recTransform;
    private ColorKey colorKey;

    public Image BallImage { get => ballImage;}
    public RectTransform RecTransform { get => recTransform; set => recTransform = value; }
    public ColorKey ColorKey { get => colorKey; set => colorKey = value; }
}
