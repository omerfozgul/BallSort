using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameGenerator : MonoBehaviour {
    public int beherSayisi = 5;
    public GameObject blue, red, yellow, green, orange, gray;
    public int level;
    private static Stack<gameBall>[] arr;

    private void Start() {

        arr = new Stack<gameBall>[beherSayisi];
        for (int i = 0; i < arr.Length; i++) {
            arr[i] = new Stack<gameBall>();
        }
        generateGame(level);
        //randomLevel();
    }

    public static Stack<gameBall>[] getArr() {
        return arr;
    }

    private void generateGame(int level){
        switch (level) {
            case 1:
                level1();
                break;
            case 2:
                level2();
                break;
            case 3:
                level3();
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
        }
    }

    private void level1(){
        GameObject ball1 = green, ball2 = orange;
        float posX = -2f, posY = -2f;
        int beher = 0;
        for (int i = 0; i < 8; i++)
        {
            GameObject gameObj;
            gameBall ball;
            if (i == 0 || i == 2 || i == 5 || i == 7)
            {//ball-1
                gameObj = Instantiate(ball1, new Vector3(posX, posY, 0f), Quaternion.identity);
                ball = new gameBall(gameObj, "green");
            }
            else
            {//ball-2
                gameObj = Instantiate(ball2, new Vector3(posX, posY, 0f), Quaternion.identity);
                ball = new gameBall(gameObj, "orange");
            }
            arr[beher].Push(ball);
            posY = posY + 1f;
            if (i == 3)
            {
                posX = 0f;
                posY = -2f;
                beher = 1;
            }
        }
    }
    private void level2() {
        GameObject ball1 = blue, ball2 = orange, ball3 = red;
        float posX = -4f, posY = -2f;
        int beher = 0;
        for (int i = 0; i < 12; i++)
        {
            GameObject gameObj;
            gameBall ball;
            if (i == 0 || i == 4 || i == 6 || i == 9)
            {//ball-1
                gameObj = Instantiate(ball1, new Vector3(posX, posY, 0f), Quaternion.identity);
                ball = new gameBall(gameObj, "blue");
            }
            else if(i == 2 || i == 3 || i == 8 || i == 11)
            {//ball-2
                gameObj = Instantiate(ball2, new Vector3(posX, posY, 0f), Quaternion.identity);
                ball = new gameBall(gameObj, "orange");
            }
            else
            {
                gameObj = Instantiate(ball3, new Vector3(posX, posY, 0f), Quaternion.identity);
                ball = new gameBall(gameObj, "red");
            }
            arr[beher].Push(ball);
            posY = posY + 1f;

             if (i == 3)
            {
                posX = -2f;
                posY = -2f;
                beher = 1;
            }
            if (i == 7)
            {
                posX = 0f;
                posY = -2f;
                beher = 2;
            }
        }
    }
    private void level3()
    {
        GameObject ball1 = blue, ball2 = orange, ball3 = red, ball4 = green, ball5 = gray;
        float posX = -6f, posY = -2f;
        int beher = 0;
        for (int i = 0; i < 20; i++)
        {
            GameObject gameObj;
            gameBall ball;
            if (i == 4 || i == 5 || i == 10 || i == 15)
            {//ball-1
                gameObj = Instantiate(ball1, new Vector3(posX, posY, 0f), Quaternion.identity);
                ball = new gameBall(gameObj, "blue");
            }
            else if (i == 1 || i == 3 || i == 7 || i == 11)
            {//ball-2
                gameObj = Instantiate(ball2, new Vector3(posX, posY, 0f), Quaternion.identity);
                ball = new gameBall(gameObj, "orange");
            }
            else if (i == 2 || i == 6 || i == 14 || i == 17)
            {//ball-3
                gameObj = Instantiate(ball3, new Vector3(posX, posY, 0f), Quaternion.identity);
                ball = new gameBall(gameObj, "red");
            }
            else if (i == 0 || i == 12 || i == 16 || i == 18)
            {//ball-4
                gameObj = Instantiate(ball4, new Vector3(posX, posY, 0f), Quaternion.identity);
                ball = new gameBall(gameObj, "green");
            }
            else
            {//ball-5
                gameObj = Instantiate(ball5, new Vector3(posX, posY, 0f), Quaternion.identity);
                ball = new gameBall(gameObj, "gray");
            }
            arr[beher].Push(ball);
            posY = posY + 1f;

            if (i == 3)
            {
                posX = -4f;
                posY = -2f;
                beher = 1;
            }
            if (i == 7)
            {
                posX = -2f;
                posY = -2f;
                beher = 2;
            }
            if (i == 11)
            {
                posX = 0f;
                posY = -2f;
                beher = 3;
            }
            if (i == 15)
            {
                posX = 2f;
                posY = -2f;
                beher = 4;
            }
        }
    }
    private void level4() { }
    private void level5() { }
    private void level6() { }
    private void level7() { }
    private void level8() { }
    private void level9() { }
    private void level10() { }

    private void randomLevel() {
        int[] count = new int[] { 4, 4, 4 };
        float posX = -4f;
        float posY = -2.5f;
        int beher = 0;
        for (int i = 0; i < 12; i++)
        {
            int rand = Random.Range(0, 3);
            while (count[rand] == 0)
            {
                rand = Random.Range(0, 3);
            }
            count[rand]--;
            GameObject gameObj;
            gameBall ball;
            switch (rand)
            {
                case 0://yellow
                    gameObj = Instantiate(yellow, new Vector3(posX, posY, 0f), Quaternion.identity);
                    ball = new gameBall(gameObj, "yellow");
                    arr[beher].Push(ball);
                    break;
                case 1://blue
                    gameObj = Instantiate(blue, new Vector3(posX, posY, 0f), Quaternion.identity);
                    ball = new gameBall(gameObj, "blue");
                    arr[beher].Push(ball);
                    break;
                case 2://red
                    gameObj = Instantiate(red, new Vector3(posX, posY, 0f), Quaternion.identity);
                    ball = new gameBall(gameObj, "red");
                    arr[beher].Push(ball);
                    break;
            }
            posY = posY + 1.25f;

            if (i == 3)
            {
                posX = -2f;
                posY = -2.5f;
                beher = 1;
            }
            if (i == 7)
            {
                posX = 0f;
                posY = -2.5f;
                beher = 2;
            }
        }
    }
}   