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
    }
}