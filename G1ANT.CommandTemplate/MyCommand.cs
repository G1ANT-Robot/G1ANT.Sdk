using System;
using System.Collections.Generic;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;

using G1ANT.Language;


namespace $rootnamespace$
{
	[Command(Name = "", Tooltip = "")]
	class $safeitemrootname$ : Command
	{
		public $safeitemrootname$(AbstractScripter scripter) : base(scripter)
		{ }
	}
}
