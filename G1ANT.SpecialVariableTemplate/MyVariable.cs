using System;
using System.Collections.Generic;
using System.Windows.Forms;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;

using G1ANT.Language;


namespace $rootnamespace$
{
	[Variable(Name = "$safeitemrootname$", Tooltip = "...")]
	public class $safeitemrootname$ : Variable
	{
        public $safeitemrootname$(AbstractScripter scripter) : base(scripter)
        {
        }

        public override Structure GetValue(string index = "")
        {
            return new TextStructure("something");
        }

        public override void SetValue(Structure value, string index = "")
        {
            // set something to value.ToString() or do something else
        }
	}
}