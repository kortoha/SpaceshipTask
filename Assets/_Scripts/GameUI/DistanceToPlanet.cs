using System;
using UnityEngine;
using UnityEngine.UI;

public class DistanceToPlanet : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _planet;

    [SerializeField] private Image _progressBar;

    private float _maxDistance;


    private void Start()
    {
        _maxDistance = Vector3.Distance(_player.position, _planet.position);
    }

    private void Update()
    {
        UpdateProgressBar();
    }

    private void UpdateProgressBar()
    {
        float distance = Vector3.Distance(_player.position, _planet.position);

        if (distance > _maxDistance)
        {
            _maxDistance = distance;
        }

        float fillAmount = Mathf.Clamp01(1 - (distance / _maxDistance));

        _progressBar.fillAmount = fillAmount;
    }
}
