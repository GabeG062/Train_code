namespace TrainClasses;

public class MexicanTrain : Train
{
    //methods
    
    public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
    {
        return IsPlayable(d, out mustFlip);
    }

    public MexicanTrain() {}
    
    public MexicanTrain(int engineValue) : base(engineValue) {}
}