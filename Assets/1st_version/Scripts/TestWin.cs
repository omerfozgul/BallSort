using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Threading;

public class TestWin : MonoBehaviour {
    public GameObject winBoard;
    public AudioSource winSound;
    bool win = false;

    private void Update() {
        Stack<gameBall>[] arr = GameGenerator.getArr();
        for(int i=0; i<arr.Length; i++) {
            win = testStack(arr[i]);
            if (!win)
                break;
        }
        if(win){
            winBoard.SetActive(true);
        }
    }

    private bool testStack(Stack<gameBall> stack) {
        Stack<gameBall> stack2 = new Stack<gameBall>(new Stack<gameBall>(stack));//copy of original stack
        if(stack2.Count == 0 || stack2.Count == 4) { 
            if(stack2.Count == 4) {
                string color = stack2.Pop().getColorName();
                while(stack2.Count > 0) { 
                    if(!(color == stack2.Pop().getColorName())){
                        return false;
                    }
                }
            }
            return true;
        }
        return false;
    }

}
