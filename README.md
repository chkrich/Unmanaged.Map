# Unmanaged.Map
Map unmanaged structure from C,C++ to class object.

### Installation
```sh
Install-Package Unmanaged.Map
```

### Usage
```sh
[DllImport("college.dll")]
public static extern IntPtr GetStudent();

[UnmanagedStruct(8)]
public class Student
{
    [UnmanagedField(Unmanaged.Type.BOOL)]
    public bool Graduated;

    [UnmanagedField(Unmanaged.Type.INT64)]
    public long ID;

    [UnmanagedField(Unmanaged.Type.POINTER_TO_STRING, Encoding = "utf-8")]
    public string Name;
}

static void Main(string[] args)
{
    IntPtr pointer = GetStudent();
    Student student = pointer.MapTo<Student>();

    Console.WriteLine("ID:   " + student.ID);
    Console.WriteLine("Name: " + student.Name);
    if (student.Graduated == true)
    	Console.WriteLine("Graduated from here.");
    else
    	Console.WriteLine("He is a student.");
}
```

### Dynamic length field
```sh
[UnmanagedField(Unmanaged.Type.INT32)]
public int studentCount;

[UnmanagedField(Unmanaged.Type.ARRAY_OF_POINTERS, TargetType=typeof(Student), Count="studentCount")]
public Student[] students;
```

### Data Type
```sh
BOOL                          C/C++ bool type, 1 byte. (0 = false, other  = true).
CHAR                          C/C++ char type, signed 1 byte.
UNSIGNED_CHAR                 C/C++ unsigned char type, unsigned 1 byte.
INT8                          C/C++ char type, signed 1 byte.
UNSIGNED_INT8                 C/C++ unsigned char type, unsigned 1 byte.
SHORT                         C/C++ short type, signed 2 byte.
UNSIGNED_SHORT                C/C++ unsigned short type, unsigned 2 byte.
INT16                         C/C++ short type, signed 2 byte.
UNSIGNED_INT16                C/C++ unsigned short type, unsigned 2 byte.
INT                           C/C++ int (32-bits), __int32 type, signed 4 byte.
UNSIGNED_INT                  C/C++ unsigned int (32-bits), unsigned __int32 type, unsigned 4 byte.
INT32                         C/C++ int (32-bits), __int32 type, signed 4 byte.
UNSIGNED_INT32                C/C++ unsigned int (32-bits), unsigned __int32 type, unsigned 4 byte.
LONG                          C/C++ long type, signed 4 byte.
UNSIGNED_LONG                 C/C++ unsigned long type, unsigned 4 byte.
INT64                         C/C++ __int64 type, signed 8 byte.
UNSIGNED_INT64                C/C++ unsigned __int64 type, unsigned 8 byte.
LONG_LONG                     C/C++ long long type, signed 8 byte.
UNSIGNED_LONG_LONG            C/C++ unsigned long long type, unsigned 8 byte.
BYTE                          C/C++ unsigned char type, unsigned 1 byte.
WORD                          C/C++ unsigned short type, unsigned 2 byte.
DWORD                         C/C++ unsigned int (32-bits), unsigned __int32 type, unsigned 4 byte.
QWORD                         C/C++ unsigned __int64 type, unsigned 8 byte.
FLOAT                         C/C++ float type, signed 4 bytes, 3.4E +/- 38 (7 digits).
DOUBLE                        C/C++ double type, signed 8 bytes, 1.7E +/- 308 (15 digits).
WCHAR                         C/C++ wchar_t type, UTF-16 unsigned 2 byte.
STRING                        Null-terminated character string (Custom encoding).
MULTI_STRING                  Multiple null-terminated character string end with null (Custom encoding).
ARRAY                         Array of objects.
ARRAY_OF_POINTERS             Array of pointers.
POINTER                       Pointer, The size depend on CPU architecture.
POINTER_TO_BSTR               Pointer to a null-terminated character string in which the string length is stored
                              with the string. The size depend on CPU architecture.
POINTER_TO_ANSI               Pointer to a null-terminated character ANSI string. The size depend on CPU architecture.
POINTER_TO_UTF8               Pointer to a null-terminated character UTF-8 string. The size depend on CPU architecture.
POINTER_TO_UTF16              Pointer to a null-terminated character UTF-16 string. The size depend on CPU architecture.
POINTER_TO_STRING             Pointer to a null-terminated character string (Custom encoding).
                              The size depend on CPU architecture.
POINTER_TO_MULTI_STRING       Pointer to multiple null-terminated character string end with null (Custom encoding).
                              The size depend on CPU architecture.
POINTER_TO_ARRAY              Pointer to an array of objects. The size depend on CPU architecture.
POINTER_TO_ARRAY_OF_POINTERS  Pointer to an array of pointers. The size depend on CPU architecture.
```

License
----

MIT
