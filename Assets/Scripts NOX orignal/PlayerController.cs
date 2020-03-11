using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public bool isGrounded;
	public bool isJumping;
	public bool isFalling;
	public float speed = 7f;
	public float jumpForce;
	private Animator anim;
	private Rigidbody2D rb2d;
	public LayerMask whatIsGround;
	private float moveInput;
	public float checkRadius;
	public Transform feetPos;

	public float jumpTimeCounter;
	public float jumpTime = .15f;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if(moveInput > 0){
			transform.eulerAngles = new Vector3(0,0,0);

		}else if (moveInput < 0){
			transform.eulerAngles = new Vector3(0,180,0);

		}

		anim.SetFloat ("Speed", Mathf.Abs(rb2d.velocity.x));
		anim.SetBool ("IsGrounded", isGrounded);
		anim.SetBool ("IsJumping", isJumping);
		anim.SetBool ("IsFalling", isFalling);

		isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

		if(isGrounded == true && Input.GetKeyDown(KeyCode.Space)){		
			isJumping = true;	
			jumpTimeCounter = jumpTime;
			rb2d.velocity = Vector2.up * jumpForce;
		
		}

		if(Input.GetKey(KeyCode.Space) && isJumping == true){

			if(jumpTimeCounter > 0){
				rb2d.velocity = Vector2.up * jumpForce;
				jumpTimeCounter -= Time.deltaTime;
				
			}else{
				isJumping = false;
			}

		
		}

		if(Input.GetKeyUp(KeyCode.Space)){
			isJumping = false;
		}

		if(isGrounded == true ){		
			
			jumpTimeCounter = jumpTime;
		
		
		}

/* 		if(rb2d.velocity.y != 0){
			if(rb2d.velocity.y >= 0.1){
				isGrounded = false;
			}else if (rb2d.velocity.y <= -0.1){
				isFalling = true;
				isGrounded = false;
			}
		} */
	}

	void FixedUpdate(){
		moveInput = Input.GetAxisRaw("Horizontal");
		rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
	}





}
