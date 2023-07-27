using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoment : MonoBehaviour
{
    public PlayerInput PlayerInput;
    public float speed = 1.0f;
    public Transform PlayMover;

    private float m_MovementSmoothing = 0.05f;
    private Rigidbody2D m_Rigidbody2D;
    private Vector3 velocity = Vector3.zero;

    public LayerMask LayerGround;
    public Transform transGroundcheck;
    public float radiusGroundCheck = 0.2f;

    private bool isGround = false;

    public float jumpForce = 500f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInput.dir.x == -1)
        {
            PlayMover.localScale = new Vector3(-1, 1, 1);
        }
        else if(PlayerInput.dir.x==1)
        {
            PlayMover.localScale = Vector3.one;
        }
        if (PlayerInput.dir.magnitude > 0)
        {
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(speed * PlayerInput.dir.x, m_Rigidbody2D.velocity.y);
            // And the smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);
        }
        else
        {
            m_Rigidbody2D.velocity = new Vector2(0,m_Rigidbody2D.velocity.y);
        }

    }
    public void Jump()
    {

        if (!isGround) return;
        m_Rigidbody2D.AddForce(new Vector2(0, jumpForce));
    }

    private void FixedUpdate()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transGroundcheck.position, radiusGroundCheck, LayerGround);
        if (collider2Ds.Length > 0)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }
}
