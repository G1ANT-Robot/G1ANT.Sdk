using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;
using G1ANT.Language;

namespace $rootnamespace$
{
    [Wizard(Name = "$safeitemrootname$", ExecuteOnFirstRun = false, Menu = "Tools\My Wizards", 
        Shortcut = Keys.None, ToolTip = "...")]
    public class $safeitemrootname$ : Wizard
	{

        public override void Execute(AbstractScripter scripter)
        {
            MessageBox.Show("This is my own wizard, where I can do something");
        }
    }
}