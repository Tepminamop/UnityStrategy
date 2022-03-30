using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class StepQueue : MonoBehaviour
{
    [SerializeField] private Army _armyLeft;
    [SerializeField] private Army _armyRight;
    [SerializeField] private GameObject _GOarmyRight;
    [SerializeField] private GameObject _GOarmyLeft;
    [SerializeField] private List<Unit> _unitsSteps;
    [SerializeField] private int _curUnit;


    void Start()
    {

        _unitsSteps = new List<Unit>(_armyLeft.GetUnits().Count + _armyRight.GetUnits().Count);
        for (int i = 0; i < _armyLeft.GetUnits().Count; i++)
        {
            _unitsSteps.Add(_armyLeft.GetUnits()[i]);
        }
        for (int i = 0; i < _armyRight.GetUnits().Count; i++)
        {
            _unitsSteps.Add(_armyRight.GetUnits()[i]);
        }
        _unitsSteps.Sort();
       
    }

    private List<Unit> TargetsFind(Unit unit)
    {
        List<Unit> enemys;
        if (unit._isAlive)
        {

            if (unit._armyNumber == 1)
            {
                enemys = new List<Unit>(_armyRight.GetUnits());
            }
            else
            {
                enemys = new List<Unit>(_armyLeft.GetUnits());
            }

            switch (unit._attackType)
            {
                case AttackType.MELEE:
                    if (enemys.FindAll(x => x._attackType == AttackType.MELEE && x._isAlive == true).Count != 0)
                    {
                        enemys = enemys.FindAll(x => x._attackType == AttackType.MELEE && x._isAlive == true);
                    }
                    else
                    {
                        enemys = enemys.FindAll(x => x._attackType != AttackType.MELEE && x._isAlive == true);
                    }
                    break;
                default:
                    enemys = enemys.FindAll(x => x._isAlive == true);
                    break;
            }
            return enemys;
        }
        return null;
    }

    private void changeStep()
    {
        do {
            _curUnit = (_curUnit + 1) % _unitsSteps.Count;
        } while (!_unitsSteps[_curUnit]._isAlive);
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit.transform.GetComponent<BoxCollider2D>())
            {

                string tag = hit.transform.tag;
                Unit chooseUnit = hit.transform.gameObject.GetComponent<Unit>();
                List<Unit> targets = TargetsFind(_unitsSteps[_curUnit]);
                if (targets != null)
                {
                    Debug.Log(_curUnit);
                    Debug.Log(_unitsSteps[_curUnit]._attackType);
                    Debug.Log("id"+_unitsSteps[_curUnit]._id);
                    if (targets.Find(x => x == chooseUnit))
                    {
                        if (_unitsSteps[_curUnit]._attackType != AttackType.AOE)
                        {
                            hit.transform.gameObject.GetComponent<Unit>().GetDamage(_unitsSteps[_curUnit]._damage);
                        }
                        else
                        {
                            for (int i=0;i< targets.Count;i++)
                            {
                                targets[i].GetDamage(_unitsSteps[_curUnit]._damage);
                            }
                        }
                        Debug.Log("changeStep()");
                        changeStep();
                    }
                   
                    switch (tag)
                    {
                        case "Hero":
                            Debug.Log("Dead");
                            hit.transform.GetComponent<Hero>().GetDamage(1000);
                            break;
                    }
                }
                Debug.Log("count"+targets.Count);
            }
        }
    }

}
