// UnmanagedDll.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"

/*
	BOOL,                           // 1 byte
	CHAR,                           // signed 1 byte
	UNSIGNED_CHAR,                  // unsigned 1 byte
	INT8,                           // signed 1 bytes
	UNSIGNED_INT8,                  // unsigned 1 bytes
	SHORT,                          // signed 2 bytes
	UNSIGNED_SHORT,                 // unsigned 2 bytes
	INT16,                          // signed 2 bytes
	UNSIGNED_INT16,                 // unsigned 2 bytes
	INT,                            // signed 4 bytes
	UNSIGNED_INT,                   // unsigned 4 bytes
	INT32,                          // signed 4 bytes
	UNSIGNED_INT32,                 // unsigned 4 bytes
	LONG,                           // signed 4 bytes
	UNSIGNED_LONG,                  // unsigned 4 bytes
	INT64,                          // signed 8 bytes
	UNSIGNED_INT64,                 // unsigned 8 bytes
	LONG_LONG,                      // signed 8 bytes
	UNSIGNED_LONG_LONG,             // unsigned 8 bytes
	BYTE,                           // unsigned 1 byte
	WORD,                           // unsigned 2 bytes
	DWORD,                          // unsigned 4 bytes
	QWORD,                          // unsigned 8 bytes
	FLOAT,                          // signed 4 bytes, 3.4E +/- 38 (7 digits)
	DOUBLE,                         // signed 8 bytes, 1.7E +/- 308 (15 digits)
	WCHAR,                          // unsigned 2 bytes
	BSTR,                           // Binary String from COM
	ANSI,                           // Null terminated ANSI string
	UTF8,                           // Null terminated UTF-8 string
	UTF16,                          // Null terminated UTF-16 string
	STRING,                         // Null terminated string (Custom encoding)
	MULTI_STRING,                   // Multiple null terminated strings end with null (Custom encoding)
	ARRAY,                          // Array of objects
	ARRAY_OF_POINTERS,              // Array of pointers
	POINTER,                        // Depend on CPU architecture
	POINTER_TO_BSTR,                // Depend on CPU architecture
	POINTER_TO_ANSI,                // Depend on CPU architecture
	POINTER_TO_UTF8,                // Depend on CPU architecture
	POINTER_TO_UTF16,               // Depend on CPU architecture
	POINTER_TO_STRING,				// Depend on CPU architecture
	POINTER_TO_MULTI_STRING,		// Depend on CPU architecture
	POINTER_TO_ARRAY,               // Depend on CPU architecture
	POINTER_TO_ARRAY_OF_POINTERS    // Depend on CPU architecture
*/

#pragma pack(push, 8)
typedef struct _UNMANAGED_ARRAY2 {
	INT8				int1;
	INT8				int2;
	INT64				int3;
} UNMANAGED_ARRAY2;
#pragma pack(pop)

#pragma pack(push, 8)
typedef struct _UNMANAGED_ARRAY {
	INT16				int1;
	INT8				int2;
	UNMANAGED_ARRAY2	array2[2];
} UNMANAGED_ARRAY;
#pragma pack(pop)

#pragma pack(push, 8)
typedef struct _UNMANAGED_CHILD {
	__int32				no;
	CONST CHAR*			name;
} UNMANAGED_CHILD;

typedef struct _UNMANAGED {
	bool				boolean;
	INT8				int8;
	UINT8				uint8;
	INT16				int16;
	UINT16				uint16;
	__int32				int32;
	unsigned __int32	uint32;
	INT64				int64;
	UINT64				uint64;
	float				real32;
	double				real64;
	WCHAR				wchar;
	CHAR				string[10];
	CHAR				multiString[50];
	UNMANAGED_ARRAY		array[10];
	UNMANAGED_CHILD*	arrayOfPointers[3];
	UNMANAGED_CHILD*	pointer;
	CONST CHAR*			pointerToAnsi;
	CONST CHAR*			pointerToUtf8;
	CONST WCHAR*		pointerToUtf16;
	CONST CHAR*			pointerToString;
	CONST CHAR*			pointerToMultiString;
	__int32				pointerToArrayCount;
	UNMANAGED_CHILD*	pointerToArray;
	__int32				pointerToArrayOfPointersCount;
	UNMANAGED_CHILD**	pointerToArrayOfPointers;
} UNMANAGED;
#pragma pack(pop)

CONST CHAR*				ansi		= "ANSI";
CONST CHAR*				utf8		= u8"UTF8";
CONST WCHAR*			utf16		= L"UTF16";
CONST CHAR*				string		= "string";
CONST CHAR*				multiString	= "string1\0string2\0string3\0string4\0string5\0";
UNMANAGED_CHILD			childAlone	= { 0, "Alone" };
UNMANAGED_CHILD			child[5]	= {
	{ 1, "First" },
	{ 2, "Second" },
	{ 3, "Third" },
	{ 4, "Forth" },
	{ 5, "Fifth" }
};
UNMANAGED_CHILD*		childPointers[]	= { &child[0], &child[2], &child[4] };
UNMANAGED				unmanaged;

