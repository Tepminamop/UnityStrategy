using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : Unit, IObservable
{
    [SerializeField] private int _leadership;
    [SerializeField] private List<IObserver> _observers;
    
    public void SetCharachteristics(AttackType attackType, int hp, int initiative, int leadership, int damage)
    {
        this._isAlive = true;
        this._hp = hp;
        this._damage = damage;
        this._attackType = attackType;
        this._initiative = initiative;
        this._leadership = leadership;
        this._observers = new List<IObserver>();
        this._id = Unit._counter++;
    }

    public new void Dead()
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
