//
// Copyright (c) 2008, Brian Frank and Andy Frank
// Licensed under the Academic Free License version 3.0
//
// History:
//    7 Nov 08  Brian Frank  Creation
//

**
** WriteTest
**
class WriteTest : Test
{

  Void testWrites()
  {
    x := XElem("x")
    verifyWrite(x, "<x/>")

    x.addAttr("a", "aval")
    verifyWrite(x, "<x a='aval'/>")

    x.addAttr("b", "bval")
    verifyWrite(x, "<x a='aval' b='bval'/>")

    withText := XElem("withText").add(XText("some text"))
    verifyWrite(withText, "<withText>some text</withText>")

    x.add(withText)
    verifyWrite(x,
      "<x a='aval' b='bval'>
        <withText>some text</withText>
       </x>")

    a := XElem("a").add(XPi("pi", "name='val'"))
    b := XElem("b").addAttr("foo", "bar")
    x.add(a).add(b)
    verifyWrite(x,
      "<x a='aval' b='bval'>
        <withText>some text</withText>
        <a>
         <?pi name='val'?>
        </a>
        <b foo='bar'/>
       </x>")

    c := XElem("c").add(XText("text of c!"))
    x.add(c)
    verifyWrite(x,
      "<x a='aval' b='bval'>
        <withText>some text</withText>
        <a>
         <?pi name='val'?>
        </a>
        <b foo='bar'/>
        <c>text of c!</c>
       </x>")

    mixed := XElem("mixed")
    {
      XText("the ")
      XElem("b") { XText("real") }
      XText(" deal")
    }
    verifyWrite(mixed, "<mixed>the <b>real</b> deal</mixed>")

    x.add(mixed)
    verifyWrite(x,
      "<x a='aval' b='bval'>
        <withText>some text</withText>
        <a>
         <?pi name='val'?>
        </a>
        <b foo='bar'/>
        <c>text of c!</c>
        <mixed>the <b>real</b> deal</mixed>
       </x>")

    seq := XElem("seq").add(XText("a")).add(XText("b")).add(XText("c"))
    verifyWrite(seq, "<seq>abc</seq>")

    multi := XElem("multi").add(XText("line1\nline2"))
    verifyWrite(multi, "<multi>line1\nline2</multi>")
  }

  Void testEsc()
  {
    x := XElem("x").addAttr("foo", "<AT&T>")
    verifyWrite(x, "<x foo='&lt;AT&amp;T>'/>")

    x = XElem("x").addAttr("foo", "quot=\" \n apos='")
    verifyWrite(x, "<x foo='quot=&quot; &#x0a; apos=&apos;'/>")

    x = XElem("x").add(XText("'hi' & <there>\n \"line2\""))
    verifyWrite(x, "<x>'hi' &amp; &lt;there>\n \"line2\"</x>")
  }

  Void testCdata()
  {
    x := XElem("x").add(XText("'hi' & <there>\n \"line2\"") { cdata=true })
    verifyWrite(x, "<x><![CDATA['hi' & <there>\n \"line2\"]]></x>")

    x = XElem("x").add(XText("]]>") { cdata=true })
    verifyErr(IOErr#) |,| { verifyWrite(x, "?") }
  }

  Void testNs()
  {
    nsdef := XNs("", `http://foo/def`)
    nsq   := XNs("q", `http://foo/q`)
    x := XElem("root", nsdef)
    {
      XAttr.makeNs(nsdef)
      XAttr.makeNs(nsq)
      XElem("a", nsdef)
      XElem("b", nsq)
      {
        XAttr("x", "xv")
        XAttr("y", "yv", nsq)
      }
    }
    verifyWrite(x,
      "<root xmlns='http://foo/def' xmlns:q='http://foo/q'>
        <a/>
        <q:b x='xv' q:y='yv'/>
       </root>")
  }

  Void verifyWrite(XElem xml, Str expected)
  {
    buf := Buf()
    xml.write(buf.out)
    actual := buf.flip.readAllStr
    verifyEq(actual, expected)
  }
}