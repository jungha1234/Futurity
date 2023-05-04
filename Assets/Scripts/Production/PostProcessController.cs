using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessController : MonoBehaviour
{
	private Volume volume;

	private bool isHited;
	private float curTime;
	private float vignetteTime;

	private void Start()
    {
        volume= GetComponent<Volume>();
	}

	private void Update()
	{
		if (isHited && volume.profile.TryGet(out Vignette vignette))
		{
			if (vignetteTime > curTime)
			{
				vignette.active = true;
				curTime += Time.deltaTime;
				vignette.intensity.value = 0 + curTime;
			}
			else
			{
				vignette.intensity.value = 0;
				curTime= 0;
				isHited = false;
			}
		}
	
	}

	public void SetVignette(float time)
	{
		vignetteTime = time;
		isHited = true;
	}
}
