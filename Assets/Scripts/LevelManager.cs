using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelGenerator levelGenerator;
    [SerializeField] private GeneralDataSO generalDataSO;
    private int currentLevelIndex = 0;
    public void createCurrentLevel() {
        createLevel(currentLevelIndex);
        currentLevelIndex++;
        
    }
    private void createLevel(LevelDataSO levelData) {
        if (levelData == null)
            Debug.Log(null);
        levelGenerator.generateLevel(levelData, generalDataSO.Colors);
    }

    public void createLevel(int levelNum) {
        LevelDataSO levelDataSO = generalDataSO.LevelDataSOArray[levelNum];
        PlayerPrefs.SetInt("currentLevel", currentLevelIndex);
        createLevel(levelDataSO);
    }

    public LevelDataSO getCurrentLevelDataSO() {
        LevelDataSO levelDataSO = generalDataSO.LevelDataSOArray[currentLevelIndex];
        return levelDataSO;
    }

    public Stack<BallView>[] getBalls() {
        return levelGenerator.getBalls();
    }
    public List<TubeView> getTubes(){
        return levelGenerator.getTubes();
    }
}
