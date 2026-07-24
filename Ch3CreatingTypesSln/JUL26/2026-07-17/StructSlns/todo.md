- Add Point `class`
    - 2 `int` mbrs
- Add Point `array` with 1,000,000 Point instances
- Where does each point instance live

```C#
class Point{
    public int a
    public int b
}

Point[] points =  Point[1_000_000]

```


```text
Stack           Heap    
-----           -------
                Point[] array object 
points ------>  +---------+
                | ref     |
                +-----⫟----+
                     |

                |Point() obj|
                +-----------+
                |Point() obj|
                +-----------+

```

# Explain `int x=1`

# 1. Memory
Memory is like a street of houses/dwellings (or boxes), addresses increment by 1 byte at a time:
- each smallest dwelling stores a byte
- each dwelling has their own address
- big dwellings can take up more multiple addresses:
    - 1 byte: 
    - 2 bytes: `short` 
    - 4 bytes: `int`

# 2. `int` needs 4 bytes
- It's a mansion, it takes up 4 individual addresses.
    - Note: 4 bytes = 32 bits

# 3. `int x = 5;`
Assume runtime places `x` at address `100`:
- x take up

```text
Address         Contents
-------         --------

100             Byte 1
101             Byte 2
102             Byte 3
103             Byte 4

so x = 5
 00000000-00000000-00000000-00000101 = 
```




q








