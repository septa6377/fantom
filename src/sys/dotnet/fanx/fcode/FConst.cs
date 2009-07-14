//
// Copyright (c) 2006, Brian Frank and Andy Frank
// Licensed under the Academic Free License version 3.0
//
// History:
//   14 Jul 09  Auto-generated by /adm/genfcode.rb
//
namespace Fanx.Fcode
{

/**
 * FConst provides all the fcode constants
 */
public class FConst
{

//////////////////////////////////////////////////////////////////////////
// Stuff
//////////////////////////////////////////////////////////////////////////

  public const int FCodeMagic    = 0x0FC0DE05;
  public const int FCodeVersion  = 0x01000045;
  public const int TypeDbMagic   = 0x0FC0DEDB;
  public const int TypeDbVersion = 0x01000018;

//////////////////////////////////////////////////////////////////////////
// Flags
//////////////////////////////////////////////////////////////////////////

  public const int Abstract   = 0x00000001;
  public const int Const      = 0x00000002;
  public const int Ctor       = 0x00000004;
  public const int Enum       = 0x00000008;
  public const int Final      = 0x00000010;
  public const int Getter     = 0x00000020;
  public const int Internal   = 0x00000040;
  public const int Mixin      = 0x00000080;
  public const int Native     = 0x00000100;
  public const int Override   = 0x00000200;
  public const int Private    = 0x00000400;
  public const int Protected  = 0x00000800;
  public const int Public     = 0x00001000;
  public const int Setter     = 0x00002000;
  public const int Static     = 0x00004000;
  public const int Storage    = 0x00008000;
  public const int Synthetic  = 0x00010000;
  public const int Virtual    = 0x00020000;
  public const int FlagsMask  = 0x0003ffff;

//////////////////////////////////////////////////////////////////////////
// MethodVarFlags
//////////////////////////////////////////////////////////////////////////

  public const int Param = 0x0001;  // parameter or local variable

//////////////////////////////////////////////////////////////////////////
// Attributes
//////////////////////////////////////////////////////////////////////////

  public const string ErrTableAttr     = "ErrTable";
  public const string FacetsAttr       = "Facets";
  public const string LineNumberAttr   = "LineNumber";
  public const string LineNumbersAttr  = "LineNumbers";
  public const string SourceFileAttr   = "SourceFile";
  public const string ParamDefaultAttr = "ParamDefault";

//////////////////////////////////////////////////////////////////////////
// OpCodes
//////////////////////////////////////////////////////////////////////////

