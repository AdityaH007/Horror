using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
	public static float distancefrom;

	public float totarget;

	private void Update()
	{
		if (Physics.Raycast(base.transform.position, base.transform.TransformDirection(Vector3.forward), out var hitInfo))
		{
			Debug.DrawRay(base.transform.position, base.transform.TransformDirection(Vector3.forward) * 10f, Color.red);
			totarget = hitInfo.distance;
			distancefrom = totarget;
		}
	}
}
