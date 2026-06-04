namespace TrainClasses
{
    public abstract class Train
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
    public void Add(Domino d)
    {
        dominoes.Add(d);
    }

    public bool IsPlayable(Domino d, out bool mustFlip)
    {
        mustFlip = false;
        return true;
    }

    public abstract bool IsPlayable(Hand h, Domino d, out bool mustFlip);

    public void Play(Hand h, Domino d)
    {
        return;
    }

    public Train() {}

    public Train(int engineValue)
    {
        this.engineValue = engineValue;
    }

    public override string ToString()
    {
        return "Train";
    }
    
    
    }
}