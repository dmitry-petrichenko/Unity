using UnityEngine;

public class UnitScript : MonoBehaviour
{
	private Animator _animator;
	
	void Awake () {
		_animator = GetComponent<Animator>();
	}

	public void playWalkingAnimation()
	{
		//_animator.SetBool("IsWalking", true);
		//_animator.Play("Move", -1, 0f);
		_animator.SetInteger("animation", 15);
	}
	
	public void playIdleAnimation()
	{
		//_animator.Play("Idle", -1, 0f);
		_animator.SetInteger("animation", 2);
		//_animator.SetBool("IsWalking", false);
	}
	
	public void playAttackAnimation()
	{
		_animator.SetInteger("animation", 11);
		//_animator.Play("ATK1", -1, 0f);
		//_animator.SetBool("IsAttacking", true);
	}
}
