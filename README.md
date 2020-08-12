# Pogo2Ts

Use Antlr grammars to generate TypeScript models from POGOs (Plain Old Groovy Objects).
With this side project I wanted to learn a little bit more about Antlr grammars and code generation.
Unfortunately, Groovy was a terrible choice to learn with as you'll see below.

Additionally, my company seemed like they wanted something like this.


## General Idea
* Lex and parse Groovy source using Antlr4
* Walk through generated AST
* Write TypeScript source


## Groovy Grammars
There are official Antlr4 grammars located in https://github.com/apache/groovy/blob/master/src/antlr/ .
However, I found out the Parrot parser for Groovy uses a fork of Antlr4 (https://issues.apache.org/jira/browse/GROOVY-9232).
This means that the official Antlr4 grammars don't work out of the box with the official Antlr4 jar.


After a lot of screwing around with trying to build the fork from https://github.com/tunnelvisionlabs/antlr4 
I decided I would just modify the existing Antlr4 Java8 grammars at https://github.com/antlr/grammars-v4/tree/master/java/java8 since Groovy is just a superset of Java. 


Since I'm really just trying to convert POGOs, I will be skipping over the following (unless coerced into diving back in):
* Closures
* Metaprogramming
* All the cool Groovy string literal stuff - (interpolation, GStrings, etc)


I will try my best to include enough for minimally functional Groovy grammars using the following resources:
* Groovy Language Documentation - https://docs.groovy-lang.org/latest/html/documentation/
* Groovy Syntax - https://groovy-lang.org/syntax.html
* Groovy Style Guide - https://groovy-lang.org/style-guide.html


I will reiterate, this is for converting POGOs and is nowhere near a full converter.
**If I missed something absolutely critical, please open an issue!**



## Setup (Windows)
* Download Antlr4 jar - https://www.antlr.org/download/antlr-4.8-complete.jar
* Add Antlr4 jar to CLASSPATH system variable
  * System Properties > Environment Variables > CLASSPATH  (create if doesn't exist)
  * Example: CLASSPATH = ```C:\Antlr4\antlr-4.8-complete.jar```

Add antlr4 batch script to PATH -> EX: ```C:\Antlr4\antlr4.bat```
```batch
java org.antlr.v4.Tool %*
```


## Commands
* Generate Lexer -  ```antlr4 grammars/GroovyLexer.g4 -Dlanguage=CSharp -o Groovy2TS\generated\Groovy -encoding UTF-8```
* Generate Parser - ```antlr4 -visitor grammars/GroovyParser.g4 -Dlanguage=CSharp -o Groovy2TS\generated\Groovy -encoding UTF-8```


## References
* Antlr Mega Tutorial - https://tomassetti.me/antlr-mega-tutorial/
* The Definitive ANTLR4 Reference - https://pragprog.com/book/tpantlr2/the-definitive-antlr-4-reference
* Apache Groovy - https://github.com/apache/groovy
* Antlr4 Grammars - https://github.com/antlr/grammars-v4