# 1. Values Types vs Reference Types
## 1.1 Value Types
The variable ***is*** the actual data
- contents: built-in types
- copies lead to independent storage
```C# 
int age = 30;  
// 'age' directly contains 30
```
## 1.1 Reference Types
The variable is a ***note with directions*** (aka holds a reference) to where data **lives**:
```c#
string name = "Alice" 
// 'name' does not contain "alice" directly
// 'name' contains a "pointer" saying "go to this daddy to find Alice"
```

# to-do         
- `public static bool TryParse(ReadOnlySpan<byte> utf8Text, out Decimal result)`:
    - find out what is `ROSpan<byte> utf8Text`
- 