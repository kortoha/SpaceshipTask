using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPointsArray; 
    [SerializeField] private GameObject[] _planetsArray;

    [SerializeField] private float _minSpawnInterval = 2f; 
    [SerializeField] private float _maxSpawnInterval = 4f;

    [SerializeField] private Transform _parent;

    private void Start()
    {
        StartSpawningPlanets();
    }

    private void StartSpawningPlanets()
    {
        Invoke(nameof(SpawnPlanet), Random.Range(_minSpawnInterval, _maxSpawnInterval));
    }

    private void SpawnPlanet()
    {
        Transform spawnPoint = _spawnPointsArray[Random.Range(0, _spawnPointsArray.Length)];

        GameObject planetPrefab = _planetsArray[Random.Range(0, _planetsArray.Length)];

        GameObject newObstacle = Instantiate(planetPrefab, spawnPoint.position, spawnPoint.rotation);

        newObstacle.transform.SetParent(_parent);

        StartSpawningPlanets();
    }
}
