using UnityEngine;

public class OrbitMovement : MonoBehaviour
{
    public enum OrbitAxis { X, Y, Z }

    [SerializeField] private Transform _planet;

    [SerializeField] private float _orbitRadius = 10f;
    [SerializeField] private float _orbitSpeed = 5f;
    [SerializeField] private OrbitAxis _selectedAxis; 

    private float _angle;

    private void OnEnable()
    {
        _angle = Random.Range(0f, 360f);

        _selectedAxis = (OrbitAxis)Random.Range(0, 3);

        gameObject.transform.position = _planet.position;
    }

    private void Update()
    {
        Orbit();
    }

    private void Orbit()
    {
        if (_planet == null) return;

        _angle += _orbitSpeed * Time.deltaTime;

        float x = _planet.position.x;
        float y = _planet.position.y;
        float z = _planet.position.z;

        switch (_selectedAxis)
        {
            case OrbitAxis.X:
                x = _planet.position.x + Mathf.Cos(_angle) * _orbitRadius;
                y = _planet.position.y + Mathf.Sin(_angle) * _orbitRadius;
                break;
            case OrbitAxis.Y:
                x = _planet.position.x + Mathf.Cos(_angle) * _orbitRadius;
                z = _planet.position.z + Mathf.Sin(_angle) * _orbitRadius;
                break;
            case OrbitAxis.Z:
                y = _planet.position.y + Mathf.Cos(_angle) * _orbitRadius;
                z = _planet.position.z + Mathf.Sin(_angle) * _orbitRadius;
                break;
        }

        transform.position = new Vector3(x, y, z);
    }
}
