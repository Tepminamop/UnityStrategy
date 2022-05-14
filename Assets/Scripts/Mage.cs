using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Unit, IProduct
{
    public void MakeUnit(int hp, int initiative, int damage, IObservable hero, int armyNumber)
    {
        this._isAlive = true;
        this._hp = hp;
        this._damage = damage;
        this._initiative = initiative;
        this._hero = hero;
        this._armyNumber = armyNumber;
        this._id = _counter++;
        _hero.RegisterObserver(this);
    }

    public void SetAttackType(AttackType attackType)
    {
        this._attackType = attackType;
    }
}
