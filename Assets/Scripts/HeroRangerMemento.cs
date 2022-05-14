using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRangerMemento : MonoBehaviour, IMemento
{
    private HeroRanger memento;
    public HeroRangerMemento(HeroRanger state)
    {
        memento = state;
    }

    public HeroRanger GetState()
    {
        return memento.GetInstance();
    }
}
