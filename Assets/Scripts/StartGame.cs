using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject _go_hero1;
    [SerializeField] GameObject _go_hero2;
    [SerializeField] GameObject _go_army1;
    [SerializeField] GameObject _go_army2;

    private void Start()
    {
        _go_hero1.GetComponent<Hero>().SetCharachteristics(AttackType.MELEE, 200, 50, 5, 60);
        _go_hero2.GetComponent<Hero>().SetCharachteristics(AttackType.MELEE, 200, 50, 5, 60);

        foreach (Transform obj in this._go_army1.transform)
        {
            string tag = obj.tag;
            switch (tag)
            {
                case "Archer":
                    obj.GetComponent<Archer>().MakeArcher(90, 60, 40, _go_hero1.GetComponent<Hero>());
                    break;
                case "Swordsman":
                    obj.GetComponentInChildren<Swordsman>().MakeSwordsman(50, 50, 150, _go_hero1.GetComponent<Hero>());
                    break;
                case "Mage":
                    obj.GetComponent<Mage>().MakeMage(30, 100, 40, _go_hero1.GetComponent<Hero>());
                    break;
            }
        }

        foreach (Transform obj in this._go_army2.transform)
        {
            string tag = obj.tag;
            switch (tag)
            {
                case "Archer":
                    obj.GetComponent<Archer>().MakeArcher(90, 60, 40, _go_hero2.GetComponent<Hero>());
                    break;
                case "Swordsman":
                    obj.GetComponentInChildren<Swordsman>().MakeSwordsman(50, 50, 150, _go_hero2.GetComponent<Hero>());
                    break;
                case "Mage":
                    obj.GetComponent<Mage>().MakeMage(30, 100, 40, _go_hero2.GetComponent<Hero>());
                    break;
            }
        }
    }
}
