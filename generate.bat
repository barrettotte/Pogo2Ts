@ECHO OFF
REM Generate lexer/parser using Antlr4 grammars
REM TODO: check if antlr4 command exists
antlr4 -visitor grammars/GroovyLexer.g4 -Dlanguage=CSharp -o GroovyToTS\generated\Groovy -encoding UTF-8
REM TODO: GroovyParser.g4 ??
REM TODO: Not sure how this works...