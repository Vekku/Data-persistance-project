using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuHandler : MonoBehaviour
{

    public TextMeshProUGUI nameInputText;
    public TextMeshProUGUI highscoreText;
    public TMP_InputField nameField;

    // Start is called before the first frame update
    void Start()
    {
        nameField.text = GameManager.instance.currentName;
        if (GameManager.instance.highscoreName != null)
        {
            highscoreText.text = $"Highcore: {GameManager.instance.highscoreName} {GameManager.instance.highscore} points";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
        GameManager.instance.SaveCurrentName(nameInputText.text);
    }

    public void Exit()
    {
        GameManager.instance.Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif

    }
}
