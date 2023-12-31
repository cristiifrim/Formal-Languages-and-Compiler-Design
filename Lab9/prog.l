%{ 	 
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "parser.tab.h"
int lines = 1;
%} 

%option noyywrap
%option caseless

DIGIT 		[0-9]
WORD		\"[a-zA-Z0-9]*\"
NUMBER		[+-]?[1-9][0-9]*|0$
CHARACTER 	\'[a-zA-Z0-9]\'
const		{WORD}|{NUMBER}|{CHARACTER}|{DIGIT}
id		[a-zA-Z][a-zA-Z0-9_]{0,7}

%%

and {printf("Reserved word: %s\n", yytext); return AND;}
array {printf( "Reserved word: %s\n", yytext); return ARRAY;}
else {printf( "Reserved word: %s\n", yytext); return ELSE;}
for {printf( "Reserved word: %s\n", yytext); return FOR;}
go {printf( "Reserved word: %s\n", yytext); return GO;}
if {printf( "Reserved word: %s\n", yytext); return IF;}
number {printf( "Reserved word: %s\n", yytext); return NUMBER;}
or {printf( "Reserved word: %s\n", yytext); return OR;}
cin {printf( "Reserved word: %s\n", yytext); return CIN;}
cout {printf( "Reserved word: %s\n", yytext); return COUT;}
string {printf( "Reserved word: %s\n", yytext); return STRING;}
while {printf( "Reserved word: %s\n", yytext); return WHILE;}
xor {printf( "Reserved word: %s\n", yytext); return XOR;}

{id} {printf( "Identifier: %s\n", yytext); return ID;}

{const} {printf( "Constant: %s\n", yytext ); return CONST;}

":" {printf( "Separator: %s\n", yytext ); return COLON;}
";" {printf( "Separator: %s\n", yytext ); return SEMI_COLON;}
"," {printf( "Separator: %s\n", yytext ); return COMMA;}
"." {printf( "Separator: %s\n", yytext ); return DOT;}
"{" {printf( "Separator: %s\n", yytext ); return OPEN_CURLY_BRACKET;}
"}" {printf( "Separator: %s\n", yytext ); return CLOSED_CURLY_BRACKET;}
"(" {printf( "Separator: %s\n", yytext ); return OPEN_ROUND_BRACKET;}
")" {printf( "Separator: %s\n", yytext ); return CLOSED_ROUND_BRACKET;}
"[" {printf( "Separator: %s\n", yytext ); return OPEN_RIGHT_BRACKET;}
"]" {printf( "Separator: %s\n", yytext ); return CLOSED_RIGHT_BRACKET;}
"=" {printf( "Separator: %s\n", yytext ); return ATRIB;}

"+" {printf( "Operator: %s\n", yytext ); return PLUS;}
"-" {printf( "Operator: %s\n", yytext ); return MINUS;}
"*" {printf( "Operator: %s\n", yytext ); return MUL;}
"/" {printf( "Operator: %s\n", yytext ); return DIV;}
"<" {printf( "Operator: %s\n", yytext ); return LT;}
">" {printf( "Operator: %s\n", yytext ); return GT;}
"<=" {printf( "Operator: %s\n", yytext ); return LE;}
">=" {printf( "Operator: %s\n", yytext ); return GE;}
"!=" {printf( "Operator: %s\n", yytext ); return NE;}
"==" {printf( "Operator: %s\n", yytext ); return EQ;}
"!" {printf( "Operator: %s\n", yytext ); return NOT;}
">>" {printf( "Operator: %s\n", yytext ); return READ_OP;}
"<<" {printf( "Operator: %s\n", yytext ); return WRITE_OP;}



[ \t]+  	{}
[\n]+ {lines++;}
		 
[+-]?0[0-9]+ {printf("Illegal constant: %s at line %d\n", yytext, lines); exit(1);}

[a-zA-Z][a-zA-Z0-9]{8,}	{printf("Illegal size of the identifier at line %d\n", lines); exit(1);}

[0-9~@#$%^][a-zA-Z0-9]*	{printf("Illegal identifier %s at line %d\n", yytext, lines); exit(1);}

\'[a-zA-Z0-9]{2,}\' {printf("Character of length >=2 at line %d\n", lines); exit(1);}

. {printf("Illegal character at line %d\n", lines); exit(1);}
%%  