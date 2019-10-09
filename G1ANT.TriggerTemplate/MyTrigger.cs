using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;
using G1ANT.Language;

namespace $rootnamespace$
{
    [Trigger(Name = "$safeitemrootname$"]
    public class $safeitemrootname$ : Language.TriggerTyped<MailTrigger.Arguments, MailTrigger.TaskArguments>, IDisposable
	{
        public class Arguments : TriggerArguments
        {
            [TriggerArgument(Required = true)]
            public TextStructure MyExampleFileName { get; set; }
        }

        public class TaskArguments : TriggerTaskArguments
        {
            [TriggerArgument(Required = true)]
            public TextStructure MyFileContent { get; set; }
        }

        public override bool Initialize(Arguments arguments)
        {
            // initialise trigger
            return true;
        }

        public override bool Active
        {
            set
            {
                if (value)
                {
                    // activate trigger
                }
                else
                {
                    // deactivate trigger
                }
            }
            get
            {
                return true; // if trigger active
            }
        }

        public override bool Check(Arguments arguments, out TaskArguments taskArguments)
        {
            
            // Should I execute task by this trigger?
            // For example: is there any new file in folder to process data?
            if (File.Exists(arguments.MyExampleFileName.Value))
            {
                taskArguments = new TaskArguments()
                {
                    MyFileContent = File.ReadAllText(arguments.MyExampleFileName.Value)
                };
                File.Delete(arguments.MyExampleFileName.Value);
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            Stop();
        }

    }
}