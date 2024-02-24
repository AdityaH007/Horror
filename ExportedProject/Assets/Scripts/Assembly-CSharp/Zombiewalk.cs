using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombiewalk : MonoBehaviour
{
	public float speed = 3f;

	public GameObject enemyObject;

	public Transform player;

	public Animator animator;

	public AudioSource walk;

	public bool isWalking;

	public RawImage Healthbar;

	public Text Heathtext;

	public Transform raycastorigin;

	public GameObject ammo;

	public GameObject health;

	public PlayerHealth CharacterController;

	public RawImage red;

	public SoldierAI enemychild;

	private bool isAttackingPlayer;

	private void Start()
	{
		animator = GetComponent<Animator>();
		ammo.SetActive(value: false);
		health.SetActive(value: false);
	}

	private void Update()
	{
		Vector3[] array = new Vector3[4]
		{
			base.transform.forward,
			-base.transform.forward,
			-base.transform.right,
			base.transform.right
		};
		foreach (Vector3 direction in array)
		{
			if (!Physics.Raycast(raycastorigin.position, direction, out var hitInfo, float.PositiveInfinity))
			{
				continue;
			}
			Debug.DrawRay(raycastorigin.position, base.transform.forward * 100f, Color.red);
			if (hitInfo.collider.CompareTag("Player"))
			{
				float num = Vector3.Distance(base.transform.position, player.position);
				isWalking = true;
				NavMeshAgent component = enemyObject.GetComponent<NavMeshAgent>();
				if (component != null)
				{
					component.enabled = true;
					if (num > 5f)
					{
						component.enabled = true;
						animator.Play("Zombie Running");
						walk.Play();
					}
					else if (num <= 5f)
					{
						animator.SetBool("Zombie Running", value: false);
						component.enabled = false;
						animator.Play("Zombie Attack");
						red.enabled = true;
						if (!isAttackingPlayer)
						{
							StartCoroutine(DamagePlayerWithDelay());
							component.enabled = true;
							animator.SetBool("Zombie Attack", value: false);
							animator.Play("Zombie Running");
						}
					}
				}
				else
				{
					Debug.LogWarning("NavMeshAgent component not found on the enemyObject.");
				}
			}
			else
			{
				isWalking = false;
			}
		}
	}

	private IEnumerator DamagePlayerWithDelay()
	{
		isAttackingPlayer = true;
		PlayerHealth component = player.GetComponent<PlayerHealth>();
		if (component != null)
		{
			component.Damage(10);
		}
		yield return new WaitForSeconds(1.5f);
		isAttackingPlayer = false;
		red.enabled = false;
	}

	private void OnDestroy()
	{
		ammo.SetActive(value: true);
		health.SetActive(value: true);
		enemyObject.GetComponent<NavMeshAgent>().enabled = false;
	}
}
