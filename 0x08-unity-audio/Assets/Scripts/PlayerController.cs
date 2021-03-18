using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public CharacterController controller;
  public Animator anim;
  private bool groundedPlayer;
  private bool jumped;
  private Vector3 playerVelocity;
  public float playerSpeed = 6.0f;
  public float verticalSpeed = 0;
  public float jumpHeight = 1.5f;
  public float gravityValue = -9.81f;
  [SerializeField] AudioClip landingClip;

  private AudioSource audioSource;
  Vector3 originalPos;

  void Awake()
  {
    originalPos = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);
    audioSource = GetComponent<AudioSource>();
  }

  void Update()
  {
    if (controller.isGrounded && (Input.GetButton("Horizontal") || Input.GetButton("Vertical")))
		{
			anim.SetBool("Running", true);
		}
		else
		{
			anim.SetBool("Running", false);
		}
    Move();
    CheckInfiniteFalling();
  }

  void Move()
  {
    float horizontalMove = Input.GetAxis("Horizontal");
    float verticalMove = Input.GetAxis("Vertical");
    groundedPlayer = controller.isGrounded;

    if (groundedPlayer && playerVelocity.y < 0)
    {
      playerVelocity.y = 0f;
      anim.SetBool("IsJumping", false);
      anim.SetBool("Falling", false);
    }

    Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
    controller.Move(playerSpeed * Time.deltaTime * move);

    if (Input.GetButtonDown("Jump") && groundedPlayer)
    {
      playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
      anim.SetBool("IsJumping", true);
      jumped = true;
    }
    else if (!Input.GetButtonDown("Jump") && groundedPlayer)
    {
      if (jumped == true)
        audioSource.PlayOneShot(landingClip);
      jumped = false;
    }
    
    playerVelocity.y += gravityValue * Time.deltaTime;
    controller.Move(playerVelocity * Time.deltaTime);
  }

  void CheckInfiniteFalling()
  {
    if (transform.position.y <= -10)
    {
      anim.SetBool("Falling", true);
      if (transform.position.y <= -60)
      {
        transform.position = originalPos;
      }
    }
  }
}