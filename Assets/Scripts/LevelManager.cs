using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelGenerator levelGenerator;
    [SerializeField] private GeneralDataSO generalDataSO;
    private int currentLevelIndex = 0;
    public int CurrentLevelIndex { get => currentLevelIndex; set => currentLevelIndex = value; }

    public void createNextLevel() {
        currentLevelIndex++;
        createLevel(currentLevelIndex);
    }
    private void createLevel(LevelDataSO levelData) {
        if (levelData == null)
            Debug.Log("LevelData is NULL");
        levelGenerator.generateLevel(levelData, generalDataSO.Colors);
    }
    public void createLevel(int levelNum) {
        LevelDataSO levelDataSO = generalDataSO.LevelDataSOArray[levelNum];
        currentLevelIndex = levelNum;
        createLevel(levelDataSO);
    }
    public Tube[] GetTubes() {
        return levelGenerator.GetTubes();
    }
    public List<TubeView> GetTubeViews(){
        return levelGenerator.GetTubeViews();
    }
}
