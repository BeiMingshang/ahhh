using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇学习
{
    internal class BeginScene : BeginOrEndSceneBase
    {
        public BeginScene()
        {
            title = "贪吃蛇小游戏";
            select1 = "开始游戏";
        }
        public override void EnterJDoSomething()
        {
            if (index == 0)
            {
                Game.ChangScene(Game.E_SceneType.Game);
            }
            else
            {
                Environment.Exit(0);//退出固定写法
            }
        }
    }
}
