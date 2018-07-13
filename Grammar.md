# G1ANT.Language Formal Grammar

```
<script> ::= <line-command> | <block-command> | <end-of-line> { <full-comand> <end-of-line> }

<line-comand> ::= <command-with-arguments> | <special-command>

<command-with-arguments> ::= <command-name> { <space> <argument-name> <space> <argument-value> } | <command-name> <space> <argument-value> { <space> <argument-name> <space> <argument-value> }

<command-name> ::= <symbol> | <symbol> . <symbol>

<argument-name> ::= <symbol>

<argument-value> ::= 





<symbol> ::= <letter> { <letter-or-digit> }

<letter-or-digit> ::= <letter> | <digit>

<letter> ::= <lower-letter> | <upper-letter>

<lower-letter> ::= a | b | c | d | e | f | g | h | i | j | k | l | m | n | o | p | q | r | s | t | u | v | w | x | y | z

<upper-letter> ::= A | B | C | D | E | F | G | H | I | J | K | L | M | N | O | P | Q | R | S | T | U | V | W | X | Y | Z

<digit> ::= 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9

<end-of-line> ::= \r\n

<space> ::= \t | \s
```
