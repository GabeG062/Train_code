namespace TrainClasses;

public class MexicanTrain : Train
{
    //methods
    
    public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
    {
        mustFlip = false;
        return true;
    }

    MexicanTrain() {}
    
    MexicanTrain(int engineValue) : base(engineValue) {}
}