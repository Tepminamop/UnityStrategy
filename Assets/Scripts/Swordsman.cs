using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordsman : Unit
{
    public void MakeSwordsman(int hp, int initiative, int damage, IObservable hero)
    {
        this._isAlive = true;
        this._attackType = AttackType.MELEE;
        this._hp = hp;
        this._damage = damage;
        this._initiative = initiative;
        this._hero = hero;
        _hero.RegisterObserver(this);
    }
}
