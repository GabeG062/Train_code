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
       if (IsPlayable(d, out mustFlip) && h == hand)
       {
           Close();
           return true;
       }

       if (IsPlayable(d, out mustFlip) && h != hand)
       {
           return true;
       }
       Open();
       return false;
    }
    
    public void Open()
    {
        isOpen = true;
    }

    public PlayerTrain(Hand h) { hand = h; }
    
    public PlayerTrain(Hand h, int engineValue) : base(engineValue) { hand = h; }
}