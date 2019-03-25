using Newtonsoft.Json;
using System;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Text;
using Unmanaged;

namespace UnmanagedTest
{
	class Program
	{
		[DllImport("UnmanagedDll.dll")]
		public static extern IntPtr GetUnmanagedStruct();

		[UnmanagedStruct(8)]
		public class Array2
		{
			[UnmanagedField(Unmanaged.Type.INT8)]
			public sbyte int1;

			[UnmanagedField(Unmanaged.Type.INT8)]
			public sbyte int2;

			[UnmanagedField(Unmanaged.Type.INT64)]
			public long int3;
		}

		[UnmanagedStruct(8)]
		public class Array1
		{
			[UnmanagedField(Unmanaged.Type.INT16)]
			public short int1;

			[UnmanagedField(Unmanaged.Type.INT8)]
			public sbyte int2;

			[UnmanagedField(Unmanaged.Type.ARRAY, TargetType = typeof(Array2), Count = "2")]
			public Array2[] array2;
		}

		[UnmanagedStruct(8)]
		public class ManagedChild
		{
			[UnmanagedField(Unmanaged.Type.INT64)]
			public long no;

			[UnmanagedField(Unmanaged.Type.POINTER_TO_ANSI)]
			public string pName;
		}

		[UnmanagedStruct(8)]
		public class Managed
		{
			[UnmanagedField(Unmanaged.Type.BOOL)]
			public bool boolean;

			[UnmanagedField(Unmanaged.Type.INT8)]
			public sbyte int8;

			[UnmanagedField(Unmanaged.Type.UNSIGNED_INT8)]
			public byte uint8;

			[UnmanagedField(Unmanaged.Type.INT16)]
			public short int16;

			[UnmanagedField(Unmanaged.Type.UNSIGNED_INT16)]
			public ushort uint16;

			[UnmanagedField(Unmanaged.Type.INT32)]
			public int int32;

			[UnmanagedField(Unmanaged.Type.UNSIGNED_INT32)]
			public uint uint32;

			[UnmanagedField(Unmanaged.Type.INT64)]
			public long int64;

			[UnmanagedField(Unmanaged.Type.UNSIGNED_INT64)]
			public ulong uint64;

			[UnmanagedField(Unmanaged.Type.FLOAT)]
			public float real32;

			[UnmanagedField(Unmanaged.Type.DOUBLE)]
			public double real64;

			[UnmanagedField(Unmanaged.Type.WCHAR)]
			public char wchar;

			[UnmanagedField(Unmanaged.Type.STRING, Encoding = "us-ascii", Count = "10")]
			public string str;

			[UnmanagedField(Unmanaged.Type.MULTI_STRING, Encoding = "us-ascii", Count = "50")]
			public string[] strs;

			[UnmanagedField(Unmanaged.Type.ARRAY, TargetType = typeof(Array1), Count = "10")]
			public Array1[] array;

			[UnmanagedField(Unmanaged.Type.ARRAY_OF_POINTERS, TargetType = typeof(ManagedChild), Count = "3")]
			public ManagedChild[] arrayOfPointers;

			[UnmanagedField(Unmanaged.Type.POINTER, TargetType = typeof(ManagedChild))]
			public ManagedChild pointer;

			[UnmanagedField(Unmanaged.Type.POINTER_TO_ANSI)]
			public string pointerToAnsi;

			[UnmanagedField(Unmanaged.Type.POINTER_TO_UTF8)]
			public string pointerToUtf8;

			[UnmanagedField(Unmanaged.Type.POINTER_TO_UTF16)]
			public string pointerToUtf16;

			[UnmanagedField(Unmanaged.Type.POINTER_TO_STRING, Encoding = "us-ascii")]
			public string pointerToString;

			[UnmanagedField(Unmanaged.Type.POINTER_TO_MULTI_STRING, Encoding = "us-ascii")]
			public string[] pointerToMultiString;

			[UnmanagedField(Unmanaged.Type.INT32)]
			public int pointerToArrayCount;

			[UnmanagedField(Unmanaged.Type.POINTER_TO_ARRAY, TargetType = typeof(ManagedChild), Count = "pointerToArrayCount")]
			public ManagedChild[] pointerToArray;

			[UnmanagedField(Unmanaged.Type.INT32)]
			public int pointerToArrayOfPointersCount;

			[UnmanagedField(Unmanaged.Type.POINTER_TO_ARRAY_OF_POINTERS, TargetType = typeof(ManagedChild), Count = "pointerToArrayOfPointersCount")]
			public ManagedChild[] pointerToArrayOfPointers;
		}

		static void Main(string[] args)
		{
			Console.WriteLine("Unmanaged Test");

			IntPtr pointer = GetUnmanagedStruct();
			Console.WriteLine(string.Format("Unmanaged Struct: 0x{0:X}", pointer.ToInt64()));

			//int managed = pointer.MapTo<int>();
			Managed managed = pointer.MapTo<Managed>();

			Console.Write(JsonConvert.SerializeObject(managed, Formatting.Indented));

			Console.ReadKey();
		}
	}
}
