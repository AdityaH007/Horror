using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class NewBehaviourScript : MonoBehaviour
{
	public float walkingSpeed = 7.5f;

	public float runningSpeed = 11.5f;

	public float jumpSpeed = 8f;

	public float gravity = 20f;

	public Camera playerCamera;

	private bool isCrouching;

	public float lookSpeed = 2f;

	public float lookXLimit = 45f;

	private CharacterController characterController;

	private Vector3 moveDirection = Vector3.zero;

	private float rotationX;

	[HideInInspector]
	public bool canMove = true;

	private void Start()
	{
		characterController = GetComponent<CharacterController>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void Update()
	{
		Vector3 vector = base.transform.TransformDirection(Vector3.forward);
		Vector3 vector2 = base.transform.TransformDirection(Vector3.right);
		bool key = Input.GetKey(KeyCode.LeftShift);
		float num = (canMove ? ((key ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical")) : 0f);
		float num2 = (canMove ? ((key ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal")) : 0f);
		float y = moveDirection.y;
		moveDirection = vector * num + vector2 * num2;
		if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
		{
			moveDirection.y = jumpSpeed;
		}
		else
		{
			moveDirection.y = y;
		}
		if (!characterController.isGrounded)
		{
			moveDirection.y -= gravity * Time.deltaTime;
		}
		characterController.Move(moveDirection * Time.deltaTime);
		if (canMove)
		{
			rotationX += (0f - Input.GetAxis("Mouse Y")) * lookSpeed;
			rotationX = Mathf.Clamp(rotationX, 0f - lookXLimit, lookXLimit);
			playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
			base.transform.rotation *= Quaternion.Euler(0f, Input.GetAxis("Mouse X") * lookSpeed, 0f);
		}
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			ToggleCrouch();
		}
		void ToggleCrouch()
		{
			isCrouching = !isCrouching;
			float height = (isCrouching ? 0.5f : 2f);
			characterController.height = height;
			float y2 = (isCrouching ? 0.5f : 0.5f);
			playerCamera.transform.localPosition = new Vector3(0f, y2, 0f);
		}
	}
}
