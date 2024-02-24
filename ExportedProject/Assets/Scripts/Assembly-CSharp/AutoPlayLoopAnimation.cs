using UnityEngine;

public class AutoPlayLoopAnimation : MonoBehaviour
{
	public Animator animator;

	public string animationName = "34";

	private void Start()
	{
		if (animator != null)
		{
			animator.Play(animationName);
			animator.SetBool("Loop", value: true);
		}
	}
}
