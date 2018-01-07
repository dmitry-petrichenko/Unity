using System.Linq;
using Units;
using UnityEngine;

namespace Tests.Animation
{
	public class MainTestController : MonoBehaviour
	{
		public GameObject animatedUnit;
		public UnitAnimationController unitAnimationController;
		
		// Use this for initialization
		void Start ()
		{
			var center = GameObject.FindGameObjectsWithTag("Respawn").FirstOrDefault();
			var gameObject = Instantiate(animatedUnit, new Vector3(0, 0, 0), Quaternion.identity,
				center.transform);
			unitAnimationController = new UnitAnimationController();
			unitAnimationController.Initialize(gameObject);
		}

		public void PlayIdleAnimation()
		{
			unitAnimationController.PlayIdleAnimation();
		}
        
		public void PlayAttackAnimation()
		{
			unitAnimationController.PlayAttackAnimation();
		}
        
		public void PlayWalkAnimation()
		{
			unitAnimationController.PlayWalkAnimation();
		}

	}
}