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
    public class $safeitemrootname$ : Language.Addon
    {

        public override void Check()
        {
            base.Check();
            // Check integrity of your Addon
            // Throw exception if this Addon is wrong in any way
        }

        public override void LoadDlls()
        {
            base.LoadDlls();
            // all dlls embeded in resources will be load automaticaly,
            // but you can load here some additional dlls:

            // Assembly.Load("...")
        }

        public override void Initialize()
        {
            base.Initialize();
            // put here some code to initialize addon's objects
        }

        public override void Dispose()
        {
            base.Dispose();
            // put here some code which will dispose all unecessary objects when this addon will be unloaded
        }
    }
}