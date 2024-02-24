using System.Collections;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
	public Animator animator;

	public string firstAnimationName = "FirstAnimation";

	public string secondAnimationName = "SecondAnimation";

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			StartCoroutine(PlayFirstAnimation());
		}
	}

	private IEnumerator PlayFirstAnimation()
	{
		animator.SetTrigger(firstAnimationName);
		yield return new WaitForSeconds(5f);
		animator.Play(secondAnimationName);
	}
}
