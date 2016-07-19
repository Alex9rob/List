using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORT_06
{
    public interface IList
    {
        void Init(int[] ini);
        void Clear();
        String ToString();
        int[] ToArray();
        void AddEnd(int val);
        void AddStart(int val);
        void AddPos(int pos, int val);
        int DelStart();
        int DelEnd();
        int DelPos(int pos);
        int Min();
        int Max();
        int MinInd();
        int MaxInd();
        void Set(int pos, int val);
        int Get(int pos);
        //void Reverse();
        //void HalfReverse();
        //void Sort();
        //void AddPos(int pos, int[] ini);
        int Size();
    }
}
