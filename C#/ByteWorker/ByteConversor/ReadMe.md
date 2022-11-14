#V0.0.1
Read all bytes from a file, convert those bytes to 8-padded bits and create a new file with
path&filename
bytes concatenated with ';' Ex: 105;110;100;101;
8-padded bits concatenated without separator Ex: 01101001011011100110010001100101

#V0.0.2
UPDATE
Show line with progress
Erased las ';' from bytes, now the line ends with "\n"

#V0.0.3
UPDATE
Change default Path to HOME directory for read and write

#V0.0.4
UPDATE
Optimization of read loops
Use of StringBuilder instead of raw string
Eliminated all raw strings inside the loops

#V0.0.5
UPDATE
Complete rework of class.
Use of Span<T> inside the loops
Changed List<T> for Array[]
Removed BitConversor class, not needed

#V0.0.6
UPDATE
Instead of create a single string with bytes and a single with bits data, separate line with 256 bytes length each one