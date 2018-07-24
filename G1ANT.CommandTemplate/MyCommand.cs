using System;
using System.Collections.Generic;
using System.Windows.Forms;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;

using G1ANT.Language;


namespace $rootnamespace$
{
	[Command(Name = "", Tooltip = "")]
	class $safeitemrootname$ : Command
	{
        public class Arguments : CommandArguments
        {
            // Enter all arguments you need
            [Argument(Required = true, Tooltip = "...")]
            public TextStructure Text { get; set; }

            [Argument(Tooltip = "Result variable")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }

        public $safeitemrootname$(AbstractScripter scripter) : 
            base(scripter)
        {
        }

        // Implement this method
        public void Execute(Arguments arguments)
        {
            // do something: for example, display argument text on the screen
            MessageBox.Show(arguments.Text.Value);

            // set result variable to the calculated text argument
            Scripter.Variables.SetVariableValue(arguments.Result.Value, new TextStructure(arguments.Text.Value));

            // set other variable to the calculated text argument
            Scripter.Variables.SetVariableValue("other", new TextStructure(arguments.Text.Value));
        }
	}
}