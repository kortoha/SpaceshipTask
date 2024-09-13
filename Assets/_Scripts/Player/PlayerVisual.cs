using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private const string MOVE_BOOL = "IsMove";
    private const string DAMAGE_TRIGGER = "IsDamaged";

    [SerializeField] private Animator _animator;

    [SerializeField] private PlayerMovement _playerMovement;

    [SerializeField] private Transform _hook; 

    [SerializeField] private LineRenderer _lineRenderer; 

    private void Start()
    {
        _lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        UpdateVisual();
        DrawLine();
    }

    private void UpdateVisual()
    {
        _animator.SetBool(MOVE_BOOL, _playerMovement.IsMoving());
    }

    private void DrawLine()
    {
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, _hook.position);
    }

    public void DamageAnim()
    {
        _animator.SetTrigger(DAMAGE_TRIGGER);
    }
}
