using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : MonoBehaviour, IObservable
{
    [SerializeField] protected internal AttackType _attackType;
    [SerializeField] protected internal int _hp;
    [SerializeField] protected internal int _initiative;
    [SerializeField] protected internal int _damage;
    [SerializeField] protected internal bool _isAlive;
    [SerializeField] protected internal int _leadership;
    [SerializeField] protected internal List<IObserver> _observers;

    public void SetCharachteristics(AttackType attackType, int hp, int initiative, int leadership, int damage)
    {
        this._isAlive = true;
        this._hp = hp;
        this._damage = damage;
        this._attackType = attackType;
        this._initiative = initiative;
        this._leadership = leadership;
        this._observers = new List<IObserver>();
    }

    public void GetDamage(int damage)
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
        this.NotifyObservers();
    }

    public void Skill()
    {

    }

    public void RegisterObserver(IObserver o)
    {
        this._observers.Add(o);
    }

    public void RemoveObserver(IObserver o)
    {
        this._observers.Remove(o);
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in _observers)
        {
            observer.Change(null);
        }
    }
}
