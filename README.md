## Overview:
A simple arithmetic parser for evaluating mathematical expressions, written in C#.
* **Lexer**: Splits the input text into a list of tokens. Each token is an object that has a string, an enum type and other members associated with it:
```
"1 + 2 * 3" -> [1, +, 2, *, 3]
```
* **Parser**: Uses a method known as the [shunting-yard algorithm](https://en.wikipedia.org/wiki/Shunting-yard_algorithm) in order to convert the list of tokens into postfix notation. This simplifies the next step which involves producing the final result. 
The conversion to postfix notation yields the following:
```
[1, +, 2, *, 3] -> [1, 2, 3, *, +]
```
* **Interpreter**: Uses a stack-based algorithm that iterates through the postfix list to yield the final result. When it sees a number, that number is pushed on the stack. If it sees an operator, it will pop 2 numbers off the stack and apply the given operation, then push the result back on the stack. The final answer is produced when there's one element left on the stack.
## Valid tokens:

| Token | Symbol |
| :---: |  :---: |   
|  numberToken     |    any integer    | 
|   plusToken    |    +    | 
|   minusToken    |    -    | 
|   multiplyToken    |    *    | 
|   divideToken    |    /     | 
|   exponentToken    |    ^    | 
|   lBracketToken    |    (    | 
|   rBracketToken    |    )    | 
|   whitespace    |    " "    | 
