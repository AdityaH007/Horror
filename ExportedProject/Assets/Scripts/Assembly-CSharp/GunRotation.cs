using System.Collections;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
	private bool isRotating;

	private void Update()
	{
		if (base.gameObject.activeSelf)
		{
			if (Input.GetKeyDown(KeyCode.Y) && !isRotating)
			{
				StartCoroutine(RotateX(90f, 1f));
			}
			if (Input.GetKeyDown(KeyCode.R) && !isRotating)
			{
				StartCoroutine(RotateY(360f, 1f));
			}
		}
	}

	private IEnumerator RotateX(float angle, float duration)
	{
		isRotating = true;
		Quaternion startRotation = base.transform.rotation;
		Quaternion endRotation2 = Quaternion.Euler(angle, 0f, 0f) * startRotation;
		float elapsedTime2 = 0f;
		while (elapsedTime2 < duration)
		{
			base.transform.rotation = Quaternion.Slerp(startRotation, endRotation2, elapsedTime2 / duration);
			elapsedTime2 += Time.deltaTime;
			yield return null;
		}
		base.transform.rotation = endRotation2;
		yield return new WaitForSeconds(0.5f);
		endRotation2 = Quaternion.Euler(-90f, 0f, 0f) * base.transform.rotation;
		elapsedTime2 = 0f;
		while (elapsedTime2 < duration)
		{
			base.transform.rotation = Quaternion.Slerp(endRotation2, startRotation, elapsedTime2 / duration);
			elapsedTime2 += Time.deltaTime;
			yield return null;
		}
		base.transform.rotation = startRotation;
		isRotating = false;
	}

	private IEnumerator RotateY(float angle, float duration)
	{
		isRotating = true;
		Quaternion startRotation = base.transform.rotation;
		Quaternion endRotation = Quaternion.Euler(0f, angle, 0f) * startRotation;
		float elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			base.transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		base.transform.rotation = endRotation;
		isRotating = false;
	}
}
