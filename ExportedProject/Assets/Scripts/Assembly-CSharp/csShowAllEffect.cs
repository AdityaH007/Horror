using UnityEngine;
using UnityEngine.UI;

public class csShowAllEffect : MonoBehaviour
{
	public string[] EffectNames;

	public string[] Effect2Names;

	public Transform[] Effect;

	public Text Text1;

	private int i;

	private int a;

	private void Start()
	{
		Object.Instantiate(Effect[i], new Vector3(0f, 5f, 0f), Quaternion.identity);
	}

	private void Update()
	{
		Text1.text = i + 1 + ":" + EffectNames[i];
		if (Input.GetKeyDown(KeyCode.Z))
		{
			if (i <= 0)
			{
				i = 99;
			}
			else
			{
				i--;
			}
			for (a = 0; a < Effect2Names.Length; a++)
			{
				if (EffectNames[i] == Effect2Names[a])
				{
					Object.Instantiate(Effect[i], new Vector3(0f, 0.01f, 0f), Quaternion.identity);
					break;
				}
			}
			if (a++ == Effect2Names.Length)
			{
				Object.Instantiate(Effect[i], new Vector3(0f, 5f, 0f), Quaternion.identity);
			}
		}
		if (Input.GetKeyDown(KeyCode.X))
		{
			if (i < 99)
			{
				i++;
			}
			else
			{
				i = 0;
			}
			for (a = 0; a < Effect2Names.Length; a++)
			{
				if (EffectNames[i] == Effect2Names[a])
				{
					Object.Instantiate(Effect[i], new Vector3(0f, 0.01f, 0f), Quaternion.identity);
					break;
				}
			}
			if (a++ == Effect2Names.Length)
			{
				Object.Instantiate(Effect[i], new Vector3(0f, 5f, 0f), Quaternion.identity);
			}
		}
		if (!Input.GetKeyDown(KeyCode.C))
		{
			return;
		}
		for (a = 0; a < Effect2Names.Length; a++)
		{
			if (EffectNames[i] == Effect2Names[a])
			{
				Object.Instantiate(Effect[i], new Vector3(0f, 0.01f, 0f), Quaternion.identity);
				break;
			}
		}
		if (a++ == Effect2Names.Length)
		{
			Object.Instantiate(Effect[i], new Vector3(0f, 5f, 0f), Quaternion.identity);
		}
	}
}
