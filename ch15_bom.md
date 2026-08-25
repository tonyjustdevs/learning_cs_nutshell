
First Bytes of File:

| First bytes in file | Means                    |
| ------------------- | ------------------------ |
| `EF BB BF`          | UTF-8 BOM                |
| `FE FF`             | UTF-16 Big Endian BOM    |
| `FF FE`             | UTF-16 Little Endian BOM |
| `00 00 FE FF`       | UTF-32 Big Endian BOM    |
| `FF FE 00 00`       | UTF-32 Little Endian BOM |
