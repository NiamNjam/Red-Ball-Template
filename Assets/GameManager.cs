using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int hp;
    public int currentlevel;
    public List<string> levels;
    public static GameManager instance;
    public AudioSource WinS;
    public AudioClip WinC;

    //singleton

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            //Invoke("LoadScene", 1f);
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    public void Win()
    {
        print("touch");
        WinS.clip = WinC;
        WinS.Play();
        currentlevel++;
        Invoke("LoadScene", 1f);
        //SceneManager.LoadScene(levels[currentlevel]);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(levels[currentlevel]);
    }

    public void Lose()
    {
        hp--;
        if (hp > 0)
        {
            //SceneManager.LoadScene(levels[currentlevel]);
            Invoke("LoadScene", 1f);
        }
        else
        {
            //SceneManager.LoadScene(levels[0]);
            currentlevel = 0;
            Invoke("LoadScene", 1f);
        }
    }
}
