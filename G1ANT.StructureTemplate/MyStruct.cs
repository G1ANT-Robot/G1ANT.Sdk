using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $rootnamespace$
{
    public class MyStruct
    {
        // Example field values of MyStruct which is the part of $safeitemrootname$

        public int Num { get; set; } = 0;

        public string Text { get; set; } = "";

        public MyStruct(int num, string text)
        {
            Num = num;
            Text = text;
        }

        public MyStruct()
        {
        }
    }
}
