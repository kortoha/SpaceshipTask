using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private GameObject[] _satellitesArray;

    [SerializeField] private float _currentScale = 1f;

    private int _satellitesCount = 0;

    private void OnEnable()
    {
        transform.localScale = Vector3.zero;
        StartCoroutine(ScaleUp());
        ActivateSatellites();
    }

    private void ActivateSatellites()
    {
        if (_satellitesArray != null && _satellitesArray.Length > 0)
        {
            _satellitesCount = Random.Range(1, _satellitesArray.Length + 1);

            for (int i = 0; i < _satellitesCount; i++)
            {
                if (_satellitesArray[i] != null)
                {
                    _satellitesArray[i].SetActive(true);
                }
            }
        }
    }

    private System.Collections.IEnumerator ScaleUp()
    {
        float duration = 1f;
        float elapsedTime = 0f;
        Vector3 targetScale = Vector3.one * _currentScale;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / duration);
            transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, progress);
            yield return null;
        }

        transform.localScale = targetScale;
    }

    private void OnDisable()
    {
        if (_satellitesArray != null && _satellitesArray.Length > 0)
        {
            for (int i = 0; i < _satellitesCount; i++)
            {
                if (i < _satellitesArray.Length && _satellitesArray[i] != null)
                {
                    _satellitesArray[i].SetActive(false);
                }
            }
        }
    }
}
