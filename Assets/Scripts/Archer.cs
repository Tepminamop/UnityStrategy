using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Unit
{
    public void MakeArcher(int hp, int initiative, int damage, IObservable hero)
    {
        this._isAlive = true;
        this._attackType = AttackType.RANGE;
        this._hp = hp;
        this._damage = damage;
        this._initiative = initiative;
        this._hero = hero;
        _hero.RegisterObserver(this);
    }
}

