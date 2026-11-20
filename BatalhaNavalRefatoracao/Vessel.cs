using System.Security.Cryptography;

public class Vessel
{
    public int Size { get; set; }

    public List<int> Position { get; set; }

    public bool Orientation { get; set; }

    public bool SetOrientation()
    {
        int orientation = Random.Shared.Next(0, 2);
        if (orientation == 0)
            return true;
        return false;
    }
    public void CreateVessel(int[,] matrix)
    {
        

    }
}

