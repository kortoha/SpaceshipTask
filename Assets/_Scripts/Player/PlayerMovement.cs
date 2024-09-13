using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _returnRotationSpeed = 2f;
    [SerializeField] private float _inertiaDecayRate = 0.98f;

    [SerializeField] private GameUI _gameUI;
    [SerializeField] private ForwardMover _forwardMover;

    [SerializeField] private GameObject[] _spawnersArray;

    [SerializeField] private GameObject _obstaclesParent;

    private bool _isMoving = false;

    private Vector3 _currentVelocity;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Enable();
    }

    private void Update()
    {
        HandleMove();
        ClampPosition();

        Vector3 localPosition = transform.localPosition;
        localPosition.z = 0;
        transform.localPosition = localPosition;
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = _playerInput.Player.Move.ReadValue<Vector2>();
        return inputVector.normalized;
    }

    private void HandleMove()
    {
        Vector2 inputVector = GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0f);

        if (moveDir.magnitude > 0.1f)
        {
            _currentVelocity = moveDir * _moveSpeed;
            _isMoving = true;
        }
        else
        {
            _currentVelocity *= _inertiaDecayRate;
            _isMoving = false;
        }

        transform.position += _currentVelocity * Time.deltaTime;

        if (moveDir.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        }
        else
        {
            Quaternion returnRotation = Quaternion.Euler(0f, 0f, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, returnRotation, Time.deltaTime * _returnRotationSpeed);
        }
    }

    private void ClampPosition()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        viewPos.x = Mathf.Clamp(viewPos.x, 0f, 1f);
        viewPos.y = Mathf.Clamp(viewPos.y, 0f, 1f);

        transform.position = Camera.main.ViewportToWorldPoint(viewPos);
    }

    public bool IsMoving()
    {
        return _isMoving;
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.layer == LayerMask.NameToLayer("Earth"))
        {
            _gameUI.Win();
            _forwardMover.enabled = false;
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Deactivator"))
        {
            _obstaclesParent.SetActive(false);

            foreach (var item in _spawnersArray)
            {
                item.SetActive(false);
            }
        }
    }

    private void OnDestroy()
    {
        _playerInput.Dispose();
    }
}
