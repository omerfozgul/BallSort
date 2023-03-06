using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour {

    [SerializeField] private Button button;
    [SerializeField] private GameObject lockIcon;
    [SerializeField] private GameObject textLevel;

    public GameObject LockIcon { get => lockIcon;}
    public GameObject TextLevel { get => textLevel;}
    public Button Button { get => button;}
}
