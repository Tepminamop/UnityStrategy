using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class HeroMage : Hero
{
	private static HeroMage instance = null;

	private void Awake()
	{
		if (instance is null)
		{
			instance = this;
		}
		else if (instance == this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);

		InitializeManager();
	}

	private void InitializeManager()
	{

	}

	public HeroMage GetInstance()
	{
		return instance;
	}

	public HeroMageMemento Save()
    {
		return new HeroMageMemento(GetInstance());
    }

	public void Restore(HeroMageMemento memento)
    {
		instance = memento.GetState();
    }
}
