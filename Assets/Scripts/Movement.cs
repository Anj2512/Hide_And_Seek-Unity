using Fusion;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    public Camera Camera;

    private CharacterController _controller;

    public float PlayerSpeed = 20f;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    public override void Spawned()
    {
        if (HasStateAuthority)
        {
            Camera = Camera.main;
            Camera.GetComponent<CameraView>().Target = transform;
        }
    }

    public override void FixedUpdateNetwork()
    {
        Quaternion cameraRotationY = Quaternion.Euler(0, Camera.transform.rotation.eulerAngles.y, 0);
        Vector3 move = cameraRotationY * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Runner.DeltaTime * PlayerSpeed;

        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Runner.DeltaTime * PlayerSpeed;

        _controller.Move(move);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }
}
