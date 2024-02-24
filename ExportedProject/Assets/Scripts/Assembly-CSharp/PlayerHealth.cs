using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public int max = 100;

	private int current;

	public Text healthtext;

	private void Start()
	{
		current = max;
		UpdateHealthText();
	}

	private void Update()
	{
		UpdateHealthText();
	}

	private void UpdateHealthText()
	{
		if (healthtext != null)
		{
			healthtext.text = " MY Health: " + current;
		}
	}

	public void Damage(int damage)
	{
		current -= damage;
		if (current <= 0)
		{
			Die();
		}
		UpdateHealthText();
	}

	private void Die()
	{
		Application.Quit();
	}

	public void addHealth(int gain)
	{
		current += gain;
	}
}
