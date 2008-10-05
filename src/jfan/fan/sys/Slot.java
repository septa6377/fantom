//
// Copyright (c) 2006, Brian Frank and Andy Frank
// Licensed under the Academic Free License version 3.0
//
// History:
//   4 Jan 06  Brian Frank  Creation
//
package fan.sys;

import fanx.fcode.*;

/**
 * Slot models a member field or method of a Type.
 */
public abstract class Slot
  extends FanObj
{

//////////////////////////////////////////////////////////////////////////
// Management
//////////////////////////////////////////////////////////////////////////

  public static Method findMethod(Str qname) { return (Method)find(qname.val, true); }
  public static Method findMethod(Str qname, Boolean checked) { return (Method)find(qname.val, checked.booleanValue()); }
  public static Method findMethod(String qname, boolean checked) { return (Method)find(qname, checked); }

  public static Field findField(Str qname) { return (Field)find(qname.val, true); }
  public static Field findField(Str qname, Boolean checked) { return (Field)find(qname.val, checked.booleanValue()); }
  public static Field findField(String qname, boolean checked) { return (Field)find(qname, checked); }

  public static Slot find(Str qname) { return find(qname.val, true); }
  public static Slot find(Str qname, Boolean checked) { return find(qname.val, checked.booleanValue()); }
  public static Slot find(String qname, boolean checked)
  {
    String typeName, slotName;
    try
    {
      int dot = qname.indexOf('.');
      typeName = qname.substring(0, dot);
      slotName = qname.substring(dot+1);
    }
    catch (Exception e)
    {
      throw Err.make("Invalid slot qname \"" + qname + "\", use <pod>::<type>.<slot>").val;
    }
    Type type = Type.find(typeName, checked);
    if (type == null) return null;
    return type.slot(slotName, checked);
  }

  public static Func findFunc(Str qname) { return findFunc(qname.val, true); }
  public static Func findFunc(Str qname, Boolean checked) { return findFunc(qname.val, checked.booleanValue()); }
  public static Func findFunc(String qname, boolean checked)
  {
    Method m = (Method)find(qname, checked);
    if (m == null) return null;
    return m.func;
  }

//////////////////////////////////////////////////////////////////////////
// Constructor
//////////////////////////////////////////////////////////////////////////

  public Slot(Type parent, Str name, int flags, Facets facets, int lineNum)
  {
    this.parent  = parent;
    this.name    = name;
    this.qname   = parent == null ? name : Str.make(parent.qname.val + "." + name.val);
    this.flags   = flags;
    this.facets  = facets;
    this.lineNum = lineNum;
  }

  // ctor for Field and Method make()
  Slot()
  {
  }

//////////////////////////////////////////////////////////////////////////
// Methods
//////////////////////////////////////////////////////////////////////////

  public Type type() { return Sys.SlotType; }

  public Type parent()   { return parent; }
  public Str name()      { return name; }
  public Str qname()     { return qname; }
  public Boolean isField()  { return this instanceof Field; }
  public Boolean isMethod() { return this instanceof Method; }
  public abstract Str signature();

//////////////////////////////////////////////////////////////////////////
// Flags
//////////////////////////////////////////////////////////////////////////

  public final int flags() { return flags; }
  public final Boolean isAbstract()  { return (flags & FConst.Abstract) != 0; }
  public /* */ Boolean isConst()     { return (flags & FConst.Const) != 0; } // we let synethic Methods override
  public final Boolean isCtor()      { return (flags & FConst.Ctor) != 0; }
  public final Boolean isInternal()  { return (flags & FConst.Internal) != 0; }
  public final Boolean isNative()    { return (flags & FConst.Native) != 0; }
  public final Boolean isOverride()  { return (flags & FConst.Override) != 0; }
  public final Boolean isPrivate()   { return (flags & FConst.Private) != 0; }
  public final Boolean isProtected() { return (flags & FConst.Protected) != 0; }
  public final Boolean isPublic()    { return (flags & FConst.Public) != 0; }
  public final Boolean isStatic()    { return (flags & FConst.Static) != 0; }
  public final Boolean isSynthetic() { return (flags & FConst.Synthetic) != 0; }
  public final Boolean isVirtual()   { return (flags & FConst.Virtual) != 0; }

  public Object trap(Str name, List args)
  {
    // private undocumented access
    String n = name.val;
    if (n.equals("flags")) return Int.make(flags);
    if (n.equals("lineNumber")) return Int.make(lineNum);
    return super.trap(name, args);
  }

//////////////////////////////////////////////////////////////////////////
// Facets
//////////////////////////////////////////////////////////////////////////

  public Map facets() { return facets.map(); }
  public Object facet(Str name) { return facets.get(name, null); }
  public Object facet(Str name, Object def) { return facets.get(name, def); }

//////////////////////////////////////////////////////////////////////////
// Documentation
//////////////////////////////////////////////////////////////////////////

  public Str doc()
  {
    parent.doc();  // ensure parent has loaded documentation
    return doc;
  }

//////////////////////////////////////////////////////////////////////////
// Conversion
//////////////////////////////////////////////////////////////////////////

  public Str toStr() { return qname; }

//////////////////////////////////////////////////////////////////////////
// Fields
//////////////////////////////////////////////////////////////////////////

  int flags;
  Str name;
  Str qname;
  Type parent;
  Facets facets;
  public Str doc;
  int lineNum;


}