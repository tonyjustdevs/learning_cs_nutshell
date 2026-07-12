# `Compile-time` vs `Run-time` Checking

Consider a car factory.


Before car is ***ready***, checks are made, e.g.:
- 4 wheels attached
- Engine installed
- Breaks connected
Note: this is `compile-time` checking
After car is running, new things occur:
- Wheels blown
- Engine overheats
- Breaks fluid runout
Note: these problems **only exist** whilst car is actually running, this is `runtime` checking

# What the `Compiler` knows & does not know 
Consider `int` and `string`:
```c#
int age = "42"
string name = "mate"
```
Compiled knows:
- `age` is `int`
- `name` is `string`
ie, keeps track of every variable's type

Consider `object`
```c#
object obj
```
Compiler does not know:
- whats inside `obj`? 
- could be `int`, `string`, `DateTime.Now`
- Compiler just knows `obj` is an **object reference** 

# `GetType` Method & `typeof` Operator
- `GetType` is evaluated at run-time
    - `GetType()` get the **type** of the `OBJECT`, not the type of the `VARIABLE`.
- `typeof` is evaluated statically at compile-time

Example: `GetType()` vs `typeof()`

```c#
int a = 42
object b = a;
```

What is `int a`?
- it is a value
- it is 4 bytes
- its **not** an object
- no heap allocation

```text
Stack                   Heap
---------               -------------
int a = 1     
object b    ---->       new boxed object (boxing)
                        +-----------+
                        | Int32: 42 |
                        +-----------+


a.GetType() get type of `int`: Int32
b.GetType() get type of boxed object: Int32
```