using System.Collections;
using System.Collections.Generic;
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
}
