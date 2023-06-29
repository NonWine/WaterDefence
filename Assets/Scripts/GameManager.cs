using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _TutorialPanel;
    private bool isFinish;
    public bool InGame;
    private void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        Time.timeScale = 0f;


    }

    public void GameLose()
    {
        if (isFinish)
            return;
        InGame = false;
        isFinish = true;
        _losePanel.SetActive(true);
        _gamePanel.SetActive(false);
    }

    public void GameWin()
    {
        if (isFinish)
            return;
        Player.Instance.GetComponent<PlayerController>().enabled = false;
        Player.Instance.GetComponent<ShootController>().enabled = false;
        Player.Instance.enabled = false;
        isFinish = true;
        _gamePanel.SetActive(false);
        _winPanel.SetActive(true);
 
    }

    public void NextLevel()
    {

        _winPanel.SetActive(false);
        _gamePanel.SetActive(true);

        LevelManager.Instance.LoadLevel();

    }
    

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void StartLevel()
    {
        InGame = true;
        _gamePanel.SetActive(true);
        _TutorialPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public bool GetFinish()
    {
        return isFinish;
    }

}