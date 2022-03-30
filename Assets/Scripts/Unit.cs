using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void Change(object ob);
}

public interface IObservable
{
    void RegisterObserver(IObserver o);
    void RemoveObserver(IObserver o);
    void NotifyObservers();
}

public enum AttackType
{
    AOE,
    MELEE,
    RANGE
}

public abstract class Unit : MonoBehaviour, IObserver, IComparable
{
    [SerializeField] protected internal AttackType _attackType;
    [SerializeField] protected internal int _hp;
    [SerializeField] protected internal int _initiative;
    [SerializeField] protected internal int _damage;
    [SerializeField] protected internal bool _isAlive;
    [SerializeField] protected internal IObservable _hero;
    [SerializeField] protected internal int _armyNumber;
    [SerializeField] protected internal int _id;
    [SerializeField] protected static internal int _counter = 0;



    public virtual void GetDamage(int damage)
    {
        this._hp -= damage;
        if (this._hp <= 0)
        {
            this.Dead();
        }
    }

    public void Attack()
    {

    }

    public void Dead()
    {
        this._hp = 0;
        this._initiative = 0;
        this._isAlive = false;
        if(this._id >1) this._hero.RemoveObserver(this);
    }

    public void LowMorale()
    {
        this._damage = (int)Math.Round(this._damage * 0.85f);
    }

    public void Change(object ob)
    {
        this.LowMorale();
    }

    public int CompareTo(object obj)
    {
        return -this._initiative.CompareTo(((Unit)obj)._initiative);
    }

    public static bool operator ==(Unit unit1, Unit unit2)
    {
        return unit1._id == unit2._id;
    }

    public static bool operator !=(Unit unit1, Unit unit2)
    {
        return unit1._id != unit2._id;
    }
}
