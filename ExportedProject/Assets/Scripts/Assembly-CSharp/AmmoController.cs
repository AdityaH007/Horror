using UnityEngine;

public class AmmoController : MonoBehaviour
{
	public int maxAmmo = 100;

	public int maxLoaddedAmmo = 6;

	public int totalAmmo;

	public int loadedAmmo;

	private void Start()
	{
		totalAmmo = 60;
		loadedAmmo = maxLoaddedAmmo;
	}

	private void Update()
	{
		if (Input.GetButtonDown("Fire1") && loadedAmmo > 0)
		{
			Shoot();
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			Reload();
		}
	}

	private void Shoot()
	{
		loadedAmmo--;
		Debug.Log("Shot! Loaded Ammo:" + loadedAmmo + "Total Ammo" + totalAmmo);
	}

	private void Reload()
	{
		int num = maxLoaddedAmmo - loadedAmmo;
		if (totalAmmo >= num)
		{
			loadedAmmo = maxLoaddedAmmo;
			totalAmmo -= num;
		}
		else
		{
			loadedAmmo += totalAmmo;
			totalAmmo = 0;
		}
	}

	public void AddAmmo(int amount)
	{
		totalAmmo = Mathf.Min(totalAmmo + amount, maxAmmo);
	}
}
