
# Nullables


# 1. Boxing an `int`
## 1.1 declare `int x`
`int x=1;`

```text
stack       heap
-----  ---> -----
int x
+-+
|1|
+-+
```

## 1.2 boxing `x`
`object o = x`
```text
stack           heap
-----  ------>  -----

o  ---------->  +-----+
                |int x| 
                |+-+  |
                ||1|  |
                |+-+  |
                +---- +
```

# 2. Boxing an `int?`
## 2.1 Declare: `int? x=5`

```text
stack                   heap
-----  ------------>    -----
struct Nullable<int> 
+-------------------+
|.Value=5           |
|.HasValue=true     |
+-------------------+

```

## 2.2 Box `int? x`
Expectd below but its not actual
```text

stack       heap
----- ----> -----
o --------> struct Nullable<int> 
            +-------------------+
            |.Value=5           |
            |.HasValue=true     |
            +-------------------+
```

Actual simple copies 5 because an object can be nulled. 