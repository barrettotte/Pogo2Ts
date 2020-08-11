# Groovy-To-TypeScript

Use Antlr grammars to generate TypeScript code from Groovy source.
With this side project I wanted to learn a little bit more about Antlr grammars and code generation.

Additionally, my company seemed like they wanted something like this.


## General Idea
* Lex and parse Groovy source using Antlr4
* Walk through generated AST
* Write TypeScript source


## Setup Antlr4 (Windows)
* Download Antlr4 jar - https://www.antlr.org/download/antlr-4.8-complete.jar
* Add Antlr4 jar to CLASSPATH system variable
  * System Properties > Environment Variables > CLASSPATH  (create if doesn't exist)
  * Example: CLASSPATH = ```C:\Antlr4\antlr-4.8-complete.jar```

Add antlr4 batch script to PATH -> EX: ```C:\Antlr4\antlr4.bat```
```batch
java org.antlr.v4.Tool %*
```


## Commands
* Generate Lexer/Parser - ```antlr4 -visitor grammars/SQL.g4 -Dlanguage=CSharp -o JsonSchemaGen\generated\SQL -encoding UTF-8```


## Groovy Grammars
Grammars found in official Groovy repository
* grammars/GroovyLexer.g4 - https://github.com/apache/groovy/blob/master/src/antlr/GroovyLexer.g4
* grammars/GroovyParser.g4 - https://github.com/apache/groovy/blob/master/src/antlr/GroovyParser.g4


## References
* Antlr Mega Tutorial - https://tomassetti.me/antlr-mega-tutorial/
* The Definitive ANTLR4 Reference - https://pragprog.com/book/tpantlr2/the-definitive-antlr-4-reference
* Antlr4 Grammars - https://github.com/antlr/grammars-v4
* Apache Groovy - https://github.com/apache/groovy


## License
Licensed to the Apache Software Foundation (ASF) under one
or more contributor license agreements.  See the NOTICE file
distributed with this work for additional information
regarding copyright ownership.  The ASF licenses this file
to you under the Apache License, Version 2.0 (the
"License"); you may not use this file except in compliance
with the License.  You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing,
software distributed under the License is distributed on an
"AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
KIND, either express or implied.  See the License for the
specific language governing permissions and limitations
under the License.
