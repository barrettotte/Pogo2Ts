@ECHO OFF
REM Generate lexer/parser using Antlr4 grammars

REM TODO: check if antlr4 command exists

antlr4 grammars/GroovyLexer.g4 -Dlanguage=CSharp -o Groovy2TS\generated\Groovy -encoding UTF-8 ^
  & antlr4 -visitor grammars/GroovyParser.g4 -Dlanguage=CSharp -o Groovy2TS\generated\Groovy -encoding UTF-8
