//
// Copyright (c) 2011, Brian Frank and Andy Frank
// Licensed under the Academic Free License version 3.0
//
// History:
//   11 Aug 11  Brian Frank  Creation
//

**
** DocSlot models the documentation of a `sys::Slot`.
**
abstract const class DocSlot
{
  ** Constructor
  internal new make(DocLoc loc, DocTypeRef parent, Str name, Int flags, Str doc, DocFacet[] facets)
  {
    this.loc    = loc
    this.parent = parent
    this.name   = name
    this.qname  = parent.qname + "." + name
    this.flags  = flags
    this.doc    = doc
    this.facets = facets
  }

  ** Source code location of this slot
  const DocLoc loc

  ** Type which defines the slot
  const DocTypeRef parent

  ** Simple name of the slot such as "equals".
  const Str name

  ** Qualified name formatted as "sys::Str.replace".
  const Str qname

  ** Flags mask - see `DocFlags`
  const Int flags

  ** Fandoc documentation string
  const Str doc

  ** Facets defined on this slot
  const DocFacet[] facets

  internal virtual Void dump(OutStream out)
  {
    out.printLine("$name")
    out.printLine("    parent = $parent")
    out.printLine("    name   = $name")
    out.printLine("    flags  = " + DocFlags.toNames(flags))
    out.printLine("    doc    = $doc.toCode")
    facets.each |facet| { out.printLine("    $facet") }
  }
}

**************************************************************************
** DocField
**************************************************************************

**
** DocField models the documentation of a `sys::Field`.
**
const class DocField : DocSlot
{
  ** Constructor
  internal new make(DocLoc loc, DocTypeRef parent, Str name, Int flags, Str doc, DocFacet[] facets,
                    DocTypeRef type, Str? init)
    : super(loc, parent, name, flags, doc, facets)
  {
    this.type = type
    this.init = init
  }

  ** Type of the field
  const DocTypeRef type

  ** Expression used to initialize the field
  const Str? init

  internal override Void dump(OutStream out)
  {
    super.dump(out)
    out.printLine("    type   = $type")
    out.printLine("    init   = $init")
  }
}

**************************************************************************
** DocMethod
**************************************************************************

**
** DocMethod models the documentation of a `sys::Method`.
**
const class DocMethod : DocSlot
{
  ** Constructor
  internal new make(DocLoc loc, DocTypeRef parent, Str name, Int flags, Str doc, DocFacet[] facets,
                    DocTypeRef returns, DocParam[] params)
    : super(loc, parent, name, flags, doc, facets)
  {
    this.returns = returns
    this.params  = params
  }

  ** Return type of the method
  const DocTypeRef returns

  ** Parameters of the method
  const DocParam[] params

  internal override  Void dump(OutStream out)
  {
    super.dump(out)
    out.printLine("    return = $returns")
    params.each |p, i| { out.printLine("    p[$i]  = $p") }
  }
}

**************************************************************************
** DocMethod
**************************************************************************

**
** DocParam models the documentation of a `sys::Param`
**
const class DocParam
{
  ** Constructor
  internal new make(DocTypeRef type, Str name, Str? def)
  {
    this.type = type
    this.name = name
    this.def  = def
  }

  ** Type of the parameter
  const DocTypeRef type

  ** Name of the parameter
  const Str name

  ** Default expression if defined
  const Str? def

  override Str toStr()
  {
    s := StrBuf().add(type).addChar(' ').add(name)
    if (def != null) s.add(" := ").add(def)
    return s.toStr
  }
}

