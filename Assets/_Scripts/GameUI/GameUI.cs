using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _winPanel;

    public void Restart()
    {
        SFX.Instance.ClickSound();

        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void ToMenu()
    {
        SFX.Instance.ClickSound();

        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        SFX.Instance.ClickSound();

        Time.timeScale = 0f;

        _gamePanel.SetActive(false);
        _pausePanel.SetActive(true);
    }

    public void UnPause()
    {
        SFX.Instance.ClickSound();

        Time.timeScale = 1.0f;

        _gamePanel.SetActive(true);
        _pausePanel.SetActive(false);
    }

    public void Win()
    {
        SFX.Instance.WinSound();

        _gamePanel.SetActive(false);
        _winPanel.SetActive(true);
    }
}
