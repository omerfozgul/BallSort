using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour {

    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject tubes;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private ButtonControl[] buttonArr;
    [SerializeField] private Button homeButton;

    private bool level1flag = false;

    private void createButtons(LevelDataSO levelDataSO){
        //create button with prefabs
    }
    public void level1(){
        //level1 Awake icerisinde olusturuluyor
        //ama daha sonra main menu uzerinden tekrardan acildigi zaman calisiyor
        if(level1flag){
            gameManager.LevelManager.createLevel(0);
            gameManager.getReadyLevel();
        }
        level1flag = true;
        mainMenu.SetActive(false);
        tubes.SetActive(true);
        levelText.text = "LEVEL1";
        levelText.gameObject.SetActive(true);
        homeButton.gameObject.SetActive(true);
    }

    public void level2(){
        level(2);
    }
    public void level3(){
        level(3);
    }
    public void level4(){
        level(4);
    }
    public void level5(){
        level(5);
    }
    
    public void temp(){
        Button button = null;
        int i=0;
        button.onClick.AddListener(() => level(i));
    }

    private void level(int i){
        gameManager.LevelManager.createLevel(i-1);
        gameManager.getReadyLevel();
        mainMenu.SetActive(false);
        tubes.SetActive(true);
        homeButton.gameObject.SetActive(true);
        levelText.gameObject.SetActive(true);
        levelText.text = "LEVEL" + i;
    }
    public void nextLevel(){
        gameManager.startNextLevel();
        int currentLevelIndex = PlayerPrefs.GetInt("currentLevel");
        Debug.Log("current level ind: " + currentLevelIndex);
        levelText.text = "LEVEL" +(currentLevelIndex + 1);
        updateMainMenu();
    }

    public void MainMenu(){
        mainMenu.SetActive(true);
        tubes.SetActive(false);
        gameManager.cleanScreen();
        levelText.gameObject.SetActive(false);
        homeButton.gameObject.SetActive(false);
    }

    private void updateMainMenu(){
        int currentLevel = PlayerPrefs.GetInt("currentLevel");
        Debug.Log("levelNum " + currentLevel);
        for(int i=0; i <= currentLevel; i++){
            buttonArr[i].LockIcon.SetActive(false);
            buttonArr[i].TextLevel.SetActive(true);
            buttonArr[i].Button.interactable = true;
        }
    }
}
