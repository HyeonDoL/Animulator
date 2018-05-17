using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    private const float maxRotationY = 45.0f;
    private const float minRotationY = -45.0f;

    private float sensitivityX = 1.5f;
    private float sensitivityY = 1.5f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private Transform cameraTrans;

    private void Awake()
    {
        cameraTrans = Camera.main.transform;
    }

    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * sensitivityX;

        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minRotationY, maxRotationY);

        cameraTrans.rotation = Quaternion.Euler(-rotationY, rotationX, 0);
        transform.rotation = Quaternion.Euler(0, rotationX, 0);
    }
}