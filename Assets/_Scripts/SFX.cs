using UnityEngine;

public class SFX : MonoBehaviour
{
    public static SFX Instance { get; set; }

    public bool isSoundOn = true;
    public bool isMusicOn = true;
    public bool isVibrationOn = true;

    [SerializeField] private GameObject _music;

    [Header("Sounds")]

    [SerializeField] private AudioSource _click;
    [SerializeField] private AudioSource _damage;
    [SerializeField] private AudioSource _win;
    [SerializeField] private AudioSource _coin;

    private const string SOUND_PREF = "SoundOn";
    private const string MUSIC_PREF = "MusicOn";
    private const string VIBRATION_PREF = "VibrationOn";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadSettings(); 
        }
        else
        {
            Destroy(gameObject);
        }

        _music.SetActive(isMusicOn);
    }

    public void Vibrate()
    {
        if (isVibrationOn)
        {
            Handheld.Vibrate();
        }
    }

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        PlayerPrefs.SetInt(SOUND_PREF, isSoundOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn;

        _music.SetActive(isMusicOn);

        PlayerPrefs.SetInt(MUSIC_PREF, isMusicOn ? 1 : 0);
        PlayerPrefs.Save();

        _music.SetActive(isMusicOn);
    }

    public void ToggleVibration()
    {
        isVibrationOn = !isVibrationOn;
        PlayerPrefs.SetInt(VIBRATION_PREF, isVibrationOn ? 1 : 0);
        PlayerPrefs.Save();

        if (isVibrationOn)
        {
            Vibrate();
        }
    }

    public void ClickSound()
    {
        if (isSoundOn)
        {
            _click.Play();
        }
    }

    public void DamageSound()
    {
        if (isSoundOn)
        {
            _damage.Play();
        }
    }

    public void WinSound()
    {
        if (isSoundOn)
        {
            _win.Play();
        }
    }

    public void CoinSound()
    {
        if (isSoundOn)
        {
            _coin.Play();
        }
    }

    private void LoadSettings()
    {
        isSoundOn = PlayerPrefs.GetInt(SOUND_PREF, 1) == 1;
        isMusicOn = PlayerPrefs.GetInt(MUSIC_PREF, 1) == 1;
        isVibrationOn = PlayerPrefs.GetInt(VIBRATION_PREF, 1) == 1;
    }
}
