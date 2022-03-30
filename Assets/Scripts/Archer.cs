using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Unit
{
    public void MakeArcher(int hp, int initiative, int damage, IObservable hero,int armyNumber)
    {
        this._isAlive = true;
        this._attackType = AttackType.RANGE;
        this._hp = hp;
        this._damage = damage;
        this._initiative = initiative;
        this._hero = hero;
        this._armyNumber=armyNumber;
        this._id = Unit._counter++;
        _hero.RegisterObserver(this);
    }
}

