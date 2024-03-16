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
    
    public static void ToStage1()
    {
        SceneManager.LoadScene("Stage1");
    }

    public static void ToStage2()
    {
        SceneManager.LoadScene("Stage2");
    }

    public static void ToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public static void ToGoal()
    {
        SceneManager.LoadScene("Goal");
    }

    public static void ToStageGoal()
    {
        SceneManager.LoadScene("StageGoal");
    }

    public static void ToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

}
