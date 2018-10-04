/**
*    Copyright(C) G1ANT Ltd, All rights reserved
*    Solution G1ANT.Sdk, File G1ANT.Language.g4
*    www.g1ant.com
*
*    Licensed under the LGPL license.
*    See License.txt file in the project root for full license information.
*
*/

grammar G1ANT;

@parser::members {
  private HashSet<string> blockCommands = new HashSet<string>();

  public void SetBlockCommands(HashSet<string> blockCommands)
  {
    this.blockCommands = blockCommands;
  }
}

script
	: EOL* scriptLine*
	;

scriptLine
	: SPACE* (emptyLine | lineComment | command)
	;

emptyLine
	: EOL ; 

lineComment
    : LINECOMMENT EOL ;

command
	: blockCommand
	| lineCommand
	| variableAssignment
	| snippetCommand
	| LINESNIPPET
	;

blockCommand
	: {blockCommands.Contains(_input.Lt(1).Text.ToLower())}? cmd=commandName (SPACE+ argumentValue argumentPair* | argumentPair*)? SPACE* EOL
	  scriptLine*
	  END_IDENT SPACE+ { _input.Lt(1).Text.Equals($cmd.text) }? commandName SPACE* EOL
	;

lineCommand
	: commandName (SPACE+ argumentValue argumentPair* | argumentPair*)? SPACE* EOL
	;

commandName
	: IDENT ('.' IDENT)?
	;

argumentPair
	: SPACE+ argumentName SPACE+ argumentValue
	;

argumentName
	: IDENT
	;

argumentValue
	: commandExpression
	;

commandExpression
	: (expression
	| ~(EOL|SPACE))+
	;

snippetCommand
	: '⊂' EOL
	  snippetCode
	  '⊃' EOL
	;

snippetCode
	: ((~(EOL|'⊃')*)? EOL)*
	;

variableAssignment
	: VARIABLE SPACE* '=' SPACE* STRUCTURECAST? variableExpression EOL
	;

variableExpression
	: (expression
	| ~EOL)+
	;

expression
    : VARIABLE
    | BRACKETTEXT
    | LINESNIPPET
    | KEY
    ;

VARIABLE
    : '♥' IDENT VARIABLEINDEX*
    ;

STRUCTURECAST
	: '⟦' STRUCTURENAME (':' STRUCTUREFORMAT )? '⟧'
	;

fragment STRUCTURENAME
	: IDENT
	;

fragment STRUCTUREFORMAT
	: ~[\r\n]*
	;

BRACKETTEXT
	: '‴' ~[\r\n‴]* '‴'
	;

LINESNIPPET
	: '⊂' ~[\r\n⊃]* '⊃'
	;

KEY
	: '⋘' ~[\r\n⋙]* '⋙'
	;

VARIABLEINDEX
	: '⟦' ~[\r\n⟧]* '⟧'
	;

COMMENT
	: '-' ;

END_IDENT
	: [eE] [nN] [dD]
	;

IDENT
	: LETTER (LETTER | DIGIT)*
	;

LINECOMMENT
	: '-' ~[\r\n]*
	;

LETTER
	: 'a'..'z'
	| 'A'..'Z'
	;

DIGIT
	: '0'..'9'
	;

SPACE
	: ' ' | '\t';

EOL
    : '\r'? '\n' | '\r';

WS
	: SPACE+ -> skip;
