public class PlayerPC: Players
{
    public Boards PlayerBoard { get; set; }
    public PlayerPC(Boards playerBoard) : base(playerBoard)
    {
        PlayerBoard = playerBoard;
    }

    //gera as duas posicaoes de jogada da maquina
    void GerarPosicoesDeJogada()
    {
        this.EixoX = Random.Shared.Next(0, this.PlayerBoard.Size);
        this.EixoY = Random.Shared.Next(0, this.PlayerBoard.Size);

    }
}