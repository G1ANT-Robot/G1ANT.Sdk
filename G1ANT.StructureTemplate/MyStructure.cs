using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;
using G1ANT.Language;

namespace $rootnamespace$
{
    [Structure(Name = "$safeitemrootname$", Priority = 100, Default = default(MyStruct), Tooltip = "...")]
    public class $safeitemrootname$ : StructureTyped<MyStruct>
	{
        public $safeitemrootname$() : 
            base(new MyStruct(), null, null)
        {
        }

        public $safeitemrootname$(MyStruct value, string format = "", AbstractScripter scripter = null) :
            base(value, format, scripter)
        { 
        }

        public $safeitemrootname$(string value, string format = "") : 
            this(value, format, null)
        {
        }

        public $safeitemrootname$(object value, string format = null, AbstractScripter scripter = null) : 
            base(value, format, scripter)
        { 
        }

        public override Structure Get(string index = "")
        {
            // Example implementation, how to get data from this structure
            if (String.IsNullOrWhiteSpace(index))
                return this;

            switch(index.Trim().ToLower())
            {
                case "num":
                    return Value.Num;
                case "text":
                    return Value.Text;
                default:
                    throw new ArgumentException($"Unknown index {index}");
            }
        }

        public override void Set(Structure structure, string index = null)
        {
            // Example implementation, how to set data into this structure
            if (structure == null || structure.Object == null)
                throw new ArgumentNullException(nameof(structure));

            if (String.IsNullOrWhiteSpace(index))
                this.Value = (MyStruct)structure.Object;
            else
                switch(index.Trim().ToLower())
                {
                    case "num":
                        Value.Num = (int)structure.Object;
                        break;
                    case "text":
                        Value.Text = (string)structure.Text;
                        break;
                    default:
                        throw new ArgumentException($"Unknown index {index}");
                }
        }

        public override string ToString(string format = "")
        {
            // Implement method which will convert MyStruct into string 
            // based on format (parameter) or Format (instance property)
            if (string.IsNullOrWhiteSpace(format))
                format = this.Format;

            if (string.IsNullOrWhiteSpace(format))
                // Example: num:15,text:"Hello World"
                return $"num:{Value.Num},text:\"{Value.Text}\"";
            else
                // Example: {num},{text} will produce: 15,Hello World
                return format.Replace("{num}", Value.Num).Replace("{text}", Value.Text);
        }

        protected override MyStruct Parse(string value, string format = null)
        {
            // Implement method which will convert value from string into MyStruct 
            // based on format (parameter) or Format (instance property)
            // format isn't implemented, we're using: 
            // example: num:15,text:"Hello World"
            if (value.Contains("num:") == false || value.Contains("text:") == false)
                throw new ArgumentException("Expected, for example num:15,text:\"Hello World\"");

            MyStruct my = new MyStruct();
            int indexOfComma = value.IndexOf(',');
            string num = value.Substring(0, indexOfComma - 1).Trim();
            num = num.Substring("num:".Length);
            string text = value.Substring(indexOfComma + 1).Trim();
            text = text.Substring("text:".Length).Trim();
            text = text.Substring(1, text.Length - 2);
            Value = new MyStruct(num, text);
        }
    }
}