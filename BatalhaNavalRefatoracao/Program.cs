int[] VesselSizes = { 5, 4, 3, 3, 2 };
Boards playerBoard = new Boards(VesselSizes);
Boards pcBoard = new Boards(VesselSizes);

playerBoard.InitializeBoards();
pcBoard.InitializeBoards();

// depois de criadao a matrix de cada jogador passa ela para a classe jogador. 
//Aqui no program, só chamar as funções de cada um para fazer o registo de jogada, ver se é valida e registrar la na matrix
PlayerHuman player = new PlayerHuman(playerBoard);
PlayerPC playerPC = new PlayerPC(pcBoard);