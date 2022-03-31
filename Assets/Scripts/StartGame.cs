using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject _go_hero1;
    [SerializeField] private GameObject _go_hero2;
    [SerializeField] private GameObject _go_army1;
    [SerializeField] private GameObject _go_army2;

    private void Awake()
    {
        _go_hero1.GetComponent<HeroSwordsman>().SetCharachteristics(AttackType.MELEE, 200, 50, 5, 60, 1);
        _go_hero2.GetComponent<HeroRanger>().SetCharachteristics(AttackType.RANGE, 200, 50, 5, 60, 2);

        this._go_army1.GetComponent<Army>().AddUnit(_go_hero1.GetComponent<HeroSwordsman>());
        this._go_army2.GetComponent<Army>().AddUnit(_go_hero2.GetComponent<HeroRanger>());

        foreach (Transform obj in this._go_army1.transform)
        {
            string tag = obj.tag;
            switch (tag)
            {
                case "Archer":
                    obj.GetComponent<Archer>().MakeArcher(90, 60, 40, _go_hero1.GetComponent<Hero>(), 1);
                    this._go_army1.GetComponent<Army>().AddUnit(obj.GetComponent<Archer>());
                    break;
                case "Swordsman":
                    obj.GetComponentInChildren<Swordsman>().MakeSwordsman(50, 50, 150, _go_hero1.GetComponent<Hero>(), 1);
                    this._go_army1.GetComponent<Army>().AddUnit(obj.GetComponent<Swordsman>());
                    break;
                case "Mage":
                    obj.GetComponent<Mage>().MakeMage(30, 100, 40, _go_hero1.GetComponent<Hero>(), 1);
                    this._go_army1.GetComponent<Army>().AddUnit(obj.GetComponent<Mage>());
                    break;
            }
        }

        foreach (Transform obj in this._go_army2.transform)
        {
            string tag = obj.tag;
            switch (tag)
            {
                case "Archer":
                    obj.GetComponent<Archer>().MakeArcher(90, 60, 40, _go_hero2.GetComponent<Hero>(), 2);
                    this._go_army2.GetComponent<Army>().AddUnit(obj.GetComponent<Archer>());
                    break;
                case "Swordsman":
                    obj.GetComponentInChildren<Swordsman>().MakeSwordsman(50, 50, 150, _go_hero2.GetComponent<Hero>(), 2);
                    this._go_army2.GetComponent<Army>().AddUnit(obj.GetComponent<Swordsman>());
                    break;
                case "Mage":
                    obj.GetComponent<Mage>().MakeMage(30, 100, 40, _go_hero2.GetComponent<Hero>(), 2);
                    this._go_army2.GetComponent<Army>().AddUnit(obj.GetComponent<Mage>());
                    break;
            }
        }
    }
}
