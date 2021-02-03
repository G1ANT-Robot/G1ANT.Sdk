/**
*    Copyright(C) G1ANT Ltd, All rights reserved
*    Solution G1ANT.Sdk, File G1ANT.Language.g4
*    www.g1ant.com
*
*    Licensed under the LGPL license.
*    See License.txt file in the project root for full license information.
*
*/

grammar g1ant;

@lexer::header {
  using AntlrTest.G1Parser;
}

@lexer::members {
  public static LexerTokenLookup tokenLookup = LexerTokenLookup.Instance;
}

@parser::header {
  using AntlrTest.G1Parser;
}

@parser::members {
  public static LexerTokenLookup tokenLookup = LexerTokenLookup.Instance;
}

tokens {
  BLOCK_COMMAND_NAME,
  BLOCK_COMMAND_END
}

script :
  (action)+ EOF;

action :
    WHITESPACE* 
    (
    EOL 
    | (
        comment 
        | command 
        | {tokenLookup.IsEnabled(g1antParser.BLOCK_COMMAND_NAME) && tokenLookup.IsEnabled(g1antParser.BLOCK_COMMAND_END)}? blockCommand 
        | assignment 
        | snippet 
        | snippetMultiline
      ) WHITESPACE* (EOL | EOF)
    );

command :
    commandName=COMMAND_NAME (WHITESPACE+ expression)? (WHITESPACE+ commandArgument)*;

blockCommand:
    commandName=BLOCK_COMMAND_NAME (WHITESPACE+ expression)? (WHITESPACE+ commandArgument)* WHITESPACE* EOL+
    (action)*
    WHITESPACE* BLOCK_COMMAND_END (WHITESPACE+ commandNameEnd=BLOCK_COMMAND_NAME)?;

commandArgument :
    identifier WHITESPACE+ expression;

expressionWithSpaces:
    (WHITESPACE* (quotedText | expressionPart))* WHITESPACE*;

expressionPartsWithSpaces:
    (WHITESPACE* expressionPart)* WHITESPACE*;

expression :
    (quotedText | expressionPart | keystroke)*;

expressionPart :
    variable
    | snippet
    | simpleText;

keystroke:
    LSHORTCUT expressionPartsWithSpaces RSHORTCUT;

snippet:
    LSNIPPET expressionWithSpaces RSNIPPET;

snippetMultiline:
    LSNIPPET
    WHITESPACE*
    (expressionWithSpaces EOL)+
    WHITESPACE*
    RSNIPPET;

assignment :
    variable WHITESPACE* VAR_ASSIGN WHITESPACE* (variableIndex)? expressionWithSpaces;

variable :
    VARIABLE variableIndex*;

variableIndex :
    LVARINDEX expressionWithSpaces RVARINDEX;

comment :
    COMMENT_PREFIX ~(EOL)*;

identifier :
    ID
    | COMMAND_NAME
    | BLOCK_COMMAND_NAME
    | BLOCK_COMMAND_END;

quotedText :
    QUOTE_CHAR expressionPartsWithSpaces QUOTE_CHAR;

simpleText
	: ~(QUOTE_CHAR | WHITESPACE | EOL | VARIABLE | LVARINDEX | RVARINDEX | LSNIPPET | RSNIPPET | LSHORTCUT | RSHORTCUT | ARRAY_DELIMITER | POINT_DELIMITER)+;

QUOTE_CHAR : '‴';
LSNIPPET : '⊂';
RSNIPPET : '⊃';
LSHORTCUT : '⋘';
RSHORTCUT : '⋙';
LVARINDEX : '⟦';
RVARINDEX : '⟧';
PROCEDURE_PREFIX : '➤';
LABEL_PREFIX : '➜';
ARRAY_DELIMITER : '❚';
POINT_DELIMITER : '⫽';
SEARCH_CHAR : '✱';
VAR_ASSIGN : '=';
COMMAND_GROUP_DELIMITER : '.';
COMMENT_PREFIX : '-';

VARIABLE : VAR_PREFIX ID;

//BLOCK_COMMAND_END : E N D;

COMMAND_NAME : 
    ID (COMMAND_GROUP_DELIMITER ID)?
    {
        if (tokenLookup.IsEnabled(g1antParser.BLOCK_COMMAND_NAME) && tokenLookup.IsEnabled(g1antParser.BLOCK_COMMAND_END))
        {
            if(tokenLookup.Contains(g1antParser.BLOCK_COMMAND_NAME, Text)) 
                Type = g1antParser.BLOCK_COMMAND_NAME;
            else if(tokenLookup.Contains(g1antParser.BLOCK_COMMAND_END, Text)) 
                Type = g1antParser.BLOCK_COMMAND_END;
        }
    };

ID : VALID_ID_CHAR (VALID_ID_CHAR | NUMBER)*;

WHITESPACE : ' ' | '\t';

EOL : [\r\n]+;

ANYCHAR : '\u0000'..'\uFFFE';

fragment VAR_PREFIX : '♥';
fragment VALID_ID_CHAR : ('a' .. 'z') | ('A' .. 'Z') | '_' ;
fragment NUMBER : ('0' .. '9') ;

fragment A : [aA]; // match either an 'a' or 'A'
fragment B : [bB];
fragment C : [cC];
fragment D : [dD];
fragment E : [eE];
fragment F : [fF];
fragment G : [gG];
fragment H : [hH];
fragment I : [iI];
fragment J : [jJ];
fragment K : [kK];
fragment L : [lL];
fragment M : [mM];
fragment N : [nN];
fragment O : [oO];
fragment P : [pP];
fragment Q : [qQ];
fragment R : [rR];
fragment S : [sS];
fragment T : [tT];
fragment U : [uU];
fragment V : [vV];
fragment W : [wW];
fragment X : [xX];
fragment Y : [yY];
fragment Z : [zZ];
