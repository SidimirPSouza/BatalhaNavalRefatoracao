public class Vessel
{
    public int Size { get; set; }
    public int[] Rows { get; set; }
    public int[] Columns { get; set; }
    public int Orientation { get; set; }

    public Vessel(int size)
    {
        Size = size;
        Rows = new int[size];
        Columns = new int[size];
    }

    
}

