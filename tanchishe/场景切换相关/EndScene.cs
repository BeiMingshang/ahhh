using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇学习
{
    internal class EndScene : BeginOrEndSceneBase
    {
        public EndScene()
        {
            title = "GAME OVER!";
            select1 = "返回开始界面";

        }
        public override void EnterJDoSomething()
        {
            if (index == 0)
            {
                Game.ChangScene(Game.E_SceneType.Begin);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