  public const int Nop              =   0; // ()        no operation
  public const int LoadNull         =   1; // ()        load null literal onto stack
  public const int LoadFalse        =   2; // ()        load false literal onto stack
  public const int LoadTrue         =   3; // ()        load true literal onto stack
  public const int LoadInt          =   4; // (int)     load Int const by index onto stack
  public const int LoadFloat        =   5; // (float)   load Float const by index onto stack
  public const int LoadDecimal      =   6; // (decimal)  load Decimal const by index onto stack
  public const int LoadStr          =   7; // (str)     load Str const by index onto stack
  public const int LoadDuration     =   8; // (dur)     load Duration const by index onto stack
  public const int LoadType         =   9; // (type)    load Type instance by index onto stack
  public const int LoadUri          =  10; // (uri)     load Uri const by index onto stack
  public const int LoadVar          =  11; // (reg)     local var register index (0 is this)
  public const int StoreVar         =  12; // (reg)     local var register index (0 is this)
  public const int LoadInstance     =  13; // (field)   load field from storage
  public const int StoreInstance    =  14; // (field)   store field to storage
  public const int LoadStatic       =  15; // (field)   load static field from storage
  public const int StoreStatic      =  16; // (field)   store static field to storage
  public const int LoadMixinStatic  =  17; // (field)   load static on mixin field from storage
  public const int StoreMixinStatic =  18; // (field)   store static on mixin field to storage
  public const int CallNew          =  19; // (method)  alloc new object and call constructor
  public const int CallCtor         =  20; // (method)  call constructor (used for constructor chaining)
  public const int CallStatic       =  21; // (method)  call static method
  public const int CallVirtual      =  22; // (method)  call virtual instance method
  public const int CallNonVirtual   =  23; // (method)  call instance method non-virtually (private or super only b/c of Java invokespecial)
  public const int CallMixinStatic  =  24; // (method)  call static mixin method
  public const int CallMixinVirtual =  25; // (method)  call virtual mixin method
  public const int CallMixinNonVirtual =  26; // (method)  call instance mixin method non-virtually (named super)
  public const int Jump             =  27; // (jmp)     unconditional jump
  public const int JumpTrue         =  28; // (jmp)     jump if bool true
  public const int JumpFalse        =  29; // (jmp)     jump if bool false
  public const int CompareEQ        =  30; // (typePair)  a.equals(b)
  public const int CompareNE        =  31; // (typePair)  !a.equals(b)
  public const int Compare          =  32; // (typePair)  a.compare(b)
  public const int CompareLE        =  33; // (typePair)  a.compare(b) <= 0
  public const int CompareLT        =  34; // (typePair)  a.compare(b) < 0
  public const int CompareGT        =  35; // (typePair)  a.compare(b) > 0
  public const int CompareGE        =  36; // (typePair)  a.compare(b) >= 0
  public const int CompareSame      =  37; // ()        a === b
  public const int CompareNotSame   =  38; // ()        a !== b
  public const int CompareNull      =  39; // (type)    a == null
  public const int CompareNotNull   =  40; // (type)    a != null
  public const int Return           =  41; // ()        return from method
  public const int Pop              =  42; // (type)    pop top object off stack
  public const int Dup              =  43; // (type)    duplicate object ref on top of stack
  public const int Is               =  44; // (type)    is operator
  public const int As               =  45; // (type)    as operator
  public const int Coerce           =  46; // (typePair)  from->to coercion value/reference/nullable
  public const int Switch           =  47; // ()        switch jump table 2 count + 2*count
  public const int Throw            =  48; // ()        throw Err on top of stack
  public const int Leave            =  49; // (jmp)     jump out of a try or catch block
  public const int JumpFinally      =  50; // (jmp)     jump to a finally block
  public const int CatchAllStart    =  51; // ()        start catch all block - do not leave Err on stack
  public const int CatchErrStart    =  52; // (type)    start catch block - leave typed Err on stack
  public const int CatchEnd         =  53; // ()        start catch block - leave typed Err on stack
  public const int FinallyStart     =  54; // ()        starting instruction of a finally block
  public const int FinallyEnd       =  55; // ()        ending instruction of a finally block
  public const int LoadSymbol       =  56; // (symbol)  load Symbol const by index onto stack

  public static readonly string[] OpNames =
  {
    "Nop",                //   0 
    "LoadNull",           //   1 
    "LoadFalse",          //   2 
    "LoadTrue",           //   3 
    "LoadInt",            //   4 
    "LoadFloat",          //   5 
    "LoadDecimal",        //   6 
    "LoadStr",            //   7 
    "LoadDuration",       //   8 
    "LoadType",           //   9 
    "LoadUri",            //  10 
    "LoadVar",            //  11 
    "StoreVar",           //  12 
    "LoadInstance",       //  13 
    "StoreInstance",      //  14 
    "LoadStatic",         //  15 
    "StoreStatic",        //  16 
    "LoadMixinStatic",    //  17 
    "StoreMixinStatic",   //  18 
    "CallNew",            //  19 
    "CallCtor",           //  20 
    "CallStatic",         //  21 
    "CallVirtual",        //  22 
    "CallNonVirtual",     //  23 
    "CallMixinStatic",    //  24 
    "CallMixinVirtual",   //  25 
    "CallMixinNonVirtual",  //  26 
    "Jump",               //  27 
    "JumpTrue",           //  28 
    "JumpFalse",          //  29 
    "CompareEQ",          //  30 
    "CompareNE",          //  31 
    "Compare",            //  32 
    "CompareLE",          //  33 
    "CompareLT",          //  34 
    "CompareGT",          //  35 
    "CompareGE",          //  36 
    "CompareSame",        //  37 
    "CompareNotSame",     //  38 
    "CompareNull",        //  39 
    "CompareNotNull",     //  40 
    "Return",             //  41 
    "Pop",                //  42 
    "Dup",                //  43 
    "Is",                 //  44 
    "As",                 //  45 
    "Coerce",             //  46 
    "Switch",             //  47 
    "Throw",              //  48 
    "Leave",              //  49 
    "JumpFinally",        //  50 
    "CatchAllStart",      //  51 
    "CatchErrStart",      //  52 
    "CatchEnd",           //  53 
    "FinallyStart",       //  54 
    "FinallyEnd",         //  55 
    "LoadSymbol",         //  56 
  };

