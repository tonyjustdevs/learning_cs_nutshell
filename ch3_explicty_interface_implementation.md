# Explicity Interface Implementation

```c#
Widget w = new Widget();
w.Foo();
((I1)w).Foo()
((I2)w).Foo()
```

```text
Stack               Heap
----------          ---------
(Widget) w  ----->  Widget object
                    +-----------+
                    | Foo()     |
                    +-----------+
```

Sane object, different viewpoint.
`((I1)w)`: treat this Widget object as an `I1`
`((I2)w)`: treat this Widget object as an `I2`

```text
Stack               Heap
----------          ---------
(I1) w      ----->  Widget object
                    +-----------+
                    | Foo()     |
(I2) w      ----->  +-----------+
```