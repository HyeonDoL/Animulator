using UnityEngine;
using System.Collections;

// FIXME : 추후 상태가 추가될 경우, 상태들을 객체로 분리하여 FSM 구현하기

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private float jumpHeight = 1f;

    [SerializeField]
    private Rigidbody rigidbody;

    private float horizontal;
    private float vertical;

    public bool IsGround { get; set; }
    public bool IsFalling { get; set; }

    private void Awake()
    {
        IsGround = true;
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && IsGround)
            StartCoroutine(Jump());
    }

    private void FixedUpdate()
    {
        Move();

        if (IsFalling)
            CheckGrounded();
    }

    public void Move()
    {
        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;

        transform.Translate(movement, Space.Self);
    }

    public IEnumerator Jump()
    {
        rigidbody.AddForce(transform.up * jumpHeight, ForceMode.Impulse);


        IsGround = false;

        yield return new WaitForSeconds(0.5f);

        IsFalling = true;

    }

    public void CheckGrounded()
    {
        float distanceToGround;
        float threshold = 1.2f;
        RaycastHit hit;

        if (Physics.Raycast((rigidbody.position), -Vector3.up, out hit, 100f))
        {
            distanceToGround = hit.distance;

            if (distanceToGround < threshold)
            {
                IsGround = true;
                IsFalling = false;
            }
        }
    }
}
