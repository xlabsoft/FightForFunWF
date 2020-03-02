using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightForFunWF
{
    class Board
    {
        // PT0N0K0N0TP
        // PP0N0A0N0PP
        // 00000000000
        // 11111111111
        // 11111111111
        // 11111111111
        // 11111111111
        // 11111111111
        // 00000000000
        // pp0n0a0n0pp
        // pt0n0k0n0tp
        public static string startPosition = "PT0N0K0N0TPPP0N0A0N0PP00000000000111111111111111111111111111111111111111111111111111111100000000000pp0n0a0n0pppt0n0k0n0tp";

        public static bool winterIsComing = false;
        public static int boardSize = 11;
        public static char[,] gameField = new char[boardSize, boardSize];

        private static void FillBoard()
        {
            //SetStartPosition();
            Char[] board1D = startPosition.ToCharArray();
            int counter = 0;

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    gameField[j, i] = board1D[counter];
                    counter++;
                }
            }

        }

        public static void SetStartPosition(){
            startPosition = "PT0N0K0N0TPPP0N0A0N0PP00000000000111111111111111111111111111111111111111111111111111111100000000000pp0n0a0n0pppt0n0k0n0tp";
        }
        public static void SetPosition(String newPosition){
            startPosition = newPosition;
        }      



        public static void BoardInit()
        {            
            Obstacle.PrepareObstacle();
            string obstacleSpaceInStartPosition = "1111111111111111111111111111111111111111111111111111111";
            startPosition = startPosition.Replace(obstacleSpaceInStartPosition, new string(Obstacle.obstacleArea));
            FillBoard();
            //SetUnits();
        }        
        

    }
}
