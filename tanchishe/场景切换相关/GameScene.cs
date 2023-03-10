using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇学习.游戏场景;
using 贪吃蛇学习.游戏场景.地图相关;

namespace 贪吃蛇学习
{
    internal class GameScene : ISceneUpdate

    {
        Map map;
        Snake snake;
        Food food;
        public GameScene() 
        { 
            map = new Map();
            snake = new Snake(40, 10);
            food = new Food(snake);

        }
        public void Update()
        {
            if(Console.KeyAvailable) {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        snake.ChangeDirection(E_Direction.Up); break;
                    case ConsoleKey.S:
                        snake.ChangeDirection(E_Direction.Down); break;
                    case ConsoleKey.A:
                        snake.ChangeDirection(E_Direction.Left); break;
                    case ConsoleKey.D:
                        snake.ChangeDirection(E_Direction.Right);
                        break;

                }
            }

            Thread.Sleep(300);//避免太快
            snake.Move();
            map.Draw();
            snake.Draw();
            food.Draw();
            
            snake.CheakEat(food);
            if(snake.CheakEnd(map))
                    Game.ChangScene(Game.E_SceneType.End);

        }

    }
}

