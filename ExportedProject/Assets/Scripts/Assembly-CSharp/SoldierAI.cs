using UnityEngine;

public class SoldierAI : MonoBehaviour
{
	public Transform player;

	private void Update()
	{
		Debug.DrawRay(base.transform.position, base.transform.forward * 5f, Color.red);
		base.transform.LookAt(player.position);
		base.transform.rotation = Quaternion.Euler(0f, base.transform.rotation.eulerAngles.y, 0f);
	}
}
