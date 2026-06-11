using System.Collections;

namespace TrainClasses
{
    public abstract class Train : IEnumerable<Domino>
    {
        //fields
        private List<Domino> dominoes = new List<Domino>();
    
        private int engineValue;
        //properties

        private int Count
        {
            get
            {
                return dominoes.Count;
            }
        }

        public int EngineValue
        {
            get => engineValue;
            set => engineValue = value;
        }

        public bool IsEmpty
        {
            get
            {
                return Count == 0;
            }
        }

        public Domino LastDomino
        {
            get
            {
                return dominoes[Count -1];
            }
        }

        public int PlayableValue
        {
            get
            {
                if (IsEmpty)
                {
                    return EngineValue;
                }

                return LastDomino.Side2;
            }
        }

        public Domino this[int index]
        {
            get
            {
                return dominoes[index];
            }
        }
        
        //methods
        
        public IEnumerator<Domino> GetEnumerator()
        {
            return dominoes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(Domino d)
        {
            dominoes.Add(d);
        }

        public bool IsPlayable(Domino d, out bool mustFlip)
        {
            if (d.Side1 == PlayableValue)
            {
                mustFlip = false;
                return true;   
            }
            else if (d.Side2 == PlayableValue)
            {
                mustFlip = true;
                return true;
            }
            else
            {
                mustFlip = false;
                return false;
            }
        }

        public abstract bool IsPlayable(Hand h, Domino d, out bool mustFlip);

        public void Play(Hand h, Domino d)
        {
            int index = h.IndexOf(d);
            if (IsPlayable(h, d, out bool mustFlip))
            {
                if (mustFlip)
                {
                    d.Flip();
                    
                }
                Add(d);
                h.Discard(index);
            }
            else
            {
                throw new InvalidOperationException("Domino is not playable.");
            }
        }

        public Train() {}

        public Train(int engineValue)
        {
            this.engineValue = engineValue;
        }

        public override string ToString()
        {
            if (IsEmpty)
            {
                return "Empty train";
            }
            
            string output = "";

            foreach  (Domino d in dominoes)
            {
                output += d.ToString() + "\n";
            }
            return output;
            
        }
    
    
    }
}