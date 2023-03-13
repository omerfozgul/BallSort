using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ButtonManager : MonoBehaviour {

    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject tubes;
    [SerializeField] private TextMeshProUGUI levelText;
    //[SerializeField] private ButtonControl[] buttonArr;
    [SerializeField] private Button homeButton;
    [SerializeField] private ButtonControl levelButton;
    [SerializeField] private GameObject buttonParent;
    private List<ButtonControl> buttonControlList;

    public void createButtons(){
        buttonControlList = new List<ButtonControl>();
        for(int i=0; i<5; i++){
            ButtonControl btnControl = Instantiate(levelButton);
            btnControl.gameObject.transform.SetParent(buttonParent.transform);
            int levelNum = i+1;
            btnControl.GetComponentInChildren<TextMeshProUGUI>().text = levelNum.ToString();
            btnControl.Button.onClick.AddListener(() => level(levelNum));
            //oyun baslangicinda sadece ilk button aciktir
            if(i>0)
                btnControl.setActiveButton(false);
            buttonControlList.Add(btnControl);
        }
    }
    private void level(int i){
        //i is actual level number here
        PlayerPrefs.SetInt("isLevelScene", 1);
        gameManager.LevelManager.createLevel(i-1);
        gameManager.setBallsAndTubes(gameManager.LevelManager.getBalls(), gameManager.LevelManager.getTubes());
        gameManager.getReadyLevel();
        getActiveLevelObjects(true);
        levelText.text = "LEVEL" + i;
    }

    //"next" button triggers nextLevel function
    public void nextLevel(){
        gameManager.startNextLevel();
        int currentLevelIndex = gameManager.LevelManager.CurrentLevelIndex;
        buttonControlList[currentLevelIndex].setActiveButton(true);
        levelText.text = "LEVEL" +(currentLevelIndex + 1);
    }

    public void MainMenu(){
        PlayerPrefs.SetInt("isLevelScene", 0);
        gameManager.cleanScreen();
        getActiveLevelObjects(false);
    }

    private void getActiveLevelObjects(bool active){
        mainMenu.SetActive(!active);
        tubes.SetActive(active);
        levelText.gameObject.SetActive(active);
        homeButton.gameObject.SetActive(active);
    }
}
