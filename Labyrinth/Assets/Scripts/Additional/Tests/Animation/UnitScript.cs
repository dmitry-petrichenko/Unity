using UnityEngine;

public class UnitScript : MonoBehaviour
{
	private Animator _animator;
	
	void Awake () {
		_animator = GetComponent<Animator>();
	}

	public void playWalkingAnimation()
	{
		_animator.SetBool("IsWalking", true);
	}
	
	public void playIdleAnimation()
	{
		_animator.SetBool("IsWalking", false);
	}
	
	public void playAttackAnimation()
	{
		_animator.SetBool("IsAttacking", true);
	}
}
