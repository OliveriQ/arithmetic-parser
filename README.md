## Overview
A simple arithmetic parser for evaluating mathematical expressions.
* **Lexer**: Splits the input text into a list of tokens. Each token is an object that has a string, an enum type and other members associated with it. 
```
"1 + 2 * 3" -> [1, +, 2, *, 3]
```
* **Parser**: Uses a method known as the [shuntining-yard algorithm](https://en.wikipedia.org/wiki/Shunting-yard_algorithm) in order to convert the list of tokens to postfix notation. This drastically simplifies the next step which is producing the final result. 
The conversion to postfix notation yields the following:
```
[1, +, 2, *, 3] -> [1, 2, 3, *, +]
```
