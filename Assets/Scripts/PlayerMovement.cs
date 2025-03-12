using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;

    public float groundDrag;

    public float playerHeight;
    public LayerMask isGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    public PlayerInteractions player;

    public AudioSource audio;
    public AudioClip walking;

    bool isWalking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        rb.freezeRotation = true;
        ResetJump();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, isGround);

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.Space) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();

            Invoke("ResetJump", jumpCooldown);
        }
        
        if(player.typing == false)
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                if(!isWalking)
                {
                    audio.clip = walking;
                    audio.Play();
                }
                isWalking = true;
            }

            if(Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.D) == false)
            {
                audio.Stop();
                isWalking = false;
            }
        }
        else if(player.typing == true)
        {
            audio.Stop();
            isWalking = false;
        }

        if(grounded)
        {
            rb.linearDamping = groundDrag;
        }
        else
        {
            rb.linearDamping = 0;
        }

        Debug.Log(grounded);
        Debug.Log(moveSpeed);
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if(player.typing == false)
        {
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if(grounded)
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            }
            else if(!grounded)
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
            }
        }
    }

    void Jump()
    {
        if(player.typing == false)
        {
            Debug.Log("jumped");
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    void ResetJump()
    {
        readyToJump = true;
    }
}
