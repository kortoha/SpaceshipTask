using UnityEngine;

public class AsteroidAndCoinSpawner : MonoBehaviour
{
    [SerializeField] private Collider _spawnArea; 
    [SerializeField] private GameObject[] _asteroidsArray; 
    [SerializeField] private GameObject _coinPrefab;

    [SerializeField] private Transform _parent;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 0f, 1); 
    }

    private void SpawnObject()
    {
        GameObject objectToSpawn = Random.value > 0.5f
            ? _asteroidsArray[Random.Range(0, _asteroidsArray.Length)]
            : _coinPrefab; 

        Vector3 spawnPosition = GetRandomPointInCollider();

        GameObject newObstacle = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        newObstacle.transform.SetParent(_parent);
    }

    private Vector3 GetRandomPointInCollider()
    {
        Vector3 point = new Vector3(
            Random.Range(_spawnArea.bounds.min.x, _spawnArea.bounds.max.x),
            Random.Range(_spawnArea.bounds.min.y, _spawnArea.bounds.max.y),
            Random.Range(_spawnArea.bounds.min.z, _spawnArea.bounds.max.z)
        );

        if (_spawnArea.bounds.Contains(point))
        {
            return point;
        }
        else
        {
            return GetRandomPointInCollider();
        }
    }
}
