using System.Collections;
using UnityEngine;

public class addhealth : MonoBehaviour
{
	public PlayerHealth CharacterController;

	public GameObject Heathbox;

	public GameObject player;

	public bool isTaking;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		StartCoroutine(destroy());
	}

	private IEnumerator destroy()
	{
		player.GetComponent<PlayerHealth>().addHealth(50);
		yield return new WaitForSeconds(0.1f);
		Heathbox.SetActive(value: false);
	}
}
