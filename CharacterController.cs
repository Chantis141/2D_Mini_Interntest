using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D PlayerRb;
    public float speed = 1;
    public float input;
    public float JumpForce;
    public SpriteRenderer spriteRenderer;
    public LayerMask groundLayer;
    public Transform feetPosition;
    public float groundCheckCircle;

    enum PlayerState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    bool isGrounded;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");

        if (input < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (input > 0)
        {
            spriteRenderer.flipX = false;
        }

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            jumpSoundEffect.Play();
            PlayerRb.velocity = new Vector2(PlayerRb.velocity.x, JumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        PlayerState state;

        if (Mathf.Abs(input) > 0f)
        {
            state = PlayerState.running;
        }
        else
        {
            state = PlayerState.idle;
        }

        if (PlayerRb.velocity.y > 0.1f)
        {
            state = PlayerState.jumping;
        }
        else if (PlayerRb.velocity.y < -0.1f)
        {
            state = PlayerState.falling;
        }

        anim.SetInteger("PlayerState", (int)state);
    }

    void FixedUpdate()
    {
        PlayerRb.velocity = new Vector2(input * speed, PlayerRb.velocity.y);
    }
}