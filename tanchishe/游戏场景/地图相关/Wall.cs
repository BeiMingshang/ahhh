using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇学习.游戏场景.基类相关;

namespace 贪吃蛇学习.游戏场景.地图相关
{
    class Wall : GameObject
    {
        public Wall(int x,int y) 
        {
            pos.x= x; 
            pos.y = y;
        }

        /// <summary>
        /// 绘制墙体逻辑
        /// </summary>
        public override void Draw()
        {
           Console.ForegroundColor= ConsoleColor.Red;
           Console.SetCursorPosition(pos.x,pos.y);
           Console.Write("■");

        }
        public void  RandomPos(Snake snake,Wall walls)
        {
            Random r = new Random();//生成指定范围的随机数
            int x = r.Next(2, 80 / 2 - 1) * 2;//中文占2格需要×2
            int y = r.Next(1, 20 - 4);

            pos = new Position(x, y);
            Draw();
            if (snake.CheckSamePos(pos))
                RandomPos(snake,walls);//如果重复递归重新改变位置

        }

    }
}
