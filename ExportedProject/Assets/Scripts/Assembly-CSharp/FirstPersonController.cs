using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
	public float walkSpeed = 5f;

	public float runSpeed = 10f;

	public float crouchSpeed = 2f;

	public float jumpForce = 5f;

	public float mouseSensitivity = 2f;

	private CharacterController characterController;

	private Camera playerCamera;

	private bool isCrouching;

	private float verticalRotation;

	private float verticalVelocity;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		characterController = GetComponent<CharacterController>();
		playerCamera = GetComponentInChildren<Camera>();
	}

	private void Update()
	{
		float axis = Input.GetAxis("Horizontal");
		float axis2 = Input.GetAxis("Vertical");
		Vector3 normalized = new Vector3(axis, 0f, axis2).normalized;
		float num = (isCrouching ? crouchSpeed : (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed));
		Vector3 vector = base.transform.TransformDirection(normalized) * num;
		characterController.Move(vector * Time.deltaTime);
		float num2 = Input.GetAxis("Mouse X") * mouseSensitivity;
		float num3 = Input.GetAxis("Mouse Y") * mouseSensitivity;
		base.transform.Rotate(Vector3.up * num2);
		verticalRotation -= num3;
		verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
		playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			ToggleCrouch();
		}
		if (Input.GetButton("Jump") && characterController.isGrounded)
		{
			verticalVelocity = jumpForce;
		}
		else
		{
			verticalVelocity = verticalVelocity;
		}
		if (!characterController.isGrounded)
		{
			verticalVelocity -= Physics.gravity.y * Time.deltaTime;
		}
		characterController.Move(normalized * Time.deltaTime);
	}

	private void ToggleCrouch()
	{
		isCrouching = !isCrouching;
		float height = (isCrouching ? 0.5f : 2f);
		characterController.height = height;
		float y = (isCrouching ? 0.5f : 1f);
		playerCamera.transform.localPosition = new Vector3(0f, y, 0f);
	}
}
