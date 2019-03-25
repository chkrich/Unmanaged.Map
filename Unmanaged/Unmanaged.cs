/*
 * The MIT License
 * -------------------------------------------------------------
 * Copyright (c) Krich Charoenpoldee. All rights reserved.
 *  
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 * 
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Unmanaged
{
	/// <summary>
	/// Unmanaged data type
	/// </summary>
	public enum Type
	{
		/// <summary>
		/// C/C++ bool type, 1 byte. (0 = false, other  = true).
		/// </summary>
		BOOL,
		/// <summary>
		/// C/C++ char type, signed 1 byte.
		/// </summary>
		CHAR,
		/// <summary>
		/// C/C++ unsigned char type, unsigned 1 byte.
		/// </summary>
		UNSIGNED_CHAR,
		/// <summary>
		/// C/C++ char type, signed 1 byte.
		/// </summary>
		INT8,
		/// <summary>
		/// C/C++ unsigned char type, unsigned 1 byte.
		/// </summary>
		UNSIGNED_INT8,
		/// <summary>
		/// C/C++ short type, signed 2 byte.
		/// </summary>
		SHORT,
		/// <summary>
		/// C/C++ unsigned short type, unsigned 2 byte.
		/// </summary>
		UNSIGNED_SHORT,
		/// <summary>
		/// C/C++ short type, signed 2 byte.
		/// </summary>
		INT16,
		/// <summary>
		/// C/C++ unsigned short type, unsigned 2 byte.
		/// </summary>
		UNSIGNED_INT16,
		/// <summary>
		/// C/C++ int (32-bits), __int32 type, signed 4 byte.
		/// </summary>
		INT,
		/// <summary>
		/// C/C++ unsigned int (32-bits), unsigned __int32 type, unsigned 4 byte.
		/// </summary>
		UNSIGNED_INT,
		/// <summary>
		/// C/C++ int (32-bits), __int32 type, signed 4 byte.
		/// </summary>
		INT32,
		/// <summary>
		/// C/C++ unsigned int (32-bits), unsigned __int32 type, unsigned 4 byte.
		/// </summary>
		UNSIGNED_INT32,
		/// <summary>
		/// C/C++ long type, signed 4 byte.
		/// </summary>
		LONG,
		/// <summary>
		/// C/C++ unsigned long type, unsigned 4 byte.
		/// </summary>
		UNSIGNED_LONG,
		/// <summary>
		/// C/C++ __int64 type, signed 8 byte.
		/// </summary>
		INT64,
		/// <summary>
		/// C/C++ unsigned __int64 type, unsigned 8 byte.
		/// </summary>
		UNSIGNED_INT64,
		/// <summary>
		/// C/C++ long long type, signed 8 byte.
		/// </summary>
		LONG_LONG,
		/// <summary>
		/// C/C++ unsigned long long type, unsigned 8 byte.
		/// </summary>
		UNSIGNED_LONG_LONG,
		/// <summary>
		/// C/C++ unsigned char type, unsigned 1 byte.
		/// </summary>
		BYTE,
		/// <summary>
		/// C/C++ unsigned short type, unsigned 2 byte.
		/// </summary>
		WORD,
		/// <summary>
		/// C/C++ unsigned int (32-bits), unsigned __int32 type, unsigned 4 byte.
		/// </summary>
		DWORD,
		/// <summary>
		/// C/C++ unsigned __int64 type, unsigned 8 byte.
		/// </summary>
		QWORD,
		/// <summary>
		/// C/C++ float type, signed 4 bytes, 3.4E +/- 38 (7 digits).
		/// </summary>
		FLOAT,
		/// <summary>
		/// C/C++ double type, signed 8 bytes, 1.7E +/- 308 (15 digits).
		/// </summary>
		DOUBLE,
		/// <summary>
		/// C/C++ wchar_t type, UTF-16 unsigned 2 byte.
		/// </summary>
		WCHAR,
		/// <summary>
		/// Null-terminated character string (Custom encoding).
		/// </summary>
		STRING,
		/// <summary>
		/// Multiple null-terminated character string end with null (Custom encoding).
		/// </summary>
		MULTI_STRING,
		/// <summary>
		/// Array of objects.
		/// </summary>
		ARRAY,
		/// <summary>
		/// Array of pointers.
		/// </summary>
		ARRAY_OF_POINTERS,
		/// <summary>
		/// Pointer, The size depend on CPU architecture.
		/// </summary>
		POINTER,
		/// <summary>
		/// Pointer to a null-terminated character string in which the string length is stored with the string. The size depend on CPU architecture.
		/// </summary>
		POINTER_TO_BSTR,
		/// <summary>
		/// Pointer to a null-terminated character ANSI string. The size depend on CPU architecture.
		/// </summary>
		POINTER_TO_ANSI,
		/// <summary>
		/// Pointer to a null-terminated character UTF-8 string. The size depend on CPU architecture.
		/// </summary>
		POINTER_TO_UTF8,
		/// <summary>
		/// Pointer to a null-terminated character UTF-16 string. The size depend on CPU architecture.
		/// </summary>
		POINTER_TO_UTF16,
		/// <summary>
		/// Pointer to a null-terminated character string (Custom encoding). The size depend on CPU architecture.
		/// </summary>
		POINTER_TO_STRING,
		/// <summary>
		/// Pointer to multiple null-terminated character string end with null (Custom encoding). The size depend on CPU architecture.
		/// </summary>
		POINTER_TO_MULTI_STRING,
		/// <summary>
		/// Pointer to an array of objects. The size depend on CPU architecture.
		/// </summary>
		POINTER_TO_ARRAY,
		/// <summary>
		/// Pointer to an array of pointers. The size depend on CPU architecture.
		/// </summary>
		POINTER_TO_ARRAY_OF_POINTERS
	}

	/// <summary>
	/// Attribute for structure mapping.
	/// </summary>
	/// <example>
	/// <code>
	/// [UnmanagedStruct(8)]
	/// [DllImport("college.dll")]
	/// public static extern IntPtr GetStudent();
	/// 
	/// public class Student
	/// {
	///	    [UnmanagedField(Unmanaged.Type.BOOL)]
	///	    public bool Graduated;
	///
	///	    [UnmanagedField(Unmanaged.Type.INT64)]
	///	    public long ID;
	///
	///	    [UnmanagedField(Unmanaged.Type.POINTER_TO_STRING, Encoding = "utf-8")]
	///	    public string Name;
	/// }
	/// 
	/// static void Main(string[] args)
	/// {
	///	    IntPtr pointer = GetStudent();
	///	    Student student = pointer.MapTo&lt;Student&gt;();
	///
	///	    Console.WriteLine("ID:   " + student.ID);
	///	    Console.WriteLine("Name: " + student.Name);
	///	    if (student.Graduated == true)
	///	    	Console.WriteLine("Graduated from here.");
	///	    else
	///	    	Console.WriteLine("He is a student.");
	/// }
	/// </code>
	/// </example>
	[AttributeUsage(AttributeTargets.Class)]
	public class UnmanagedStructAttribute : Attribute
	{
		private int					align;

		/// <summary>
		/// Constructor for structure mapping
		/// </summary>
		/// <param name="align">Structure alignment. The value must be 1, 2, 4, 8.</param>
		public UnmanagedStructAttribute(int align)
		{
			this.align				= align;
		}

		/// <summary>
		/// Align property. The value must be 1, 2, 4, 8.
		/// </summary>
		public virtual int Align {
			get { return align; }
		}
	}

	/// <summary>
	/// Attribute for field mapping.
	/// </summary>
	/// <example>
	/// <code>
	/// [UnmanagedStruct(8)]
	/// [DllImport("college.dll")]
	/// public static extern IntPtr GetStudent();
	/// 
	/// public class Student
	/// {
	///	    [UnmanagedField(Unmanaged.Type.BOOL)]
	///	    public bool Graduated;
	///
	///	    [UnmanagedField(Unmanaged.Type.INT64)]
	///	    public long ID;
	///
	///	    [UnmanagedField(Unmanaged.Type.POINTER_TO_STRING, Encoding = "utf-8")]
	///	    public string Name;
	/// }
	/// 
	/// static void Main(string[] args)
	/// {
	///	    IntPtr pointer = GetStudent();
	///	    Student student = pointer.MapTo&lt;Student&gt;();
	///
	///	    Console.WriteLine("ID:   " + student.ID);
	///	    Console.WriteLine("Name: " + student.Name);
	///	    if (student.Graduated == true)
	///	    	Console.WriteLine("Graduated from here.");
	///	    else
	///	    	Console.WriteLine("He is a student.");
	/// }
	/// </code>
	/// </example>
	[AttributeUsage(AttributeTargets.Field)]
	public class UnmanagedFieldAttribute : Attribute
	{
		// Private fields.
		private Type				type;
		private string				encoding;
		private System.Type			targetType;
		private string				count;

		/// <summary>
		/// Constructor for structure mapping
		/// </summary>
		/// <param name="type">Filed type. See <see cref="Unmanaged.Type"/></param>
		public UnmanagedFieldAttribute(Type type)
		{
			this.type				= type;
			this.encoding			= "us-ascii";
			this.targetType			= null;
			this.count				= null;
		}

		/// <summary>
		/// Type property. See <see cref="Unmanaged.Type"/>
		/// </summary>
		public virtual Type Type {
			get { return type; }
		}

		/// <summary>
		/// Encoding property. See <see cref="System.Text.Encoding"/>
		/// </summary>
		public virtual string Encoding {
			get { return encoding; }
			set { encoding = value; }
		}

		/// <summary>
		/// TargetType property. Use with array or pointer mapping. See <see cref="System.Type"/>
		/// </summary>
		public virtual System.Type TargetType {
			get { return targetType; }
			set { targetType = value; }
		}

		/// <summary>
		/// Count property. Number of elements, use with array or pointer mapping. The value can be field name for dynamic size./>
		/// </summary>
		public virtual string Count {
			get { return count; }
			set { count = value; }
		}
	}

	/// <summary>
	/// Mapping the C/C++ structure to C# class object.
	/// </summary>
	/// <example>
	/// <code>
	/// [UnmanagedStruct(8)]
	/// [DllImport("college.dll")]
	/// public static extern IntPtr GetStudent();
	/// 
	/// public class Student
	/// {
	///	    [UnmanagedField(Unmanaged.Type.BOOL)]
	///	    public bool Graduated;
	///
	///	    [UnmanagedField(Unmanaged.Type.INT64)]
	///	    public long ID;
	///
	///	    [UnmanagedField(Unmanaged.Type.POINTER_TO_STRING, Encoding = "utf-8")]
	///	    public string Name;
	/// }
	/// 
	/// static void Main(string[] args)
	/// {
	///	    IntPtr pointer = GetStudent();
	///	    Student student = pointer.MapTo&lt;Student&gt;();
	///
	///	    Console.WriteLine("ID:   " + student.ID);
	///	    Console.WriteLine("Name: " + student.Name);
	///	    if (student.Graduated == true)
	///	    	Console.WriteLine("Graduated from here.");
	///	    else
	///	    	Console.WriteLine("He is a student.");
	/// }
	/// </code>
	/// </example>
	public static class UnmanagedMap
	{
		private static IntPtr Offset(this IntPtr pointer, int offset)
		{
			return new IntPtr(pointer.ToInt64() + offset);
		}

		private static int DefaultAlign(this System.Type type)
		{
			try
			{
				UnmanagedStructAttribute unmanagedAttribute = type.GetCustomAttribute<UnmanagedStructAttribute>();
				return unmanagedAttribute.Align;
			}
			catch (Exception)
			{
			}

			return 8;
		}

		
		private static int AlignOfPrimitive(System.Type type)
		{
			if (type == typeof(bool))
				return 1;
			else if (type == typeof(sbyte))
				return 1;
			else if (type == typeof(short))
				return 2;
			else if (type == typeof(int))
				return 4;
			else if (type == typeof(long))
				return 8;
			else if (type == typeof(byte))
				return 1;
			else if (type == typeof(ushort))
				return 2;
			else if (type == typeof(uint))
				return 4;
			else if (type == typeof(ulong))
				return 8;
			else if (type == typeof(string))
				return Marshal.SizeOf(typeof(IntPtr));

			return 0;
		}

		private static int Align(this System.Type type)
		{
			int				align			= AlignOfPrimitive(type);
			if (align > 0)
				return align;
			
			FieldInfo[]		fieldInfos		= type.GetFields();
			int				typeAlign		= type.DefaultAlign();
			int				variableAlign	= 0;

			foreach (FieldInfo fieldInfo in fieldInfos)
			{
				try
				{
					UnmanagedFieldAttribute		unmanagedAttribute		= fieldInfo.GetCustomAttribute<UnmanagedFieldAttribute>();
					if (unmanagedAttribute != null)
					{
						switch (unmanagedAttribute.Type)
						{
							case Type.BOOL:								// 1 byte
							case Type.CHAR:								// signed 1 byte
							case Type.INT8:								// signed 1 bytes
							case Type.UNSIGNED_CHAR:					// unsigned 1 byte
							case Type.UNSIGNED_INT8:					// unsigned 1 bytes
							case Type.BYTE:                             // unsigned 1 byte
								variableAlign							= 1;
								break;
							case Type.SHORT:							// signed 2 bytes
							case Type.INT16:							// signed 2 bytes
							case Type.UNSIGNED_SHORT:					// unsigned 2 bytes
							case Type.UNSIGNED_INT16:					// unsigned 2 bytes
							case Type.WORD:								// unsigned 2 bytes
							case Type.WCHAR:							// unsigned 2 bytes
								variableAlign							= 2;
								break;
							case Type.INT:								// signed 4 bytes
							case Type.INT32:							// signed 4 bytes
							case Type.LONG:								// signed 4 bytes
							case Type.UNSIGNED_INT:						// unsigned 4 bytes
							case Type.UNSIGNED_INT32:					// unsigned 4 bytes
							case Type.UNSIGNED_LONG:					// unsigned 4 bytes
							case Type.DWORD:							// unsigned 4 bytes
							case Type.FLOAT:							// signed 4 bytes, 3.4E +/- 38 (7 digits)
								variableAlign							= 4;
								break;
							case Type.INT64:							// signed 8 bytes
							case Type.LONG_LONG:						// signed 8 bytes
							case Type.UNSIGNED_INT64:					// unsigned 8 bytes
							case Type.UNSIGNED_LONG_LONG:				// unsigned 8 bytes
							case Type.QWORD:							// unsigned 8 bytes
							case Type.DOUBLE:                           // signed 8 bytes, 1.7E +/- 308 (15 digits)
								variableAlign							= 8;
								break;
							case Type.STRING:							// Null terminated string with encoding
							case Type.MULTI_STRING:                     // Multiple null terminated strings end with null
								variableAlign							= 1;
								break;
							case Type.ARRAY:                            // Array of objects
								variableAlign							= unmanagedAttribute.TargetType.Align();
								break;
							case Type.ARRAY_OF_POINTERS:				// Array of pointers
								variableAlign							= Marshal.SizeOf(typeof(IntPtr));
								break;
							case Type.POINTER:                          // Pointer, The size depend on CPU architecture.
							case Type.POINTER_TO_BSTR:                  // Pointer to a null-terminated character string in which the string length is stored with the string. The size depend on CPU architecture.
							case Type.POINTER_TO_ANSI:                  // Pointer to a null-terminated character ANSI string. The size depend on CPU architecture.
							case Type.POINTER_TO_UTF8:                  // Pointer to a null-terminated character UTF-8 string. The size depend on CPU architecture.
							case Type.POINTER_TO_UTF16:                 // Pointer to a null-terminated character UTF-16 string. The size depend on CPU architecture.
							case Type.POINTER_TO_STRING:                // Pointer to a null-terminated character string (Custom encoding). The size depend on CPU architecture.
							case Type.POINTER_TO_MULTI_STRING:          // Pointer to multiple null-terminated character string end with null (Custom encoding). The size depend on CPU architecture.
							case Type.POINTER_TO_ARRAY:                 // Pointer to an array of objects. The size depend on CPU architecture.
							case Type.POINTER_TO_ARRAY_OF_POINTERS:     // Pointer to an array of pointers. The size depend on CPU architecture.
								variableAlign							= Marshal.SizeOf(typeof(IntPtr));
								break;
						}

						if (align < variableAlign)
							align										= variableAlign;

						if (align > typeAlign)
							align										= typeAlign;
					}
				}
				catch (Exception)
				{
				}
			}

			return align;
		}

		private static int SizeOfPrimitive(System.Type type)
		{
			if (type == typeof(bool))
				return 1;
			else if (type == typeof(sbyte))
				return 1;
			else if (type == typeof(short))
				return 2;
			else if (type == typeof(int))
				return 4;
			else if (type == typeof(long))
				return 8;
			else if (type == typeof(byte))
				return 1;
			else if (type == typeof(ushort))
				return 2;
			else if (type == typeof(uint))
				return 4;
			else if (type == typeof(ulong))
				return 8;
			else if (type == typeof(string))
				return Marshal.SizeOf(typeof(IntPtr));

			return 0;
		}

		private static int Size(this System.Type type)
		{
			int offset = SizeOfPrimitive(type);
			if (offset > 0)
				return offset;

			int typeAlign = type.DefaultAlign();
			FieldInfo[] fieldInfos = type.GetFields();
			int padding = 0;
			int variableAlign = 0;
			int variableSize = 0;
			int count;

			foreach (FieldInfo fieldInfo in fieldInfos)
			{
				try
				{
					UnmanagedFieldAttribute unmanagedAttribute = fieldInfo.GetCustomAttribute<UnmanagedFieldAttribute>();
					if (unmanagedAttribute != null)
					{
						variableSize = 0;

						switch (unmanagedAttribute.Type)
						{
							case Type.BOOL:                             // 1 byte
							case Type.CHAR:                             // signed 1 byte
							case Type.INT8:                             // signed 1 bytes
							case Type.UNSIGNED_CHAR:                    // unsigned 1 byte
							case Type.UNSIGNED_INT8:                    // unsigned 1 bytes
							case Type.BYTE:                             // unsigned 1 byte
								variableAlign							= 1;
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								break;
							case Type.SHORT:                            // signed 2 bytes
							case Type.INT16:                            // signed 2 bytes
							case Type.UNSIGNED_SHORT:                   // unsigned 2 bytes
							case Type.UNSIGNED_INT16:                   // unsigned 2 bytes
							case Type.WORD:                             // unsigned 2 bytes
							case Type.WCHAR:                            // unsigned 2 bytes
								variableAlign							= 2;
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								break;
							case Type.INT:                              // signed 4 bytes
							case Type.INT32:                            // signed 4 bytes
							case Type.LONG:                             // signed 4 bytes
							case Type.UNSIGNED_INT:                     // unsigned 4 bytes
							case Type.UNSIGNED_INT32:                   // unsigned 4 bytes
							case Type.UNSIGNED_LONG:                    // unsigned 4 bytes
							case Type.DWORD:                            // unsigned 4 bytes
							case Type.FLOAT:                            // signed 4 bytes, 3.4E +/- 38 (7 digits)
								variableAlign							= 4;
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								break;
							case Type.INT64:                            // signed 8 bytes
							case Type.LONG_LONG:                        // signed 8 bytes
							case Type.UNSIGNED_INT64:                   // unsigned 8 bytes
							case Type.UNSIGNED_LONG_LONG:               // unsigned 8 bytes
							case Type.QWORD:                            // unsigned 8 bytes
							case Type.DOUBLE:                           // signed 8 bytes, 1.7E +/- 308 (15 digits)
								variableAlign							= 8;
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								break;
							case Type.STRING:                           // Null terminated string with encoding
							case Type.MULTI_STRING:                     // Multiple null terminated strings end with null
								count									= GetCount(unmanagedAttribute.Count);
								variableAlign							= 1;
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								variableSize							= count;
								break;
							case Type.ARRAY:                            // Array of objects
								count									= GetCount(unmanagedAttribute.Count);
								variableAlign							= unmanagedAttribute.TargetType.Align();
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								variableSize							= count * unmanagedAttribute.TargetType.Size();
								break;
							case Type.ARRAY_OF_POINTERS:                // Array of pointers
								count									= GetCount(unmanagedAttribute.Count);
								variableAlign							= Marshal.SizeOf(typeof(IntPtr));
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								variableSize							= count * variableAlign;
								break;
							case Type.POINTER:                          // Pointer, The size depend on CPU architecture.
							case Type.POINTER_TO_BSTR:                  // Pointer to a null-terminated character string in which the string length is stored with the string. The size depend on CPU architecture.
							case Type.POINTER_TO_ANSI:                  // Pointer to a null-terminated character ANSI string. The size depend on CPU architecture.
							case Type.POINTER_TO_UTF8:                  // Pointer to a null-terminated character UTF-8 string. The size depend on CPU architecture.
							case Type.POINTER_TO_UTF16:                 // Pointer to a null-terminated character UTF-16 string. The size depend on CPU architecture.
							case Type.POINTER_TO_STRING:                // Pointer to a null-terminated character string (Custom encoding). The size depend on CPU architecture.
							case Type.POINTER_TO_MULTI_STRING:          // Pointer to multiple null-terminated character string end with null (Custom encoding). The size depend on CPU architecture.
							case Type.POINTER_TO_ARRAY:                 // Pointer to an array of objects. The size depend on CPU architecture.
							case Type.POINTER_TO_ARRAY_OF_POINTERS:     // Pointer to an array of pointers. The size depend on CPU architecture.
								variableAlign							= Marshal.SizeOf(typeof(IntPtr));
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								break;
						}

						offset							+= padding;
						if (variableSize == 0)
							offset						+= variableAlign;
						else
							offset						+= variableSize;
					}
				}
				catch (Exception)
				{
				}
			}

			return offset;
		}

		private static void SetProperty(this System.Type type, object obj, string name, object value)
		{
			FieldInfo fieldInfo = type.GetField(name);
			if (fieldInfo != null)
			{
				fieldInfo.SetValue(obj, value);
			}
		}

		private static object GetProperty(this System.Type type, object obj, string name, object value)
		{
			FieldInfo fieldInfo = type.GetField(name);
			if (fieldInfo != null)
			{
				return fieldInfo.GetValue(obj);
			}

			return null;
		}

		private static int GetCount(string name, int defaultValue = 0)
		{
			if (string.IsNullOrEmpty(name) == false)
			{
				foreach (char c in name)
				{
					if (char.IsDigit(c) == false)
					{
						return defaultValue;
					}
				}

				// If the name is number (all characters is digit), work here.
				try
				{
					return int.Parse(name);
				}
				catch (Exception)
				{
				}
			}

			return defaultValue;
		}

		private static bool ReadBool(IntPtr pointer)
		{
			return Marshal.ReadByte(pointer) != 0;
		}

		private static sbyte ReadChar(IntPtr pointer)
		{
			return (sbyte)Marshal.ReadByte(pointer);
		}

		private static short ReadShort(IntPtr pointer)
		{
			return Marshal.ReadInt16(pointer);
		}

		private static int ReadInt(IntPtr pointer)
		{
			return Marshal.ReadInt32(pointer);
		}

		private static long ReadInt64(IntPtr pointer)
		{
			return Marshal.ReadInt64(pointer);
		}

		private static byte ReadByte(IntPtr pointer)
		{
			return Marshal.ReadByte(pointer);
		}

		private static ushort ReadWord(IntPtr pointer)
		{
			return (ushort)Marshal.ReadInt16(pointer);
		}

		private static uint ReadDword(IntPtr pointer)
		{
			return (uint)Marshal.ReadInt32(pointer);
		}

		private static ulong ReadQword(IntPtr pointer)
		{
			return (ulong)Marshal.ReadInt64(pointer);
		}

		private static float ReadFloat(IntPtr pointer)
		{
			float[]	value	= new float[1];
			Marshal.Copy(pointer, value, 0, 1);
			return value[0];
		}

		private static double ReadDouble(IntPtr pointer)
		{
			double[] value	= new double[1];
			Marshal.Copy(pointer, value, 0, 1);
			return value[0];
		}

		private static char ReadWChar(IntPtr pointer)
		{
			return (char)Marshal.ReadInt16(pointer);
		}

		private static IntPtr ReadPointer(IntPtr pointer)
		{
			return Marshal.ReadIntPtr(pointer);
		}

		private static int StrLength(IntPtr pointer)
		{
			int				length	= 0;
			while (Marshal.ReadByte(pointer) > 0)
			{
				length++;
				pointer				= pointer.Offset(1);
			}

			return length;
		}

		private static int MultiStrLength(IntPtr pointer)
		{
			int				length			= 0;
			bool			nullTerminated	= false;
			while (true)
			{
				if (Marshal.ReadByte(pointer) == 0)
				{
					if (nullTerminated == true)	// Second null-terminated
						break;

					nullTerminated			= true;
				}
				else
					nullTerminated			= false;

				length++;
				pointer = pointer.Offset(1);
			}

			return length;
		}

		private static string ReadBSTR(IntPtr pointer)
		{
			return Marshal.PtrToStringBSTR(pointer);
		}

		private static string ReadAnsi(IntPtr pointer)
		{
			return Marshal.PtrToStringAnsi(pointer);
		}

		private static string ReadUtf8(IntPtr pointer)
		{
			int length	= StrLength(pointer);
			if (length > 0)
			{
				byte[]		data	= new byte[length];
				Marshal.Copy(pointer, data, 0, length);
				return Encoding.UTF8.GetString(data);
			}
			
			return null;
		}

		private static string ReadUtf16(IntPtr pointer)
		{
			return Marshal.PtrToStringUni(pointer);
		}

		private static string ReadEncoding(IntPtr pointer, Encoding encoding, int count = 0)
		{
			if (encoding == null)
				encoding			= Encoding.ASCII;

			if (count == 0)
				count				= StrLength(pointer);

			if (count > 0)
			{
				byte[]		str		= new byte[count];
				Marshal.Copy(pointer, str, 0, count);
				return encoding.GetString(str);
			}

			return null;
		}

		private static string[] ReadMultiEncoding(IntPtr pointer, Encoding encoding, int count)
		{
			if (encoding == null)
				encoding			= Encoding.ASCII;

			List<string>	strings	= new List<string>();
			byte[]			data	= null;
			if (count > 0)
			{
				data				= new byte[count];
				Marshal.Copy(pointer, data, 0, count);
			}
			else
			{
				count				= MultiStrLength(pointer);
				if (count > 0)
				{
					data			= new byte[count];
					Marshal.Copy(pointer, data, 0, count);
				}
			}

			if (data != null)
			{
				int		startIndex	= 0;
				while (startIndex < data.Length)
				{
					int	length		= Array.IndexOf(data, (byte)0, startIndex) - startIndex;
					if (length > 0)
					{
						byte[] str	= new byte[length];
						Array.Copy(data, startIndex, str, 0, length);
						strings.Add(encoding.GetString(str));

						startIndex	+= length + 1;
					}
					else
					{
						break;
					}
				}
			}

			return strings.ToArray();
		}

		private static object[] ReadArray(IntPtr pointer, int count, System.Type type, out int variableSize, Encoding defaultEncoding)
		{
			System.Type		listType		= typeof(List<>);
			System.Type		listTargetType	= listType.MakeGenericType(type);

			dynamic			objs			= Activator.CreateInstance(listTargetType);

			int				typeAlign		= type.DefaultAlign();
			int				variableAlign	= type.Align();
			int				size			= type.Size();

			size							+= PaddingSize(size, variableAlign, typeAlign);

			variableSize					= 0;
			while (count > 0)
			{
				dynamic		obj				= MapTo(type, pointer, defaultEncoding);

				// I can not use objs.Add(obj) for .NET Standard Library
				MethodInfo AddMethod		= listTargetType.GetMethod("Add");
				object[]	parameters		= new object[] { obj };
				AddMethod.Invoke(objs, parameters);

				variableSize				+= size;
				pointer						= pointer.Offset(size);
				count--;
			}

			// I can not use objs.ToArray() for .NET Standard Library
			MethodInfo ToArrayMethod		= listTargetType.GetMethod("ToArray");
			return ToArrayMethod.Invoke(objs, null);
		}

		private static object[] ReadArrayOfPointers(IntPtr pointer, int count, System.Type type, out int variableSize, Encoding defaultEncoding)
		{
			System.Type		listType		= typeof(List<>);
			System.Type		listTargetType	= listType.MakeGenericType(type);

			dynamic			objs			= Activator.CreateInstance(listTargetType);

			int				size			= Marshal.SizeOf(typeof(IntPtr));

			variableSize					= 0;
			while (count > 0)
			{
				IntPtr		pointerToObject	= ReadPointer(pointer);
				dynamic		obj				= MapTo(type, pointerToObject, defaultEncoding);

				// I can not use objs.Add(obj) for .NET Standard Library
				MethodInfo AddMethod		= listTargetType.GetMethod("Add");
				object[]	parameters		= new object[] { obj };
				AddMethod.Invoke(objs, parameters);

				variableSize				+= size;
				pointer						= pointer.Offset(size);
				count--;
			}

			// I can not use objs.ToArray() for .NET Standard Library
			MethodInfo ToArrayMethod = listTargetType.GetMethod("ToArray");
			return ToArrayMethod.Invoke(objs, null);
		}

		private static int PaddingSize(int offset, int variableAlign, int typeAlign)
		{
			int		align;

			if (variableAlign > typeAlign)
				align		= typeAlign;
			else
				align		= variableAlign;

			return (align - (offset % align)) % align;
		}

		private static int GetCount(System.Type type, object obj, string name, int defaultValue = 0)
		{
			if (string.IsNullOrEmpty(name) == false)
			{
				foreach (char c in name)
				{
					if (char.IsDigit(c) == false)
					{
						// If the name is variable, work here.
						object value	= type.GetProperty(obj, name, defaultValue);
						if (value != null)
						{
							try
							{
								return Convert.ToInt32(value);
							}
							catch (Exception)
							{
							}
						}

						return defaultValue;
					}
				}

				// If the name is number (all characters is digit), work here.
				try
				{
					return int.Parse(name);
				}
				catch (Exception)
				{
				}
			}

			return defaultValue;
		}

		private static object MapToPrimitive(System.Type targetType, IntPtr pointer, Encoding defaultEncoding)
		{
			if (targetType == typeof(bool))
				return ReadBool(pointer);
			else if (targetType == typeof(sbyte))
				return ReadChar(pointer);
			else if (targetType == typeof(short))
				return ReadShort(pointer);
			else if (targetType == typeof(int))
				return ReadInt(pointer);
			else if (targetType == typeof(long))
				return ReadInt64(pointer);
			else if (targetType == typeof(byte))
				return ReadByte(pointer);
			else if (targetType == typeof(ushort))
				return ReadWord(pointer);
			else if (targetType == typeof(uint))
				return ReadDword(pointer);
			else if (targetType == typeof(ulong))
				return ReadQword(pointer);
			else if (targetType == typeof(string))
				return ReadEncoding(pointer, defaultEncoding);

			return null;
		}

		private static object MapTo(System.Type type, IntPtr pointer, Encoding defaultEncoding)
		{
			object			obj				= MapToPrimitive(type, pointer, defaultEncoding);

			if (obj != null)
				return obj;

			FieldInfo[]		fieldInfos		= type.GetFields();
			int				typeAlign		= type.DefaultAlign();
			int				variableAlign	= 0;
			int				variableSize	= 0;
			int				offset			= 0;
			Encoding		encoding;
			IntPtr			lastPointer		= pointer;
			IntPtr			pointerToObject;
			int				padding			= 0;
			int				count;
			object			value;

			obj								= Activator.CreateInstance(type);

			foreach (FieldInfo fieldInfo in fieldInfos)
			{
				try
				{
					UnmanagedFieldAttribute		unmanagedAttribute		= fieldInfo.GetCustomAttribute<UnmanagedFieldAttribute>();
					if (unmanagedAttribute != null)
					{
						variableSize									= 0;
						try
						{
							encoding									= Encoding.GetEncoding(unmanagedAttribute.Encoding);
						}
						catch (Exception)
						{
							encoding									= defaultEncoding;
						}

						switch (unmanagedAttribute.Type)
						{
							case Type.BOOL:                             // 1 byte
								variableAlign							= 1;
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								type.SetProperty(obj, fieldInfo.Name, ReadBool(lastPointer));
								break;
							case Type.CHAR:								// signed 1 byte
							case Type.INT8:                             // signed 1 bytes
								variableAlign							= 1;
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								type.SetProperty(obj, fieldInfo.Name, ReadChar(lastPointer));
								break;
							case Type.SHORT:							// signed 2 bytes
							case Type.INT16:                            // signed 2 bytes
								variableAlign							= 2;
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								type.SetProperty(obj, fieldInfo.Name, ReadShort(lastPointer));
								break;
							case Type.INT:								// signed 4 bytes
							case Type.INT32:							// signed 4 bytes
							case Type.LONG:                             // signed 4 bytes
								variableAlign							= 4;
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								type.SetProperty(obj, fieldInfo.Name, ReadInt(lastPointer));
								break;
							case Type.INT64:							// signed 8 bytes
							case Type.LONG_LONG:                        // signed 8 bytes
								variableAlign							= 8;
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								type.SetProperty(obj, fieldInfo.Name, ReadInt64(lastPointer));
								break;
							case Type.UNSIGNED_CHAR:					// unsigned 1 byte
							case Type.UNSIGNED_INT8:					// unsigned 1 bytes
							case Type.BYTE:                             // unsigned 1 byte
								variableAlign							= 1;
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								type.SetProperty(obj, fieldInfo.Name, ReadByte(lastPointer));
								break;
							case Type.UNSIGNED_SHORT:					// unsigned 2 bytes
							case Type.UNSIGNED_INT16:					// unsigned 2 bytes
							case Type.WORD:                             // unsigned 2 bytes
								variableAlign							= 2;
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								type.SetProperty(obj, fieldInfo.Name, ReadWord(lastPointer));
								break;
							case Type.UNSIGNED_INT:						// unsigned 4 bytes
							case Type.UNSIGNED_INT32:					// unsigned 4 bytes
							case Type.UNSIGNED_LONG:					// unsigned 4 bytes
							case Type.DWORD:                            // unsigned 4 bytes
								variableAlign							= 4;
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								type.SetProperty(obj, fieldInfo.Name, ReadDword(lastPointer));
								break;
							case Type.UNSIGNED_INT64:					// unsigned 8 bytes
							case Type.UNSIGNED_LONG_LONG:				// unsigned 8 bytes
							case Type.QWORD:                            // unsigned 8 bytes
								variableAlign							= 8;
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								type.SetProperty(obj, fieldInfo.Name, ReadQword(lastPointer));
								break;
							case Type.FLOAT:                            // signed 4 bytes, 3.4E +/- 38 (7 digits)
								variableAlign							= 4;
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								type.SetProperty(obj, fieldInfo.Name, ReadFloat(lastPointer));
								break;
							case Type.DOUBLE:                           // signed 8 bytes, 1.7E +/- 308 (15 digits)
								variableAlign							= 8;
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								type.SetProperty(obj, fieldInfo.Name, ReadDouble(lastPointer));
								break;
							case Type.WCHAR:                            // unsigned 2 bytes
								variableAlign							= 2;
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								type.SetProperty(obj, fieldInfo.Name, ReadWChar(lastPointer));
								break;
							case Type.STRING:							// Null terminated string with encoding
								count									= GetCount(type, obj, unmanagedAttribute.Count);
								variableAlign							= 1;
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								type.SetProperty(obj, fieldInfo.Name, ReadEncoding(lastPointer, encoding, count));
								variableSize							= count;
								break;
							case Type.MULTI_STRING:						// Multiple null terminated strings end with null
								count									= GetCount(type, obj, unmanagedAttribute.Count);
								variableAlign							= 1;
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								type.SetProperty(obj, fieldInfo.Name, ReadMultiEncoding(lastPointer, encoding, count));
								variableSize							= count;
								break;
							case Type.ARRAY:							// Array of objects
								count									= GetCount(type, obj, unmanagedAttribute.Count);
								variableAlign							= unmanagedAttribute.TargetType.Align();
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								value									= ReadArray(lastPointer, count, unmanagedAttribute.TargetType, out variableSize, defaultEncoding);
								type.SetProperty(obj, fieldInfo.Name, value);
								break;
							case Type.ARRAY_OF_POINTERS:				// Array of pointers
								count									= GetCount(type, obj, unmanagedAttribute.Count);
								variableAlign							= Marshal.SizeOf(typeof(IntPtr));
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								value									= ReadArrayOfPointers(lastPointer, count, unmanagedAttribute.TargetType, out variableSize, defaultEncoding);
								type.SetProperty(obj, fieldInfo.Name, value);
								break;
							case Type.POINTER:                          // Pointer, The size depend on CPU architecture.
								variableAlign							= Marshal.SizeOf(typeof(IntPtr));
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								pointerToObject							= ReadPointer(lastPointer);
								if (pointerToObject == IntPtr.Zero || unmanagedAttribute.TargetType == null)
								{
									type.SetProperty(obj, fieldInfo.Name, pointerToObject);
								}
								else
								{
									value								= MapTo(unmanagedAttribute.TargetType, pointerToObject, defaultEncoding);
									type.SetProperty(obj, fieldInfo.Name, value);
								}
							
								break;
							case Type.POINTER_TO_BSTR:                  // Pointer to a null-terminated character string in which the string length is stored with the string. The size depend on CPU architecture.
								variableAlign							= Marshal.SizeOf(typeof(IntPtr));
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								pointerToObject							= ReadPointer(lastPointer);
								type.SetProperty(obj, fieldInfo.Name, ReadBSTR(pointerToObject));
								break;
							case Type.POINTER_TO_ANSI:                  // Pointer to a null-terminated character ANSI string. The size depend on CPU architecture.
								variableAlign							= Marshal.SizeOf(typeof(IntPtr));
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								pointerToObject							= ReadPointer(lastPointer);
								type.SetProperty(obj, fieldInfo.Name, ReadAnsi(pointerToObject));
								break;
							case Type.POINTER_TO_UTF8:                  // Pointer to a null-terminated character UTF-8 string. The size depend on CPU architecture.
								variableAlign							= Marshal.SizeOf(typeof(IntPtr));
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								pointerToObject							= ReadPointer(lastPointer);
								type.SetProperty(obj, fieldInfo.Name, ReadUtf8(pointerToObject));
								break;
							case Type.POINTER_TO_UTF16:                 // Pointer to a null-terminated character UTF-16 string. The size depend on CPU architecture.
								variableAlign							= Marshal.SizeOf(typeof(IntPtr));
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								pointerToObject							= ReadPointer(lastPointer);
								type.SetProperty(obj, fieldInfo.Name, ReadUtf16(pointerToObject));
								break;
							case Type.POINTER_TO_STRING:                // Pointer to a null-terminated character string (Custom encoding). The size depend on CPU architecture.
								count									= GetCount(type, obj, unmanagedAttribute.Count);
								variableAlign							= Marshal.SizeOf(typeof(IntPtr));
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								pointerToObject							= ReadPointer(lastPointer);
								type.SetProperty(obj, fieldInfo.Name, ReadEncoding(pointerToObject, encoding, count));
								break;
							case Type.POINTER_TO_MULTI_STRING:          // Pointer to multiple null-terminated character string end with null (Custom encoding). The size depend on CPU architecture.
								count									= GetCount(type, obj, unmanagedAttribute.Count);
								variableAlign							= Marshal.SizeOf(typeof(IntPtr));
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								pointerToObject							= ReadPointer(lastPointer);
								type.SetProperty(obj, fieldInfo.Name, ReadMultiEncoding(pointerToObject, encoding, count));
								break;
							case Type.POINTER_TO_ARRAY:                 // Pointer to an array of objects. The size depend on CPU architecture.
								variableAlign							= Marshal.SizeOf(typeof(IntPtr));
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								pointerToObject							= ReadPointer(lastPointer);
								count									= GetCount(type, obj, unmanagedAttribute.Count);
								if (pointerToObject == IntPtr.Zero)
								{
									type.SetProperty(obj, fieldInfo.Name, pointerToObject);
								}
								else
								{
									value								= ReadArray(pointerToObject, count, unmanagedAttribute.TargetType, out variableSize, defaultEncoding);
									type.SetProperty(obj, fieldInfo.Name, value);
								}
							
								variableSize							= 0;
								break;
							case Type.POINTER_TO_ARRAY_OF_POINTERS:     // Pointer to an array of pointers. The size depend on CPU architecture.
								variableAlign							= Marshal.SizeOf(typeof(IntPtr));
								padding									= PaddingSize(offset, variableAlign, typeAlign);
								lastPointer								= lastPointer.Offset(padding);
								pointerToObject							= ReadPointer(lastPointer);
								count									= GetCount(type, obj, unmanagedAttribute.Count);
								if (pointerToObject == IntPtr.Zero)
								{
									type.SetProperty(obj, fieldInfo.Name, pointerToObject);
								}
								else
								{
									value								= ReadArrayOfPointers(pointerToObject, count, unmanagedAttribute.TargetType, out variableSize, defaultEncoding);
									type.SetProperty(obj, fieldInfo.Name, value);
								}
							
								variableSize							= 0;
								break;
						}

						offset							+= padding;
						if (variableSize == 0)
						{
							offset						+= variableAlign;
							lastPointer					= lastPointer.Offset(variableAlign);
						}
						else
						{
							offset						+= variableSize;
							lastPointer					= lastPointer.Offset(variableSize);
						}
					}
				}
				catch (Exception)
				{
				}
			}

			return obj;
		}

		/// <summary>
		/// Extension for IntPtr variable.
		/// </summary>
		/// <param name="pointer">IntPtr pointer to data structure.</param>
		/// <example>
		/// <code>
		/// [UnmanagedStruct(8)]
		/// [DllImport("college.dll")]
		/// public static extern IntPtr GetStudent();
		/// 
		/// public class Student
		/// {
		///	    [UnmanagedField(Unmanaged.Type.BOOL)]
		///	    public bool Graduated;
		///
		///	    [UnmanagedField(Unmanaged.Type.INT64)]
		///	    public long ID;
		///
		///	    [UnmanagedField(Unmanaged.Type.POINTER_TO_STRING, Encoding = "utf-8")]
		///	    public string Name;
		/// }
		/// 
		/// static void Main(string[] args)
		/// {
		///	    IntPtr pointer = GetStudent();
		///	    Student student = pointer.MapTo&lt;Student&gt;();
		///
		///	    Console.WriteLine("ID:   " + student.ID);
		///	    Console.WriteLine("Name: " + student.Name);
		///	    if (student.Graduated == true)
		///	    	Console.WriteLine("Graduated from here.");
		///	    else
		///	    	Console.WriteLine("He is a student.");
		/// }
		/// </code>
		/// </example>
		public static T MapTo<T>(this IntPtr pointer) where T : new()
		{
			System.Type type	= typeof(T);
			return (T)MapTo(type, pointer, Encoding.ASCII);
		}

		/// <summary>
		/// Extension for IntPtr variable.
		/// </summary>
		/// <param name="pointer">IntPtr pointer to data structure.</param>
		/// <param name="encoding">Default encoding.</param>
		/// <example>
		/// <code>
		/// [UnmanagedStruct(8)]
		/// [DllImport("college.dll")]
		/// public static extern IntPtr GetStudent();
		/// 
		/// public class Student
		/// {
		///	    [UnmanagedField(Unmanaged.Type.BOOL)]
		///	    public bool Graduated;
		///
		///	    [UnmanagedField(Unmanaged.Type.INT64)]
		///	    public long ID;
		///
		///	    [UnmanagedField(Unmanaged.Type.POINTER_TO_STRING, Encoding = "utf-8")]
		///	    public string Name;
		/// }
		/// 
		/// static void Main(string[] args)
		/// {
		///	    IntPtr pointer = GetStudent();
		///	    Student student = pointer.MapTo&lt;Student&gt;("utf-8");
		///
		///	    Console.WriteLine("ID:   " + student.ID);
		///	    Console.WriteLine("Name: " + student.Name);
		///	    if (student.Graduated == true)
		///	    	Console.WriteLine("Graduated from here.");
		///	    else
		///	    	Console.WriteLine("He is a student.");
		/// }
		/// </code>
		/// </example>
		private static T MapTo<T>(this IntPtr pointer, string encoding) where T : new()
		{
			System.Type type	= typeof(T);
			return (T)MapTo(type, pointer, Encoding.GetEncoding(encoding));
		}
	}
}
