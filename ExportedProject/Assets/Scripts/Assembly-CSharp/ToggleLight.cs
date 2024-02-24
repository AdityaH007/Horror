using UnityEngine;

public class ToggleLight : MonoBehaviour
{
	public Light targetLight;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab) && targetLight != null)
		{
			targetLight.enabled = !targetLight.enabled;
		}
	}
}
