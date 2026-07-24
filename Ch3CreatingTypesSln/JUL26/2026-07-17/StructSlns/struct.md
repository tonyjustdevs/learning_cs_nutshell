# Structs
- what we write
- what compiler know
- what compiler rewrites

## Questions

```c#
struct Point
{
    public int X;
    public int Y;
}

Point[] pts = new Point[3];
```
Where is `pts` array object?

- **Array** are **classes** (ie allocated on the **heap**)

```text
Stack                   Heap
-----                   ---------
'pts' variable          Point[] starting at 500
                        +-----------------+
                        | Array Header    |
+---------+             +-----+-----+-----+
|ref_addy:|             | X=0 | X=0 | X=0 |
|500  ----|------------>| Y=0 | Y=0 | Y=0 |
+---------+             +-----+-----+-----+
                        | 500 | 508 | 516 |   
                  Addy: | 507 | 515 | 531 |
                        +-----+-----+-----+
                        pts[0]pts[1]pts[2]
```

## GPT Examples:

### Question 1
```c#
int x = 5;
```
### Solution Attempt 1
- `int` is an alias for `Int32`
- `Int32` is a struct

```text
Stack
------
addy: 5000 to 5003
+----+
| 5  |: 5000
|    |: 5001
|    |: 5002
|    |: 5003
+----+
```

### Question 2
```c#
Point p;
struct Point
{
    public int X;
    public int Y;
}
```
### Solution Attempt 2
- `Point` is a `struct` type, 
- which is a value-type (lives where its declared)
- since declared in stack, lives in stack??

```text
Stack
-----
p (compiler variable name)

Point object, No Headers
- The 8 bytes IS the Point object
+-------------+ : Addy
| int X value | : 5000 (int takes up 4 bytes)
| int Y value | : 5004 (int takes up 4 bytes)
+-------------+ : 

```

### Question 3

```c#
class Person
{
    public int Age;
}

Person p = new Person();
```

### Solution Attempt 3
- Person is **ref-type**
- lives in **heap**
- Stack variable `p`: 
    - does not contain `Person` object
    - it contains address to `Person` object
```text
Stack               Heap
------              ------
                    Runtime allocates memory on the heap.
p (ref var) ------> 5000: Person
1000:
+------+            +-----------+
| 5000 |            | Header    | : size, type, mbrs 
+------+            +-----------+
                    | int Age=0 | 4-bytes
                    +-----------+           
```

### Question 4
Arrays are ref-types
- Lives on stack
- Runtime allocates memory on the heap.

```c#
Point[] points = new Point[3];
```

```text
Stack               Heap
------              ------
                    
points (ref var) --> 5000: Array Object
1000:                5000:
+------+            +--------+
| 5000 |            | Header | : 
+------+            +--------+
                    | X=0    | header + length + padding = points[0]
                    | Y=0    | 
                    | X=0    | points[0] + size(point) * 1
                    | Y=0    | 
                    | X=0    | points[0] + size(point) * 2
                    | Y=0    | 
                    +--------+
```
### Solution Attempt 4

### Question 5
```c#
Person[] people = new Person[3];
```
### Solution Attempt 5



### `struct` strategy

Consider:

```c#


















