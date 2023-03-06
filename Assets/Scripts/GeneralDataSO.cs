using System;
using UnityEngine;

[Serializable]
public enum ColorKey { Red, Green, Blue, Yellow, Gray, Pink, Orange, Purple}
[Serializable]
public struct ColorData{
    public ColorKey colorKey;
    public Color colorValue;
}

[CreateAssetMenu(fileName = "generalData", menuName = "ScriptableObjects/GeneralDataScriptableObject", order = 1)]
public class GeneralDataSO : ScriptableObject {
    [SerializeField] private LevelDataSO[] levelDataSOArray ;
    [SerializeField] private ColorData[] colors;


    public LevelDataSO[] LevelDataSOArray { get => levelDataSOArray; }
    public ColorData[] Colors { get => colors; }
}
