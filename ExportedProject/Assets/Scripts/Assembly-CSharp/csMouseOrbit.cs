using UnityEngine;

public class csMouseOrbit : MonoBehaviour
{
	public Transform Target;

	public float distance;

	public float xSpeed = 250f;

	public float ySpeed = 120f;

	public float yMinLimit = -20f;

	public float yMaxLimit = 80f;

	private float x;

	private float y;

	public float CameraDist = 10f;

	private void Start()
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		x = eulerAngles.x;
		y = eulerAngles.y;
		distance = 30f;
		if ((bool)GetComponent<Rigidbody>())
		{
			GetComponent<Rigidbody>().freezeRotation = true;
		}
	}

	private void LateUpdate()
	{
		if ((bool)Target)
		{
			x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
			y += Input.GetAxis("Mouse Y") * ySpeed * 0.05f;
			y = ClampAngle(y, yMinLimit, yMaxLimit);
			Quaternion quaternion = Quaternion.Euler(y, x, 0f);
			Vector3 position = quaternion * new Vector3(0f, 0f, 0f - distance) + Target.position;
			base.transform.rotation = quaternion;
			base.transform.position = position;
			distance = CameraDist;
		}
	}

	private float ClampAngle(float ag, float min, float max)
	{
		if (ag < -360f)
		{
			ag += 360f;
		}
		if (ag > 360f)
		{
			ag -= 360f;
		}
		return Mathf.Clamp(ag, min, max);
	}
}
