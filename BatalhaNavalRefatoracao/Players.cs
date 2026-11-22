public abstract class Players
{
    //classe base
    public int Points { get; set; } = 0;
    public string Name { get; set; }
    public int coordinateX { get; set; } = 0;
    public int coordinateY { get; set; } = 0;
    public Boards PlayerBoard { get; set; }
    public Players(Boards board)
    {
        PlayerBoard = board;
    }

    //verifica se a posição que está sendo jogada atente a todos os criteiros para ser valida
    public bool CheckPositionIsValid()
    {
        if (this.coordinateX < this.PlayerBoard.Size && this.coordinateY < this.PlayerBoard.Size && this.coordinateX >= 0 && this.coordinateY >= 0)
        {
            return true;
        }

        return false;
    }

    //confere se a posicao jogada é agua ou navio, se for uma posicao que já jogou não faz nada
    public bool CheckCoordinates()
    {
        if (!CheckPositionIsValid())
            return false;

        char position = PlayerBoard.BoardMatrix[coordinateX, coordinateY];

        switch (position)
        {

            case '~':
                RecordMoves('X');
                return false;

            case 'N':
                RecordMoves('O');
                RecordPoints();
                return true;

            default:
                return false;
        }

    }


    //regista um ponto pro jogar, só para separar as resposabilidade de cada função
    public void RecordPoints()
    {
        this.Points += 1;
    }

    //registra na matrix a posicao que o usuario jogou com o symbol de acerto ou erro
    public void RecordMoves(char symbol)
    {
        this.PlayerBoard.BoardMatrix[coordinateX, coordinateY] = symbol;
        this.PlayerBoard.ShotsMatrix[coordinateX, coordinateY] = symbol;
    }

}