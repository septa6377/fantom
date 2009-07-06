//
// Copyright (c) 2009, Brian Frank and Andy Frank
// Licensed under the Academic Free License version 3.0
//
// History:
//   26 May 09  Andy Frank  Creation
//

var fwt_SashPanePeer = sys_Obj.$extend(fwt_PanePeer);

fwt_SashPanePeer.prototype.$ctor = function(self)
{
  fwt_PanePeer.prototype.$ctor.call(this, self);
}

fwt_SashPanePeer.prototype.weights$get = function(self) { return this.weights; }
fwt_SashPanePeer.prototype.weights$set = function(self, val) { this.weights = val; }
fwt_SashPanePeer.prototype.weights = null;

fwt_SashPanePeer.prototype.sync = function(self)
{
  if (this.weights != null && this.weights.length != self.kids.length)
    throw new sys_ArgErr.make("weights.size != kids.length");

  if (self.orientation == fwt_Orientation.horizontal)
    this.doHoriz(self);
  else
    this.doVert(self);
  fwt_WidgetPeer.prototype.sync.call(this, self);
}

fwt_SashPanePeer.prototype.doHoriz = function(self)
{
  var w = this.size.w;
  var h = this.size.h;
  var wt = this.weights;

  var dy = 0;
  var dh = Math.floor(h /self.kids.length);

  for (var i=0; i<self.kids.length; i++)
  {
    var cw = w;
    var ch = wt==null ? dh : Math.floor(h * (wt[i].valueOf() / 100));

    // if last widget, force to fill remaining space
    if (i == self.kids.length-1) ch = h-dy;

    self.kids[i].pos$set(gfx_Point.make(0, dy));
    self.kids[i].size$set(gfx_Size.make(cw, ch));

    dy += ch;
  }
}

fwt_SashPanePeer.prototype.doVert = function(self)
{
  var w = this.size.w;
  var h = this.size.h;
  var wt = this.weights

  var dx = 0;
  var dw = Math.floor(w / self.kids.length);

  for (var i=0; i<self.kids.length; i++)
  {
    var cw = wt==null ? dw : Math.floor(w * (wt[i].valueOf() / 100));
    var ch = h;

    // if last widget, force to fill remaining space
    if (i == self.kids.length-1) cw = w-dx;

    self.kids[i].pos$set(gfx_Point.make(dx, 0));
    self.kids[i].size$set(gfx_Size.make(cw, ch));

    dx += cw;
  }
}