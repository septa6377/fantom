//
// Copyright (c) 2009, Brian Frank and Andy Frank
// Licensed under the Academic Free License version 3.0
//
// History:
//   30 Mar 09  Andy Frank  Creation
//

namespace Fan.Sys
{
  /// <summary>
  /// Context.
  /// </summary>
  public sealed class Context : FanObj
  {

  //////////////////////////////////////////////////////////////////////////
  // Construction
  //////////////////////////////////////////////////////////////////////////

    public Context(Actor actor)
    {
      this.m_actor = actor;
    }

  //////////////////////////////////////////////////////////////////////////
  // Obj
  //////////////////////////////////////////////////////////////////////////

    public override Type type() { return Sys.ContextType; }

  //////////////////////////////////////////////////////////////////////////
  // Context
  //////////////////////////////////////////////////////////////////////////

    public Actor actor() { return m_actor; }

    public Map map() { return m_map; }

    public object get(string name) { return m_map.get(name); }
    public object get(string name, object def) { return m_map.get(name, def); }

    public Context set(string name, object val) { m_map.set(name, val); return this; }

  //////////////////////////////////////////////////////////////////////////
  // Fields
  //////////////////////////////////////////////////////////////////////////

    internal readonly Actor m_actor;
    internal readonly Map m_map = new Map(Sys.StrType, Sys.ObjType.toNullable());
    internal readonly Map m_locals = new Map(Sys.StrType, Sys.ObjType.toNullable());
    internal Locale m_locale = Locale.current();

  }
}