  public static readonly int[] OpSkips =
  {
    0,  //   0 Nop 
    0,  //   1 LoadNull 
    0,  //   2 LoadFalse 
    0,  //   3 LoadTrue 
    2,  //   4 LoadInt 
    2,  //   5 LoadFloat 
    2,  //   6 LoadDecimal 
    2,  //   7 LoadStr 
    2,  //   8 LoadDuration 
    2,  //   9 LoadType 
    2,  //  10 LoadUri 
    2,  //  11 LoadVar 
    2,  //  12 StoreVar 
    2,  //  13 LoadInstance 
    2,  //  14 StoreInstance 
    2,  //  15 LoadStatic 
    2,  //  16 StoreStatic 
    2,  //  17 LoadMixinStatic 
    2,  //  18 StoreMixinStatic 
    2,  //  19 CallNew 
    2,  //  20 CallCtor 
    2,  //  21 CallStatic 
    2,  //  22 CallVirtual 
    2,  //  23 CallNonVirtual 
    2,  //  24 CallMixinStatic 
    2,  //  25 CallMixinVirtual 
    2,  //  26 CallMixinNonVirtual 
    2,  //  27 Jump 
    2,  //  28 JumpTrue 
    2,  //  29 JumpFalse 
    0,  //  30 CompareEQ 
    0,  //  31 CompareNE 
    0,  //  32 Compare 
    0,  //  33 CompareLE 
    0,  //  34 CompareLT 
    0,  //  35 CompareGT 
    0,  //  36 CompareGE 
    0,  //  37 CompareSame 
    0,  //  38 CompareNotSame 
    0,  //  39 CompareNull 
    0,  //  40 CompareNotNull 
    0,  //  41 Return 
    0,  //  42 Pop 
    0,  //  43 Dup 
    2,  //  44 Is 
    2,  //  45 As 
    4,  //  46 Coerce 
    0,  //  47 Switch 
    0,  //  48 Throw 
    2,  //  49 Leave 
    2,  //  50 JumpFinally 
    0,  //  51 CatchAllStart 
    2,  //  52 CatchErrStart 
    0,  //  53 CatchEnd 
    0,  //  54 FinallyStart 
    0,  //  55 FinallyEnd 
    2,  //  56 LoadSymbol 
  };

  public static readonly string[] OpSigs =
  {
    "()",         //   0 Nop
    "()",         //   1 LoadNull
    "()",         //   2 LoadFalse
    "()",         //   3 LoadTrue
    "(int)",      //   4 LoadInt
    "(float)",    //   5 LoadFloat
    "(decimal)",  //   6 LoadDecimal
    "(str)",      //   7 LoadStr
    "(dur)",      //   8 LoadDuration
    "(type)",     //   9 LoadType
    "(uri)",      //  10 LoadUri
    "(reg)",      //  11 LoadVar
    "(reg)",      //  12 StoreVar
    "(field)",    //  13 LoadInstance
    "(field)",    //  14 StoreInstance
    "(field)",    //  15 LoadStatic
    "(field)",    //  16 StoreStatic
    "(field)",    //  17 LoadMixinStatic
    "(field)",    //  18 StoreMixinStatic
    "(method)",   //  19 CallNew
    "(method)",   //  20 CallCtor
    "(method)",   //  21 CallStatic
    "(method)",   //  22 CallVirtual
    "(method)",   //  23 CallNonVirtual
    "(method)",   //  24 CallMixinStatic
    "(method)",   //  25 CallMixinVirtual
    "(method)",   //  26 CallMixinNonVirtual
    "(jmp)",      //  27 Jump
    "(jmp)",      //  28 JumpTrue
    "(jmp)",      //  29 JumpFalse
    "(typePair)",  //  30 CompareEQ
    "(typePair)",  //  31 CompareNE
    "(typePair)",  //  32 Compare
    "(typePair)",  //  33 CompareLE
    "(typePair)",  //  34 CompareLT
    "(typePair)",  //  35 CompareGT
    "(typePair)",  //  36 CompareGE
    "()",         //  37 CompareSame
    "()",         //  38 CompareNotSame
    "(type)",     //  39 CompareNull
    "(type)",     //  40 CompareNotNull
    "()",         //  41 Return
    "(type)",     //  42 Pop
    "(type)",     //  43 Dup
    "(type)",     //  44 Is
    "(type)",     //  45 As
    "(typePair)",  //  46 Coerce
    "()",         //  47 Switch
    "()",         //  48 Throw
    "(jmp)",      //  49 Leave
    "(jmp)",      //  50 JumpFinally
    "()",         //  51 CatchAllStart
    "(type)",     //  52 CatchErrStart
    "()",         //  53 CatchEnd
    "()",         //  54 FinallyStart
    "()",         //  55 FinallyEnd
    "(symbol)",   //  56 LoadSymbol
  };

} // FConst


} // Fanx.Fcode
