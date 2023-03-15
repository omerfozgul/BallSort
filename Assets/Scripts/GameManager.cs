using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private ButtonManager buttonManager;
    [SerializeField] private float moveTime = 0.2f;
    [SerializeField] private TextMeshProUGUI Title;
    [SerializeField] private GameObject winPanel;

    private Tube[] Tubes;
    private List<TubeView> TubeViewList; 
    private BallView m_curBall;
    private int m_startStackIndex, m_endStackIndex;
    private int curStage = 0;//0: top secilmedi, 1 top secildi
    

    private void Awake() {
        StartCoroutine(changeColorTitle());
        buttonManager.createButtons();
    }
    public void playBall(Tube tubeRef){
        string tubeTag = PlayerPrefs.GetString("CurrentBeherTag");
        if(curStage == 0){
            m_startStackIndex = TubeTagToIndex(tubeTag);
            Stack<BallView>startStack = Tubes[m_startStackIndex].getBallStack();
            TubeView curTubeView = TubeViewList[m_startStackIndex];
            if (startStack.Count > 0) {
                m_curBall = startStack.Pop();
                PickBallOfTube(m_curBall.RecTransform, curTubeView.RectTransform, curTubeView.TopOfTubeRectTransform);
                curStage = 1;
            }
        }
        else{
            m_endStackIndex = TubeTagToIndex(tubeTag);
            if (m_startStackIndex == m_endStackIndex){
                //Ayni index geldiyse top tube'a geri birakiliyor
                TubeView startTubeView = Tubes[m_startStackIndex].TubeView;
                Stack<BallView> startStack = Tubes[m_startStackIndex].getBallStack();
                moveCurrentBall(m_curBall.RecTransform, startTubeView.RectTransform);
                startStack.Push(m_curBall);
            }
            else{
                //Farkli tube ise diger behere birakiliyor
                TubeView curTubeView = TubeViewList[m_endStackIndex];
                Stack<BallView> endStack = Tubes[m_endStackIndex].getBallStack();
                if (endStack.Count == 0 || (endStack.Count < 4 && m_curBall.ColorKey == endStack.Peek().ColorKey)){
                    //Ya tube bos olmali yada tube'un en tepesindeki ball'un rengi ile curBall'in rengi ayni olmali
                    endStack.Push(m_curBall);
                    m_curBall.RecTransform.SetParent(curTubeView.RectTransform);
                    moveCurrentBall(m_curBall.RecTransform, curTubeView.RectTransform);
                }
                else {//Degilse, geldigi tube'a geri birakiliyor
                    TubeView startTubeView = Tubes[m_startStackIndex].TubeView;
                    Stack<BallView> startStack = Tubes[m_startStackIndex].getBallStack();
                    moveCurrentBall(m_curBall.RecTransform, startTubeView.RectTransform);
                    startStack.Push(m_curBall);
                }
            }
            curStage = 0;
        }

        if(isGameFinished()){
            foreach(Tube tube in Tubes)
                tube.OnPointerDown -= playBall;
            winPanel.SetActive(true);
        }
            
    }
    public void startLevel(int levelNum){
        levelManager.createLevel(levelNum);
        Tubes = levelManager.GetTubes();
        TubeViewList = levelManager.GetTubeViews();
        foreach(Tube tube in Tubes){
            tube.OnPointerDown += playBall;
        }
    }

    public void setBallsAndTubes(Tube[] tubes, List<TubeView> tubeViews){
        Tubes = tubes;
        TubeViewList = tubeViews;
        foreach(Tube tube in Tubes){
            tube.OnPointerDown += playBall;
        }
    }

    public void cleanScreen(){
        while(TubeViewList.Count > 0){
            TubeView tubeView = TubeViewList[0];
            Destroy(tubeView.TubeGameObject);
            TubeViewList.RemoveAt(0);
        }
        winPanel.SetActive(false);
        curStage = 0;
    }
    public void startNextLevel(){
        cleanScreen();
        startLevel(levelManager.CurrentLevelIndex+1);
    }
    public int GetCurrentLevelIndex(){
        return levelManager.CurrentLevelIndex;
    }

    private IEnumerator changeColorTitle(){
        while(true){
            Color randColor = UnityEngine.Random.ColorHSV();//generate random color
            Title.color = randColor;
            yield return new WaitForSeconds(1f);
        }
    }
    
    private bool isGameFinished(){
        bool win = false;
        for (int i = 0; i < Tubes.Length; i++) {
            win = testStack(Tubes[i].getBallStack());
            if (!win)
                return false;
        }
        return true;
    }

    private bool testStack(Stack<BallView> ballStack) {
        Stack<BallView> copyOfStack = new Stack<BallView>(ballStack);//copy of original stack
        if (copyOfStack.Count == 0 || copyOfStack.Count == 4){
            if (copyOfStack.Count == 4){
                ColorKey colorKey = copyOfStack.Pop().ColorKey;
                while (copyOfStack.Count > 0){
                    if (!(colorKey == copyOfStack.Pop().ColorKey)){
                        return false;
                    }
                }
            }
            return true;
        }
        return false;
    }
    private Sequence PickBallOfTube(RectTransform ballTransform, RectTransform tubeTransform, RectTransform topOfTubeTransform){
        Sequence seq = DOTween.Sequence();
        seq.Append(ballTransform.DOLocalMoveY(topOfTubeTransform.localPosition.y, moveTime));
        seq.AppendCallback(() => tubeTransform.pivot = new Vector2(tubeTransform.pivot.x, tubeTransform.pivot.y - 0.2f));
        return seq;
    }

    private Sequence moveCurrentBall(RectTransform ballTransform, RectTransform tubeTransform)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(ballTransform.DOLocalMoveX(0, moveTime));
        seq.Append(ballTransform.DOLocalMoveY(tubeTransform.pivot.y, moveTime));
        seq.AppendCallback(() => tubeTransform.pivot = new Vector2(tubeTransform.pivot.x, tubeTransform.pivot.y + 0.2f));
        return seq;
    }
    private int TubeTagToIndex(string tubeTag) {//converts tag-beher to beher-index
        if (tubeTag == null)
            return -1;
        string strIndex = tubeTag.Substring(4);
        int index = int.Parse(strIndex);
        return index;
    }
}