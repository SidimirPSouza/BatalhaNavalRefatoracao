using System.Security.Cryptography;

public class Boards
{
    public int Size { get; set; } = 10;
    public char[,] BoardMatrix { get; set; } = new char[10, 10];
    public List<Vessel> VesselsPositions { get; set; } = new List<Vessel>();

    public Boards(int[] vesselSizes)
    {
        foreach (int size in vesselSizes)
        {
            VesselsPositions.Add(new Vessel(size));  // construtor cria uma embarcação de cada tamanho e armazena na lista
        }
    }

    public void InitializeBoards()
    {
        for (int row = 0; row < Size; row++)
        {
            for (int column = 0; column < Size; column++)
            {
                BoardMatrix[row, column] = '~';           // criação dos tabuleiros 
            }
        }
    }

    public void PositionVessels()
    {
        foreach (Vessel currentVessel in VesselsPositions)
        {
            GeneratePositions(currentVessel);
            RegisterPositions(currentVessel);
        }
    }
    public void GeneratePositions(Vessel currentVessel)
    {
        do
        {
            currentVessel.Orientation = RandomNumberGenerator.GetInt32(0, 2);
            int row = RandomNumberGenerator.GetInt32(0, Size);                   //sorteia a orientação e a posição de linha e coluna
            int column = RandomNumberGenerator.GetInt32(0, Size);

            for (int accontant = 0; accontant < currentVessel.Size; accontant++)    //com base no sorteio inicial e tamanho da embarcação
            {                                                                            //calcula as posições de cada embarcação
                if (currentVessel.Orientation == 0) // embarcação na horizontal
                {
                    currentVessel.Rows[accontant] = row;
                    currentVessel.Columns[accontant] = column + accontant;
                }
                else // embarcação na vertical
                {
                    currentVessel.Rows[accontant] = row + accontant;
                    currentVessel.Columns[accontant] = column;
                }
            }
        } while (!ValidatePosition(currentVessel));

        RegisterPositions(currentVessel);
    }

    public bool ValidatePosition(Vessel currentVessel)
    {
        for (int i = 0; i < currentVessel.Size; i++)
        {
            if (currentVessel.Rows[i] < 0 || currentVessel.Rows[i] >= Size)
            {
                return false;                                                            //verifica se as coordenadas de cada embarcação estão dentro 
            }                                                                                   //dos limites do tabuleiro
            else if (currentVessel.Columns[i] < 0 || currentVessel.Columns[i] >= Size)
            {
                return false;
            }
            else if (BoardMatrix[currentVessel.Rows[i], currentVessel.Columns[i]] == 'N')
            {                                                                                  //verifica se a posição já tem alguma embarcação
                return false;
            }
        }

        return true;
    }

    public void RegisterPositions(Vessel currentVessel)
    {
        for (int i = 0; i < currentVessel.Size; i++)
        {                                                                          //registra as posições válidas no tabuleiro
            BoardMatrix[currentVessel.Rows[i], currentVessel.Columns[i]] = 'N';
        }
    }

    public void ShowMatrix(int EixoX, char[,] Matrix)
    {
        for (int EixoY = 0; EixoY < this.Size; EixoY++)
        {
            if (Matrix[EixoX, EixoY] == '~')
                Console.ForegroundColor = ConsoleColor.Blue;
            else if (Matrix[EixoX, EixoY] == 'X')
                Console.ForegroundColor = ConsoleColor.Red;
            else if (Matrix[EixoX, EixoY] == 'O')
                Console.ForegroundColor = ConsoleColor.Green;

            Console.Write($"{Matrix[EixoX, EixoY]}".PadLeft(2));

            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public void ShowAllMatrix(Boards board)
    {
        CreateHeader();


        for (int EixoX = 0; EixoX < this.Size; EixoX++)
        {
            ShowMatrix(EixoX, BoardMatrix);
            
            Console.Write($"{EixoX}".PadLeft(2));
            Console.Write(" ");

            ShowMatrix(EixoX, board.BoardMatrix);

            Console.Write($"{EixoX}".PadLeft(2));
            Console.WriteLine();
        }
    }

    private void CreateHeader()
    {
        Console.Write("Seu tabuleiro:          Tabuleiro PC:");
        Console.WriteLine();
        for (int EixoY = 0; EixoY < this.Size; EixoY++)
        {
            Console.Write($"{EixoY}".PadLeft(2));
        }
        Console.Write("   ");

        for (int EixoY = 0; EixoY < this.Size; EixoY++)
        {
            Console.Write($"{EixoY}".PadLeft(2));
        }
        Console.WriteLine();
    }
}