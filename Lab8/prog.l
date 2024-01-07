%{ 	 
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
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

and {printf("Reserved word: %s\n", yytext);}
array	{printf( "Reserved word: %s\n", yytext);}
else	{printf( "Reserved word: %s\n", yytext);}
for	{printf( "Reserved word: %s\n", yytext);}
go	{printf( "Reserved word: %s\n", yytext);}
if	{printf( "Reserved word: %s\n", yytext);}
number	{printf( "Reserved word: %s\n", yytext);}
or	{printf( "Reserved word: %s\n", yytext);}
cin	{printf( "Reserved word: %s\n", yytext);}
cout	{printf( "Reserved word: %s\n", yytext);}
string	{printf( "Reserved word: %s\n", yytext);}
while	{printf( "Reserved word: %s\n", yytext);}
xor	{printf( "Reserved word: %s\n", yytext);}

{id}	{printf( "Identifier: %s\n", yytext);}

{const}	{printf( "Constant: %s\n", yytext );}

":"	{printf( "Separator: %s\n", yytext );}
";"	{printf( "Separator: %s\n", yytext );}
","	{printf( "Separator: %s\n", yytext );}
"."	{printf( "Separator: %s\n", yytext );}
"{"	{printf( "Separator: %s\n", yytext );}
"}"	{printf( "Separator: %s\n", yytext );}
"("	{printf( "Separator: %s\n", yytext );}
")"	{printf( "Separator: %s\n", yytext );}
"["	{printf( "Separator: %s\n", yytext );}
"]"	{printf( "Separator: %s\n", yytext );}
"="	{printf( "Separator: %s\n", yytext );}

"+"	{printf( "Operator: %s\n", yytext );}
"-"	{printf( "Operator: %s\n", yytext );}
"*"	{printf( "Operator: %s\n", yytext );}
"/"	{printf( "Operator: %s\n", yytext );}
"<"	{printf( "Operator: %s\n", yytext );}
">"	{printf( "Operator: %s\n", yytext );}
"<=" {printf( "Operator: %s\n", yytext );}
">=" {printf( "Operator: %s\n", yytext );}
"!=" {printf( "Operator: %s\n", yytext );}
"==" {printf( "Operator: %s\n", yytext );}
"!"	{printf( "Operator: %s\n", yytext );}
">>" {printf( "Operator: %s\n", yytext );}
"<<" {printf( "Operator: %s\n", yytext );}



[ \t]+  	{}
[\n]+ {lines++;}
		 
[+-]?0[0-9]+ {printf("Illegal constant: %s at line %d\n", yytext, lines); exit(1);}

[a-zA-Z][a-zA-Z0-9]{8,}	{printf("Illegal size of the identifier at line %d\n", lines); exit(1);}

[0-9~@#$%^][a-zA-Z0-9]*	{printf("Illegal identifier %s at line %d\n", yytext, lines); exit(1);}

\'[a-zA-Z0-9]{2,}\' {printf("Character of length >=2 at line %d\n", lines); exit(1);}

. {printf("Illegal character at line %d\n", lines); exit(1);}
%%  

int main(int argc, char** argv) {
    if (argc > 1) 
    {
        yyin = fopen(argv[1], "r");
    }
    else 
    {
        yyin = stdin;
    }
    yylex();
    return 0;
}