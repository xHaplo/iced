/*
Copyright (C) 2018-2019 de4dot@gmail.com

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System.Linq;

namespace Generator.Enums {
	enum MemorySize {
		[Comment("Unknown size or the instruction doesn't reference any memory (eg. #(c:lea)#)")]
		Unknown,
		[Comment("Memory location contains a #(t:u8)#")]
		UInt8,
		[Comment("Memory location contains a #(t:u16)#")]
		UInt16,
		[Comment("Memory location contains a #(t:u32)#")]
		UInt32,
		[Comment("Memory location contains a #(t:u52)#")]
		UInt52,
		[Comment("Memory location contains a #(t:u64)#")]
		UInt64,
		[Comment("Memory location contains a #(t:u128)#")]
		UInt128,
		[Comment("Memory location contains a #(t:u256)#")]
		UInt256,
		[Comment("Memory location contains a #(t:u512)#")]
		UInt512,
		[Comment("Memory location contains a #(t:i8)#")]
		Int8,
		[Comment("Memory location contains a #(t:i16)#")]
		Int16,
		[Comment("Memory location contains a #(t:i32)#")]
		Int32,
		[Comment("Memory location contains a #(t:i64)#")]
		Int64,
		[Comment("Memory location contains a #(t:i128)#")]
		Int128,
		[Comment("Memory location contains a #(t:i256)#")]
		Int256,
		[Comment("Memory location contains a #(t:i512)#")]
		Int512,
		[Comment("Memory location contains a seg:ptr pair, #(t:u16)# (offset) + #(t:u16)# (segment/selector)")]
		SegPtr16,
		[Comment("Memory location contains a seg:ptr pair, #(t:u32)# (offset) + #(t:u16)# (segment/selector)")]
		SegPtr32,
		[Comment("Memory location contains a seg:ptr pair, #(t:u64)# (offset) + #(t:u16)# (segment/selector)")]
		SegPtr64,
		[Comment("Memory location contains a 16-bit offset (#(c:jmp/call word ptr [mem])#)")]
		WordOffset,
		[Comment("Memory location contains a 32-bit offset (#(c:jmp/call dword ptr [mem])#)")]
		DwordOffset,
		[Comment("Memory location contains a 64-bit offset (#(c:jmp/call qword ptr [mem])#)")]
		QwordOffset,
		[Comment("Memory location contains two #(t:u16)#s (16-bit #(c:bound)#)")]
		Bound16_WordWord,
		[Comment("Memory location contains two #(t:u32)#s (32-bit #(c:bound)#)")]
		Bound32_DwordDword,
		[Comment("32-bit #(c:bndmov)#, 2 x #(t:u32)#")]
		Bnd32,
		[Comment("64-bit #(c:bndmov)#, 2 x #(t:u64)#")]
		Bnd64,
		[Comment("Memory location contains a 16-bit limit and a 32-bit address (eg. #(c:lgdtw)#, #(c:lgdtd)#)")]
		Fword6,
		[Comment("Memory location contains a 16-bit limit and a 64-bit address (eg. #(c:lgdtq)#)")]
		Fword10,
		[Comment("Memory location contains a #(t:f16)#")]
		Float16,
		[Comment("Memory location contains a #(t:f32)#")]
		Float32,
		[Comment("Memory location contains a #(t:f64)#")]
		Float64,
		[Comment("Memory location contains a #(t:f80)#")]
		Float80,
		[Comment("Memory location contains a #(t:f128)#")]
		Float128,
		[Comment("Memory location contains a #(t:bf16)#")]
		BFloat16,
		[Comment("Memory location contains a 14-byte FPU environment (16-bit #(c:fldenv)#/#(c:fstenv)#)")]
		FpuEnv14,
		[Comment("Memory location contains a 28-byte FPU environment (32/64-bit #(c:fldenv)#/#(c:fstenv)#)")]
		FpuEnv28,
		[Comment("Memory location contains a 94-byte FPU environment (16-bit #(c:fsave)#/#(c:frstor)#)")]
		FpuState94,
		[Comment("Memory location contains a 108-byte FPU environment (32/64-bit #(c:fsave)#/#(c:frstor)#)")]
		FpuState108,
		[Comment("Memory location contains 512-bytes of #(c:fxsave)#/#(c:fxrstor)# data")]
		Fxsave_512Byte,
		[Comment("Memory location contains 512-bytes of #(c:fxsave64)#/#(c:fxrstor64)# data")]
		Fxsave64_512Byte,
		[Comment("32-bit #(c:XSAVE)# area")]
		Xsave,
		[Comment("64-bit #(c:XSAVE)# area")]
		Xsave64,
		[Comment("Memory location contains a 10-byte #(t:bcd)# value (#(c:fbld)#/#(c:fbstp)#)")]
		Bcd,
		[Comment("16 bit location: 2 x #(t:u8)#")]
		Packed16_UInt8,
		[Comment("16 bit location: 2 x #(t:i8)#")]
		Packed16_Int8,
		[Comment("32 bit location: 4 x #(t:u8)#")]
		Packed32_UInt8,
		[Comment("32 bit location: 4 x #(t:i8)#")]
		Packed32_Int8,
		[Comment("32 bit location: 2 x #(t:u16)#")]
		Packed32_UInt16,
		[Comment("32 bit location: 2 x #(t:i16)#")]
		Packed32_Int16,
		[Comment("32 bit location: 2 x #(t:bf16)#")]
		Packed32_BFloat16,
		[Comment("64-bit location: 8 x #(t:u8)#")]
		Packed64_UInt8,
		[Comment("64-bit location: 8 x #(t:i8)#")]
		Packed64_Int8,
		[Comment("64-bit location: 4 x #(t:u16)#")]
		Packed64_UInt16,
		[Comment("64-bit location: 4 x #(t:i16)#")]
		Packed64_Int16,
		[Comment("64-bit location: 2 x #(t:u32)#")]
		Packed64_UInt32,
		[Comment("64-bit location: 2 x #(t:i32)#")]
		Packed64_Int32,
		[Comment("64-bit location: 4 x #(t:f16)#")]
		Packed64_Float16,
		[Comment("64-bit location: 2 x #(t:f32)#")]
		Packed64_Float32,
		[Comment("128 bit location: 16 x #(t:u8)#")]
		Packed128_UInt8,
		[Comment("128 bit location: 16 x #(t:i8)#")]
		Packed128_Int8,
		[Comment("128 bit location: 8 x #(t:u16)#")]
		Packed128_UInt16,
		[Comment("128 bit location: 8 x #(t:i16)#")]
		Packed128_Int16,
		[Comment("128 bit location: 4 x #(t:u32)#")]
		Packed128_UInt32,
		[Comment("128 bit location: 4 x #(t:i32)#")]
		Packed128_Int32,
		[Comment("128 bit location: 2 x #(t:u52)#")]
		Packed128_UInt52,
		[Comment("128 bit location: 2 x #(t:u64)#")]
		Packed128_UInt64,
		[Comment("128 bit location: 2 x #(t:i64)#")]
		Packed128_Int64,
		[Comment("128 bit location: 8 x #(t:f16)#")]
		Packed128_Float16,
		[Comment("128 bit location: 4 x #(t:f32)#")]
		Packed128_Float32,
		[Comment("128 bit location: 2 x #(t:f64)#")]
		Packed128_Float64,
		[Comment("128 bit location: 4 x (2 x #(t:bf16)#)")]
		Packed128_2xBFloat16,
		[Comment("256 bit location: 32 x #(t:u8)#")]
		Packed256_UInt8,
		[Comment("256 bit location: 32 x #(t:i8)#")]
		Packed256_Int8,
		[Comment("256 bit location: 16 x #(t:u16)#")]
		Packed256_UInt16,
		[Comment("256 bit location: 16 x #(t:i16)#")]
		Packed256_Int16,
		[Comment("256 bit location: 8 x #(t:u32)#")]
		Packed256_UInt32,
		[Comment("256 bit location: 8 x #(t:i32)#")]
		Packed256_Int32,
		[Comment("256 bit location: 4 x #(t:u52)#")]
		Packed256_UInt52,
		[Comment("256 bit location: 4 x #(t:u64)#")]
		Packed256_UInt64,
		[Comment("256 bit location: 4 x #(t:i64)#")]
		Packed256_Int64,
		[Comment("256 bit location: 2 x #(t:u128)#")]
		Packed256_UInt128,
		[Comment("256 bit location: 2 x #(t:i128)#")]
		Packed256_Int128,
		[Comment("256 bit location: 16 x #(t:f16)#")]
		Packed256_Float16,
		[Comment("256 bit location: 8 x #(t:f32)#")]
		Packed256_Float32,
		[Comment("256 bit location: 4 x #(t:f64)#")]
		Packed256_Float64,
		[Comment("256 bit location: 2 x #(t:f128)#")]
		Packed256_Float128,
		[Comment("256 bit location: 8 x (2 x #(t:bf16)#)")]
		Packed256_2xBFloat16,
		[Comment("512 bit location: 64 x #(t:u8)#")]
		Packed512_UInt8,
		[Comment("512 bit location: 64 x #(t:i8)#")]
		Packed512_Int8,
		[Comment("512 bit location: 32 x #(t:u16)#")]
		Packed512_UInt16,
		[Comment("512 bit location: 32 x #(t:i16)#")]
		Packed512_Int16,
		[Comment("512 bit location: 16 x #(t:u32)#")]
		Packed512_UInt32,
		[Comment("512 bit location: 16 x #(t:i32)#")]
		Packed512_Int32,
		[Comment("512 bit location: 8 x #(t:u52)#")]
		Packed512_UInt52,
		[Comment("512 bit location: 8 x #(t:u64)#")]
		Packed512_UInt64,
		[Comment("512 bit location: 8 x #(t:i64)#")]
		Packed512_Int64,
		[Comment("256 bit location: 4 x #(t:u128)#")]
		Packed512_UInt128,
		[Comment("512 bit location: 16 x #(t:f32)#")]
		Packed512_Float32,
		[Comment("512 bit location: 8 x #(t:f64)#")]
		Packed512_Float64,
		[Comment("512 bit location: 16 x (2 x #(t:bf16)#)")]
		Packed512_2xBFloat16,
		[Comment("Broadcast #(t:u32)# to 64 bits")]
		Broadcast64_UInt32,
		[Comment("Broadcast #(t:i32)# to 64 bits")]
		Broadcast64_Int32,
		[Comment("Broadcast #(t:f32)# to 64 bits")]
		Broadcast64_Float32,
		[Comment("Broadcast #(t:u32)# to 128 bits")]
		Broadcast128_UInt32,
		[Comment("Broadcast #(t:i32)# to 128 bits")]
		Broadcast128_Int32,
		[Comment("Broadcast #(t:u52)# to 128 bits")]
		Broadcast128_UInt52,
		[Comment("Broadcast #(t:u64)# to 128 bits")]
		Broadcast128_UInt64,
		[Comment("Broadcast #(t:i64)# to 128 bits")]
		Broadcast128_Int64,
		[Comment("Broadcast #(t:f32)# to 128 bits")]
		Broadcast128_Float32,
		[Comment("Broadcast #(t:f64)# to 128 bits")]
		Broadcast128_Float64,
		[Comment("Broadcast #(t:u32)# to 256 bits")]
		Broadcast256_UInt32,
		[Comment("Broadcast #(t:i32)# to 256 bits")]
		Broadcast256_Int32,
		[Comment("Broadcast #(t:u52)# to 256 bits")]
		Broadcast256_UInt52,
		[Comment("Broadcast #(t:u64)# to 256 bits")]
		Broadcast256_UInt64,
		[Comment("Broadcast #(t:i64)# to 256 bits")]
		Broadcast256_Int64,
		[Comment("Broadcast #(t:f32)# to 256 bits")]
		Broadcast256_Float32,
		[Comment("Broadcast #(t:f64)# to 256 bits")]
		Broadcast256_Float64,
		[Comment("Broadcast #(t:u32)# to 512 bits")]
		Broadcast512_UInt32,
		[Comment("Broadcast #(t:i32)# to 512 bits")]
		Broadcast512_Int32,
		[Comment("Broadcast #(t:u52)# to 512 bits")]
		Broadcast512_UInt52,
		[Comment("Broadcast #(t:u64)# to 512 bits")]
		Broadcast512_UInt64,
		[Comment("Broadcast #(t:i64)# to 512 bits")]
		Broadcast512_Int64,
		[Comment("Broadcast #(t:f32)# to 512 bits")]
		Broadcast512_Float32,
		[Comment("Broadcast #(t:f64)# to 512 bits")]
		Broadcast512_Float64,
		[Comment("Broadcast 2 x #(t:i16)# to 128 bits")]
		Broadcast128_2xInt16,
		[Comment("Broadcast 2 x #(t:i16)# to 256 bits")]
		Broadcast256_2xInt16,
		[Comment("Broadcast 2 x #(t:i16)# to 512 bits")]
		Broadcast512_2xInt16,
		[Comment("Broadcast 2 x #(t:u32)# to 128 bits")]
		Broadcast128_2xUInt32,
		[Comment("Broadcast 2 x #(t:u32)# to 256 bits")]
		Broadcast256_2xUInt32,
		[Comment("Broadcast 2 x #(t:u32)# to 512 bits")]
		Broadcast512_2xUInt32,
		[Comment("Broadcast 2 x #(t:i32)# to 128 bits")]
		Broadcast128_2xInt32,
		[Comment("Broadcast 2 x #(t:i32)# to 256 bits")]
		Broadcast256_2xInt32,
		[Comment("Broadcast 2 x #(t:i32)# to 512 bits")]
		Broadcast512_2xInt32,
		[Comment("Broadcast 2 x #(t:bf16)# to 128 bits")]
		Broadcast128_2xBFloat16,
		[Comment("Broadcast 2 x #(t:bf16)# to 256 bits")]
		Broadcast256_2xBFloat16,
		[Comment("Broadcast 2 x #(t:bf16)# to 512 bits")]
		Broadcast512_2xBFloat16,
	}

	static class MemorySizeEnum {
		const string documentation = "Size of a memory reference";
		public const int NumValues = 136;

		static EnumValue[] GetValues() =>
			typeof(MemorySize).GetFields().Where(a => a.IsLiteral).Select(a => new EnumValue((uint)(MemorySize)a.GetValue(null)!, a.Name, CommentAttribute.GetDocumentation(a))).ToArray();

		public static readonly EnumType Instance = new EnumType(TypeIds.MemorySize, documentation, GetValues(), EnumTypeFlags.Public);
	}
}
