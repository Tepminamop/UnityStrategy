using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMageCaretaker : MonoBehaviour, ICaretaker
{
    public Stack<HeroMageMemento> history;

    public HeroMageCaretaker()
    {
        history = new Stack<HeroMageMemento>();
    }

    public void Undo() 
    {
        if (history.Count == 0)
        {
            throw new ArgumentNullException("Change history is empty", nameof(history));
        }

        var heroMage = new HeroMage();
        heroMage.Restore(history.Pop());
    }

    public void Save()
    {
        var heroMage = new HeroMage();
        history.Push(heroMage.Save());
    }
}
