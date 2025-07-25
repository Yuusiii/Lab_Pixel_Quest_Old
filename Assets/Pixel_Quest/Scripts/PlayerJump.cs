using UnityEngine;


public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    public float JumpForce = 10f;
    public float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.08f;
    public Transform FeetCollider;
    public LayerMask GroundMask;
    private bool GroundCheck;
    public float FallForce = 2;
    public Vector2 GravityVector;
    public float jumpForce = 10;
    private bool WaterCheck;
    private string WaterTag = "Water";

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck = Physics2D.OverlapCapsule(FeetCollider.position, new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal, 0, GroundMask);
        if (Input.GetKeyDown(KeyCode.Space) && (GroundCheck|| WaterCheck))
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

            if (rb.velocity.y < 0 && !WaterCheck)   
            rb.velocity += GravityVector * (FallForce * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(WaterTag))
        {
            WaterCheck = true;
        }
    }
  private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(WaterTag))
        {
            WaterCheck = false;

        }

    }
}
