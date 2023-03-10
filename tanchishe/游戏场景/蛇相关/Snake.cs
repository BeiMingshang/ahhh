using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇学习.游戏场景;
using 贪吃蛇学习.游戏场景.地图相关;

namespace 贪吃蛇学习
{
    internal class Snake:IDraw
    {
        SnakeBody[] bodies;
        int nowIndex;
        E_Direction nowDiretion;
        public Snake(int x,int y)
        {
            bodies = new SnakeBody[200];
            bodies[0] = new SnakeBody(x,y,SnakeBody.E_SnakeType.Snake);
            nowIndex=1;
        }
        public void Draw()
        {

            for (int i = 0; i < nowIndex; i++)
            {
                bodies[i].Draw();
            }
        }
        /// <summary>
        /// 移动逻辑
        /// </summary>
        public void Move()
        {
            SnakeBody last= bodies[nowIndex-1];//最后一节
            Console.SetCursorPosition(last.pos.x, last.pos.y);
            Console.Write("  ");//覆盖之前的身
            ///  <summary>
            ///  身体跟着头逻辑
            ///  </summary>
            for (int i = nowIndex-1; i >0; i--)
            {
                bodies[i].pos = bodies[i - 1].pos;
            }
            switch(nowDiretion) 
            {
                case E_Direction.Up:
                    bodies[0].pos.y--;
                    break;
                case E_Direction.Down:
                    bodies[0].pos.y++;
                    break;
                case E_Direction.Left:
                    bodies[0].pos.x-=2;
                    break;
                case E_Direction.Right:
                    bodies[0].pos.x+=2;
                    break;
            }
        }
        /// <summary>
        /// 改变方向逻辑
        /// </summary>
        /// <param name="Direction"></param>
        public void ChangeDirection(E_Direction Direction)
        {
            if(nowIndex>1&&
                (nowDiretion==E_Direction.Left&&Direction==E_Direction.Right)||
                (nowDiretion == E_Direction.Right && Direction == E_Direction.Left)||
                (nowDiretion == E_Direction.Up && Direction == E_Direction.Down)||
                  (nowDiretion == E_Direction.Down && Direction == E_Direction.Up))
            { return; }//禁止往回走
            nowDiretion= Direction;
        }
        /// <summary>
        /// 判断是否撞身体
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool CheckSamePos(Position position)
        {
            for (int i = 0; i < nowIndex; i++)

            {
                if (bodies[i].pos==position) return true;
                


            }
            return false;
        }
        /// <summary>
        /// 吃东西长身体随机墙
        /// </summary>
        /// <param name="food"></param>
        public void CheakEat(Food food)
        {
            if (bodies[0].pos==food.pos)
            {
                food.RandomPos(this);
                Wall wall = new Wall(0, 0);
                wall.RandomPos(this, wall);
                bodies[nowIndex] = new SnakeBody(0, 0, SnakeBody.E_SnakeType.Body);
                
                
                nowIndex++;
                

                
            }
        }
        public bool CheakEnd(Map map)
        {
            for (int i = 1; i < nowIndex; i++)//从蛇身开始

            {
                if (bodies[0].pos == bodies[i].pos)

                    return true;

            }
            //if(bodies[0].pos == wall.pos)
               // return true;
            for (int i = 0; i < map.walls.Length; i++)
            {
                if (bodies[0].pos == map.walls[i].pos)
                    return true;
            }
            return false;
        }
    }
    enum E_Direction
    { 
        Up,
        Down,
        Left,
        Right,
        
    }


}
