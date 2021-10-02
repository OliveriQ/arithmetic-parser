## Overview
A simple arithmetic parser for evaluating mathematical expressions.
* **Lexer**: Splits the input text into a list of tokens. Each token is an object that has a string, an enum type and other members associated with it. Afterwards, it uses a method known as the [shuntining-yard algorithm](https://en.wikipedia.org/wiki/Shunting-yard_algorithm) in order to convert the list to postfix notation. This step facilitates the parsing. 
```
"1 + 2 * 3" -> [1, +, 2, *, 3]
```
The conversion to postfix notation yields the following:
```
[1, +, 2, *, 3] -> [1, 2, 3, *, +]
```
