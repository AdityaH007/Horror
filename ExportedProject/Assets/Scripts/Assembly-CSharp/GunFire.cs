using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GunFire : MonoBehaviour
{
	public GameObject gun;

	public GameObject crosshair;

	public GameObject Muzzle;

	public AudioSource gunfire;

	public PostProcessProfile postProcessProfile;

	public bool isFiring;

	public AmmoController ammoController;

	public Transform raycastorigin;

	public float damagepershot = 20f;

	public LayerMask enemyLayer;

	public PlayerCasting playerCasting;

	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			if (!isFiring && ammoController != null && ammoController.loadedAmmo > 0)
			{
				StartCoroutine(FiringGun());
				ApplyColorDistortion();
				ShootRay();
			}
			else
			{
				Debug.Log("No ammo loaded. Press 'R' to reload.");
			}
		}
	}

	private IEnumerator FiringGun()
	{
		isFiring = true;
		gun.GetComponent<Animator>().Play("New Animation");
		crosshair.GetComponent<Animator>().Play("crosshair");
		Muzzle.SetActive(value: true);
		gunfire.Play();
		yield return new WaitForSeconds(0.1f);
		Muzzle.SetActive(value: false);
		yield return new WaitForSeconds(0.45f);
		gun.GetComponent<Animator>().Play("New State");
		isFiring = false;
	}

	private void ApplyColorDistortion()
	{
		if (postProcessProfile.TryGetSettings<ChromaticAberration>(out var outSetting))
		{
			outSetting.intensity.value = 1f;
		}
	}

	private void ShootRay()
	{
		if (Physics.Raycast(playerCasting.transform.position, playerCasting.transform.TransformDirection(Vector3.forward), out var hitInfo, float.PositiveInfinity, enemyLayer))
		{
			Debug.DrawRay(raycastorigin.position, base.transform.forward * 10f, Color.red);
			EnemyHealth component = hitInfo.collider.GetComponent<EnemyHealth>();
			if (component != null)
			{
				Debug.Log("Hit enemy: " + hitInfo.collider.gameObject.name);
				component.TakeDamage(20);
			}
		}
	}
}
