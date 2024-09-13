using UnityEngine;

public class RotationAroundAxis : MonoBehaviour
{
    public enum RotationAxis
    {
        X_Axis,
        Y_Axis,
        Z_Axis
    }

    [SerializeField] private RotationAxis _rotationAxis; 
    [SerializeField] private float _rotationSpeed = 3;

    private void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        Vector3 axis = Vector3.zero;

        switch (_rotationAxis)
        {
            case RotationAxis.X_Axis:
                axis = Vector3.right;
                break;
            case RotationAxis.Y_Axis:
                axis = Vector3.up;
                break;
            case RotationAxis.Z_Axis:
                axis = Vector3.forward;
                break;
        }

        transform.Rotate(axis, _rotationSpeed * Time.deltaTime);
    }
}
