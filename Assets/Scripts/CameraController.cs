using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public PlayerController playerController;
    private float smoothSpeed;
    private float offset = 6;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        smoothSpeed = playerController.speed + 5;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(playerTransform.position.x + offset, transform.position.y, transform.position.z);
        Vector3 smoothPosition = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothPosition;
    }
}
