using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour {

    public void goMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void restrartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void undo() {
        Debug.Log("Undo");
        TouchObject.undo();
    }
    public void goLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void goLevel2() {
        SceneManager.LoadScene("Level2");
    }
    public void goLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void goLevel4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void goLevel5()
    {
        SceneManager.LoadScene("Level5");
    }
    public void goLevel6()
    {
        SceneManager.LoadScene("Level6");
    }
    public void goLevel7()
    {
        SceneManager.LoadScene("Level7");
    }
    public void goLevel8()
    {
        SceneManager.LoadScene("Level8");
    }
    public void goLevel9()
    {
        SceneManager.LoadScene("Level9");
    }
    public void goLevel10()
    {
        SceneManager.LoadScene("Level10");
    }
}
