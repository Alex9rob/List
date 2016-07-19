using ORT_06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // LList2 lst = new LList2();
            //LList1 lst = new LList1();
           // AListR lst = new AListR();

            //AList0 lst = new AList0();
            AList1 lst = new AList1();
            //AList2 lst = new AList2();
            //LListR lst = new LListR();
            int[] d = new int[] { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            //  int[] d = new int[] { 1 };

            // int[] y = new int[] { 13, 66 };
            //int[] o = new int[] { 0, 0, 0 };
            //////int[] tt = null;
            //int[] rr = { 10, 20, 34, 77, 11, 99, 17, 0 };
            ////int[] dd = {};
             lst.Init(d);
            //lst.Resize();


           // int[] a = lst.ToArray();

            Console.WriteLine(lst);

           // Console.WriteLine(lst.Size());
            lst.Clear();
            //lst.AddStart(333);
            //lst.AddStart(222);
            Console.WriteLine(lst);

            Console.ReadLine();
        }
    }
}
