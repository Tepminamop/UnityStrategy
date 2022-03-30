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

    public void AddUnit(Unit _unit)
    {
        this._units.Add(_unit);
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

