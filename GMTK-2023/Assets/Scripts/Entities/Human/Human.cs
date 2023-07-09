using System.Collections;
using System.Collections.Generic;
using Runtime.GameManagement;
using Runtime.Player;
using UnityEngine;

namespace Runtime.Entities
{
	public class Human : Entity
	{
		public override void Initialize(PlayerInstance owner, bool useRegisteredHealthPoints = false)
		{
			base.Initialize(owner, useRegisteredHealthPoints);

			if (useRegisteredHealthPoints)
				HealthBar.Initialize(GameManager.Instance.OnHumanDeath, HealthBar.CurrentHealthPoints);
			else
				HealthBar.Initialize(GameManager.Instance.OnHumanDeath);
		}
	}
}
