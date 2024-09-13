using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _settingsPanel;

    public void Play()
    {
        SFX.Instance.ClickSound();

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SFX.Instance.ClickSound();

        Application.Quit();
    }

    public void OpenSettings()
    {
        SFX.Instance.ClickSound();

        _settingsPanel.SetActive(true);
        _menuPanel.SetActive(false);
    }

    public void CloseSettings()
    {
        SFX.Instance.ClickSound();

        _settingsPanel.SetActive(false);
        _menuPanel.SetActive(true);
    }
}
