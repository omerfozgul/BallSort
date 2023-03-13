using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform TubesParent;
    [SerializeField] private BallView ballViewPrefab;
    [SerializeField] private Tube tubePrefab;

    private List<TubeView> tubeViews;
    private Tube[] tubes;

    public void generateLevel(LevelDataSO levelData, ColorData[] colors) {

        tubeViews = new List<TubeView>();
        List<TubeData> TubeDataList = levelData.Tubes;
        tubes = new Tube[TubeDataList.Count];

        int tubeIndex = 0;
        float defaultTubeTransformY = 0.15f;
        foreach(TubeData tube in TubeDataList) {
            //creating tube object
            Tube curTube = Instantiate(tubePrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, TubesParent);
            curTube.tag = "tube" + tubeIndex.ToString();

            tubeViews.Add(curTube.TubeView);
            curTube.TubeView.RectTransform.pivot = new Vector2(curTube.TubeView.RectTransform.pivot.x, defaultTubeTransformY);

            foreach(BallData ball in tube.Balls) {
                ballViewPrefab.BallImage.color = getColor(ball.Color, colors);

                //creating ball object
                BallView curBall = Instantiate(ballViewPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, curTube.TubeView.RectTransform);
                curBall.ColorKey = ball.Color;
                curTube.getBallStack().Push(curBall);
                //pivot is rising up
                curTube.TubeView.RectTransform.pivot = new Vector2(curTube.TubeView.RectTransform.pivot.x, curTube.TubeView.RectTransform.pivot.y + 0.2f);
            }
            tubes[tubeIndex] = curTube;
            tubeIndex++;
        }
    }
    public Tube[] getBalls(){
        return tubes;
    }
    public List<TubeView> getTubes(){
        return tubeViews;
    }
    private Color getColor(ColorKey key, ColorData[] colorData) {
        foreach(ColorData color in colorData) {
            if (color.colorKey == key)
                return color.colorValue;
        }
        Debug.Log("Color is not found.");
        return Color.white;
    }
}
