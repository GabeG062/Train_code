namespace TrainClasses;

public class program
{
    public static void Main(string[] args)
    {
        TestPlayerTrainConstructors();
        TestPlayerTrainOpenAndClose();
        TestPlayerTrainIsOpen();
        TestPlayerTrainInheritedEngineValue();
        TestPlayerTrainInheritedAdd();
        TestPlayerTrainInheritedIndexer();
        TestPlayerTrainInheritedLastDomino();
        TestPlayerTrainInheritedPlayableValue();
        TestPlayerTrainIsPlayable();
        TestPlayerTrainToString();

        Console.ReadLine();
    }

    static void TestPlayerTrainConstructors()
    {
        Hand hand = new Hand();

        PlayerTrain train1 = new PlayerTrain(hand);
        PlayerTrain train2 = new PlayerTrain(hand, 12);

        Console.WriteLine("Testing PlayerTrain constructors");
        Console.WriteLine("Default PlayerTrain with hand. Expecting IsEmpty true. " + train1.IsEmpty);
        Console.WriteLine("Overloaded PlayerTrain with hand and engine value. Expecting EngineValue 12. " + train2.EngineValue);
        Console.WriteLine();
    }

    static void TestPlayerTrainOpenAndClose()
    {
        Hand hand = new Hand();
        PlayerTrain train = new PlayerTrain(hand, 12);

        Console.WriteLine("Testing PlayerTrain Open and Close");

        train.Open();
        Console.WriteLine("After Open. Expecting true. " + train.IsOpen);

        train.Close();
        Console.WriteLine("After Close. Expecting false. " + train.IsOpen);

        Console.WriteLine();
    }

    static void TestPlayerTrainIsOpen()
    {
        Hand hand = new Hand();
        PlayerTrain train = new PlayerTrain(hand, 12);

        Console.WriteLine("Testing PlayerTrain IsOpen property");
        Console.WriteLine("New PlayerTrain IsOpen. Expecting false. " + train.IsOpen);

        train.Open();
        Console.WriteLine("After Open IsOpen. Expecting true. " + train.IsOpen);

        train.Close();
        Console.WriteLine("After Close IsOpen. Expecting false. " + train.IsOpen);

        Console.WriteLine();
    }

    static void TestPlayerTrainInheritedEngineValue()
    {
        Hand hand = new Hand();
        PlayerTrain train = new PlayerTrain(hand, 12);

        Console.WriteLine("Testing inherited EngineValue property");
        Console.WriteLine("EngineValue from constructor. Expecting 12. " + train.EngineValue);

        train.EngineValue = 9;
        Console.WriteLine("EngineValue after setter. Expecting 9. " + train.EngineValue);

        Console.WriteLine();
    }

    static void TestPlayerTrainInheritedAdd()
    {
        Hand hand = new Hand();
        PlayerTrain train = new PlayerTrain(hand, 12);

        Domino d = new Domino(12, 5);

        Console.WriteLine("Testing inherited Add method");
        Console.WriteLine("Before Add IsEmpty. Expecting true. " + train.IsEmpty);

        train.Add(d);

        Console.WriteLine("After Add IsEmpty. Expecting false. " + train.IsEmpty);
        Console.WriteLine("Domino at index 0. Expecting Side 1: 12  Side 2: 5. " + train[0]);

        Console.WriteLine();
    }

    static void TestPlayerTrainInheritedIndexer()
    {
        Hand hand = new Hand();
        PlayerTrain train = new PlayerTrain(hand, 12);

        Domino d1 = new Domino(12, 5);
        Domino d2 = new Domino(5, 8);

        train.Add(d1);
        train.Add(d2);

        Console.WriteLine("Testing inherited indexer");
        Console.WriteLine("Indexer [0]. Expecting Side 1: 12  Side 2: 5. " + train[0]);
        Console.WriteLine("Indexer [1]. Expecting Side 1: 5  Side 2: 8. " + train[1]);

        Console.WriteLine();
    }

    static void TestPlayerTrainInheritedLastDomino()
    {
        Hand hand = new Hand();
        PlayerTrain train = new PlayerTrain(hand, 12);

        Domino d1 = new Domino(12, 5);
        Domino d2 = new Domino(5, 8);

        train.Add(d1);

        Console.WriteLine("Testing inherited LastDomino property");
        Console.WriteLine("LastDomino after one Add. Expecting Side 1: 12  Side 2: 5. " + train.LastDomino);

        train.Add(d2);

        Console.WriteLine("LastDomino after two Adds. Expecting Side 1: 5  Side 2: 8. " + train.LastDomino);

        Console.WriteLine();
    }

    static void TestPlayerTrainInheritedPlayableValue()
    {
        Hand hand = new Hand();
        PlayerTrain train = new PlayerTrain(hand, 12);

        Console.WriteLine("Testing inherited PlayableValue property");
        Console.WriteLine("PlayableValue when empty. Expecting 12. " + train.PlayableValue);

        Domino d1 = new Domino(12, 5);
        train.Add(d1);

        Console.WriteLine("PlayableValue after adding 12|5. Expecting 5. " + train.PlayableValue);

        Domino d2 = new Domino(5, 8);
        train.Add(d2);

        Console.WriteLine("PlayableValue after adding 5|8. Expecting 8. " + train.PlayableValue);

        Console.WriteLine();
    }

    static void TestPlayerTrainIsPlayable()
    {
        Hand hand = new Hand();
        PlayerTrain train = new PlayerTrain(hand, 12);

        Domino d = new Domino(12, 5);

        bool mustFlip;
        bool isPlayable = train.IsPlayable(hand, d, out mustFlip);

        Console.WriteLine("Testing PlayerTrain IsPlayable");
        Console.WriteLine("IsPlayable result. Expecting true. " + isPlayable);
        Console.WriteLine("mustFlip result. Expecting false. " + mustFlip);

        Console.WriteLine();
    }

    static void TestPlayerTrainToString()
    {
        Hand hand = new Hand();
        PlayerTrain train = new PlayerTrain(hand, 12);

        Console.WriteLine("Testing inherited ToString");
        Console.WriteLine("ToString. Expecting Train. " + train.ToString());

        Console.WriteLine();
    }
}