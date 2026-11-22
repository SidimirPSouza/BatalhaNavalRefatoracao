public class PlayerHuman : Players
{
    public Boards PlayerBoard { get; set; }
    public PlayerHuman(Boards playerBoard) : base(playerBoard)
    {
        PlayerBoard = playerBoard;
    }
    public string ReceiveCoordinates()
    {
        while (true)
        {

            try
            {
                Console.WriteLine("Sua vez!");
                Console.WriteLine("\nDigite a posição de linha: ");
                coordinateX = int.Parse(Console.ReadLine());

                if (coordinateX < 0 || coordinateX > 9)
                {
                    Console.WriteLine("Valor inválido! Digite um valor entre 0 e 9.");
                    continue;
                }


                while (true) {
                    Console.WriteLine("Digite a posição de coluna: ");
                    coordinateY = int.Parse(Console.ReadLine());

                    if (coordinateY < 0 || coordinateY > 9)
                    {
                        Console.WriteLine("Valor inválido! Digite um valor entre 0 e 9.");
                        continue;
                    }

                    return "Sucesso";
                }
            }
                
            catch (FormatException)
            {
                Console.WriteLine("O valor informado é inválido. Digite um número inteiro entre 0 e 9.");
                Thread.Sleep(1500);
            }
        }
    }
}