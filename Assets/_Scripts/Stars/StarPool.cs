using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> _starPool; 
    [SerializeField] private float _activationInterval = 2f; 

    private void Start()
    {
        StartCoroutine(ActivateStarFromPool());
    }

    private IEnumerator ActivateStarFromPool()
    {
        while (true)
        {
            yield return new WaitForSeconds(_activationInterval);

            GameObject inactiveStar = _starPool.Find(star => !star.activeInHierarchy);

            if (inactiveStar != null)
            {
                inactiveStar.transform.position = gameObject.transform.position;
                inactiveStar.SetActive(true);

                float randomZRotation = Random.Range(0f, 360f);
                inactiveStar.transform.rotation = Quaternion.Euler(0f, 0f, randomZRotation);
            }
        }
    }
}
