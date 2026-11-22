public class PlayerPC: Players
{
    public Boards PlayerBoard { get; set; }
    public PlayerPC(Boards playerBoard) : base(playerBoard)
    {
        PlayerBoard = playerBoard;
    }

    //gera as duas posicaoes de jogada da maquina
     public void GenerateMovePositions()
    {
        this.coordinateX = Random.Shared.Next(0, this.PlayerBoard.Size);
        this.coordinateY = Random.Shared.Next(0, this.PlayerBoard.Size);
    }
}