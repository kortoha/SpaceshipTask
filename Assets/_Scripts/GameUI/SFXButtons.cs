using UnityEngine;
using UnityEngine.UI;

public class SFXButtons : MonoBehaviour
{
    [Header("Buttons")]

    [SerializeField] private Button _vibrationButton;
    [SerializeField] private Button _soundButton;
    [SerializeField] private Button _musicButton;

    [Header("Images")]

    [SerializeField] private Image _vibrationButtonImage;
    [SerializeField] private Image _soundButtonImage;
    [SerializeField] private Image _musicButtonImage;

    [Header("Sprites")]

    [SerializeField] private Sprite _vibrationOnButtonSprite;
    [SerializeField] private Sprite _soundOnButtonSprite;
    [SerializeField] private Sprite _musicOnButtonSprite;

    [SerializeField] private Sprite _vibrationOffButtonSprite;
    [SerializeField] private Sprite _soundOffButtonSprite;
    [SerializeField] private Sprite _musicOffButtonSprite;

    private void Start()
    {
        _vibrationButton.onClick.AddListener(() =>
        {
            SFX.Instance.ClickSound();

            SFX.Instance.ToggleVibration();

            UpdateUI(_vibrationButtonImage, _vibrationOnButtonSprite, _vibrationOffButtonSprite, SFX.Instance.isVibrationOn);
        });

        _soundButton.onClick.AddListener(() =>
        {
            SFX.Instance.ToggleSound();

            UpdateUI(_soundButtonImage, _soundOnButtonSprite, _soundOffButtonSprite, SFX.Instance.isSoundOn);

            SFX.Instance.ClickSound();
        });

        _musicButton.onClick.AddListener(() =>
        {
            SFX.Instance.ClickSound();

            SFX.Instance.ToggleMusic();

            UpdateUI(_musicButtonImage, _musicOnButtonSprite, _musicOffButtonSprite, SFX.Instance.isMusicOn);
        });

        UpdateUI(_vibrationButtonImage, _vibrationOnButtonSprite, _vibrationOffButtonSprite, SFX.Instance.isVibrationOn);
        UpdateUI(_soundButtonImage, _soundOnButtonSprite, _soundOffButtonSprite, SFX.Instance.isSoundOn);
        UpdateUI(_musicButtonImage, _musicOnButtonSprite, _musicOffButtonSprite, SFX.Instance.isMusicOn);
    }

    private void UpdateUI(Image image, Sprite onSprite, Sprite offSprite, bool isOn)
    {
        switch (isOn)
        {
            case true:
                image.sprite = onSprite;
                break;

            case false:
                image.sprite = offSprite;
                break;
        }
    }
}
