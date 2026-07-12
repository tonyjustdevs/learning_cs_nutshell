`object obj = 3.5;`

- A value type cannot simply become a reference, so C# automatically performs boxing.
- The variable obj doesn't contain 3.5.
- It contains a reference to a boxed double object.
```text
Stack                     Heap
-----                     ----------------
obj  ------------------>  boxed double
                           +-----------+
                           |   3.5     |
                           +-----------+
```

int x = (int)(double)obj;

First cast `(double)obj`:
- "I know this object actually contains a boxed double. Please give me the original double back." aka **unboxing**

Second cast: `(int)temp`
- Not unboxing
- Numeric converion: `3 -> 3.50`, dropping fractional components

TONY SELF QUESTION

# Stack & Heap

**[1]** Setup
```c#
int a=1
box b = a
a=2
```
**[2]** Stack & Heaps
```text
Stack               Heap
-----               -----
a=1     ----->      boxed b object[value = 1]
```

**[3]** Stack & Heaps 2
- `a=2`
```text
Stack               Heap
-----               -----
                    boxed b object(value = 1)
a=2                 
```

Expectation a=2, b remains 1




