using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇学习
{
    class Game
    {
        public int weath = 80, heath = 20;
        static ISceneUpdate nowScene;
        public Game()
        {
            Console.CursorVisible = false;//隐藏光标
            Console.SetWindowSize(weath, heath);//建立窗口
            Console.SetBufferSize(weath, heath);//缓冲区窗口
        }

        public void Start()//使游戏开始并持续
        {
            ChangScene(E_SceneType.Begin);
            while (true)
            {
                if (nowScene != null) nowScene.Update();

            }
        }
        public static ISceneUpdate GetNowScene()//删了也可以
        {
            return nowScene;
        }


        public static void ChangScene(E_SceneType type)//静态方法存在周期长，方法经常使用
        {
            Console.Clear();//每次改变之前需要清屏
            switch (type)
            {
                case E_SceneType.Begin:
                    nowScene = new BeginScene();
                    break;
                case E_SceneType.Game:
                    nowScene = new GameScene();
                    break;
                case E_SceneType.End:
                    nowScene = new EndScene();
                    break;

            }
        }



        public enum E_SceneType//便于场景切换
        {
            Begin,
            Game,
            End
        }
    }


}

