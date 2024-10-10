

namespace BattleShipsGameAPI.Services;
public class BattleShipsWarService
{
    private const int size = 10;
    private static bool isFirstTimeLoad = true;
    private static string[,] board = new string[size, size];
    

    public BattleShipsWarService()
    {
        if(!isFirstTimeLoad){
            return;
        }
        // Initialize empty board
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                // board
                board[i, j] = "";

        Random random = new Random();
        //Battel Ships
        int bSRandomX = random.Next(0, 9);
        int bSRandomY = random.Next(0, 5);
        board[bSRandomX, bSRandomY] = "BS";
        board[bSRandomX, ++bSRandomY] = "BS";
        board[bSRandomX, ++bSRandomY] = "BS";
        board[bSRandomX, ++bSRandomY] = "BS";
        board[bSRandomX, ++bSRandomY] = "BS";

        //adding Destroyer ship 1
        DestroyerAdding(random);

        //adding Destroyer ship 2
        DestroyerAdding(random);
        isFirstTimeLoad = false;
    }

    private void DestroyerAdding(Random random){
        int bSRandomX_DT_1 = random.Next(0, 9);
        int bSRandomY_DT_1 = random.Next(0, 6);

        for(int index = bSRandomY_DT_1; index < bSRandomY_DT_1+4 ; index++){
            if(board[bSRandomX_DT_1,index] != ""){
                DestroyerAdding(random);
            }
        }

        board[bSRandomX_DT_1, bSRandomY_DT_1] = "DT";
        board[bSRandomX_DT_1, ++bSRandomY_DT_1] = "DT";
        board[bSRandomX_DT_1, ++bSRandomY_DT_1] = "DT";
        board[bSRandomX_DT_1, ++bSRandomY_DT_1] = "DT";
    }

    public string Fire(int x, int y)
    {
        if (board[x, y] == "BS" || board[x, y] == "DT")
        {
            board[x, y] = "H";
            return "Hit";
        }
        else if (board[x, y] == "")
        {
            board[x, y] = "M";
            return "Miss";
        }
        return "Invalid move";
    }

    public object MisileStatus()
    {
        var convertedArray = new string[board.GetLength(0)][];
        for (int i = 0; i < board.GetLength(0); i++)
        {
            convertedArray[i] = new string[board.GetLength(1)];
            for (int j = 0; j < board.GetLength(1); j++)
            {
                convertedArray[i][j] = board[i, j];
            }
        }
        return convertedArray;
    }

    public void ResetGame(){
        isFirstTimeLoad = true;
    }
}
