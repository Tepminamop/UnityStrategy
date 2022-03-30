using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class HeroMage : Hero
{
    [SerializeField] private static HeroMage _heroMage;

    public static HeroMage GetInstance()
    {
        if (_heroMage == null)
            _heroMage = new HeroMage();
        return _heroMage;
    }
}
