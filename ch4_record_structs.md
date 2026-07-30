
# 1. Struct: Declare & Assign a Point
```c#
struct Point{
    public int X;
    public int Y;
}

Point p1 = new Struct{X=10;Y=20}
```

```text

Stack
--------
p1
+------+
|10 (X)|
|20 (Y)|
+------+
```

# 2. Struct: Assign Another Variable
Recall, struct are value-types:
- `struct` variables hold the value (not the reference)

```c#
Point p2=p1;
```

```text
Stack
-------
p1 & p2
+------+
|10 (X)|
|20 (Y)|
+------+
```