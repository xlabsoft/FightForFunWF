using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightForFunWF
{
    class Obstacle
    {
        private int quantity;
        private int maxInRow;
        private SurfaceType type;
        public enum SurfaceType { ground, forest, water, desert, bomb, wire, length };

        Obstacle()
        {

        }
        Obstacle(SurfaceType type, int quantity, int maxInRow)
        {   this.type = type;
            this.quantity = quantity;
            this.maxInRow = maxInRow;
            
        }

        // ObstaclesGenerator
        // 5*11=55, 15 free ground

        // [0,3]..[10,3]
        // [0,7]..[10,7]

        public static int count = FOREST + WATER + SAND + BOMB + BARBWARE; // 55(all) - 15(free ground) = 40
        private const int AVAILABLE_SPACE = 55;                             // 5 row x 11 column
        private const int FOREST = 15;                                      // 1 20
        private const int WATER = 3;                                        // 2 ICE BLOCK 4
        private const int SAND = 3;                                         // 3 SWAMP 4
        private const int BOMB = 4;                                         // 4
        private const int BARBWARE = 6;                                     // 5 8

        public static char[] obstacleArea = new char[AVAILABLE_SPACE];

        public static void PrepareObstacle()
        {
            for (int i = 0; i < AVAILABLE_SPACE; i++)
            {
                obstacleArea[i] = '0';
            }
            GenerateObstacles(new Obstacle(SurfaceType.forest, FOREST, 3));
            GenerateObstacles(new Obstacle(SurfaceType.water, WATER, 2));
            GenerateObstacles(new Obstacle(SurfaceType.desert, SAND, 1));
            GenerateObstacles(new Obstacle(SurfaceType.bomb, BOMB, 1));
            GenerateObstacles(new Obstacle(SurfaceType.wire, BARBWARE, 2));            
        }

        public static void GenerateObstacles(Obstacle obst)
        {
            var rnd = new Random();
            while (obst.quantity > 0)
            {
                int pos = rnd.Next(0, obstacleArea.Length);
                int len = rnd.Next(1, obst.maxInRow);
                if (len > obst.quantity) len = obst.quantity;
                if (pos + len < obstacleArea.Length)
                {
                    for (int j = 0; j < len; j++)
                    {
                        if (obstacleArea[pos + j] == '0')
                        {
                            obstacleArea[pos + j] =  ((int)obst.type).ToString()[0];
                            obst.quantity--;
                            count--;
                        }
                    }
                }
            }
        }

        

    }
}
