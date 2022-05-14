using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSwordsmanMemento : MonoBehaviour, IMemento
{
    private HeroSwordsman memento;
    public HeroSwordsmanMemento(HeroSwordsman state)
    {
        memento = state;
    }

    public HeroSwordsman GetState()
    {
        return memento.GetInstance();
    }
}
