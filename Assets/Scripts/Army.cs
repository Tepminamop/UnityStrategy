using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : Unit
{
    [SerializeField] private List<Unit> _units;

    public List<Unit> GetUnits()
    {
        return this._units;
    }

    public override void AddUnit(Unit unit)
    {
        this._units.Add(unit);
    }

    public override void GetDamage(int damage)
    {
        foreach (Unit unit in _units)
        {
            unit.GetDamage(damage);
        }
    }

    public bool IsAlive()
    {
        foreach (Unit unit in _units)
        {
            if (unit._isAlive)
            {
                return true;
            }
        }

        return false;
    }
}

