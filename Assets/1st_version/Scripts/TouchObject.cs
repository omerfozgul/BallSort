using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchObject : MonoBehaviour
{
    static GameObject gameObj;
    static string startColorName;
    static int startInd, lastInd;
    static float startPositionX;
    static int durum = 0;
    //static bool busy = false;
    public Collider2D col;
    /*
     * 0 -> kimse secilmedi
     * 1 -> start secildi
     */

    private void OnMouseDown() {
        Stack<gameBall>[] arr = GameGenerator.getArr();
        Stack<gameBall> stack = arr[getBeherNo(transform.name)];
        
        if (durum == 0){
            col.isTrigger = false;
            startInd = getBeherNo(transform.name);
            if(stack.Count > 0) {
                gameBall ball = stack.Pop();
                gameObj = ball.getGameObject();
                startColorName = ball.getColorName();
                gameObj.transform.position = new Vector3(gameObj.transform.position.x, 3f, 0f);
                startPositionX = gameObj.transform.position.x;
                durum = 1;
            }
            
        }
        else if(durum == 1) {
            lastInd = getBeherNo(transform.name);
            gameBall ball = new gameBall(gameObj, startColorName);

            if(stack.Count == 0 || (stack.Count < 4 && stack.Peek().getColorName() == ball.getColorName())) {
                stack.Push(ball);
                gameObj.transform.position = new Vector3(transform.position.x, 3f, 0f);
            }
            else
                arr[startInd].Push(ball);
            
            col.isTrigger = true;
            durum = 0;
        }
    }

    private int getBeherNo(string beherName) {
        if(beherName == "beher1") 
            return 0;
        else if (beherName == "beher2")
            return 1;
        else if (beherName == "beher3")
            return 2;
        else if (beherName == "beher4")
            return 3;
        else if (beherName == "beher5")
            return 4;
        else if (beherName == "beher6")
            return 5;
        else 
            return 6;
    }

    public static void undo(){
        Stack<gameBall>[] arr = GameGenerator.getArr();
        Stack<gameBall> stackLast = arr[lastInd];
        Stack<gameBall> stackFirst = arr[lastInd];
        gameBall ball = stackLast.Pop();
        gameObj = ball.getGameObject();
        gameObj.transform.position = new Vector3(gameObj.transform.position.x, 3f, 0f);
        stackFirst.Push(ball);
        gameObj.transform.position = new Vector3(startPositionX, 3f, 0f);
    }
}
