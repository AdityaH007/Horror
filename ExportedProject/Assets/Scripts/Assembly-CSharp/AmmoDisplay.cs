using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
	public AmmoController ammoController;

	public Text loadedAmmoText;

	public Text remainingAmmoText;

	private void Update()
	{
		UpdateAmmoUI();
	}

	private void UpdateAmmoUI()
	{
		if (ammoController != null)
		{
			loadedAmmoText.text = "Loaded Ammo: " + ammoController.loadedAmmo;
			remainingAmmoText.text = "Remaining Ammo: " + ammoController.totalAmmo;
		}
	}
}
