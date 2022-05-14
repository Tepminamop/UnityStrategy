using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProduct
{
    void MakeUnit(int hp, int initiative, int damage, IObservable hero, int armyNumber);
    void SetAttackType(AttackType attackType);
}

public abstract class Creator
{
    public abstract void FactoryMethod(IProduct unit);

    public void Make(IProduct unit, int hp, int initiative, int damage, IObservable hero, int armyNumber)
    {
        FactoryMethod(unit);
        unit.MakeUnit(hp, initiative, damage, hero, armyNumber);
    }
}

class ArcherCreator : Creator
{
    public override void FactoryMethod(IProduct unit)
    {
        unit.SetAttackType(AttackType.RANGE);
    }
}

class SwordsmanCreator : Creator
{
    public override void FactoryMethod(IProduct unit)
    {
        unit.SetAttackType(AttackType.MELEE);
    }
}

class MageCreator : Creator
{
    public override void FactoryMethod(IProduct unit)
    {
        unit.SetAttackType(AttackType.AOE);
    }
}

class Client
{
    public void ClientCode(Creator creator, IProduct unit, int hp, int initiative, int damage, IObservable hero, int armyNumber)
    {
        creator.Make(unit, hp, initiative, damage, hero, armyNumber);
    }
}