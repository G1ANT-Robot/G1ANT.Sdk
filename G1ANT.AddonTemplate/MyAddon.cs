using System;
using System.Collections.Generic;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;

using G1ANT.Language;


namespace $safeprojectname$
{
    [Addon(Name = "", Tooltip = "")]
    [Copyright(Author = "G1ANT LTD", Copyright = "G1ANT LTD", Email = "support@g1ant.com", Website = "www.g1ant.com")]
    [License(Type = "LGPL", ResourceName = "License.txt")]
    [CommandGroup(Name = "", Tooltip = "")]
    public class $safeitemrootname$ : Addon
    {
    }
}
