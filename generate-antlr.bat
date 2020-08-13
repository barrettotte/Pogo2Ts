@ECHO OFF
REM Generate lexer/parser using Antlr4 grammars

SET GEN_LOC=Pogo2Ts\Antlr

WHERE antlr4 >nul 2>nul
IF %ERRORLEVEL% EQU 1 GOTO :NOTFOUND

antlr4 -Dlanguage=CSharp -encoding UTF-8 -o %GEN_LOC% -Xexact-output-dir grammars\GroovyLexer.g4 ^
  & antlr4 -visitor -Dlanguage=CSharp -encoding UTF-8 -o %GEN_LOC% -Xexact-output-dir grammars\GroovyParser.g4

:NOTFOUND
  ECHO Could not find 'antlr4' in PATH.
  GOTO:EOF
