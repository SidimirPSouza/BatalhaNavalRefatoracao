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
                Console.WriteLine("Digite a posição de linha: ");
                EixoX = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite a posição coluna: ");
                EixoY = int.Parse(Console.ReadLine());
                if (EixoX <= 9 && EixoY <= 9)
                    return "Sucesso";
                else
                    Console.WriteLine("Posição de linha/coluna invalidos");
            }
            catch (FormatException)
            {
                Console.WriteLine("Valor informado não é valido, por favor insira um numero inteiro e que esteja no range");
                Thread.Sleep(5000);
            }
        }
    }

}