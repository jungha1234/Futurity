using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[FSMState((int)PlayerController.PlayerState.Dash)]
public class PlayerDashState : UnitState<PlayerController>
{
	private float currentTime;
	private const float dashTime = 0.2f;
	public override void Begin(PlayerController pc)
	{
		//base.Begin(pc);
		pc.animator.SetTrigger("Dash");
		currentTime = 0;
		pc.dashEffect.enabled = true;
		pc.rigid.velocity = pc.transform.forward * pc.playerData.DashSpeed;
		AudioManager.instance.PlayOneShot(pc.dash, pc.transform.position);
	}

	public override void Update(PlayerController pc)
	{
		if (currentTime > dashTime)
		{
			pc.BackToPreviousState();
		}
		currentTime += Time.deltaTime;
	}

	public override void FixedUpdate(PlayerController unit)
	{
	}

	public override void End(PlayerController pc)
	{
		//base.End(pc);
		pc.dashEffect.enabled = false;
		pc.rigid.velocity = Vector3.zero;
	}

	public override void OnTriggerEnter(PlayerController unit, Collider other)
	{
		throw new System.NotImplementedException();
	}
}
