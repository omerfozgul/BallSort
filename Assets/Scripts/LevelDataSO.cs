using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "level", menuName = "ScriptableObjects/LevelScriptableObject", order = 1)]
public class LevelDataSO : ScriptableObject {
    [SerializeField] private List<TubeData> tubes;
    public List<TubeData> Tubes { get => tubes; }
}