using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private SceneManagement instance;

    void Awake()
    {
        CheckInstance();
    }

    void CheckInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public static void ToMain()
    {
        SceneManager.LoadScene("Main");
    }

    public static void ToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public static void ToGoal()
    {
        SceneManager.LoadScene("Goal");
    }

    public static void ToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public static void ToMain2()
    {
        SceneManager.LoadScene("Main2");
    }
}
