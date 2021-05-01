using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public PlayerHealth pHealth;
	public Slider slider;

	void Start()
	{
		slider.maxValue = pHealth.health;
	}

	// Update is called once per frame
	void Update()
    {
		slider.value = pHealth.health;
    }
}
