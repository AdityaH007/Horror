using UnityEngine;

public class csParticleEffectPackLightControl : MonoBehaviour
{
	public Light _light;

	private float _time;

	public float Delay = 0.5f;

	public float Down = 1f;

	public Light _light2;

	public float Delay2;

	public float Delay3;

	public float Maxintensity;

	public float Up = 1f;

	private void Update()
	{
		_time += Time.deltaTime;
		if ((bool)_light && _time > Delay)
		{
			if (_light.intensity > 0f)
			{
				_light.intensity -= Time.deltaTime * Down;
			}
			if (_light.intensity <= 0f)
			{
				_light.intensity = 0f;
			}
		}
		if (!_light2)
		{
			return;
		}
		if (_time > Delay2 && _time < Delay2 + Delay3)
		{
			if (_light2.intensity <= Maxintensity)
			{
				_light2.intensity += Time.deltaTime * Up;
			}
			if (_light2.intensity > Maxintensity)
			{
				_light2.intensity = Maxintensity;
			}
		}
		if (_time > Delay2 + Delay3)
		{
			if (_light2.intensity > 0f)
			{
				_light2.intensity -= Time.deltaTime * Down;
			}
			if (_light2.intensity <= 0f)
			{
				_light2.intensity = 0f;
			}
		}
	}
}
