using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;
using System.Windows.Forms;
using G1ANT.Language;

namespace $rootnamespace$
{
    [Panel(Name = "Addons",
        Tooltip = "Lists all available addons and allows to select and deselect them, turning them on and off.",
        DockingSide = DockingSide.Left, InitialAppear = false, Width = 250)]
    public partial class AddonsPanel : RobotPanel
    {
        public $safeitemrootname$()
        {
        }

        public override void Initialize(IMainForm mainForm)
        {
            base.Initialize(mainForm);
            // do something to initialise panel
        }

        public override void RefreshContent()
        {
            // some code to refresh controls on the panel
        }
    }
}