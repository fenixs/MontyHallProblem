using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MontyHallProblem
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int tryTimes = 10;
            
            while (true)
            {
                Console.WriteLine("请输入次数(输入exit退出):");
                var stryTimes = Console.ReadLine();
                if (stryTimes == "exit")
                    return;
                Int32.TryParse(stryTimes, out tryTimes);

                //获取切换选择的结果
                var prizedoors = InitDoors(tryTimes);
                var guesses = InitGuesses(tryTimes);
                var openedDoors = HostOpenDoors(prizedoors, guesses);
                var newguesses = ChangeGuesses(guesses, openedDoors);

                Console.WriteLine(string.Format("change doors:{0:0.##}", WinPersentage(newguesses, prizedoors)));
                Console.WriteLine(string.Format("keep doors:{0:0.##}", WinPersentage(InitGuesses(tryTimes), InitDoors(tryTimes))));
                //Console.ReadKey();
            }
        }

        /// <summary>
        /// 生成奖品门
        /// </summary>
        /// <param name="tryTimes"></param>
        /// <returns></returns>
        static int[] InitDoors(int tryTimes)
        {
            var res = new int[tryTimes];
            Random rd = new Random();
            for (int i = 0; i < tryTimes; i++)
            {
                res[i] = rd.Next(0, 3);
            }

                return res;
        }

        /// <summary>
        /// 初始猜测为0
        /// </summary>
        /// <param name="tryTimes"></param>
        /// <returns></returns>
        static int[] InitGuesses(int tryTimes)
        {
            var res = new int[tryTimes];
            for (int i = 0; i < tryTimes; i++)
            {
                res[i] = 0;
            }
            return res;
        }

        /// <summary>
        /// 主持人开启不是奖品的门
        /// </summary>
        /// <param name="prizedoors">奖品所在的门</param>
        /// <param name="guesses">玩家猜测的门</param>
        /// <returns></returns>
        static int[] HostOpenDoors(int[] prizedoors, int[] guesses)
        {
            int len = prizedoors.Length;
            int len1 = guesses.Length;
            if (len != len1)
                return new int[] { };
            var res = new int[len];
            Random rd = new Random();
            int temp = 0;
            for (int i = 0; i < len; i++)
            {
                temp = rd.Next(0, 3);
                while (true)
                {
                    if (temp != prizedoors[i] && temp != guesses[i])
                    {
                        res[i] = temp;                        
                        break;
                    }
                    temp = rd.Next(0, 3);
                }
            }
            return res;
        }

        /// <summary>
        /// 切换原有选择
        /// </summary>
        /// <param name="guesses"></param>
        /// <param name="openeddoors"></param>
        /// <returns></returns>
        static int[] ChangeGuesses(int[] guesses,int[] openeddoors)
        {
            int len = guesses.Length;
            int len1 = openeddoors.Length;
            if (len != len1)
                return new int[]{};
            var res = new int[len];
            Random rd = new Random();
            int temp = 0;
            for (int i = 0; i < len; i++)
            {
                temp = rd.Next(0, 3);
                while (true)
                {
                    if (temp != guesses[i] && temp != openeddoors[i])
                    {
                        res[i] = temp;
                        break;
                    }
                    temp = rd.Next(0, 3);
                }
            }
            return res;
        }

        /// <summary>
        /// 计算胜率
        /// </summary>
        /// <param name="guesses"></param>
        /// <param name="prizedoors"></param>
        /// <returns></returns>
        static double WinPersentage(int[] guesses, int[] prizedoors)
        {
            int len = guesses.Length;
            int len1 = prizedoors.Length;
            if (len != len1)
                return 0d;
            double res = 0d;
            var chooses = new int[len];
            for (int i = 0; i < len; i++)
            {
                chooses[i] = guesses[i] == prizedoors[i] ? 1 : 0;
            }
            res = chooses.Sum() * 1.0 / len;
            return res * 100;
        }


    }

    

}
