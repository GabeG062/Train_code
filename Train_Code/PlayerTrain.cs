namespace TrainClasses;

public class PlayerTrain : Train
{
    //fields
    
    private DomHand _domHand;

    private bool isOpen;
    
    //properties
    public bool IsOpen => isOpen;
    
    //methods
    
    public void Close()
    {
        isOpen = false;
    }

    public override bool IsPlayable(DomHand h, Domino d, out bool mustFlip)
    {
       if (IsPlayable(d, out mustFlip) && h == _domHand)
       {
           Close();
           return true;
       }

       if (IsPlayable(d, out mustFlip) && h != _domHand)
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

    public PlayerTrain(DomHand h) { _domHand = h; }
    
    public PlayerTrain(DomHand h, int engineValue) : base(engineValue) { _domHand = h; }
}