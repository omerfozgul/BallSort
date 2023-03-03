using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameBall
{
    GameObject gameObj;
    string color;

    public gameBall(GameObject gameObj, string color)
    {
        this.gameObj = gameObj;
        this.color = color;
    }

    public GameObject getGameObject()
    {
        return gameObj;
    }

    public string getColorName()
    {
        return color;
    }
}
