public class PlayerHuman : Players
{
    public Boards PlayerBoard { get; set; }
    public PlayerHuman(Boards playerBoard) : base(playerBoard)
    {
        PlayerBoard = playerBoard;
    }
    public void ReceiveCoordinates()
    {
        Console.WriteLine("Digite a posição de linha: ");
        EixoX = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite a posição coluna: ");
        EixoY = int.Parse(Console.ReadLine());
    }

}