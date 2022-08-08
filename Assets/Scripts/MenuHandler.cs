using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitCliked()
    {
        DataManager.Instance.SavePlayerData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void OnEndEdit()
    {
        if (!inputField.text.Equals(DataManager.Instance.playerName))
        {
            DataManager.Instance.playerName = inputField.text;
            DataManager.Instance.playerScore = 0;

            UpdatePlayerNameAndScore();
        }
    }

    public void UpdatePlayerNameAndScore()
    {
        bestScoreText.text = "Best Score : " + DataManager.Instance.playerName + " : " + DataManager.Instance.playerScore;
    }
}
