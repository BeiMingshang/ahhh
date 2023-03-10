using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇学习
{
    abstract class BeginOrEndSceneBase : ISceneUpdate//开始场景和结束场景相似
    {
        public string title, select1;
        protected int index = 0;//设置一个标识以便选择
        public void Update()
        {
            //标题
            Console.ForegroundColor = ConsoleColor.Green;//设置颜色
            Console.SetCursorPosition(80 / 2 - title.Length, 5);//设置位置,越低越高
            Console.WriteLine(title);
            //选项1
            Console.ForegroundColor = index == 0 ? ConsoleColor.Red : ConsoleColor.Green;//设置颜色,如果选中则变色
            Console.SetCursorPosition(80 / 2 - title.Length, 8);//设置位置,越低越高
            Console.WriteLine(select1);
            //选项2
            Console.ForegroundColor = index == 1 ? ConsoleColor.Red : ConsoleColor.Green;//设置颜色
            Console.SetCursorPosition(80 / 2 - title.Length, 10);//设置位置,越低越高
            Console.WriteLine("结束游戏");//每个界面都是一样的

            switch (Console.ReadKey(true).Key) //接受并隐藏输入
            {
                case ConsoleKey.W:
                    index = 0;
                    break;
                case ConsoleKey.S:
                    index = 1;
                    break;
                case ConsoleKey.J:
                    EnterJDoSomething();
                    break;

            }
        }
        public abstract void EnterJDoSomething();

    }
}
