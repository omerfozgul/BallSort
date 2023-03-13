using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private ButtonManager buttonManager;
    [SerializeField] private float moveTime = 0.2f;
    [SerializeField] private TextMeshProUGUI Title;
    [SerializeField] private GameObject winPanel;

    private Tube[] balls;
    private List<TubeView> TubeViewList; 
    private BallView _curBall;
    private TubeView _startTubeView;
    private Stack<BallView> _startStack;
    private int _startStackIndex, _endStackIndex;
    private int curStage = 0;//0: top secilmedi, 1 top secildi
    private bool isPanelOpenable = true;//Panelin sadece bir kere acilmasini saglar
    public LevelManager LevelManager { get => levelManager;}
    public GameObject WinPanel { get => winPanel;}
    

    private void Awake() {
        StartCoroutine(changeColorTitle());
        PlayerPrefs.SetInt("isLevelScene", 0);
        buttonManager.createButtons();
    }


    //Deneme Start
    

    public void deneme(TubeControl tubeControlRef){
        string tubeTag = PlayerPrefs.GetString("CurrentBeherTag");
        if(curStage == 0){
            Debug.Log("1.beher: " + tubeTag);
            curStage = 1; 
        }
        else{
            Debug.Log("2.beher: " + tubeTag);
            curStage = 0;
        }
    }

    //Deneme End



    public void setBallsAndTubes(Tube[] balls, List<TubeView> tubes){
        this.balls = balls;
        TubeViewList = tubes;

        foreach(Tube tube in balls){
            if(tube.TubeConrtol == null)    
                Debug.Log("NULL");
            else{
                tube.TubeConrtol.OnPointerDown += deneme;
                Debug.Log("asdfsadfsd");
            }
                
        }
    }
    private void Update() {
        if(PlayerPrefs.GetInt("isLevelScene") == 1){
            playGame();
        
            if(isGameFinished() && isPanelOpenable) {
                winPanel.SetActive(true);
                isPanelOpenable = false;
            }
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
        isPanelOpenable = true;
    }
    public void getReadyLevel(){
        balls = levelManager.getBalls();
        TubeViewList = levelManager.getTubes();
    }
    public void startNextLevel(){
        cleanScreen();
        levelManager.createNextLevel();
        balls = levelManager.getBalls();
        TubeViewList = levelManager.getTubes();
    }

    private IEnumerator changeColorTitle(){
        while(true){
            Color randColor = Random.ColorHSV();//generate random color
            Title.color = randColor;
            yield return new WaitForSeconds(1f);
        }
    }
    

    private void playGame() {
        if (curStage == 0)
        {
            if (TubeManager.startIndexTube != -1)
            {
                int startIndex = TubeManager.startIndexTube;
                _startStack = balls[startIndex].getBallStack();
                TubeView curTubeView = TubeViewList[startIndex];
                _startTubeView = curTubeView;
                if (_startStack.Count > 0)
                {
                    _curBall = _startStack.Pop();
                    StartCoroutine(PickBallOfTube(_curBall.RecTransform, curTubeView.RectTransform, curTubeView.TopOfTubeRectTransform));
                    curStage = 1;

                    _startStackIndex = startIndex;
                }

            }
        }
        else if (curStage == 1)
        {
            if (TubeManager.endIndexTube != -1)
            {
                if (TubeManager.startIndexTube == TubeManager.endIndexTube)
                {//Ayni index geldiyse top tube'a geri birakiliyor
                    StartCoroutine(moveCurrentBall(_curBall.RecTransform, _startTubeView.RectTransform));
                    _startStack.Push(_curBall);
                }
                else
                {//Farkli tube ise diger behere birakiliyor
                    int endIndex = TubeManager.endIndexTube;
                    TubeView curTubeView = TubeViewList[endIndex];
                    Stack<BallView> endStack = balls[endIndex].getBallStack();
                    if (endStack.Count == 0 || (endStack.Count < 4 && _curBall.ColorKey == endStack.Peek().ColorKey))
                    {
                        //Ya tube bos olmali yada tube'un en tepesindeki ball'un rengi ile curBall'in rengi ayni olmali
                        endStack.Push(_curBall);
                        _curBall.RecTransform.SetParent(curTubeView.RectTransform);
                        StartCoroutine(moveCurrentBall(_curBall.RecTransform, curTubeView.RectTransform));
                    }
                    else
                    {
                        StartCoroutine(moveCurrentBall(_curBall.RecTransform, _startTubeView.RectTransform));
                        _startStack.Push(_curBall);
                    }
                }

                curStage = 0;
                TubeManager.startIndexTube = -1;
                TubeManager.endIndexTube = -1;
            }
        }
    }
    
    private bool isGameFinished(){
        bool win = false;
        for (int i = 0; i < balls.Length; i++) {
            win = testStack(balls[i].getBallStack());
            if (!win)
                return false;
        }
        return true;
    }

    private bool testStack(Stack<BallView> ballStack) {
        Stack<BallView> copyOfStack = new Stack<BallView>(ballStack);//copy of original stack
        if (copyOfStack.Count == 0 || copyOfStack.Count == 4)
        {
            if (copyOfStack.Count == 4)
            {
                ColorKey colorKey = copyOfStack.Pop().ColorKey;
                while (copyOfStack.Count > 0)
                {
                    if (!(colorKey == copyOfStack.Pop().ColorKey))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        return false;
    }

    private IEnumerator PickBallOfTube(RectTransform ballTransform, RectTransform tubeTransform, RectTransform topOfTubeTransform) {
        ballTransform.DOLocalMoveY(topOfTubeTransform.localPosition.y, moveTime);//ball tube'un tepesine gelir
        yield return new WaitForSeconds(moveTime);
        tubeTransform.pivot = new Vector2(tubeTransform.pivot.x, tubeTransform.pivot.y - 0.2f);//pivot asagi cekiliyor
    }

    private IEnumerator moveCurrentBall(RectTransform ballTransform, RectTransform tubeTransform)
    {
        ballTransform.DOLocalMoveX(0, moveTime);
        yield return new WaitForSeconds(moveTime);
        ballTransform.DOLocalMoveY(tubeTransform.pivot.y, moveTime);
        yield return new WaitForSeconds(moveTime);
        tubeTransform.pivot = new Vector2(tubeTransform.pivot.x, tubeTransform.pivot.y + 0.2f);//pivot yukari cekiliyor
    }

    private Sequence moveCurrentBallv2(RectTransform ballTransform, RectTransform tubeTransform)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(ballTransform.DOLocalMoveX(0, moveTime));
        seq.Append(ballTransform.DOLocalMoveY(tubeTransform.pivot.y, moveTime));
        seq.AppendCallback(() => tubeTransform.pivot = new Vector2(tubeTransform.pivot.x, tubeTransform.pivot.y + 0.2f));
        return seq;
    }
}


