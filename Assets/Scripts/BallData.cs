using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class BallData { 
    [SerializeField] private ColorKey color;
    public ColorKey Color { get => color; }
}

[System.Serializable]
public class TubeData {
    [SerializeField] private List<BallData> balls;

    public List<BallData> Balls { get => balls; }
}
