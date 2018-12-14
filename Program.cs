using System;
using System.Collections.Generic;
using System.Linq;

namespace listDicMinValue
{
	class Program
	{

		#region 初始化
		static List<Dictionary<int, double>> init()
		{
			List<Dictionary<int, double>> list = new List<Dictionary<int, double>>();

			Dictionary<int, double> dic1 = new Dictionary<int, double>();
			dic1.Add(8, 594); dic1.Add(1, 1652.1); dic1.Add(7, 1749.1); dic1.Add(9, 1749.1); dic1.Add(5, 1749.1); dic1.Add(10, 2534); dic1.Add(6, 2534); dic1.Add(2, 2631); dic1.Add(4, 2631); dic1.Add(3, 3592.1);
			list.Add(dic1);

			Dictionary<int, double> dic2 = new Dictionary<int, double>();
			dic2.Add(8, 11931); dic2.Add(6, 14162); dic2.Add(10, 14162); dic2.Add(9, 14162); dic2.Add(7, 14307.5); dic2.Add(4, 19796); dic2.Add(1, 19796); dic2.Add(2, 19941.5); dic2.Add(5, 19941.5); dic2.Add(3, 22027);
			list.Add(dic2);

			Dictionary<int, double> dic3 = new Dictionary<int, double>();
			dic3.Add(4, 19400); dic3.Add(6, 19400); dic3.Add(8, 19400); dic3.Add(2, 19400); dic3.Add(10, 19400); dic3.Add(1, 19594); dic3.Add(9, 19594); dic3.Add(3, 19594); dic3.Add(5, 19594); dic3.Add(7, 19594);
			list.Add(dic3);

			Dictionary<int, double> dic4 = new Dictionary<int, double>();
			dic4.Add(3, 0); dic4.Add(1, 0); dic4.Add(6, 19.8); dic4.Add(8, 19.8); dic4.Add(10, 19.8); dic4.Add(4, 19.8); dic4.Add(9, 97); dic4.Add(5, 97); dic4.Add(7, 97); dic4.Add(2, 116.8);
			list.Add(dic4);

			Dictionary<int, double> dic5 = new Dictionary<int, double>();
			dic5.Add(3, 0); dic5.Add(1, 0); dic5.Add(5, 194); dic5.Add(4, 194); dic5.Add(2, 194); dic5.Add(8, 198); dic5.Add(9, 198); dic5.Add(6, 198); dic5.Add(10, 392); dic5.Add(7, 392);
			list.Add(dic5);

			Dictionary<int, double> dic6 = new Dictionary<int, double>();
			dic6.Add(8, 0); dic6.Add(5, 0); dic6.Add(10, 0); dic6.Add(9, 0); dic6.Add(1, 0); dic6.Add(3, 0); dic6.Add(4, 0); dic6.Add(7, 242.5); dic6.Add(2, 242.5); dic6.Add(6, 242.5);
			list.Add(dic6);

			Dictionary<int, double> dic7 = new Dictionary<int, double>();
			dic7.Add(5, 0); dic7.Add(8, 0); dic7.Add(10, 0); dic7.Add(4, 0); dic7.Add(1, 0); dic7.Add(3, 0); dic7.Add(9, 291); dic7.Add(7, 291); dic7.Add(6, 291); dic7.Add(2, 291);
			list.Add(dic7);

			Dictionary<int, double> dic8 = new Dictionary<int, double>();
			dic8.Add(6, 0); dic8.Add(10, 0); dic8.Add(8, 0); dic8.Add(7, 0); dic8.Add(5, 0); dic8.Add(3, 0); dic8.Add(2, 0); dic8.Add(1, 291); dic8.Add(9, 291); dic8.Add(4, 291);
			list.Add(dic8);

			Dictionary<int, double> dic9 = new Dictionary<int, double>();
			dic9.Add(3, 0); dic9.Add(4, 0); dic9.Add(2, 0); dic9.Add(5, 194); dic9.Add(1, 194); dic9.Add(9, 396); dic9.Add(10, 396); dic9.Add(8, 396); dic9.Add(7, 396); dic9.Add(6, 590);
			list.Add(dic9);

			Dictionary<int, double> dic10 = new Dictionary<int, double>();
			dic10.Add(5, 0); dic10.Add(9, 0); dic10.Add(1, 0); dic10.Add(7, 194); dic10.Add(3, 194); dic10.Add(8, 198); dic10.Add(4, 198); dic10.Add(6, 198); dic10.Add(10, 392); dic10.Add(2, 392);
			list.Add(dic10);
            
			return list;
		}
		#endregion

        /// <summary>
        /// 序列
        /// </summary>
        /// <returns>The sort.</returns>
        /// <param name="list">List.</param>
		static Dictionary<int, double> sort(List<Dictionary<int, double>> list)
		{
			Dictionary<int, double> minList = new Dictionary<int, double>();
			foreach (var item in list)
			{
				KeyValuePair<int, double> min = getMin(item, minList, -1);
				minList.Add(min.Key, min.Value);
			}
			return minList;
		}

        /// <summary>
        /// 递归拿最小值
        /// </summary>
        /// <returns>The minimum.</returns>
        /// <param name="item">Item.</param>
        /// <param name="oldMin">Old minimum.</param>
        /// <param name="except">Except.</param>
		static KeyValuePair<int, double> getMin(Dictionary<int, double> item, Dictionary<int, double> oldMin, int except)
		{
			item.Remove(except);
			KeyValuePair<int, double> itemMin =
					 item.Keys
					 .Select(x => new KeyValuePair<int, double>(x, item[x]))
					 .OrderBy(x => x.Value).First();
			if (!oldMin.ContainsKey(itemMin.Key))
			{
				return itemMin;
			}
			return getMin(item, oldMin, itemMin.Key);
		}
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			List<Dictionary<int, double>> list = init();
			foreach(var item in sort(list))
				Console.WriteLine("key={0},value={1}",item.Key,item.Value);
		}
	}
}