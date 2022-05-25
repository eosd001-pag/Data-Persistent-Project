using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{
    public Text firstPlace;
    public Text secondPlace;
    public Text thirdPlace;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.LoadSettings();
        firstPlace.text = "1. " + GameManager.Instance.highScoreName + "....." + GameManager.Instance.highScoreScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        GameManager.Instance.SaveSettings();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
