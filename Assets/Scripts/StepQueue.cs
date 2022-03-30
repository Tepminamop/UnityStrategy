using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class StepQueue : MonoBehaviour
{
    [SerializeField] private Army _armyLeft;
    [SerializeField] private Army _armyRight;
    [SerializeField] private GameObject _go_armyRight;
    [SerializeField] private GameObject _go_armyLeft;
    [SerializeField] private List<Unit> _unitsSteps;
    [SerializeField] private int _curUnit = 0;
    [SerializeField] public static Dictionary<int, GameObject> _objectsDisplayed;

    private void Start()
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
        foreach (Unit unit in _unitsSteps)
        {
            Debug.Log(unit._initiative);
        }

        CreateObjects();

        foreach (Transform obj in _objectsDisplayed[_unitsSteps[_curUnit]._id].transform)
        {
            if (obj.tag == "ChosenUnit")
            {
                obj.gameObject.SetActive(true);
                break;
            }
        }
    }

    private void CreateObjects()
    {
        _objectsDisplayed = new Dictionary<int, GameObject>();

        foreach (Transform obj in _go_armyLeft.transform)
        {
            _objectsDisplayed.Add(obj.gameObject.GetComponent<Unit>()._id, obj.gameObject);
        }

        foreach (Transform obj in _go_armyRight.transform)
        {
            _objectsDisplayed.Add(obj.gameObject.GetComponent<Unit>()._id, obj.gameObject);
        }
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

    private void ChangeStep()
    {
        do {
            _curUnit = (_curUnit + 1) % _unitsSteps.Count;
        } while (!_unitsSteps[_curUnit]._isAlive);

        foreach (Transform obj in _objectsDisplayed[_unitsSteps[_curUnit]._id].transform)
        {
            if (obj.tag == "ChosenUnit")
            {
                obj.gameObject.SetActive(true);
                break;
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit)
            {
                Unit chooseUnit = hit.transform.gameObject.GetComponent<Unit>();
                List<Unit> targets = TargetsFind(_unitsSteps[_curUnit]);
                if (targets != null)
                {
                    Debug.Log(_curUnit);
                    Debug.Log(_unitsSteps[_curUnit]._attackType);
                    Debug.Log("id" + _unitsSteps[_curUnit]._id);
                    if (targets.Find(x => x == chooseUnit))
                    {
                        if (_unitsSteps[_curUnit]._attackType != AttackType.AOE)
                        {
                            hit.transform.gameObject.GetComponent<Unit>().GetDamage(_unitsSteps[_curUnit]._damage);
                        }
                        else
                        {
                            if (_unitsSteps[_curUnit]._id == 1)
                            {
                                _armyLeft.GetDamage(_unitsSteps[_curUnit]._damage);
                            }
                            else
                            {
                                _armyRight.GetDamage(_unitsSteps[_curUnit]._damage);
                            }
                        }
                        Debug.Log("changeStep()");
                        foreach (Transform obj in _objectsDisplayed[_unitsSteps[_curUnit]._id].transform)
                        {
                            if (obj.tag == "ChosenUnit")
                            {
                                obj.gameObject.SetActive(false);
                                break;
                            }
                        }
                        ChangeStep();
                    }
                }
                Debug.Log("count" + targets.Count);
            }
        }
    }
}
