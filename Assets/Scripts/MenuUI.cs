using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.IO;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private InputField nameInput;


    // Start is called before the first frame update
    void Start()
    {
        LoadScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        DataManager.Instance.userName = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }

    private void LoadScore()
    {
        string pathBestScore = Application.persistentDataPath + "/bestScore.json";
        if (File.Exists(pathBestScore))
        {
            string json = File.ReadAllText(pathBestScore);
            PlayerScore bestScore = JsonUtility.FromJson<PlayerScore>(json);
            scoreText.text = "Best Score : " + bestScore.userName + " : " + bestScore.score;
        }

    }

    [System.Serializable]
    class PlayerScore
    {
        public int score;
        public string userName;
    }
}
