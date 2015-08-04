
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.0.30319.33440
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern FSharp.Core
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 4:3:1:0
}
.assembly ILDemo
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.FSharpInterfaceDataVersionAttribute::.ctor(int32,
                                                                                                      int32,
                                                                                                      int32) = ( 01 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 1A 2E 4E 45 54 46 72 61 6D 65 77 6F 72 6B   // ....NETFramework
                                                                                                        2C 56 65 72 73 69 6F 6E 3D 76 34 2E 35 01 00 54   // ,Version=v4.5..T
                                                                                                        0E 14 46 72 61 6D 65 77 6F 72 6B 44 69 73 70 6C   // ..FrameworkDispl
                                                                                                        61 79 4E 61 6D 65 12 2E 4E 45 54 20 46 72 61 6D   // ayName..NET Fram
                                                                                                        65 77 6F 72 6B 20 34 2E 35 )                      // ework 4.5

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 01 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.mresource public FSharpSignatureData.ILDemo
{
  // Offset: 0x00000000 Length: 0x000003A3
  // WARNING: managed resource file FSharpSignatureData.ILDemo created
}
.mresource public FSharpOptimizationData.ILDemo
{
  // Offset: 0x000003A8 Length: 0x0000011D
  // WARNING: managed resource file FSharpOptimizationData.ILDemo created
}
.module ILDemo.dll
// MVID: {54E5EF04-6CAE-1C30-A745-038304EFE554}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00510000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi serializable ILDemo.Class1
       extends [mscorlib]System.Object
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 03 00 00 00 00 00 ) 
  .method public specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       10 (0xa)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  pop
    IL_0008:  nop
    IL_0009:  ret
  } // end of method Class1::.ctor

  .method public hidebysig specialname instance string 
          get_X() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldstr      "Hello World"
    IL_0006:  ret
  } // end of method Class1::get_X

  .property instance string X()
  {
    .get instance string ILDemo.Class1::get_X()
  } // end of property Class1::X
} // end of class ILDemo.Class1

.class private abstract auto ansi sealed '<StartupCode$ILDemo>'.$Library1
       extends [mscorlib]System.Object
{
} // end of class '<StartupCode$ILDemo>'.$Library1

.class private abstract auto ansi sealed '<StartupCode$ILDemo>.$.NETFramework,Version=v4.5'.AssemblyAttributes
       extends [mscorlib]System.Object
{
} // end of class '<StartupCode$ILDemo>.$.NETFramework,Version=v4.5'.AssemblyAttributes


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
