using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMageMemento : MonoBehaviour, IMemento
{
    private HeroMage memento;
    public HeroMageMemento(HeroMage state)
    {
        memento = state;
    }

    public HeroMage GetState()
    {
        return memento.GetInstance();
    }
}
