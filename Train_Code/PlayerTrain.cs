namespace TrainClasses;

public class PlayerTrain : Train
{
    //fields
    
    private Hand hand;

    private bool isOpen;
    
    //properties
    public bool IsOpen => isOpen;
    
    //methods
    
    public void Close()
    {
        isOpen = false;
    }

    public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
    {
        throw new NotImplementedException();
    }
    
    public void Open()
    {
        isOpen = true;
    }

    public PlayerTrain(Hand h)
    {
        hand = h;
    }
    
    public PlayerTrain(Hand h, int engineValue) : base(engineValue) {}
}