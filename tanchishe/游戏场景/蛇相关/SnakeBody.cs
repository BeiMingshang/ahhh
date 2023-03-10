using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇学习.游戏场景.基类相关;

namespace 贪吃蛇学习
{
    internal class SnakeBody:GameObject

    {
        E_SnakeType nowType;
        public SnakeBody(int x,int y,E_SnakeType type) 
        {

            pos.y = y; pos.x = x;
            nowType= type;
        }
        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor= nowType==E_SnakeType.Snake?ConsoleColor.Red:ConsoleColor.Green;
            Console.Write(nowType == E_SnakeType.Snake ? "●" : "■");

        }
        public enum E_SnakeType
        { 
            Snake,
            Body
        }

    }
}
