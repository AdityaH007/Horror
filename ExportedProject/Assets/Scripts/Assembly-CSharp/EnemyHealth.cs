using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
	public int maxHealth = 100;

	private int currentHealth;

	public Text healthText;

	public GameObject particlePrefab;

	public float time = 1f;

	public GameObject zombie;

	public GameObject Enemy;

	public AudioSource explosion;

	public bool isAlive;

	public AudioSource pain;

	public Transform raycastorigin;

	private void Start()
	{
		explosion.enabled = true;
		particlePrefab.SetActive(value: false);
		currentHealth = maxHealth;
		UpdateHealthText();
	}

	private void Update()
	{
		if (Physics.Raycast(raycastorigin.position, base.transform.forward, out var hitInfo))
		{
			Debug.DrawRay(raycastorigin.position, base.transform.forward * 10f, Color.red);
			if (hitInfo.collider.CompareTag("Player"))
			{
				healthText.enabled = true;
			}
		}
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		pain.Play();
		if (currentHealth <= 0)
		{
			StartCoroutine(delay());
			explosion.Play();
			Die();
		}
		UpdateHealthText();
	}

	private void UpdateHealthText()
	{
		if (healthText != null)
		{
			healthText.text = " ENEMY Health: " + currentHealth;
		}
	}

	private void Die()
	{
		particlePrefab.SetActive(value: true);
		Object.Destroy(zombie);
		isAlive = false;
		StartCoroutine(explosionsound());
	}

	private IEnumerator explosionsound()
	{
		yield return new WaitForSeconds(2f);
		Object.Destroy(base.gameObject);
	}

	private IEnumerator delay()
	{
		yield return new WaitForSeconds(1.5f);
	}

	public int isAlivee()
	{
		if (isAlive)
		{
			return 1;
		}
		return 2;
	}
}
