using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class HeroSwordsman : Hero
{
	private static HeroSwordsman instance = null;

	private void Start()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance == this)
		{
			Destroy(gameObject); // ׃האכÿול מבתוךע
		}

		DontDestroyOnLoad(gameObject);

		InitializeManager();
	}

    private void InitializeManager()
    {
        
    }

	public HeroSwordsman GetInstance()
    {
		return instance;
    }
}
