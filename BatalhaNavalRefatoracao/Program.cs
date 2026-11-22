int[] VesselSizes = { 5, 4, 3, 3, 2 };
bool changePlayer = true;

Boards playerBoard = new Boards(VesselSizes);
playerBoard.InitializeBoards();
playerBoard.PositionVessels();


Boards pcBoard = new Boards(VesselSizes);
pcBoard.InitializeBoards();
pcBoard.PositionVessels();

PlayerHuman player = new PlayerHuman(pcBoard);
PlayerPC playerPC = new PlayerPC(playerBoard);


void PlayerHuman()
{
    playerBoard.ShowAllMatrix(pcBoard);
    player.ReceiveCoordinates();

    if (player.PlayerBoard.BoardMatrix[player.coordinateX, player.coordinateY] == 'X' ||
       player.PlayerBoard.BoardMatrix[player.coordinateX, player.coordinateY] == 'O')
    {
        Console.WriteLine("Esta posição já foi escolhida anteriormente. Você perdeu sua vez!");
        Thread.Sleep(1200);
        changePlayer = false;
    }
    else if (player.CheckCoordinates())
    {
        changePlayer = true;
    }
    else
    {
        Console.WriteLine("Você errou o disparo.");
        Thread.Sleep(1200);
        changePlayer = false;
    }
}

void PlayerPC()
{
    playerBoard.ShowAllMatrix(pcBoard);

    Console.WriteLine("Aguarde, o computador está jogando...");
    Thread.Sleep(2000);

    playerPC.GenerateMovePositions();

    Console.WriteLine($"O computador atacou a posição [{playerPC.coordinateX}, {playerPC.coordinateY}]!");

    Thread.Sleep(2000);
    bool isHit = playerPC.CheckCoordinates();

    if (isHit)
    {
        Console.WriteLine("O computador acertou uma de suas embarcações...");
        Thread.Sleep(2000);
        changePlayer = false;
    }
    else
    {
        Console.WriteLine("O computador errou o disparo!");
        Thread.Sleep(2000);
        changePlayer = true;
    }
}

void Welcome()
{
    Console.WriteLine("Bem vindo ao jogo Batalha Naval 2.0!");
    Console.WriteLine("Seu objetivo é afundar todas as embarcações do adversário.");
    Console.WriteLine("Para isso, escolha atentamente as linhas e colunas que deseja atacar e faça uma boa estratégia!");
    Console.WriteLine("\nBoa sorte!");

    Console.WriteLine("\nPressione qualquer tecla para começar...");
    Console.ReadKey();
}

void StartGame()
{
    do
    {
        Console.Clear();
        if (changePlayer)
        {
            PlayerHuman();
        }
        else
        {
            PlayerPC();
        }

    } while (player.Points < 17 && playerPC.Points < 17);

    Console.WriteLine("Fim de jogo.");
    if (player.Points > playerPC.Points)
    {
        Console.WriteLine("Parabéns, você é o campeão!");
    }
    else
    {
        Console.WriteLine("A máquina venceu. Tente novamente...");
    }

}

Welcome();
StartGame();