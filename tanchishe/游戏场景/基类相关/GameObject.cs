using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇学习.游戏场景.基类相关
{
    abstract internal class GameObject : IDraw

    {
        public Position pos;
        public abstract void Draw();

    }
}
