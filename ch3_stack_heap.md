# Stack and Heap Allocation

## Table of Contents

- [Example 1: `class`](#example-1-class)
- [Example 2: `array`](#example-2-array)
- [Example 3: **Value-Type**](#example-3-value-type)
- [Example 4: **Refs-Type**](#example-4-ref-type)


Notes: 
- **Variables** are allocated where they're declared
- `Value-types` live inside whatever contains them

### Example 1

```c#
class Person {
    public int age;
}

var p = new Person();
```


```text
Stack           Heap 
-----           ---------
p       ---->   Person
                +-------+
                | age=0 |
                +-------+
```

### Example 2
```c#
int[] numbers = new int[3];
```

```text
Stack           Heap
-------         ---------
numbers ---->   array
                +-------+     
                | 0     |   
                | 0     |   
                | 0     |   
                +-------+     
```

### Example 3: Value-Type

```c#
int x=5;
```

```text
Stack
----- 
x=5 : the variable IS the value (not a reference)
```

### Example 4: Ref-Type

```c#
int x = 5;
object o = x;
```

```text
Stack           Heap 
-----           -----------
x = 5           boxed INT32
                +---------+
o       ---->   | 5       |
                +---------+
```

### Question 1: Value or Ref Type