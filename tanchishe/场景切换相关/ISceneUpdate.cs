using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇学习
{
    internal interface ISceneUpdate//接口解耦，使各个类独立进行
    {
        void Update();//游戏是不断更新的
    }
}
