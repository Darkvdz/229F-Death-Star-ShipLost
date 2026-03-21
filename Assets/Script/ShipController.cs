using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    private Rigidbody rb;
    InputAction moveAction;
    

    [Header("[Engine Settings]")] 
    [SerializeField] private float engineForce;
    [SerializeField] private float engineTorque;

    [Header("[Drag Setting]")]
    // สูตร Fd = 1/2 * rho * v^2 * Cd * A
    [SerializeField] private float rho = 1000f; // p (rho) ความหนาแน่นของน้ำ
    [SerializeField] private float cd = 0.04f; // Cd สัมประสิทธิ์แรงต้านของรูปทรงเรือ
    [SerializeField] private float area = 2.5f; // A พื้นที่หน้าตัดของเรือ (ตารางเมตร)

    [SerializeField] private float bounceForce = 20000f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");

    }

    void FixedUpdate()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        float forwardInput = moveInput.y;
        float turnInput = moveInput.x;
        rb.AddRelativeForce(engineForce * forwardInput * -Vector3.forward);
        rb.AddRelativeTorque(engineTorque * turnInput * Vector3.up);

        float currentSpeed = rb.linearVelocity.magnitude;

        if (currentSpeed > 0.1f)
        {
            float speedSqared = currentSpeed * currentSpeed;
            Vector3 dragDirection = -rb.linearVelocity.normalized;

            float dragCalculation = 0.5f * rho * speedSqared * cd * area;
            Vector3 DragForce = dragDirection * dragCalculation;

            rb.AddForce(DragForce);
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Vector3 pushDirection = collision.contacts[0].normal;
            rb.linearVelocity = rb.linearVelocity * 0.5f; 
            rb.AddForce(pushDirection.normalized * bounceForce);
        }
    }
}
