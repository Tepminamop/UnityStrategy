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

    public virtual void AddUnit(Unit unit) 
    {

    }

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

    public virtual void Dead()
    {
        this._hp = 0;
        this._initiative = 0;
        this._isAlive = false;
        StepQueue._objectsDisplayed[this._id].SetActive(false);
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

    public int CompareTo(object obj)
    {
        return -this._initiative.CompareTo(((Unit)obj)._initiative);
    }

    public override bool Equals(object obj)
    {
        return obj is Unit unit &&
               base.Equals(obj) &&
               name == unit.name &&
               hideFlags == unit.hideFlags &&
               EqualityComparer<Transform>.Default.Equals(transform, unit.transform) &&
               EqualityComparer<GameObject>.Default.Equals(gameObject, unit.gameObject) &&
               tag == unit.tag &&
               enabled == unit.enabled &&
               isActiveAndEnabled == unit.isActiveAndEnabled &&
               useGUILayout == unit.useGUILayout &&
               runInEditMode == unit.runInEditMode &&
               _attackType == unit._attackType &&
               _hp == unit._hp &&
               _initiative == unit._initiative &&
               _damage == unit._damage &&
               _isAlive == unit._isAlive &&
               EqualityComparer<IObservable>.Default.Equals(_hero, unit._hero) &&
               _armyNumber == unit._armyNumber &&
               _id == unit._id;
    }

    public override int GetHashCode()
    {
        int hashCode = -1245531986;
        hashCode = hashCode * -1521134295 + base.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
        hashCode = hashCode * -1521134295 + hideFlags.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<Transform>.Default.GetHashCode(transform);
        hashCode = hashCode * -1521134295 + EqualityComparer<GameObject>.Default.GetHashCode(gameObject);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(tag);
        hashCode = hashCode * -1521134295 + enabled.GetHashCode();
        hashCode = hashCode * -1521134295 + isActiveAndEnabled.GetHashCode();
        hashCode = hashCode * -1521134295 + useGUILayout.GetHashCode();
        hashCode = hashCode * -1521134295 + runInEditMode.GetHashCode();
        hashCode = hashCode * -1521134295 + _attackType.GetHashCode();
        hashCode = hashCode * -1521134295 + _hp.GetHashCode();
        hashCode = hashCode * -1521134295 + _initiative.GetHashCode();
        hashCode = hashCode * -1521134295 + _damage.GetHashCode();
        hashCode = hashCode * -1521134295 + _isAlive.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<IObservable>.Default.GetHashCode(_hero);
        hashCode = hashCode * -1521134295 + _armyNumber.GetHashCode();
        hashCode = hashCode * -1521134295 + _id.GetHashCode();
        return hashCode;
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
