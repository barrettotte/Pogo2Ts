@ECHO OFF
REM Generate lexer/parser using Antlr4 grammars

SET LANG=Groovy
SET GRAMMAR_LOC=grammars
SET GENERATE_LOC=Pogo2Ts\generated\Groovy

WHERE antlr4 >nul 2>nul
IF %ERRORLEVEL% EQU 1 GOTO :NOTFOUND

antlr4 %GRAMMAR_LOC%\%LANG%Lexer.g4 -Dlanguage=CSharp -o %GENERATE_LOC% -encoding UTF-8 ^
  && antlr4 -visitor %GRAMMAR_LOC%\%LANG%Parser.g4 -Dlanguage=CSharp -o %GENERATE_LOC% -encoding UTF-8

:NOTFOUND
  ECHO Could not find 'antlr4' in PATH.
  GOTO:EOF
