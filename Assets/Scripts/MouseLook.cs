// Ellie McDonald
// 3/25/2021
// This class controls the camera using the player mouse
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Speed of the mouse
    public float mouseSensitivity = 100f;
    private float xRotation = 0;

    public Transform playerBody;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        offset = transform.position - playerBody.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; // if += rotation is opposite of desired direction
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // prevents over rotations so the camera doesn't rotate behind the player
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);
    }

    // Makes sure the camera moves last - meaning, after the player moves
    void LateUpdate()
    {
        transform.position = playerBody.transform.position + offset;
    }
}