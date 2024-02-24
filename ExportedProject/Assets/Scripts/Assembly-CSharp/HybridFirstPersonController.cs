using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class HybridFirstPersonController : MonoBehaviour
{
	public float walkSpeed = 5f;

	public float runSpeed = 10f;

	public float crouchSpeed = 2f;

	public float jumpForce = 5f;

	public float mouseSensitivity = 2f;

	public Camera playerCamera;

	private CharacterController characterController;

	private bool isCrouching;

	private float verticalRotation;

	private float verticalVelocity;

	public Zombiewalk zombie;

	public GameObject enemy;

	private bool controlsLocked = true;

	public AudioSource walkingAudio;

	public AudioSource runningAudio;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		StartCoroutine(DelayedUnlockControls());
		characterController = GetComponent<CharacterController>();
		if (playerCamera == null)
		{
			playerCamera = Camera.main;
		}
	}

	private void Update()
	{
		if (!controlsLocked)
		{
			PlayerMovement();
			PlayerRotation();
			if (Input.GetKeyDown(KeyCode.LeftControl))
			{
				ToggleCrouch();
			}
			if (Input.GetButton("Jump"))
			{
				Jump();
			}
		}
	}

	private void PlayerMovement()
	{
		float axis = Input.GetAxis("Horizontal");
		float axis2 = Input.GetAxis("Vertical");
		Vector3 normalized = new Vector3(axis, 0f, axis2).normalized;
		float num = (isCrouching ? crouchSpeed : (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed));
		Vector3 vector = base.transform.TransformDirection(normalized) * num;
		characterController.Move(vector * Time.deltaTime);
		if (characterController.isGrounded)
		{
			verticalVelocity = 0f;
			if (normalized.magnitude > 0f && !isCrouching && !Input.GetKey(KeyCode.LeftShift) && !walkingAudio.isPlaying)
			{
				walkingAudio.Play();
			}
			else if (normalized.magnitude == 0f || isCrouching || Input.GetKey(KeyCode.LeftShift))
			{
				walkingAudio.Stop();
			}
		}
		verticalVelocity += Physics.gravity.y * Time.deltaTime;
		characterController.Move(new Vector3(0f, verticalVelocity, 0f) * Time.deltaTime);
	}

	private void PlayerRotation()
	{
		float num = Input.GetAxis("Mouse X") * mouseSensitivity;
		float num2 = Input.GetAxis("Mouse Y") * mouseSensitivity;
		base.transform.Rotate(Vector3.up * num);
		verticalRotation -= num2;
		verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
		playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
	}

	private void Jump()
	{
		if (characterController.isGrounded)
		{
			verticalVelocity = Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y);
		}
		verticalVelocity += Physics.gravity.y * Time.deltaTime;
		if (characterController.isGrounded)
		{
			characterController.Move(new Vector3(0f, verticalVelocity, 0f) * Time.deltaTime);
		}
	}

	private void ToggleCrouch()
	{
		isCrouching = !isCrouching;
		float height = (isCrouching ? 0.5f : 2f);
		characterController.height = height;
		float y = (isCrouching ? 0.5f : 1f);
		playerCamera.transform.localPosition = new Vector3(0f, y, 0f);
	}

	private IEnumerator DelayedUnlockControls()
	{
		yield return new WaitForSeconds(30f);
		controlsLocked = false;
	}
}
