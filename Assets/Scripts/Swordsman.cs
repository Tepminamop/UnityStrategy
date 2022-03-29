using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Swordsman : Unit, IPointerClickHandler, IPointerDownHandler
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

    public void OnPointerClick(PointerEventData eventData) //разбить на функции
    {
        GameObject go = eventData.pointerCurrentRaycast.gameObject;
        Debug.Log("touch");
        if (go.transform.tag == "Swordsman")
        {
            Debug.Log("SWORDSMAN");
            //HandleTouch(go);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    //public Swordsman(int hp, int initiative, int damage, IObservable hero)
    //    : base(hp, initiative, damage, hero)
    //{
    //    this._attackType = AttackType.MELEE;
    //}
}
