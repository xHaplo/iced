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

namespace Generator.Enums {
	static class CpuidFeatureEnum {
		const string documentation = "CPUID feature flags";

		static EnumValue[] GetValues() =>
			new EnumValue[] {
				new EnumValue("INTEL8086", "8086 or later"),
				new EnumValue("INTEL8086_ONLY", "8086 only"),
				new EnumValue("INTEL186", "80186 or later"),
				new EnumValue("INTEL286", "80286 or later"),
				new EnumValue("INTEL286_ONLY", "80286 only"),
				new EnumValue("INTEL386", "80386 or later"),
				new EnumValue("INTEL386_ONLY", "80386 only"),
				new EnumValue("INTEL386_A0_ONLY", "80386 A0-B0 stepping only (xbts, ibts instructions)"),
				new EnumValue("INTEL486", "Intel486 or later"),
				new EnumValue("INTEL486_A_ONLY", "Intel486 A stepping only (cmpxchg)"),
				new EnumValue("INTEL386_486_ONLY", "80386 and Intel486 only"),
				new EnumValue("IA64", "IA-64"),
				new EnumValue("X64", "CPUID.80000001H:EDX.LM[bit 29]"),
				new EnumValue("ADX", "CPUID.(EAX=07H, ECX=0H):EBX.ADX[bit 19]"),
				new EnumValue("AES", "CPUID.01H:ECX.AES[bit 25]"),
				new EnumValue("AVX", "CPUID.01H:ECX.AVX[bit 28]"),
				new EnumValue("AVX2", "CPUID.(EAX=07H, ECX=0H):EBX.AVX2[bit 5]"),
				new EnumValue("AVX512_4FMAPS", "CPUID.(EAX=07H, ECX=0H):EDX.AVX512_4FMAPS[bit 3]"),
				new EnumValue("AVX512_4VNNIW", "CPUID.(EAX=07H, ECX=0H):EDX.AVX512_4VNNIW[bit 2]"),
				new EnumValue("AVX512_BF16", "CPUID.(EAX=07H, ECX=1):EAX[bit 5]"),
				new EnumValue("AVX512_BITALG", "CPUID.(EAX=07H, ECX=0H):ECX.AVX512_BITALG[bit 12]"),
				new EnumValue("AVX512_IFMA", "CPUID.(EAX=07H, ECX=0H):EBX.AVX512_IFMA[bit 21]"),
				new EnumValue("AVX512_VBMI", "CPUID.(EAX=07H, ECX=0H):ECX.AVX512_VBMI[bit 1]"),
				new EnumValue("AVX512_VBMI2", "CPUID.(EAX=07H, ECX=0H):ECX.AVX512_VBMI2[bit 6]"),
				new EnumValue("AVX512_VNNI", "CPUID.(EAX=07H, ECX=0H):ECX.AVX512_VNNI[bit 11]"),
				new EnumValue("AVX512_VP2INTERSECT", "CPUID.(EAX=07H, ECX=0):EDX[bit 08]"),
				new EnumValue("AVX512_VPOPCNTDQ", "CPUID.(EAX=07H, ECX=0H):ECX.AVX512_VPOPCNTDQ[bit 14]"),
				new EnumValue("AVX512BW", "CPUID.(EAX=07H, ECX=0H):EBX.AVX512BW[bit 30]"),
				new EnumValue("AVX512CD", "CPUID.(EAX=07H, ECX=0H):EBX.AVX512CD[bit 28]"),
				new EnumValue("AVX512DQ", "CPUID.(EAX=07H, ECX=0H):EBX.AVX512DQ[bit 17]"),
				new EnumValue("AVX512ER", "CPUID.(EAX=07H, ECX=0H):EBX.AVX512ER[bit 27]"),
				new EnumValue("AVX512F", "CPUID.(EAX=07H, ECX=0H):EBX.AVX512F[bit 16]"),
				new EnumValue("AVX512PF", "CPUID.(EAX=07H, ECX=0H):EBX.AVX512PF[bit 26]"),
				new EnumValue("AVX512VL", "CPUID.(EAX=07H, ECX=0H):EBX.AVX512VL[bit 31]"),
				new EnumValue("BMI1", "CPUID.(EAX=07H, ECX=0H):EBX.BMI1[bit 3]"),
				new EnumValue("BMI2", "CPUID.(EAX=07H, ECX=0H):EBX.BMI2[bit 8]"),
				new EnumValue("CET_IBT", "CPUID.(EAX=07H, ECX=0H):EDX.CET_IBT[bit 20]"),
				new EnumValue("CET_SS", "CPUID.(EAX=07H, ECX=0H):ECX.CET_SS[bit 7]"),
				new EnumValue("CL1INVMB", "CL1INVMB instruction (Intel SCC = Single-Chip Computer)"),
				new EnumValue("CLDEMOTE", "CPUID.(EAX=07H, ECX=0H):ECX.CLDEMOTE[bit 25]"),
				new EnumValue("CLFLUSHOPT", "CPUID.(EAX=07H, ECX=0H):EBX.CLFLUSHOPT[bit 23]"),
				new EnumValue("CLFSH", "CPUID.01H:EDX.CLFSH[bit 19]"),
				new EnumValue("CLWB", "CPUID.(EAX=07H, ECX=0H):EBX.CLWB[bit 24]"),
				new EnumValue("CLZERO", "CPUID.80000008H:EBX.CLZERO[bit 0]"),
				new EnumValue("CMOV", "CPUID.01H:EDX.CMOV[bit 15]"),
				new EnumValue("CMPXCHG16B", "CPUID.01H:ECX.CMPXCHG16B[bit 13]"),
				new EnumValue("CPUID", "RFLAGS.ID can be toggled"),
				new EnumValue("CX8", "CPUID.01H:EDX.CX8[bit 8]"),
				new EnumValue("D3NOW", "CPUID.80000001H:EDX.3DNOW[bit 31]"),
				new EnumValue("D3NOWEXT", "CPUID.80000001H:EDX.3DNOWEXT[bit 30]"),
				new EnumValue("ENCLV", "CPUID.(EAX=12H, ECX=0H):EAX.OSS[bit 5]"),
				new EnumValue("ENQCMD", "CPUID.(EAX=07H, ECX=0):ECX[bit 29]"),
				new EnumValue("F16C", "CPUID.01H:ECX.F16C[bit 29]"),
				new EnumValue("FMA", "CPUID.01H:ECX.FMA[bit 12]"),
				new EnumValue("FMA4", "CPUID.80000001H:ECX.FMA4[bit 16]"),
				new EnumValue("FPU", "8087 or later (CPUID.01H:EDX.FPU[bit 0])"),
				new EnumValue("FPU287", "80287 or later"),
				new EnumValue("FPU287XL_ONLY", "80287XL only"),
				new EnumValue("FPU387", "80387 or later"),
				new EnumValue("FPU387SL_ONLY", "80387SL only"),
				new EnumValue("FSGSBASE", "CPUID.(EAX=07H, ECX=0H):EBX.FSGSBASE[bit 0]"),
				new EnumValue("FXSR", "CPUID.01H:EDX.FXSR[bit 24]"),
				new EnumValue("GEODE", "AMD Geode LX/GX CPU"),
				new EnumValue("GFNI", "CPUID.(EAX=07H, ECX=0H):ECX.GFNI[bit 8]"),
				new EnumValue("HLE", "CPUID.(EAX=07H, ECX=0H):EBX.HLE[bit 4]"),
				new EnumValue("HLE_or_RTM", "#(e:HLE)# or #(e:RTM)#"),
				new EnumValue("INVEPT", "#(e:VMX)# and IA32_VMX_EPT_VPID_CAP[bit 20]"),
				new EnumValue("INVPCID", "CPUID.(EAX=07H, ECX=0H):EBX.INVPCID[bit 10]"),
				new EnumValue("INVVPID", "#(e:VMX)# and IA32_VMX_EPT_VPID_CAP[bit 32]"),
				new EnumValue("LWP", "CPUID.80000001H:ECX.LWP[bit 15]"),
				new EnumValue("LZCNT", "CPUID.80000001H:ECX.LZCNT[bit 5]"),
				new EnumValue("MCOMMIT", "CPUID.80000008H:EBX.MCOMMIT[bit 8]"),
				new EnumValue("MMX", "CPUID.01H:EDX.MMX[bit 23]"),
				new EnumValue("MONITOR", "CPUID.01H:ECX.MONITOR[bit 3]"),
				new EnumValue("MONITORX", "CPUID.80000001H:ECX.MONITORX[bit 29]"),
				new EnumValue("MOVBE", "CPUID.01H:ECX.MOVBE[bit 22]"),
				new EnumValue("MOVDIR64B", "CPUID.(EAX=07H, ECX=0H):ECX.MOVDIR64B[bit 28]"),
				new EnumValue("MOVDIRI", "CPUID.(EAX=07H, ECX=0H):ECX.MOVDIRI[bit 27]"),
				new EnumValue("MPX", "CPUID.(EAX=07H, ECX=0H):EBX.MPX[bit 14]"),
				new EnumValue("MSR", "CPUID.01H:EDX.MSR[bit 5]"),
				new EnumValue("MULTIBYTENOP", "Multi-byte nops (0F1F /0): CPUID.01H.EAX[Bits 11:8] = 0110B or 1111B"),
				new EnumValue("PADLOCK_ACE", "CPUID.0C0000000H:EAX >= 0C0000001H AND CPUID.0C0000001H:EDX.ACE[Bits 7:6] = 11B ([6] = exists, [7] = enabled)"),
				new EnumValue("PADLOCK_PHE", "CPUID.0C0000000H:EAX >= 0C0000001H AND CPUID.0C0000001H:EDX.PHE[Bits 11:10] = 11B ([10] = exists, [11] = enabled)"),
				new EnumValue("PADLOCK_PMM", "CPUID.0C0000000H:EAX >= 0C0000001H AND CPUID.0C0000001H:EDX.PMM[Bits 13:12] = 11B ([12] = exists, [13] = enabled)"),
				new EnumValue("PADLOCK_RNG", "CPUID.0C0000000H:EAX >= 0C0000001H AND CPUID.0C0000001H:EDX.RNG[Bits 3:2] = 11B ([2] = exists, [3] = enabled)"),
				new EnumValue("PAUSE", "PAUSE instruction (Pentium 4 or later)"),
				new EnumValue("PCLMULQDQ", "CPUID.01H:ECX.PCLMULQDQ[bit 1]"),
				new EnumValue("PCOMMIT", "CPUID.(EAX=07H, ECX=0H):EBX.PCOMMIT[bit 22]"),
				new EnumValue("PCONFIG", "CPUID.(EAX=07H, ECX=0H):EDX.PCONFIG[bit 18]"),
				new EnumValue("PKU", "CPUID.(EAX=07H, ECX=0H):ECX.PKU[bit 3]"),
				new EnumValue("POPCNT", "CPUID.01H:ECX.POPCNT[bit 23]"),
				new EnumValue("PREFETCHW", "CPUID.80000001H:ECX.PREFETCHW[bit 8]"),
				new EnumValue("PREFETCHWT1", "CPUID.(EAX=07H, ECX=0H):ECX.PREFETCHWT1[bit 0]"),
				new EnumValue("PTWRITE", "CPUID.(EAX=14H, ECX=0H):EBX.PTWRITE[bit 4]"),
				new EnumValue("RDPID", "CPUID.(EAX=07H, ECX=0H):ECX.RDPID[bit 22]"),
				new EnumValue("RDPMC", "RDPMC instruction (Pentium MMX or later, or Pentium Pro or later)"),
				new EnumValue("RDPRU", "CPUID.80000008H:EBX.RDPRU[bit 4]"),
				new EnumValue("RDRAND", "CPUID.01H:ECX.RDRAND[bit 30]"),
				new EnumValue("RDSEED", "CPUID.(EAX=07H, ECX=0H):EBX.RDSEED[bit 18]"),
				new EnumValue("RDTSCP", "CPUID.80000001H:EDX.RDTSCP[bit 27]"),
				new EnumValue("RTM", "CPUID.(EAX=07H, ECX=0H):EBX.RTM[bit 11]"),
				new EnumValue("SEP", "CPUID.01H:EDX.SEP[bit 11]"),
				new EnumValue("SGX1", "CPUID.(EAX=12H, ECX=0H):EAX.SGX1[bit 0]"),
				new EnumValue("SHA", "CPUID.(EAX=07H, ECX=0H):EBX.SHA[bit 29]"),
				new EnumValue("SKINIT", "CPUID.80000001H:ECX.SKINIT[bit 12]"),
				new EnumValue("SKINIT_or_SVML", "#(e:SKINIT)# or #(e:SVML)#"),
				new EnumValue("SMAP", "CPUID.(EAX=07H, ECX=0H):EBX.SMAP[bit 20]"),
				new EnumValue("SMX", "CPUID.01H:ECX.SMX[bit 6]"),
				new EnumValue("SSE", "CPUID.01H:EDX.SSE[bit 25]"),
				new EnumValue("SSE2", "CPUID.01H:EDX.SSE2[bit 26]"),
				new EnumValue("SSE3", "CPUID.01H:ECX.SSE3[bit 0]"),
				new EnumValue("SSE4_1", "CPUID.01H:ECX.SSE4_1[bit 19]"),
				new EnumValue("SSE4_2", "CPUID.01H:ECX.SSE4_2[bit 20]"),
				new EnumValue("SSE4A", "CPUID.80000001H:ECX.SSE4A[bit 6]"),
				new EnumValue("SSSE3", "CPUID.01H:ECX.SSSE3[bit 9]"),
				new EnumValue("SVM", "CPUID.80000001H:ECX.SVM[bit 2]"),
				new EnumValue("SVML", "CPUID.8000000AH:EDX.SVML[bit 2]"),
				new EnumValue("SYSCALL", "CPUID.80000001H:EDX.SYSCALL[bit 11]"),
				new EnumValue("TBM", "CPUID.80000001H:ECX.TBM[bit 21]"),
				new EnumValue("TSC", "CPUID.01H:EDX.TSC[bit 4]"),
				new EnumValue("VAES", "CPUID.(EAX=07H, ECX=0H):ECX.VAES[bit 9]"),
				new EnumValue("VMX", "CPUID.01H:ECX.VMX[bit 5]"),
				new EnumValue("VPCLMULQDQ", "CPUID.(EAX=07H, ECX=0H):ECX.VPCLMULQDQ[bit 10]"),
				new EnumValue("WAITPKG", "CPUID.(EAX=07H, ECX=0H):ECX.WAITPKG[bit 5]"),
				new EnumValue("WBNOINVD", "CPUID.(EAX=80000008H, ECX=0H):EBX.WBNOINVD[bit 9]"),
				new EnumValue("XOP", "CPUID.80000001H:ECX.XOP[bit 11]"),
				new EnumValue("XSAVE", "CPUID.01H:ECX.XSAVE[bit 26]"),
				new EnumValue("XSAVEC", "CPUID.(EAX=0DH, ECX=1H):EAX.XSAVEC[bit 1]"),
				new EnumValue("XSAVEOPT", "CPUID.(EAX=0DH, ECX=1H):EAX.XSAVEOPT[bit 0]"),
				new EnumValue("XSAVES", "CPUID.(EAX=0DH, ECX=1H):EAX.XSAVES[bit 3]"),
			};

		public static readonly EnumType Instance = new EnumType(TypeIds.CpuidFeature, documentation, GetValues(), EnumTypeFlags.Public);
	}
}
