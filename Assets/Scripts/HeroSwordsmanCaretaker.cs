using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSwordsmanCaretaker : MonoBehaviour, ICaretaker
{
    public Stack<HeroSwordsmanMemento> history;

    public HeroSwordsmanCaretaker()
    {
        history = new Stack<HeroSwordsmanMemento>();
    }

    public void Undo()
    {
        if (history.Count == 0)
        {
            throw new ArgumentNullException("Change history is empty", nameof(history));
        }

        var heroMage = new HeroSwordsman();
        heroMage.Restore(history.Pop());
    }

    public void Save()
    {
        var heroMage = new HeroSwordsman();
        history.Push(heroMage.Save());
    }
}
