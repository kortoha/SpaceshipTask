using UnityEngine;

public class PlayerGetDamaged : MonoBehaviour
{
    [SerializeField] private PlayerVisual _playerVisual;
    [SerializeField] private Transform _baseObject;
    [SerializeField] private float _moveSpeed = 50f; 

    private bool _isCanGetDamage = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            if (_isCanGetDamage)
            {
                GetDamage();
            }
        }
    }

    private void GetDamage()
    {
        _isCanGetDamage = false;

        _playerVisual.DamageAnim();

        Vector3 newPos = new Vector3(_baseObject.position.x, _baseObject.position.y, _baseObject.position.z - 50);

        StartCoroutine(MoveToPosition(newPos));
    }

    private System.Collections.IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        SFX.Instance.Vibrate();
        SFX.Instance.DamageSound();

        while (Vector3.Distance(_baseObject.position, targetPosition) > 0.1f)
        {
            _baseObject.position = Vector3.MoveTowards(_baseObject.position, targetPosition, _moveSpeed * Time.deltaTime);

            yield return null; 
        }

        _baseObject.position = targetPosition;

        _isCanGetDamage = true;
    }
}
