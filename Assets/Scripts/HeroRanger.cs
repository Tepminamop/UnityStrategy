using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class HeroRanger : Hero
{
    [SerializeField] private static HeroRanger _heroRanger;

    public static HeroRanger GetInstance()
    {
        if (_heroRanger == null)
            _heroRanger = new HeroRanger();
        return _heroRanger;
    }
}
