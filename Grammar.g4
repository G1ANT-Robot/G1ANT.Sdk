/**
*    Copyright(C) G1ANT Ltd, All rights reserved
*    Solution G1ANT.Sdk, File Grammar.g4
*    www.g1ant.com
*
*    Licensed under the LGPL license.
*    See License.txt file in the project root for full license information.
*
*/

grammar G1ANT;

script
	: scriptLine*
	;
	
scriptLine
	: command 
	| lineComment
	;

lineComment
	: '-' LINECHAR* EOL
	;

command
	: lineCommand[name ('.' name)?] 
	| blockCommand[name ('.' name)?] 
	| variableCommand 
	| snippetCommand
	;

snippetCommand
	: SPACE* '⊂' SPACE* EOL
	  snippetCode
	  SPACE* '⊃' SPACE* EOL
	;

snippetCode
	: (ANYCHAR* EOL)*
	;

variableCommand
	: SPACE* '♥' variableName variableIndex* SPACE* '=' SPACE* structureCast? expression SPACE* EOL
	;

variableName
	: name
	;

variableIndex
	: '⟦' LINECHAR* '⟧'
	;

structureCast
	: '⟦' structureName (':' structureFormat )? '⟧'
	;

structureFormat
	: LINECHAR*
	;

structureName
	: name
	;

/* to discuss: */
name
	: LETTER ~EOLSPACECHAR*
	;

blockCommand[string blockName]
	: lineCommand[blockName]
	  script 
	  SPACE* "end" SPACE+ blockName EOL
	;

lineCommand[string commandName]
	: SPACE* commandName SPACE* (SPACE+ arguments)? EOL
	;

arguments
	: (argumentName SPACE+)? argumentValue (SPACE+ argumentName SPACE+ argumentValue)+
	;

argumentName
	: name
	;

expression
	: expressionPart+
	;
	
expressionPart
	: noSpaceText 
	| bracketText 
	| lineSnippet 
	| key
	;

noSpaceText
	: ~EOLSPACECHAR+
	;

bracketText
	: '‴' LINECHAR* '‴'
	;

lineSnippet
	: '⊂' LINECHAR+ '⊃'
	;

key
	: '⋘' LINECHAR+ '⋙'
	;

EOLSPACECHAR
	: ' ' 
	| '\t' 
	| '\r' 
	| '\n'
	;

SPACE
	: ' ' 
	| '\t'
	;

LINECHAR
	: ~EOL
	;

ANYCHAR
	: .
	;

LETTER
	: 'a'..'z' 
	| 'A'..'Z'
	;

DIGIT
	: '0'..'9'
	;
