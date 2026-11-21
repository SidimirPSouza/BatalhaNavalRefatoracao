public abstract class Players
{
    //classe base
    public int Points { get; set; } = 0;
    public string Name { get; set; }
    public int EixoX { get; set; } = 0;
    public int EixoY { get; set; } = 0;
    public Boards PlayerBoard { get; set; }
    public Players(Boards board)
    {
        PlayerBoard = board;
    }

    //verifica se a posição que está sendo jogada atente a todos os criteiros para ser valida
    public bool CheckPositionIsValid()
    {
        if(this.EixoX < this.PlayerBoard.Size && this.EixoY < this.PlayerBoard.Size && this.EixoX >= 0 && this.EixoY >= 0)
        {
            Console.WriteLine("Valida");
            return true;
        }

        return false;
    }

    //confere se a posicao jogada é agua ou navio, se for uma posicao que já jogou não faz nada
    public bool CheckCoordinates()
    {
        if (this.CheckPositionIsValid())
        {
            switch (this.PlayerBoard.BoardMatrix[EixoX, EixoY])
            {
                case '~':
                    RecordMoves('X');
                    return false;
                case 'N':
                    Console.WriteLine("Acertou");
                    RecordMoves('O');
                    RecordPoints();
                    return true;
                default:
                    return false;
            }
        } else
        {
            Console.WriteLine("Errou");

            return false;
        }

    }

    //regista um ponto pro jogar, só para separar as resposabilidade de cada função
    public void RecordPoints()
    {
        this.Points += 1;
    }

    //registra na matrix a posicao que o usuario jogou com o simbolo de acerto ou erro
    public void RecordMoves(char simbolo)
    {
        this.PlayerBoard.BoardMatrix[EixoX, EixoY] = simbolo;
    }

}