using System;
using System.Collections.Generic;

namespace TrainClasses
{
    public class DomHand
    {
        protected List<Domino> dominoes = new List<Domino>();

        public DomHand()
        {
            
        }

        public int NumDominoes
        {
            get
            {
                return dominoes.Count;
            }
        }

        public Domino this[int i]
        {
            get
            {
                return dominoes[i];
            }
        }

        public void AddDomino(Domino d)
        {
            dominoes.Add(d);
        }

        public Domino Discard(int index)
        {
            if (index != -1)
            {
                Domino discardedDomino = dominoes[index];
                dominoes.RemoveAt(index);
                return discardedDomino;
            }

            return null;
        }

        public Domino GetDomino(int index)
        {
            return dominoes[index];
        }

        public bool HasDomino(Domino d)
        {
            return IndexOf(d) != -1;
        }

        public bool HasDomino(int side1, int side2)
        {
            return IndexOf(side1, side2) != -1;
        }

        public int IndexOf(Domino d)
        {
            for (int i = 0; i < dominoes.Count; i++)
            {
                if (dominoes[i].Side1 == d.Side1 && dominoes[i].Side2 == d.Side2)
                {
                    return i;
                }
            }

            return -1;
        }

        public int IndexOf(int side1, int side2)
        {
            for (int i = 0; i < dominoes.Count; i++)
            {
                if (dominoes[i].Side1 == side1 && dominoes[i].Side2 == side2)
                {
                    return i;
                }
            }

            return -1;
        }

        public override string ToString()
        {
            string output = "";

            foreach (Domino d in dominoes)
            {
                output += d.ToString() + "\n";
            }

            return output;
        }
    }
}