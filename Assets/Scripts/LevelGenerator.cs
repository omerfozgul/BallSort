using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform Tubes;
    [SerializeField] private BallView ballViewPrefab;
    [SerializeField] private TubeView tubeViewPrefab;

    private ColorData[] colorData;
    private float defaultTubeTransformY = 0.15f;

    private List<TubeView> tubeViews;
    private Stack<BallView>[] ballViews;
    //private Tube[] tubes;//burayi yapmayai sagla!!!!

    public void generateLevel(LevelDataSO levelData, ColorData[] colors) {
        colorData = colors;

        tubeViews = new List<TubeView>();
        List<TubeData> tubes = levelData.Tubes;

        ballViews = new Stack<BallView>[tubes.Count];

        for(int i=0; i<tubes.Count; i++) {
            ballViews[i] = new Stack<BallView>();
        }

        int beherIndex = 0;
        foreach(TubeData tube in tubes) {
            //creating tube object
            TubeView curTube = Instantiate(tubeViewPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, Tubes);
            curTube.tag = "tube" + beherIndex.ToString();

            tubeViews.Add(curTube);
            curTube.RectTransform.pivot = new Vector2(curTube.RectTransform.pivot.x, defaultTubeTransformY);
            List<BallData> balls = tube.Balls;

            Stack<BallView> curStackBallView = ballViews[beherIndex];
            foreach(BallData ball in balls) {
                ColorKey colorKey = ball.Color;
                ballViewPrefab.BallImage.color = getColor(colorKey);

                //creating ball object
                BallView curBall = Instantiate(ballViewPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, curTube.RectTransform);
                curBall.ColorKey = colorKey;
                curStackBallView.Push(curBall);
                curTube.RectTransform.pivot = new Vector2(curTube.RectTransform.pivot.x, curTube.RectTransform.pivot.y + 0.2f);//pivot yukar� cekiliyor
            }
            beherIndex++;
        }
    }

    private Color getColor(ColorKey key) {
        foreach(ColorData color in colorData) {
            if (color.colorKey == key)
                return color.colorValue;
        }
        Debug.Log("Color is not found.");
        return Color.white;
    }

    public Stack<BallView>[] getBalls() {
        return ballViews;
    }

    public List<TubeView> getTubes(){
        return tubeViews;
    }
}
