using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;
using G1ANT.Language;

namespace $rootnamespace$
{
    [Command(Name = "$safeitemrootname$", Priority = 100, Default = default(MyStruct), Tooltip = "...")]
    public class $safeitemrootname$ : Language.BlockCommand
	{
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "If the condition expressed with a C# snippet returns true, the robot will execute everything that is between `if` and `end`, or `if` and `else if`, or `if` and `else` commands")]
            public BooleanStructure Condition { get; set; }
        }

        public $safeitemrootname$(AbstractScripter scripter) : base(scripter)
        {
        }

        public override bool PreParse_CanProcessLine(string line, Command preParseCommand, ArgumentsBase preParseArguments)
        {
            // check something...

            return base.PreParse_CanProcessLine(line, preParseCommand, preParseArguments);
        }

        protected override BlockItem CreateBlockItem(string name, ArgumentsBase defaultArguments, int startLine, string definition)
        {
            return new $safeitemrootname$tem(name, defaultArguments, startLine, definition);
        }

        public override void OnEndBlock(bool forceExit)
        {
            if (Scripter.Stack.Count == 0)
                throw new StackOverflowException("Found end command without a corresponding block. Add a block command (like \"if\" or \"for\") before using the end command");
            else
            {
                StackItem stack = Scripter.Stack.Pop();
                if (stack.Block is $safeitemrootname$Item ifBlock)
                    Scripter.CurrentLine = ifBlock.EndLine;
                else
                    throw new AccessViolationException("Block is not inherited from $safeitemrootname$Item class");
            }
        }

        public void Execute(Arguments arguments)
        {
            $safeitemrootname$Item blockItem = FindBlockItemByStartLine(Scripter.CurrentLine) as $safeitemrootname$Item;
            if (blockItem == null)
                throw new CommandException($"Cannot find block command");

            StackItem stackItem = Scripter.CreateStackItem(blockItem);
            stackItem.ErrorJump = arguments.ErrorJump;
            stackItem.ErrorCall = arguments.ErrorCall;
            stackItem.ErrorResult = arguments.ErrorResult;
            stackItem.ErrorMessage = arguments.ErrorMessage;

            bool jumpToEnd = true;
            if (arguments.Condition.Value)
            {
                Scripter.Stack.Push(stackItem);
                jumpToEnd = false;
            }
            else if (blockItem.ElseStatements.Count > 0)
            {
                foreach (var item in blockItem.ElseStatements)
                {
                    ParserResult result = Scripter.Parser.ParseLine(item.Value);
                    if (result.Arguments is ElseCommand.Arguments cmdArgs)
                    {
                        if (cmdArgs.If.Value)
                        {
                            Scripter.CurrentLine = item.Key;
                            Scripter.Stack.Push(stackItem);
                            jumpToEnd = false;
                            break;
                        }
                    }
                }
            }
            if (jumpToEnd)
            {
                Scripter.CurrentLine = blockItem.EndLine;
            }
        }
    }

    public class $safeitemrootname$Item : BlockItem
    {
        public $safeitemrootname$Item(string name, ArgumentsBase defaultArguments, int startLine, string def)
            : base(name, defaultArguments, startLine, def)
        {
        }
    }
}