using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public InputActionReference move;
    public InputActionReference jump;

    public Animator anim;

    private Rigidbody2D rb;
    private Vector3 originalScale;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    void OnEnable() { 
        move.action.Enable(); 
        jump.action.Enable(); 
    }

    void OnDisable() { 
        move.action.Disable(); 
        jump.action.Disable(); 
    }

    void Update()
    {
        if (jump.action.WasPerformedThisFrame()) 
            Jump();
        anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
    }

    void FixedUpdate()
    {
        float x = move.action.ReadValue<float>();
        rb.linearVelocity = new Vector2(x * speed, rb.linearVelocity.y);


        if (x > 0.1f) 
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
        else if (x < -0.1f) 
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
    }

    void Jump()
    {
        bool grounded = Physics2D.OverlapCircle(
            groundCheck.position,
            0.1f,
            groundLayer
        );

        if (grounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

}
