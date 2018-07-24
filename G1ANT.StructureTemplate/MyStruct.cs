using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1ANT.StructureTemplate
{
    public class MyStruct
    {
        // Example field values of MyStruct which is the part of $safeitemrootname$
        public MyStruct(int num, string text)
        {
            Num = num;
            Text = text;
        }

        public int Num { get; set; } = 0;

        public string Text { get; set; } = "";
    }
}
