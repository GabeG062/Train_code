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
        TestMexicanTrainConstructors();
        TestMexicanTrainInheritedAdd();
        TestMexicanTrainInheritedPlayableValue();
        TestMexicanTrainIsPlayable();
        TestMexicanTrainToString();
        TestMexicanTrainForeach();
        TestDominoSorting();
        TestTrainForeach();

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

        Domino playableDomino = new Domino(12, 5);
        Domino notPlayableDomino = new Domino(3, 4);

        bool mustFlip;
        bool isPlayable = train.IsPlayable(hand, playableDomino, out mustFlip);

        Console.WriteLine("Testing PlayerTrain IsPlayable");
        Console.WriteLine("Playable domino result. Expecting true. " + isPlayable);
        Console.WriteLine("Playable domino mustFlip. Expecting false. " + mustFlip);
        Console.WriteLine("Train IsOpen after playable domino. Expecting false. " + train.IsOpen);

        isPlayable = train.IsPlayable(hand, notPlayableDomino, out mustFlip);

        Console.WriteLine("Not playable domino result. Expecting false. " + isPlayable);
        Console.WriteLine("Not playable domino mustFlip. Expecting false. " + mustFlip);
        Console.WriteLine("Train IsOpen after not playable domino. Expecting true. " + train.IsOpen);

        Domino flippedDomino = new Domino(6, 12);
        isPlayable = train.IsPlayable(hand, flippedDomino, out mustFlip);

        Console.WriteLine("Flipped playable domino result. Expecting true. " + isPlayable);
        Console.WriteLine("Flipped playable domino mustFlip. Expecting true. " + mustFlip);
        Console.WriteLine("Train IsOpen after flipped playable domino. Expecting false. " + train.IsOpen);

        Console.WriteLine();
    }

    static void TestPlayerTrainToString()
    {
        Hand hand = new Hand();
        PlayerTrain train = new PlayerTrain(hand, 12);

        Console.WriteLine("Testing inherited ToString");
        Console.WriteLine("Empty ToString. Expecting Empty train. " + train.ToString());

        train.Add(new Domino(12, 5));
        train.Add(new Domino(5, 8));

        Console.WriteLine("Non-empty ToString. Expecting two dominos:");
        Console.WriteLine(train.ToString());

        Console.WriteLine();
    }

static void TestMexicanTrainConstructors()
{
    MexicanTrain train1 = new MexicanTrain();
    MexicanTrain train2 = new MexicanTrain(12);

    Console.WriteLine("Testing MexicanTrain constructors");
    Console.WriteLine("Default MexicanTrain. Expecting IsEmpty true. " + train1.IsEmpty);
    Console.WriteLine("Overloaded MexicanTrain. Expecting EngineValue 12. " + train2.EngineValue);

    Console.WriteLine();
}

static void TestMexicanTrainInheritedAdd()
{
    MexicanTrain train = new MexicanTrain(12);

    Domino d = new Domino(12, 5);

    Console.WriteLine("Testing MexicanTrain inherited Add method");
    Console.WriteLine("Before Add IsEmpty. Expecting true. " + train.IsEmpty);

    train.Add(d);

    Console.WriteLine("After Add IsEmpty. Expecting false. " + train.IsEmpty);
    Console.WriteLine("Domino at index 0. Expecting Side 1: 12  Side 2: 5. " + train[0]);

    Console.WriteLine();
}

static void TestMexicanTrainInheritedPlayableValue()
{
    MexicanTrain train = new MexicanTrain(12);

    Console.WriteLine("Testing MexicanTrain inherited PlayableValue property");
    Console.WriteLine("PlayableValue when empty. Expecting 12. " + train.PlayableValue);

    Domino d1 = new Domino(12, 5);
    train.Add(d1);

    Console.WriteLine("PlayableValue after adding 12|5. Expecting 5. " + train.PlayableValue);

    Domino d2 = new Domino(5, 8);
    train.Add(d2);

    Console.WriteLine("PlayableValue after adding 5|8. Expecting 8. " + train.PlayableValue);

    Console.WriteLine();
}

static void TestMexicanTrainIsPlayable()
{
    Hand hand = new Hand();
    MexicanTrain train = new MexicanTrain(12);

    Domino playableDomino = new Domino(12, 5);
    Domino flippedDomino = new Domino(6, 12);
    Domino notPlayableDomino = new Domino(3, 4);

    bool mustFlip;
    bool isPlayable = train.IsPlayable(hand, playableDomino, out mustFlip);

    Console.WriteLine("Testing MexicanTrain IsPlayable");
    Console.WriteLine("Playable domino result. Expecting true. " + isPlayable);
    Console.WriteLine("Playable domino mustFlip. Expecting false. " + mustFlip);

    isPlayable = train.IsPlayable(hand, flippedDomino, out mustFlip);

    Console.WriteLine("Flipped playable domino result. Expecting true. " + isPlayable);
    Console.WriteLine("Flipped playable domino mustFlip. Expecting true. " + mustFlip);

    isPlayable = train.IsPlayable(hand, notPlayableDomino, out mustFlip);

    Console.WriteLine("Not playable domino result. Expecting false. " + isPlayable);
    Console.WriteLine("Not playable domino mustFlip. Expecting false. " + mustFlip);

    Console.WriteLine();
}

static void TestMexicanTrainToString()
{
    MexicanTrain train = new MexicanTrain(12);

    Console.WriteLine("Testing MexicanTrain inherited ToString");
    Console.WriteLine("Empty ToString. Expecting Empty train. " + train.ToString());

    train.Add(new Domino(12, 5));
    train.Add(new Domino(5, 8));

    Console.WriteLine("Non-empty ToString. Expecting two dominos:");
    Console.WriteLine(train.ToString());

    Console.WriteLine();
}

static void TestMexicanTrainForeach()
{
    MexicanTrain train = new MexicanTrain(12);

    train.Add(new Domino(12, 5));
    train.Add(new Domino(5, 8));
    train.Add(new Domino(8, 3));

    Console.WriteLine("Testing MexicanTrain foreach");
    Console.WriteLine("Expecting three dominos printed in order:");

    foreach (Domino d in train)
    {
        Console.WriteLine(d);
    }

    Console.WriteLine();
}

    static void TestDominoSorting()
    {
        List<Domino> dominos = new List<Domino>();

        dominos.Add(new Domino(6, 6));
        dominos.Add(new Domino(1, 2));
        dominos.Add(new Domino(4, 5));

        dominos.Sort();

        Console.WriteLine("Testing Domino sorting by Score");

        foreach (Domino d in dominos)
        {
            Console.WriteLine(d + " Score: " + d.Score);
        }

        Console.WriteLine();
    }
    
    static void TestTrainForeach()
    {
        Hand hand = new Hand();
        PlayerTrain train = new PlayerTrain(hand, 12);

        train.Add(new Domino(12, 5));
        train.Add(new Domino(5, 8));
        train.Add(new Domino(8, 3));

        Console.WriteLine("Testing Train foreach");
        Console.WriteLine("Expecting three dominos printed in order:");

        foreach (Domino d in train)
        {
            Console.WriteLine(d);
        }

        Console.WriteLine();
    }
}