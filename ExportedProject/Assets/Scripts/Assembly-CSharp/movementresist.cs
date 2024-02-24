using UnityEngine;

public class movementresist : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		Vector3 position = base.transform.position;
		position.y = Mathf.Clamp(position.y, 0f, 0f);
		base.transform.position = position;
	}
}
