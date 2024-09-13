using UnityEngine;

public class OutOfView : MonoBehaviour
{
    private void Update()
    {
        if (!IsVisibleFrom())
        {
            gameObject.SetActive(false);
        }
    }

    private bool IsVisibleFrom()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        return GeometryUtility.TestPlanesAABB(planes, GetComponent<Collider>().bounds);
    }
}
