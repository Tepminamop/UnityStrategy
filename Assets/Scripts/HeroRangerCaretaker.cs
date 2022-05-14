using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRangerCaretaker : MonoBehaviour, ICaretaker
{
    public Stack<HeroRangerMemento> history;

    public HeroRangerCaretaker()
    {
        history = new Stack<HeroRangerMemento>();
    }

    public void Undo()
    {
        if (history.Count == 0)
        {
            throw new ArgumentNullException("Change history is empty", nameof(history));
        }

        var heroMage = new HeroRanger();
        heroMage.Restore(history.Pop());
    }

    public void Save()
    {
        var heroMage = new HeroRanger();
        history.Push(heroMage.Save());
    }
}
