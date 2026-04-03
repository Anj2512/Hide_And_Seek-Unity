using UnityEngine;

public class CameraView : MonoBehaviour
{
    public Transform Target;
    public float MouseSensitivity = 2f;

    private float verticalRotation;
    private float horizontalRotation;

    void LateUpdate()
    {
        if (Target == null)
        {
            return;
        }
        if (Input.GetMouseButtonDown(1))
        {
            MouseSensitivity = 0f;
        }
        if (Input.GetMouseButtonDown(0))
        {
            MouseSensitivity = 2f;
        }

        transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y+ 2f, Target.transform.position.z);

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        verticalRotation -= mouseY * MouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -70f, 70f);

        horizontalRotation += mouseX * MouseSensitivity;

        transform.rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
    }
}
