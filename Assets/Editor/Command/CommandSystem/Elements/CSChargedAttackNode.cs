using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CSChargedAttackNode : CSNode
{
	public override void Initialize(Vector2 position)
	{
		base.Initialize(position);

		CommandType = CSCommandType.ChargedAttack;
	}

	public override void Draw()
	{
		base.Draw();

		RefreshExpandedState();
	}
}
