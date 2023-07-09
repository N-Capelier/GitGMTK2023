using System.Collections;
using System.Collections.Generic;
using Runtime.GameManagement;
using Runtime.Player;
using UnityEngine;

namespace Runtime.Entities
{
	public class Human : Entity
	{
		[Header("Components")]
		[SerializeField]
		private ParticleSystem _particule_walkDust;

		public override void Initialize(PlayerInstance owner, bool useRegisteredHealthPoints = false)
		{
			base.Initialize(owner, useRegisteredHealthPoints);

			if (useRegisteredHealthPoints)
				HealthBar.Initialize(GameManager.Instance.OnHumanDeath, HealthBar.CurrentHealthPoints);
			else
				HealthBar.Initialize(GameManager.Instance.OnHumanDeath);

			_particule_walkDust.Stop();
		}

		private void OnMovementInputChangedFeedbacks(Vector2 input)
		{
			if(input.magnitude > 0.2)
            {
				_particule_walkDust.Play();
			}
            else
            {
				_particule_walkDust.Stop();
			}
	
		}
	}
}
