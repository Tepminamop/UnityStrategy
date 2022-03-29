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

public abstract class Unit : MonoBehaviour, IObserver
{
    [SerializeField] protected internal AttackType _attackType;
    [SerializeField] protected internal int _hp;
    [SerializeField] protected internal int _initiative;
    [SerializeField] protected internal int _damage;
    [SerializeField] protected internal bool _isAlive;
    [SerializeField] protected internal IObservable _hero;

    //public Unit(int hp, int initiative, int damage, IObservable hero)
    //{
    //    this._hp = hp;
    //    this._damage = damage;
    //    this._initiative = initiative;
    //    this._hero = hero;
    //    _hero.RegisterObserver(this);
    //}

    //public Unit()
    //{

    //}

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
        this._hero.RemoveObserver(this);
    }

    public void LowMorale()
    {
        this._damage = (int)Math.Round(this._damage * 0.85f);
    }

    public void Change(object ob)
    {
        this.LowMorale();
    }
}
