using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SideScrollingCamera : MonoBehaviour
{
    public Transform trackedObject;

    private void LateUpdate()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = trackedObject.position.x + 6;
        transform.position = cameraPosition;
    }

}
