
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORT_06
{
    public class AList1 : IList
    {
        static int arrayMax = 10;
        public int[] ar = new int[arrayMax];
        int index = 0;

        public AList1()
        {

        }
        public void Resize()
        {
            arrayMax += arrayMax * 4 / 10;
            Array.Resize<int>(ref ar, arrayMax);
        }
        public bool Full()
        {
            return (arrayMax - Size() <= 2);
        }

        public void Init(int[] ini)
        {
            if (ini == null)
            {
                ini = new int[0];
            }
            int l = ini.Length;
            while (true)
            {
                if (l > arrayMax - 2)
                {
                    Resize();
                }
                else
                    break;
            }
            
            for (int i = 0; i < l; i++)
            {
                ar[i] = ini[i];
            }
            index = l;
        }

        public void Clear()
        {
            index = 0;
            Array.Resize<int>(ref ar, 10);
        }

        public override String ToString()
        {
            String str = "";
            for (int i = 0; i < index; i++)
            {
                if (i != index - 1)
                    str += ar[i] + ", ";
                else
                    str += ar[i];
            }
            return str;
        }
        public int[] ToArray()
        {
            int[] ret = new int[index];
            for (int i = 0; i < index; i++)
            {
                ret[i] = ar[i];
            }
            return ret;
        }
        public void AddStart(int val)
        {
            if (Full())
                Resize();
            for (int i = index; i > 0; i--)
            {
                ar[i] = ar[i - 1];
            }
            index++;
            ar[0] = val;
            if (Full())
                Resize();
        }
        public void AddEnd(int val)
        {
            if (Full())
                Resize();
            ar[index++] = val;
            if (Full())
                Resize();
        }
        public void AddPos(int pos, int val)
        {
            if ((pos > index) || (pos < 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Full())
                Resize();
            for (int i = index; i > pos; i--)
            {
                ar[i] = ar[i - 1];
            }
            index++;
            ar[pos] = val;
            if (Full())
                Resize();
        }
        public int DelStart()
        {
            if (index == 0)
            {
                throw new IndexOutOfRangeException();
            }
            int tmp = ar[0];
            index--;
            for (int i = 0; i < index; i++)
            {
                ar[i] = ar[i + 1];
            }
            return tmp;
        }
        public int DelEnd()
        {
            if (index == 0)
            {
                throw new IndexOutOfRangeException();
            }
            index--;
            return ar[index];
        }
        public int DelPos(int pos)
        {
            if (index == 0)
            {
                throw new IndexOutOfRangeException();
            }
            if ((pos > index) || (pos < 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            int tmp = ar[pos];
            index--;
            for (int i = pos; i < index; i++)
            {
                ar[i] = ar[i + 1];
            }
            return tmp;
        }
        public int Min()
        {
            if (index == 0)
            {
                throw new IndexOutOfRangeException();
            }
            int tmp = ar[0];
            for (int i = 1; i < index; i++)
            {
                if (tmp > ar[i])
                    tmp = ar[i];
            }
            return tmp;
        }
        public int Max()
        {
            if (index == 0)
            {
                throw new IndexOutOfRangeException();
            }
            int tmp = ar[0];
            for (int i = 1; i < index; i++)
            {
                if (tmp < ar[i])
                    tmp = ar[i];
            }
            return tmp;
        }
        public int MinInd()
        {
            if (index == 0)
            {
                throw new IndexOutOfRangeException();
            }
            int tmp = 0;
            for (int i = 0; i < index; i++)
            {
                if (ar[tmp] > ar[i])
                    tmp = i;
            }
            return tmp;
        }
        public int MaxInd()
        {
            if (index == 0)
            {
                throw new IndexOutOfRangeException();
            }
            int tmp = 0;
            for (int i = 0; i < index; i++)
            {
                if (ar[tmp] < ar[i])
                    tmp = i;
            }
            return tmp;
        }
        public void Set(int pos, int val)
        {
            if ((pos >= index) || (pos < 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            ar[pos] = val;
        }
        public int Get(int pos)
        {
            if ((pos >= index) || (pos < 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            return ar[pos];
        }
        public void Reverse()
        {
            for (int i = 0; i < index / 2; i++)
            {
                int tmp = ar[i];
                ar[i] = ar[index - i - 1];
                ar[index - i - 1] = tmp;
            }
        }
        public void HalfReverse()
        {
            for (int i = 0; i < index / 2; i++)
            {
                int tmp = ar[i];
                ar[i] = ar[index - index / 2 + i];
                ar[index - index / 2 + i] = tmp;
            }
        }
        public void Sort()
        {
            for (int i = 1; i < index; i++)
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
            if ((pos > index) || (pos < 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            int l = ini.Length;
            while (true)
            {
                if (ar.Length < index + l + 2)
                    Resize();
                else
                    break;
            }
            index = index + l;
            for (int i = index - 1; i >= pos + l; i--)
            {
                ar[i] = ar[i - l];
            }
            for (int i = pos; i < pos + l; i++)
            {
                ar[i] = ini[i - pos];
            }
        }
        public int Size()
        {
            return index;
        }

    }
}