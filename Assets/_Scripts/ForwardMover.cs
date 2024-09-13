using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private Vector3 _moveDirection;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime, Space.World);
    }
}
