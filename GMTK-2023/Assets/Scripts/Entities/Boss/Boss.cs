using System.Collections;
using System.Collections.Generic;
using Runtime.GameManagement;
using Runtime.Player;
using UnityEngine;

namespace Runtime.Entities
{
	public class Boss : Entity
	{
		public override void Initialize(PlayerInstance owner, bool useRegisteredHealthPoints = false)
		{
			base.Initialize(owner, useRegisteredHealthPoints);

			HealthBar.Initialize(GameManager.Instance.OnBossDeath);
		}
	}
}
