using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;

namespace ORT_06
{
    public class AList0:IList
    {
        int[] ar = { };

        public AList0()
        {

        }

        public void Init(int[] ini)
        {
            if (ini == null)
            {
                ini = new int[0];
            }
            ar = new int[ini.Length];
            for (int i = 0; i < ini.Length; i++)
            {
                ar[i] = ini[i];
            }
        }
        public void Clear()
        {
            ar = new int[0];
        }

        public override String ToString()
        {
            String str = "";
            for (int i = 0; i < ar.Length; i++)
            {
                if (i != ar.Length - 1)
                    str += ar[i] + ", ";
                else
                    str += ar[i];
            }
            return str;
        }
        public int[] ToArray()
        {
            int[] tmp = new int[ar.Length];
            for (int i = 0; i < ar.Length; i++)
            {
                tmp[i] = ar[i];
            }
            return tmp;
        }

        public void AddEnd(int val)
        {
            int[] tmp = new int[ar.Length + 1];
            for (int i = 0; i < ar.Length; i++)
            {
                tmp[i] = ar[i];
            }
            tmp[tmp.Length - 1] = val;
            ar = tmp;
        }
        public void AddStart(int val)
        {
            int[] tmp = new int[ar.Length + 1];
            for (int i = 0; i < ar.Length; i++)
            {
                tmp[i + 1] = ar[i];
            }
            tmp[0] = val;
            ar = tmp;
        }
        public void AddPos(int pos, int val)
        {
            if (((pos > ar.Length) && (ar.Length != 0)) || (pos < 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            int[] tmp = new int[ar.Length + 1];
            for (int i = 0; i < pos; i++)
            {
                tmp[i] = ar[i];
            }
            for (int i = pos; i < ar.Length; i++)
            {
                tmp[i + 1] = ar[i];
            }
            tmp[pos] = val;
            ar = tmp;
        }
        public int DelStart()
        {
            if (ar.Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            int val = ar[0];
            int[] tmp = new int[ar.Length - 1];
            for (int i = 0; i < ar.Length - 1; i++)
            {
                tmp[i] = ar[i + 1];
            }
            ar = tmp;
            return val;
        }
        public int DelEnd()
        {
            if (ar.Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            int val = ar[ar.Length - 1];
            int[] tmp = new int[ar.Length - 1];
            for (int i = 0; i < ar.Length - 1; i++)
            {
                tmp[i] = ar[i];
            }
            ar = tmp;
            return val;
        }
        public int DelPos(int pos)
        {
            if (ar.Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            if ((pos > ar.Length) || (pos < 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            int val = ar[pos];
            int[] tmp = new int[ar.Length - 1];
            for (int i = 0; i < pos; i++)
            {
                tmp[i] = ar[i];
            }
            for (int i = pos; i < ar.Length - 1; i++)
            {
                tmp[i] = ar[i + 1];
            }
            ar = tmp;
            return val;
        }
        public int Min()
        {
            if (ar.Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            int tmp = ar[0];
            for (int i = 1; i < ar.Length; i++)
            {
                if (tmp > ar[i])
                    tmp = ar[i];
            }
            return tmp;
        }
        public int Max()
        {
            if (ar.Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            int tmp = ar[0];
            for (int i = 1; i < ar.Length; i++)
            {
                if (tmp < ar[i])
                    tmp = ar[i];
            }
            return tmp;
        }
        public int MinInd()
        {
            if (ar.Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            int tmp = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[tmp] > ar[i])
                    tmp = i;
            }
            return tmp;
        }
        public int MaxInd()
        {
            if (ar.Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            int tmp = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[tmp] < ar[i])
                    tmp = i;
            }
            return tmp;
        }
        public void Set(int pos, int val)
        {
            if ((pos >= ar.Length) || (pos < 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            ar[pos] = val;
        }
        public int Get(int pos)
        {
            if ((pos >= ar.Length) || (pos < 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            return ar[pos];
        }
        public void Reverse()
        {
            for (int i = 0; i < ar.Length / 2; i++)
            {
                int tmp = ar[i];
                ar[i] = ar[ar.Length - i - 1];
                ar[ar.Length - i - 1] = tmp;
            }
        }
        public void HalfReverse()
        {
            for (int i = 0; i < ar.Length / 2; i++)
            {
                int tmp = ar[i];
                ar[i] = ar[ar.Length - ar.Length / 2 + i];
                ar[ar.Length - ar.Length / 2 + i] = tmp;
            }
        }
        public void Sort()
        {
            for (int i = 1; i < ar.Length; i++)
            {
                int j;
                int temp = ar[i];
                for (j = i - 1; j >= 0; j--)
                {
                    if (ar[j] < temp)
                        break;
                    ar[j + 1] = ar[j];
                }
                ar[j + 1] = temp;
            }
        }
        public void AddPos(int pos, int[] ini)
        {
            if (((pos > ar.Length) && (ar.Length != 0)) || (pos < 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            int[] tmp = new int[ar.Length + ini.Length];
            for (int i = 0; i < pos; i++)
            {
                tmp[i] = ar[i];
            }
            for (int i = pos; i < pos + ini.Length; i++)
            {
                tmp[i] = ini[i - pos];
            }
            for (int i = pos + ini.Length; i < ar.Length + ini.Length; i++)
            {
                tmp[i] = ar[i - ini.Length];
            }
            ar = tmp;
        }
        public int Size()
        {
            return ar.Length;
        }
    }
}