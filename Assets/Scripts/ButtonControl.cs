using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonControl : MonoBehaviour{
    [SerializeField] private Button button;
    [SerializeField] private RectTransform lockIcon;
    [SerializeField] private RectTransform textLevel;
    public Button Button { get => button;}

    public ButtonControl(Button button){
        this.button = button;
    }
    public void setActiveButton(bool active){
        lockIcon.gameObject.SetActive(!active);
        textLevel.gameObject.SetActive(active);
        button.interactable = active;
    }
}
