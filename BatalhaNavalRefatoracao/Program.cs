int[] VesselSizes = { 5, 4, 3, 3, 2 };
bool trocarJogador = true;

// depois de criadao a matrix de cada jogador passa ela para a classe jogador. 
//Aqui no program, só chamar as funções de cada um para fazer o registo de jogada, ver se é valida e registrar la na matrix
Boards playerBoard = new Boards(VesselSizes);
playerBoard.InitializeBoards();
playerBoard.PositionVessels();
PlayerHuman player = new PlayerHuman(playerBoard);

Boards pcBoard = new Boards(VesselSizes);
pcBoard.InitializeBoards();
pcBoard.PositionVessels();
PlayerPC playerPC = new PlayerPC(pcBoard);


void PlayerHuman()
{
    playerBoard.ShowMatrix();
    player.ReceiveCoordinates();
    if (player.CheckCoordinates())
    {
        trocarJogador = true;
    }
    else
    {
        trocarJogador = false;
    }
}

void PlayerPC()
{
    pcBoard.ShowMatrix();
    playerPC.GerarPosicoesDeJogada();

    if (playerPC.CheckCoordinates()){
        trocarJogador = false;
    } else
    {
        trocarJogador = true;

    }

    Console.ReadKey();
}

void IniciarJogo(){

    do
    {
        Console.Clear();
        if (trocarJogador)
        {
            PlayerHuman();
        } else
        {
            PlayerPC();
        }

    } while(player.Points < 12 && playerPC.Points < 12);

    Console.WriteLine("Fim de jogo");
    if(player.Points > playerPC.Points)
    {
        Console.WriteLine("Você é o campião");
    }
    else
    {
        Console.WriteLine("Maquina venceu");
    }

}

IniciarJogo();