using System;
using System.Collections.Generic;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;

using G1ANT.Language;


namespace $safeprojectname$
{
    [Addon(Name = "$safeitemrootname$", Tooltip = "")]
    [Copyright(Author = "G1ANT LTD", Copyright = "G1ANT LTD", Email = "support@g1ant.com", Website = "www.g1ant.com")]
    [License(Type = "LGPL", ResourceName = "License.txt")]
    //[CommandGroup(Name = "", Tooltip = "")]
    public class Addon : Language.Addon
    {

        public override void Check()
        {
            base.Check();
            // Check integrity of your Addon
            // Throw exception if this Addon needs something that doesn't exists
        }

        public override void LoadDlls()
        {
            base.LoadDlls();
            // All dlls embeded in resources will be loaded automatically,
            // but you can load here some additional dlls:

            // Assembly.Load("...")
        }

        public override void Initialize()
        {
            base.Initialize();
            // Insert some code here to initialize Addon's objects
        }

    public override void Dispose()
        {
            base.Dispose();
            // Insert some code here which will dispose all unecessary objects when this Addon will be unloaded
        }
    }
}