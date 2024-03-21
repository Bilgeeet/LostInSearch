using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private byte	speed;
	[SerializeField] private byte	jumpForce;

   //[SerializeField] float rotationSpeed;

	float   horizontalInput;
	float   verticalInput;
    bool    isJumpInput = false;
	bool    isGrounded = true;

    private Animator animator;
	Vector3 moveDirection;
    
	Rigidbody rb;

    //public SceneBlink sceneBlink;
    //public GameObject imagePanel;
   
    

    // Fixed Update independent from FPS
    private void FixedUpdate()
    {
        MovePlayer();
        Grounded();

        if (isJumpInput && isGrounded)
		{
			rb.AddForce(new Vector3(0, 1, 0), ForceMode.Impulse);
		}

    }

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update()
    {
        MyInput();

		if (Input.GetKey(KeyCode.Space))
        {
            isJumpInput = true;
        }
        else
        {
			isJumpInput = false;
        }
        if(Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0
           || Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") == 0
           ||Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") != 0) {
            animator.SetBool("isWalking",true);
            //SoundManager.Instance.PlayMainMusic(SoundManager.MainSoundTypes.Walking);
        }
        else
        {
            animator.SetBool("isWalking",false);

        }
        
        //for sound
        bool isMoving = (horizontalInput != 0f || verticalInput != 0f);
        if (isMoving //&& !SoundManager.Instance.walkingSound.isPlaying 
        )
        {
            //SoundManager.Instance.walkingSound.Play();
        }
        else if (!isMoving //& SoundManager.Instance.walkingSound.isPlaying
        )
        {
            //SoundManager.Instance.walkingSound.Stop();
        }
    }

    public void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
    }

    
    private void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection.Normalize();
        
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        
        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }
    }

    private void Grounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1f))
        {
            if(hit.distance <= 0.5f)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
    }
}