extern "C" __declspec(dllexport) void* GetUnmanagedStruct(void)
{
	unmanaged.boolean						= true;
	unmanaged.int8							= -1;
	unmanaged.uint8							= 0xF0;
	unmanaged.int16							= -1;
	unmanaged.uint16						= 0xFFF0;
	unmanaged.int32							= -1;
	unmanaged.uint32						= 0xFFFFFFF0;
	unmanaged.int64							= -1;
	unmanaged.uint64						= 0xFFFFFFFFFFFFFFF0;
	unmanaged.real32						= 0.123456789f;
	unmanaged.real64						= 0.9876543210123456789;
	unmanaged.wchar							= L'A';
	strcpy_s(&unmanaged.string[0], 10, string);
	memcpy(&unmanaged.multiString[0], multiString, 41);
	//unmanaged.array[0]						= { 0, 0xFFFFFFFFFFFFFFF0 };
	//unmanaged.array[1]						= { 1, 0xFFFFFFFFFFFFFFF0 };
	//unmanaged.array[2]						= { 2, 0xFFFFFFFFFFFFFFF0 };
	//unmanaged.array[3]						= { 3, 0xFFFFFFFFFFFFFFF0 };
	//unmanaged.array[4]						= { 4, 0xFFFFFFFFFFFFFFF0 };
	//unmanaged.array[5]						= { 5, 0xFFFFFFFFFFFFFFF0 };
	//unmanaged.array[6]						= { 6, 0xFFFFFFFFFFFFFFF0 };
	//unmanaged.array[7]						= { 7, 0xFFFFFFFFFFFFFFF0 };
	//unmanaged.array[8]						= { 8, 0xFFFFFFFFFFFFFFF0 };
	//unmanaged.array[9]						= { 9, 0xFFFFFFFFFFFFFFF0 };

	//unmanaged.array[0]						= { 9, 0, 9, 0, 1, 2, 3, 4, 5 };
	//unmanaged.array[1]						= { 9, 1, 8, 0, 1, 2, 3, 4, 5 };
	//unmanaged.array[2]						= { 9, 2, 7, 0, 1, 2, 3, 4, 5 };
	//unmanaged.array[3]						= { 9, 3, 6, 0, 1, 2, 3, 4, 5 };
	//unmanaged.array[4]						= { 9, 4, 5, 0, 1, 2, 3, 4, 5 };
	//unmanaged.array[5]						= { 9, 5, 4, 0, 1, 2, 3, 4, 5 };
	//unmanaged.array[6]						= { 9, 6, 3, 0, 1, 2, 3, 4, 5 };
	//unmanaged.array[7]						= { 9, 7, 2, 0, 1, 2, 3, 4, 5 };
	//unmanaged.array[8]						= { 9, 8, 1, 0, 1, 2, 3, 4, 5 };
	//unmanaged.array[9]						= { 9, 9, 0, 0, 1, 2, 3, 4, 5 };

	unmanaged.array[0]						= { 9, 0, 0, 1, 2, 3, 4, 5 };
	unmanaged.array[1]						= { 9, 1, 0, 1, 2, 3, 4, 5 };
	unmanaged.array[2]						= { 9, 2, 0, 1, 2, 3, 4, 5 };
	unmanaged.array[3]						= { 9, 3, 0, 1, 2, 3, 4, 5 };
	unmanaged.array[4]						= { 9, 4, 0, 1, 2, 3, 4, 5 };
	unmanaged.array[5]						= { 9, 5, 0, 1, 2, 3, 4, 5 };
	unmanaged.array[6]						= { 9, 6, 0, 1, 2, 3, 4, 5 };
	unmanaged.array[7]						= { 9, 7, 0, 1, 2, 3, 4, 5 };
	unmanaged.array[8]						= { 9, 8, 0, 1, 2, 3, 4, 5 };
	unmanaged.array[9]						= { 9, 9, 0, 1, 2, 3, 4, 5 };
	unmanaged.arrayOfPointers[0]			= &child[3];
	unmanaged.arrayOfPointers[1]			= &child[2];
	unmanaged.arrayOfPointers[2]			= &child[1];
	unmanaged.pointer						= &childAlone;
	unmanaged.pointerToAnsi					= ansi;
	unmanaged.pointerToUtf8					= utf8;
	unmanaged.pointerToUtf16				= utf16;
	unmanaged.pointerToString				= string;
	unmanaged.pointerToMultiString			= multiString;
	unmanaged.pointerToArrayCount			= (sizeof(child) / sizeof(UNMANAGED_CHILD));
	unmanaged.pointerToArray				= &child[0];
	unmanaged.pointerToArrayOfPointersCount	= (sizeof(childPointers) / sizeof(UNMANAGED_CHILD*));
	unmanaged.pointerToArrayOfPointers		= &childPointers[0];

	return &unmanaged;
}
