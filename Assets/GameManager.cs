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
    AudioSource source;
    public AudioClip WinSound;
    public AudioClip LoseSound;
    public AudioClip gameOverSound;
    //public AudioClip backgroundSound;

    public Transform transition;
    Vector3 targetScale;

    //singleton

    void Start()
    {
        source = GetComponent<AudioSource>();
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

    private void Update()
    {
        transform.localScale = Vector3.MoveTowards(transition.localScale, targetScale, 60 * Time.deltaTime);
    }
    public void Win()
    {
        print("touch");
        //source.clip = WinSound;
        //source.Play(); //jei garsas pastovus
        source.PlayOneShot(WinSound); //viena karta pagroja
        currentlevel++;
        Invoke("LoadScene", 1f);
        targetScale = Vector3.one * 30;
        //SceneManager.LoadScene(levels[currentlevel]);
    }



    void LoadScene()
    {
        targetScale = Vector3.zero;
        SceneManager.LoadScene(levels[currentlevel]);
    }

    public void Lose()
    {
        targetScale = Vector3.one * 30;
        hp--;
        if (hp > 0)
        {
            //SceneManager.LoadScene(levels[currentlevel]);
            Invoke("LoadScene", 1f);
            source.PlayOneShot(LoseSound);
        }
        else
        {
            //SceneManager.LoadScene(levels[0]);
            currentlevel = 0;
            Invoke("LoadScene", 1f);
            source.PlayOneShot(gameOverSound);
        }
    }
}
