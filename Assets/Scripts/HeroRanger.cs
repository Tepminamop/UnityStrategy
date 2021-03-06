using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class HeroRanger : Hero
{
	private static HeroRanger instance = null;

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

	public HeroRanger GetInstance()
	{
		return instance;
	}

	public HeroRangerMemento Save()
	{
		return new HeroRangerMemento(instance);
	}

	public void Restore(HeroRangerMemento memento)
	{
		if (memento != null)
		{
			instance = memento.GetState();
		}
	}
}
