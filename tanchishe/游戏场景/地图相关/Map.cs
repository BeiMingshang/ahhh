using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇学习.游戏场景.基类相关;

namespace 贪吃蛇学习.游戏场景.地图相关
{
    class Map:IDraw
    {
        public Wall[] walls = new Wall[80 + (20 - 3) * 2];//横着一个■站2个位置不用×2 -3是防止超出屏幕
        public Map()
        {
            
            int index = 0;
            for (int i=0;i<80;i+=2)
            {
                //上
                walls[index] = new Wall(i, 0);
                index++;
                //下
                walls[index]=new Wall(i, 20-2);
                index++;
            }
            for (int i = 1; i < 20-2; i += 1)
            {
                //左
                walls[index] = new Wall(0, i);
                index++;
                //右
                walls[index] = new Wall(80-2, i);
                index++;
            }
        }
        
        public void Draw()
        {
            for (int i=0;i<walls.Length; i++)
            {
                if (walls[i] != null)
                {
                    walls[i].Draw();
                }
                
                
            }
        }

    }
}
