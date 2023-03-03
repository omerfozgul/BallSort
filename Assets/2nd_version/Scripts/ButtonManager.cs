using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonManager : MonoBehaviour {

    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject tubes;
    [SerializeField] private GameObject levelTextGameObj;
    [SerializeField] private TextMeshProUGUI levelText;
    
    [SerializeField] private ButtonControl[] buttonArr; 

    private bool level1flag = false;
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
        levelTextGameObj.SetActive(true);
    }

    public void level2(){
        Debug.Log("level2");
        gameManager.LevelManager.createLevel(1);
        gameManager.getReadyLevel();
        mainMenu.SetActive(false);
        tubes.SetActive(true);
        levelText.text = "LEVEL2";
        levelTextGameObj.SetActive(true);
    }

    public void level3(){
        gameManager.LevelManager.createLevel(2);
        gameManager.getReadyLevel();
        mainMenu.SetActive(false);
        tubes.SetActive(true);
        levelText.text = "LEVEL3";
        levelTextGameObj.SetActive(true);
    }

    public void level4(){
        gameManager.LevelManager.createLevel(3);
        gameManager.getReadyLevel();
        mainMenu.SetActive(false);
        tubes.SetActive(true);
        levelText.text = "LEVEL4";
        levelTextGameObj.SetActive(true);
    }

    public void level5(){
        gameManager.LevelManager.createLevel(4);
        gameManager.getReadyLevel();
        mainMenu.SetActive(false);
        tubes.SetActive(true);
        levelText.text = "LEVEL5";
        levelTextGameObj.SetActive(true);
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
        levelTextGameObj.SetActive(false);
        gameManager.cleanScreen();
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
