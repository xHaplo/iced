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

#if (!NO_GAS_FORMATTER || !NO_INTEL_FORMATTER || !NO_MASM_FORMATTER || !NO_NASM_FORMATTER) && !NO_FORMATTER
using System;
using System.IO;
using Generator.Enums;
using Generator.IO;

namespace Generator.Formatters.CSharp {
	abstract class CSharpFormatterTableSerializer : FormatterTableSerializer {
		readonly IdentifierConverter idConverter;

		protected abstract object[][] Infos { get; }
		protected abstract string Define { get; }
		protected abstract string Namespace { get; }
		protected abstract EnumType CtorKindEnum { get; }

		protected CSharpFormatterTableSerializer() =>
			idConverter = CSharpIdentifierConverter.Create();

		public override void Initialize(StringsTable stringsTable) =>
			Initialize(stringsTable, Infos);

		public override string GetFilename(ProjectDirs projectDirs) =>
			Path.Combine(CSharpConstants.GetDirectory(projectDirs, Namespace), "InstrInfos.g.cs");

		public override void Serialize(FileWriter writer, StringsTable stringsTable) {
			writer.WriteFileHeader();
			writer.WriteLine($"#if {Define}");
			writer.WriteLine($"namespace {Namespace} {{");
			writer.Indent();
			writer.WriteLine("static partial class InstrInfos {");
			writer.Indent();
			writer.WriteLine("static byte[] GetSerializedInstrInfos() =>");
			writer.Indent();
			writer.WriteLine("new byte[] {");
			writer.Indent();

			int index = -1;
			var infos = Infos;
			for (int i = 0; i < infos.Length; i++) {
				var info = infos[i];
				index++;
				var ctorKind = (EnumValue)info[0];
				var code = (EnumValue)info[Utils.CodeValueIndex];
				if (code.Value != (uint)index)
					throw new InvalidOperationException();

				if (index != 0)
					writer.WriteLine();
				writer.WriteCommentLine(code.ToStringValue(idConverter));

				bool isSame = i > 0 && IsSame(infos[i - 1], info);
				if (isSame)
					ctorKind = CtorKindEnum["Previous"];

				if ((uint)ctorKind.Value > 0x7F)
					throw new InvalidOperationException();
				uint firstStringIndex = GetFirstStringIndex(stringsTable, info, out bool hasVPrefix);
				writer.WriteByte((byte)((uint)ctorKind.Value | (hasVPrefix ? 0x80U : 0)));
				if (hasVPrefix)
					writer.WriteCommentLine($"'v', {ctorKind.ToStringValue(idConverter)}");
				else
					writer.WriteCommentLine($"{ctorKind.ToStringValue(idConverter)}");
				if (isSame)
					continue;
				uint si;
				for (int j = 2; j < info.Length; j++) {
					switch (info[j]) {
					case string s:
						if (firstStringIndex != uint.MaxValue) {
							si = firstStringIndex;
							firstStringIndex = uint.MaxValue;
						}
						else {
							si = stringsTable.GetIndex(s, ignoreVPrefix: true, out hasVPrefix);
							if (hasVPrefix)
								throw new InvalidOperationException();
						}
						writer.WriteCompressedUInt32(si);
						writer.WriteCommentLine($"{si} = \"{s}\"");
						break;

					case char c:
						if ((ushort)c > byte.MaxValue)
							throw new InvalidOperationException();
						writer.WriteByte((byte)c);
						if (c == '\0')
							writer.WriteCommentLine(@"'\0'");
						else
							writer.WriteCommentLine($"'{c}'");
						break;

					case int ival:
						writer.WriteCompressedUInt32((uint)ival);
						writer.WriteCommentLine($"0x{ival:X}");
						break;

					case bool b:
						writer.WriteByte((byte)(b ? 1 : 0));
						writer.WriteCommentLine(b.ToString());
						break;

					case IEnumValue enumValue:
						var typeId = enumValue.DeclaringType.TypeId;
						if (typeId == TypeIds.GasInstrOpInfoFlags) {
							writer.WriteCompressedUInt32((uint)enumValue.Value);
							writer.WriteCommentLine($"0x{(uint)enumValue.Value:X} = {enumValue.ToStringValue(idConverter)}");
						}
						else if (typeId == TypeIds.IntelInstrOpInfoFlags) {
							writer.WriteCompressedUInt32((uint)enumValue.Value);
							writer.WriteCommentLine($"0x{(uint)enumValue.Value:X} = {enumValue.ToStringValue(idConverter)}");
						}
						else if (typeId == TypeIds.MasmInstrOpInfoFlags) {
							writer.WriteCompressedUInt32((uint)enumValue.Value);
							writer.WriteCommentLine($"0x{(uint)enumValue.Value:X} = {enumValue.ToStringValue(idConverter)}");
						}
						else if (typeId == TypeIds.NasmInstrOpInfoFlags) {
							writer.WriteCompressedUInt32((uint)enumValue.Value);
							writer.WriteCommentLine($"0x{(uint)enumValue.Value:X} = {enumValue.ToStringValue(idConverter)}");
						}
						else if (typeId == TypeIds.PseudoOpsKind) {
							if ((uint)enumValue.Value > byte.MaxValue)
								throw new InvalidOperationException();
							writer.WriteByte((byte)enumValue.Value);
							writer.WriteCommentLine(enumValue.ToStringValue(idConverter));
						}
						else if (typeId == TypeIds.CodeSize) {
							if ((uint)enumValue.Value > byte.MaxValue)
								throw new InvalidOperationException();
							writer.WriteByte((byte)enumValue.Value);
							writer.WriteCommentLine(enumValue.ToStringValue(idConverter));
						}
						else if (typeId == TypeIds.Register) {
							if ((uint)enumValue.Value > byte.MaxValue)
								throw new InvalidOperationException();
							writer.WriteByte((byte)enumValue.Value);
							writer.WriteCommentLine(enumValue.ToStringValue(idConverter));
						}
						else if (typeId == TypeIds.MemorySize) {
							if ((uint)enumValue.Value > byte.MaxValue)
								throw new InvalidOperationException();
							writer.WriteByte((byte)enumValue.Value);
							writer.WriteCommentLine(enumValue.ToStringValue(idConverter));
						}
						else if (typeId == TypeIds.NasmSignExtendInfo) {
							if ((uint)enumValue.Value > byte.MaxValue)
								throw new InvalidOperationException();
							writer.WriteByte((byte)enumValue.Value);
							writer.WriteCommentLine(enumValue.ToStringValue(idConverter));
						}
						else
							throw new InvalidOperationException();
						break;

					default:
						throw new InvalidOperationException();
					}
				}
			}

			writer.Unindent();
			writer.WriteLine("};");
			writer.Unindent();
			writer.Unindent();
			writer.WriteLine("}");
			writer.Unindent();
			writer.WriteLine("}");
			writer.WriteLine("#endif");
		}
	}
}
#endif
