using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class HeroSwordsman : Hero
{
    [SerializeField] private static HeroSwordsman _heroSwordsman;

    public static HeroSwordsman GetInstance()
    {
        if (_heroSwordsman == null)
            _heroSwordsman = new HeroSwordsman();
        return _heroSwordsman;
    }
}
