using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinScoreText;
    [SerializeField] private Transform _hook;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _hookSpeed = 5f;
    [SerializeField] private int _coinsScore = 0;

    private Transform _currentCoin;
    private Vector3 _hookStartLocalPos;
    private bool _isReturning = false;
    private bool _isHookBusy = false;

    private void Start()
    {
        _hookStartLocalPos = _hook.localPosition;
        _lineRenderer.enabled = false;
    }

    private void Update()
    {
        _coinScoreText.text = _coinsScore.ToString();

        if (_currentCoin != null)
        {
            if (!_isReturning)
            {
                _hook.gameObject.SetActive(true);
                _hook.position = Vector3.MoveTowards(_hook.position, _currentCoin.position, _hookSpeed * Time.deltaTime);
                _hook.LookAt(_currentCoin);

                if (Vector3.Distance(_hook.position, _currentCoin.position) < 0.1f)
                {
                    _currentCoin.GetComponent<ForwardMover>().enabled = false;
                    _isReturning = true;
                }
            }
            else
            {
                Vector3 targetPos = transform.TransformPoint(_hookStartLocalPos);
                _hook.position = Vector3.MoveTowards(_hook.position, targetPos, _hookSpeed * Time.deltaTime);
                _currentCoin.position = _hook.position;

                if (Vector3.Distance(_hook.position, targetPos) < 0.1f)
                {
                    _lineRenderer.enabled = false;
                    _currentCoin.gameObject.SetActive(false);
                    _coinsScore++;
                    _currentCoin = null;
                    _isReturning = false;
                    _isHookBusy = false;
                    _hook.gameObject.SetActive(false);
                    SFX.Instance.CoinSound();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isHookBusy && other.gameObject.layer == LayerMask.NameToLayer("Coin"))
        {
            _isHookBusy = true;
            _currentCoin = other.transform;
            _lineRenderer.enabled = true;
        }
    }
}
