/*!
 DataTables 1.10.12
 �2008-2015 SpryMedia Ltd - datatables.net/license
*/
(function (h) { "function" === typeof define && define.amd ? define(["jquery"], function (D) { return h(D, window, document) }) : "object" === typeof exports ? module.exports = function (D, I) { D || (D = window); I || (I = "undefined" !== typeof window ? require("jquery") : require("jquery")(D)); return h(I, D, D.document) } : h(jQuery, window, document) })(function (h, D, I, k) {
    function X(a) {
        var b, c, d = {}; h.each(a, function (e) {
            if ((b = e.match(/^([^A-Z]+?)([A-Z])/)) && -1 !== "a aa ai ao as b fn i m o s ".indexOf(b[1] + " ")) c = e.replace(b[0], b[2].toLowerCase()),
            d[c] = e, "o" === b[1] && X(a[e])
        }); a._hungarianMap = d
    } function K(a, b, c) { a._hungarianMap || X(a); var d; h.each(b, function (e) { d = a._hungarianMap[e]; if (d !== k && (c || b[d] === k)) "o" === d.charAt(0) ? (b[d] || (b[d] = {}), h.extend(!0, b[d], b[e]), K(a[d], b[d], c)) : b[d] = b[e] }) } function Da(a) {
        var b = m.defaults.oLanguage, c = a.sZeroRecords; !a.sEmptyTable && (c && "No data available in table" === b.sEmptyTable) && E(a, a, "sZeroRecords", "sEmptyTable"); !a.sLoadingRecords && (c && "Loading..." === b.sLoadingRecords) && E(a, a, "sZeroRecords", "sLoadingRecords");
        a.sInfoThousands && (a.sThousands = a.sInfoThousands); (a = a.sDecimal) && db(a)
    } function eb(a) {
        A(a, "ordering", "bSort"); A(a, "orderMulti", "bSortMulti"); A(a, "orderClasses", "bSortClasses"); A(a, "orderCellsTop", "bSortCellsTop"); A(a, "order", "aaSorting"); A(a, "orderFixed", "aaSortingFixed"); A(a, "paging", "bPaginate"); A(a, "pagingType", "sPaginationType"); A(a, "pageLength", "iDisplayLength"); A(a, "searching", "bFilter"); "boolean" === typeof a.sScrollX && (a.sScrollX = a.sScrollX ? "100%" : ""); "boolean" === typeof a.scrollX && (a.scrollX =
        a.scrollX ? "100%" : ""); if (a = a.aoSearchCols) for (var b = 0, c = a.length; b < c; b++) a[b] && K(m.models.oSearch, a[b])
    } function fb(a) { A(a, "orderable", "bSortable"); A(a, "orderData", "aDataSort"); A(a, "orderSequence", "asSorting"); A(a, "orderDataType", "sortDataType"); var b = a.aDataSort; b && !h.isArray(b) && (a.aDataSort = [b]) } function gb(a) {
        if (!m.__browser) {
            var b = {}; m.__browser = b; var c = h("<div/>").css({ position: "fixed", top: 0, left: 0, height: 1, width: 1, overflow: "hidden" }).append(h("<div/>").css({
                position: "absolute", top: 1, left: 1,
                width: 100, overflow: "scroll"
            }).append(h("<div/>").css({ width: "100%", height: 10 }))).appendTo("body"), d = c.children(), e = d.children(); b.barWidth = d[0].offsetWidth - d[0].clientWidth; b.bScrollOversize = 100 === e[0].offsetWidth && 100 !== d[0].clientWidth; b.bScrollbarLeft = 1 !== Math.round(e.offset().left); b.bBounding = c[0].getBoundingClientRect().width ? !0 : !1; c.remove()
        } h.extend(a.oBrowser, m.__browser); a.oScroll.iBarWidth = m.__browser.barWidth
    } function hb(a, b, c, d, e, f) {
        var g, j = !1; c !== k && (g = c, j = !0); for (; d !== e;) a.hasOwnProperty(d) &&
        (g = j ? b(g, a[d], d, a) : a[d], j = !0, d += f); return g
    } function Ea(a, b) { var c = m.defaults.column, d = a.aoColumns.length, c = h.extend({}, m.models.oColumn, c, { nTh: b ? b : I.createElement("th"), sTitle: c.sTitle ? c.sTitle : b ? b.innerHTML : "", aDataSort: c.aDataSort ? c.aDataSort : [d], mData: c.mData ? c.mData : d, idx: d }); a.aoColumns.push(c); c = a.aoPreSearchCols; c[d] = h.extend({}, m.models.oSearch, c[d]); ja(a, d, h(b).data()) } function ja(a, b, c) {
        var b = a.aoColumns[b], d = a.oClasses, e = h(b.nTh); if (!b.sWidthOrig) {
            b.sWidthOrig = e.attr("width") || null; var f =
            (e.attr("style") || "").match(/width:\s*(\d+[pxem%]+)/); f && (b.sWidthOrig = f[1])
        } c !== k && null !== c && (fb(c), K(m.defaults.column, c), c.mDataProp !== k && !c.mData && (c.mData = c.mDataProp), c.sType && (b._sManualType = c.sType), c.className && !c.sClass && (c.sClass = c.className), h.extend(b, c), E(b, c, "sWidth", "sWidthOrig"), c.iDataSort !== k && (b.aDataSort = [c.iDataSort]), E(b, c, "aDataSort")); var g = b.mData, j = Q(g), i = b.mRender ? Q(b.mRender) : null, c = function (a) { return "string" === typeof a && -1 !== a.indexOf("@") }; b._bAttrSrc = h.isPlainObject(g) &&
        (c(g.sort) || c(g.type) || c(g.filter)); b._setter = null; b.fnGetData = function (a, b, c) { var d = j(a, b, k, c); return i && b ? i(d, b, a, c) : d }; b.fnSetData = function (a, b, c) { return R(g)(a, b, c) }; "number" !== typeof g && (a._rowReadObject = !0); a.oFeatures.bSort || (b.bSortable = !1, e.addClass(d.sSortableNone)); a = -1 !== h.inArray("asc", b.asSorting); c = -1 !== h.inArray("desc", b.asSorting); !b.bSortable || !a && !c ? (b.sSortingClass = d.sSortableNone, b.sSortingClassJUI = "") : a && !c ? (b.sSortingClass = d.sSortableAsc, b.sSortingClassJUI = d.sSortJUIAscAllowed) :
        !a && c ? (b.sSortingClass = d.sSortableDesc, b.sSortingClassJUI = d.sSortJUIDescAllowed) : (b.sSortingClass = d.sSortable, b.sSortingClassJUI = d.sSortJUI)
    } function Y(a) { if (!1 !== a.oFeatures.bAutoWidth) { var b = a.aoColumns; Fa(a); for (var c = 0, d = b.length; c < d; c++) b[c].nTh.style.width = b[c].sWidth } b = a.oScroll; ("" !== b.sY || "" !== b.sX) && ka(a); u(a, null, "column-sizing", [a]) } function Z(a, b) { var c = la(a, "bVisible"); return "number" === typeof c[b] ? c[b] : null } function $(a, b) { var c = la(a, "bVisible"), c = h.inArray(b, c); return -1 !== c ? c : null }
    function aa(a) { var b = 0; h.each(a.aoColumns, function (a, d) { d.bVisible && "none" !== h(d.nTh).css("display") && b++ }); return b } function la(a, b) { var c = []; h.map(a.aoColumns, function (a, e) { a[b] && c.push(e) }); return c } function Ga(a) {
        var b = a.aoColumns, c = a.aoData, d = m.ext.type.detect, e, f, g, j, i, h, l, q, t; e = 0; for (f = b.length; e < f; e++) if (l = b[e], t = [], !l.sType && l._sManualType) l.sType = l._sManualType; else if (!l.sType) {
            g = 0; for (j = d.length; g < j; g++) {
                i = 0; for (h = c.length; i < h; i++) {
                    t[i] === k && (t[i] = B(a, i, e, "type")); q = d[g](t[i], a); if (!q &&
                    g !== d.length - 1) break; if ("html" === q) break
                } if (q) { l.sType = q; break }
            } l.sType || (l.sType = "string")
        }
    } function ib(a, b, c, d) {
        var e, f, g, j, i, n, l = a.aoColumns; if (b) for (e = b.length - 1; 0 <= e; e--) {
            n = b[e]; var q = n.targets !== k ? n.targets : n.aTargets; h.isArray(q) || (q = [q]); f = 0; for (g = q.length; f < g; f++) if ("number" === typeof q[f] && 0 <= q[f]) { for (; l.length <= q[f];) Ea(a); d(q[f], n) } else if ("number" === typeof q[f] && 0 > q[f]) d(l.length + q[f], n); else if ("string" === typeof q[f]) {
                j = 0; for (i = l.length; j < i; j++) ("_all" == q[f] || h(l[j].nTh).hasClass(q[f])) &&
                d(j, n)
            }
        } if (c) { e = 0; for (a = c.length; e < a; e++) d(e, c[e]) }
    } function N(a, b, c, d) { var e = a.aoData.length, f = h.extend(!0, {}, m.models.oRow, { src: c ? "dom" : "data", idx: e }); f._aData = b; a.aoData.push(f); for (var g = a.aoColumns, j = 0, i = g.length; j < i; j++) g[j].sType = null; a.aiDisplayMaster.push(e); b = a.rowIdFn(b); b !== k && (a.aIds[b] = f); (c || !a.oFeatures.bDeferRender) && Ha(a, e, c, d); return e } function ma(a, b) { var c; b instanceof h || (b = h(b)); return b.map(function (b, e) { c = Ia(a, e); return N(a, c.data, e, c.cells) }) } function B(a, b, c, d) {
        var e = a.iDraw,
        f = a.aoColumns[c], g = a.aoData[b]._aData, j = f.sDefaultContent, i = f.fnGetData(g, d, { settings: a, row: b, col: c }); if (i === k) return a.iDrawError != e && null === j && (L(a, 0, "Requested unknown parameter " + ("function" == typeof f.mData ? "{function}" : "'" + f.mData + "'") + " for row " + b + ", column " + c, 4), a.iDrawError = e), j; if ((i === g || null === i) && null !== j && d !== k) i = j; else if ("function" === typeof i) return i.call(g); return null === i && "display" == d ? "" : i
    } function jb(a, b, c, d) { a.aoColumns[c].fnSetData(a.aoData[b]._aData, d, { settings: a, row: b, col: c }) }
    function Ja(a) { return h.map(a.match(/(\\.|[^\.])+/g) || [""], function (a) { return a.replace(/\\./g, ".") }) } function Q(a) {
        if (h.isPlainObject(a)) { var b = {}; h.each(a, function (a, c) { c && (b[a] = Q(c)) }); return function (a, c, f, g) { var j = b[c] || b._; return j !== k ? j(a, c, f, g) : a } } if (null === a) return function (a) { return a }; if ("function" === typeof a) return function (b, c, f, g) { return a(b, c, f, g) }; if ("string" === typeof a && (-1 !== a.indexOf(".") || -1 !== a.indexOf("[") || -1 !== a.indexOf("("))) {
            var c = function (a, b, f) {
                var g, j; if ("" !== f) {
                    j = Ja(f);
                    for (var i = 0, n = j.length; i < n; i++) { f = j[i].match(ba); g = j[i].match(U); if (f) { j[i] = j[i].replace(ba, ""); "" !== j[i] && (a = a[j[i]]); g = []; j.splice(0, i + 1); j = j.join("."); if (h.isArray(a)) { i = 0; for (n = a.length; i < n; i++) g.push(c(a[i], b, j)) } a = f[0].substring(1, f[0].length - 1); a = "" === a ? g : g.join(a); break } else if (g) { j[i] = j[i].replace(U, ""); a = a[j[i]](); continue } if (null === a || a[j[i]] === k) return k; a = a[j[i]] }
                } return a
            }; return function (b, e) { return c(b, e, a) }
        } return function (b) { return b[a] }
    } function R(a) {
        if (h.isPlainObject(a)) return R(a._);
        if (null === a) return function () { }; if ("function" === typeof a) return function (b, d, e) { a(b, "set", d, e) }; if ("string" === typeof a && (-1 !== a.indexOf(".") || -1 !== a.indexOf("[") || -1 !== a.indexOf("("))) {
            var b = function (a, d, e) {
                var e = Ja(e), f; f = e[e.length - 1]; for (var g, j, i = 0, n = e.length - 1; i < n; i++) {
                    g = e[i].match(ba); j = e[i].match(U); if (g) { e[i] = e[i].replace(ba, ""); a[e[i]] = []; f = e.slice(); f.splice(0, i + 1); g = f.join("."); if (h.isArray(d)) { j = 0; for (n = d.length; j < n; j++) f = {}, b(f, d[j], g), a[e[i]].push(f) } else a[e[i]] = d; return } j && (e[i] = e[i].replace(U,
                    ""), a = a[e[i]](d)); if (null === a[e[i]] || a[e[i]] === k) a[e[i]] = {}; a = a[e[i]]
                } if (f.match(U)) a[f.replace(U, "")](d); else a[f.replace(ba, "")] = d
            }; return function (c, d) { return b(c, d, a) }
        } return function (b, d) { b[a] = d }
    } function Ka(a) { return G(a.aoData, "_aData") } function na(a) { a.aoData.length = 0; a.aiDisplayMaster.length = 0; a.aiDisplay.length = 0; a.aIds = {} } function oa(a, b, c) { for (var d = -1, e = 0, f = a.length; e < f; e++) a[e] == b ? d = e : a[e] > b && a[e]--; -1 != d && c === k && a.splice(d, 1) } function ca(a, b, c, d) {
        var e = a.aoData[b], f, g = function (c, d) {
            for (; c.childNodes.length;) c.removeChild(c.firstChild);
            c.innerHTML = B(a, b, d, "display")
        }; if ("dom" === c || (!c || "auto" === c) && "dom" === e.src) e._aData = Ia(a, e, d, d === k ? k : e._aData).data; else { var j = e.anCells; if (j) if (d !== k) g(j[d], d); else { c = 0; for (f = j.length; c < f; c++) g(j[c], c) } } e._aSortData = null; e._aFilterData = null; g = a.aoColumns; if (d !== k) g[d].sType = null; else { c = 0; for (f = g.length; c < f; c++) g[c].sType = null; La(a, e) }
    } function Ia(a, b, c, d) {
        var e = [], f = b.firstChild, g, j, i = 0, n, l = a.aoColumns, q = a._rowReadObject, d = d !== k ? d : q ? {} : [], t = function (a, b) {
            if ("string" === typeof a) {
                var c = a.indexOf("@");
                -1 !== c && (c = a.substring(c + 1), R(a)(d, b.getAttribute(c)))
            }
        }, S = function (a) { if (c === k || c === i) j = l[i], n = h.trim(a.innerHTML), j && j._bAttrSrc ? (R(j.mData._)(d, n), t(j.mData.sort, a), t(j.mData.type, a), t(j.mData.filter, a)) : q ? (j._setter || (j._setter = R(j.mData)), j._setter(d, n)) : d[i] = n; i++ }; if (f) for (; f;) { g = f.nodeName.toUpperCase(); if ("TD" == g || "TH" == g) S(f), e.push(f); f = f.nextSibling } else { e = b.anCells; f = 0; for (g = e.length; f < g; f++) S(e[f]) } if (b = b.firstChild ? b : b.nTr) (b = b.getAttribute("id")) && R(a.rowId)(d, b); return { data: d, cells: e }
    }
    function Ha(a, b, c, d) {
        var e = a.aoData[b], f = e._aData, g = [], j, i, n, l, q; if (null === e.nTr) {
            j = c || I.createElement("tr"); e.nTr = j; e.anCells = g; j._DT_RowIndex = b; La(a, e); l = 0; for (q = a.aoColumns.length; l < q; l++) {
                n = a.aoColumns[l]; i = c ? d[l] : I.createElement(n.sCellType); i._DT_CellIndex = { row: b, column: l }; g.push(i); if ((!c || n.mRender || n.mData !== l) && (!h.isPlainObject(n.mData) || n.mData._ !== l + ".display")) i.innerHTML = B(a, b, l, "display"); n.sClass && (i.className += " " + n.sClass); n.bVisible && !c ? j.appendChild(i) : !n.bVisible && c && i.parentNode.removeChild(i);
                n.fnCreatedCell && n.fnCreatedCell.call(a.oInstance, i, B(a, b, l), f, b, l)
            } u(a, "aoRowCreatedCallback", null, [j, f, b])
        } e.nTr.setAttribute("role", "row")
    } function La(a, b) { var c = b.nTr, d = b._aData; if (c) { var e = a.rowIdFn(d); e && (c.id = e); d.DT_RowClass && (e = d.DT_RowClass.split(" "), b.__rowc = b.__rowc ? pa(b.__rowc.concat(e)) : e, h(c).removeClass(b.__rowc.join(" ")).addClass(d.DT_RowClass)); d.DT_RowAttr && h(c).attr(d.DT_RowAttr); d.DT_RowData && h(c).data(d.DT_RowData) } } function kb(a) {
        var b, c, d, e, f, g = a.nTHead, j = a.nTFoot, i = 0 ===
        h("th, td", g).length, n = a.oClasses, l = a.aoColumns; i && (e = h("<tr/>").appendTo(g)); b = 0; for (c = l.length; b < c; b++) f = l[b], d = h(f.nTh).addClass(f.sClass), i && d.appendTo(e), a.oFeatures.bSort && (d.addClass(f.sSortingClass), !1 !== f.bSortable && (d.attr("tabindex", a.iTabIndex).attr("aria-controls", a.sTableId), Ma(a, f.nTh, b))), f.sTitle != d[0].innerHTML && d.html(f.sTitle), Na(a, "header")(a, d, f, n); i && da(a.aoHeader, g); h(g).find(">tr").attr("role", "row"); h(g).find(">tr>th, >tr>td").addClass(n.sHeaderTH); h(j).find(">tr>th, >tr>td").addClass(n.sFooterTH);
        if (null !== j) { a = a.aoFooter[0]; b = 0; for (c = a.length; b < c; b++) f = l[b], f.nTf = a[b].cell, f.sClass && h(f.nTf).addClass(f.sClass) }
    } function ea(a, b, c) {
        var d, e, f, g = [], j = [], i = a.aoColumns.length, n; if (b) {
            c === k && (c = !1); d = 0; for (e = b.length; d < e; d++) { g[d] = b[d].slice(); g[d].nTr = b[d].nTr; for (f = i - 1; 0 <= f; f--) !a.aoColumns[f].bVisible && !c && g[d].splice(f, 1); j.push([]) } d = 0; for (e = g.length; d < e; d++) {
                if (a = g[d].nTr) for (; f = a.firstChild;) a.removeChild(f); f = 0; for (b = g[d].length; f < b; f++) if (n = i = 1, j[d][f] === k) {
                    a.appendChild(g[d][f].cell);
                    for (j[d][f] = 1; g[d + i] !== k && g[d][f].cell == g[d + i][f].cell;) j[d + i][f] = 1, i++; for (; g[d][f + n] !== k && g[d][f].cell == g[d][f + n].cell;) { for (c = 0; c < i; c++) j[d + c][f + n] = 1; n++ } h(g[d][f].cell).attr("rowspan", i).attr("colspan", n)
                }
            }
        }
    } function O(a) {
        var b = u(a, "aoPreDrawCallback", "preDraw", [a]); if (-1 !== h.inArray(!1, b)) C(a, !1); else {
            var b = [], c = 0, d = a.asStripeClasses, e = d.length, f = a.oLanguage, g = a.iInitDisplayStart, j = "ssp" == y(a), i = a.aiDisplay; a.bDrawing = !0; g !== k && -1 !== g && (a._iDisplayStart = j ? g : g >= a.fnRecordsDisplay() ? 0 : g, a.iInitDisplayStart =
            -1); var g = a._iDisplayStart, n = a.fnDisplayEnd(); if (a.bDeferLoading) a.bDeferLoading = !1, a.iDraw++, C(a, !1); else if (j) { if (!a.bDestroying && !lb(a)) return } else a.iDraw++; if (0 !== i.length) { f = j ? a.aoData.length : n; for (j = j ? 0 : g; j < f; j++) { var l = i[j], q = a.aoData[l]; null === q.nTr && Ha(a, l); l = q.nTr; if (0 !== e) { var t = d[c % e]; q._sRowStripe != t && (h(l).removeClass(q._sRowStripe).addClass(t), q._sRowStripe = t) } u(a, "aoRowCallback", null, [l, q._aData, c, j]); b.push(l); c++ } } else c = f.sZeroRecords, 1 == a.iDraw && "ajax" == y(a) ? c = f.sLoadingRecords :
            f.sEmptyTable && 0 === a.fnRecordsTotal() && (c = f.sEmptyTable), b[0] = h("<tr/>", { "class": e ? d[0] : "" }).append(h("<td />", { valign: "top", colSpan: aa(a), "class": a.oClasses.sRowEmpty }).html(c))[0]; u(a, "aoHeaderCallback", "header", [h(a.nTHead).children("tr")[0], Ka(a), g, n, i]); u(a, "aoFooterCallback", "footer", [h(a.nTFoot).children("tr")[0], Ka(a), g, n, i]); d = h(a.nTBody); d.children().detach(); d.append(h(b)); u(a, "aoDrawCallback", "draw", [a]); a.bSorted = !1; a.bFiltered = !1; a.bDrawing = !1
        }
    } function T(a, b) {
        var c = a.oFeatures, d = c.bFilter;
        c.bSort && mb(a); d ? fa(a, a.oPreviousSearch) : a.aiDisplay = a.aiDisplayMaster.slice(); !0 !== b && (a._iDisplayStart = 0); a._drawHold = b; O(a); a._drawHold = !1
    } function nb(a) {
        var b = a.oClasses, c = h(a.nTable), c = h("<div/>").insertBefore(c), d = a.oFeatures, e = h("<div/>", { id: a.sTableId + "_wrapper", "class": b.sWrapper + (a.nTFoot ? "" : " " + b.sNoFooter) }); a.nHolding = c[0]; a.nTableWrapper = e[0]; a.nTableReinsertBefore = a.nTable.nextSibling; for (var f = a.sDom.split(""), g, j, i, n, l, q, t = 0; t < f.length; t++) {
            g = null; j = f[t]; if ("<" == j) {
                i = h("<div/>")[0];
                n = f[t + 1]; if ("'" == n || '"' == n) { l = ""; for (q = 2; f[t + q] != n;) l += f[t + q], q++; "H" == l ? l = b.sJUIHeader : "F" == l && (l = b.sJUIFooter); -1 != l.indexOf(".") ? (n = l.split("."), i.id = n[0].substr(1, n[0].length - 1), i.className = n[1]) : "#" == l.charAt(0) ? i.id = l.substr(1, l.length - 1) : i.className = l; t += q } e.append(i); e = h(i)
            } else if (">" == j) e = e.parent(); else if ("l" == j && d.bPaginate && d.bLengthChange) g = ob(a); else if ("f" == j && d.bFilter) g = pb(a); else if ("r" == j && d.bProcessing) g = qb(a); else if ("t" == j) g = rb(a); else if ("i" == j && d.bInfo) g = sb(a); else if ("p" ==
            j && d.bPaginate) g = tb(a); else if (0 !== m.ext.feature.length) { i = m.ext.feature; q = 0; for (n = i.length; q < n; q++) if (j == i[q].cFeature) { g = i[q].fnInit(a); break } } g && (i = a.aanFeatures, i[j] || (i[j] = []), i[j].push(g), e.append(g))
        } c.replaceWith(e); a.nHolding = null
    } function da(a, b) {
        var c = h(b).children("tr"), d, e, f, g, j, i, n, l, q, t; a.splice(0, a.length); f = 0; for (i = c.length; f < i; f++) a.push([]); f = 0; for (i = c.length; f < i; f++) {
            d = c[f]; for (e = d.firstChild; e;) {
                if ("TD" == e.nodeName.toUpperCase() || "TH" == e.nodeName.toUpperCase()) {
                    l = 1 * e.getAttribute("colspan");
                    q = 1 * e.getAttribute("rowspan"); l = !l || 0 === l || 1 === l ? 1 : l; q = !q || 0 === q || 1 === q ? 1 : q; g = 0; for (j = a[f]; j[g];) g++; n = g; t = 1 === l ? !0 : !1; for (j = 0; j < l; j++) for (g = 0; g < q; g++) a[f + g][n + j] = { cell: e, unique: t }, a[f + g].nTr = d
                } e = e.nextSibling
            }
        }
    } function qa(a, b, c) { var d = []; c || (c = a.aoHeader, b && (c = [], da(c, b))); for (var b = 0, e = c.length; b < e; b++) for (var f = 0, g = c[b].length; f < g; f++) if (c[b][f].unique && (!d[f] || !a.bSortCellsTop)) d[f] = c[b][f].cell; return d } function ra(a, b, c) {
        u(a, "aoServerParams", "serverParams", [b]); if (b && h.isArray(b)) {
            var d = {},
            e = /(.*?)\[\]$/; h.each(b, function (a, b) { var c = b.name.match(e); c ? (c = c[0], d[c] || (d[c] = []), d[c].push(b.value)) : d[b.name] = b.value }); b = d
        } var f, g = a.ajax, j = a.oInstance, i = function (b) { u(a, null, "xhr", [a, b, a.jqXHR]); c(b) }; if (h.isPlainObject(g) && g.data) { f = g.data; var n = h.isFunction(f) ? f(b, a) : f, b = h.isFunction(f) && n ? n : h.extend(!0, b, n); delete g.data } n = {
            data: b, success: function (b) { var c = b.error || b.sError; c && L(a, 0, c); a.json = b; i(b) }, dataType: "json", cache: !1, type: a.sServerMethod, error: function (b, c) {
                var d = u(a, null, "xhr",
                [a, null, a.jqXHR]); -1 === h.inArray(!0, d) && ("parsererror" == c ? L(a, 0, "Invalid JSON response", 1) : 4 === b.readyState && L(a, 0, "Ajax error", 7)); C(a, !1)
            }
        }; a.oAjaxData = b; u(a, null, "preXhr", [a, b]); a.fnServerData ? a.fnServerData.call(j, a.sAjaxSource, h.map(b, function (a, b) { return { name: b, value: a } }), i, a) : a.sAjaxSource || "string" === typeof g ? a.jqXHR = h.ajax(h.extend(n, { url: g || a.sAjaxSource })) : h.isFunction(g) ? a.jqXHR = g.call(j, b, i, a) : (a.jqXHR = h.ajax(h.extend(n, g)), g.data = f)
    } function lb(a) {
        return a.bAjaxDataGet ? (a.iDraw++, C(a,
        !0), ra(a, ub(a), function (b) { vb(a, b) }), !1) : !0
    } function ub(a) {
        var b = a.aoColumns, c = b.length, d = a.oFeatures, e = a.oPreviousSearch, f = a.aoPreSearchCols, g, j = [], i, n, l, q = V(a); g = a._iDisplayStart; i = !1 !== d.bPaginate ? a._iDisplayLength : -1; var k = function (a, b) { j.push({ name: a, value: b }) }; k("sEcho", a.iDraw); k("iColumns", c); k("sColumns", G(b, "sName").join(",")); k("iDisplayStart", g); k("iDisplayLength", i); var S = { draw: a.iDraw, columns: [], order: [], start: g, length: i, search: { value: e.sSearch, regex: e.bRegex } }; for (g = 0; g < c; g++) n = b[g],
        l = f[g], i = "function" == typeof n.mData ? "function" : n.mData, S.columns.push({ data: i, name: n.sName, searchable: n.bSearchable, orderable: n.bSortable, search: { value: l.sSearch, regex: l.bRegex } }), k("mDataProp_" + g, i), d.bFilter && (k("sSearch_" + g, l.sSearch), k("bRegex_" + g, l.bRegex), k("bSearchable_" + g, n.bSearchable)), d.bSort && k("bSortable_" + g, n.bSortable); d.bFilter && (k("sSearch", e.sSearch), k("bRegex", e.bRegex)); d.bSort && (h.each(q, function (a, b) {
            S.order.push({ column: b.col, dir: b.dir }); k("iSortCol_" + a, b.col); k("sSortDir_" +
            a, b.dir)
        }), k("iSortingCols", q.length)); b = m.ext.legacy.ajax; return null === b ? a.sAjaxSource ? j : S : b ? j : S
    } function vb(a, b) {
        var c = sa(a, b), d = b.sEcho !== k ? b.sEcho : b.draw, e = b.iTotalRecords !== k ? b.iTotalRecords : b.recordsTotal, f = b.iTotalDisplayRecords !== k ? b.iTotalDisplayRecords : b.recordsFiltered; if (d) { if (1 * d < a.iDraw) return; a.iDraw = 1 * d } na(a); a._iRecordsTotal = parseInt(e, 10); a._iRecordsDisplay = parseInt(f, 10); d = 0; for (e = c.length; d < e; d++) N(a, c[d]); a.aiDisplay = a.aiDisplayMaster.slice(); a.bAjaxDataGet = !1; O(a); a._bInitComplete ||
        ta(a, b); a.bAjaxDataGet = !0; C(a, !1)
    } function sa(a, b) { var c = h.isPlainObject(a.ajax) && a.ajax.dataSrc !== k ? a.ajax.dataSrc : a.sAjaxDataProp; return "data" === c ? b.aaData || b[c] : "" !== c ? Q(c)(b) : b } function pb(a) {
        var b = a.oClasses, c = a.sTableId, d = a.oLanguage, e = a.oPreviousSearch, f = a.aanFeatures, g = '<input type="search" class="' + b.sFilterInput + '"/>', j = d.sSearch, j = j.match(/_INPUT_/) ? j.replace("_INPUT_", g) : j + g, b = h("<div/>", { id: !f.f ? c + "_filter" : null, "class": b.sFilter }).append(h("<label/>").append(j)), f = function () {
            var b = !this.value ?
            "" : this.value; b != e.sSearch && (fa(a, { sSearch: b, bRegex: e.bRegex, bSmart: e.bSmart, bCaseInsensitive: e.bCaseInsensitive }), a._iDisplayStart = 0, O(a))
        }, g = null !== a.searchDelay ? a.searchDelay : "ssp" === y(a) ? 400 : 0, i = h("input", b).val(e.sSearch).attr("placeholder", d.sSearchPlaceholder).bind("keyup.DT search.DT input.DT paste.DT cut.DT", g ? Oa(f, g) : f).bind("keypress.DT", function (a) { if (13 == a.keyCode) return !1 }).attr("aria-controls", c); h(a.nTable).on("search.dt.DT", function (b, c) { if (a === c) try { i[0] !== I.activeElement && i.val(e.sSearch) } catch (d) { } });
        return b[0]
    } function fa(a, b, c) { var d = a.oPreviousSearch, e = a.aoPreSearchCols, f = function (a) { d.sSearch = a.sSearch; d.bRegex = a.bRegex; d.bSmart = a.bSmart; d.bCaseInsensitive = a.bCaseInsensitive }; Ga(a); if ("ssp" != y(a)) { wb(a, b.sSearch, c, b.bEscapeRegex !== k ? !b.bEscapeRegex : b.bRegex, b.bSmart, b.bCaseInsensitive); f(b); for (b = 0; b < e.length; b++) xb(a, e[b].sSearch, b, e[b].bEscapeRegex !== k ? !e[b].bEscapeRegex : e[b].bRegex, e[b].bSmart, e[b].bCaseInsensitive); yb(a) } else f(b); a.bFiltered = !0; u(a, null, "search", [a]) } function yb(a) {
        for (var b =
        m.ext.search, c = a.aiDisplay, d, e, f = 0, g = b.length; f < g; f++) { for (var j = [], i = 0, n = c.length; i < n; i++) e = c[i], d = a.aoData[e], b[f](a, d._aFilterData, e, d._aData, i) && j.push(e); c.length = 0; h.merge(c, j) }
    } function xb(a, b, c, d, e, f) { if ("" !== b) for (var g = a.aiDisplay, d = Pa(b, d, e, f), e = g.length - 1; 0 <= e; e--) b = a.aoData[g[e]]._aFilterData[c], d.test(b) || g.splice(e, 1) } function wb(a, b, c, d, e, f) {
        var d = Pa(b, d, e, f), e = a.oPreviousSearch.sSearch, f = a.aiDisplayMaster, g; 0 !== m.ext.search.length && (c = !0); g = zb(a); if (0 >= b.length) a.aiDisplay = f.slice();
        else { if (g || c || e.length > b.length || 0 !== b.indexOf(e) || a.bSorted) a.aiDisplay = f.slice(); b = a.aiDisplay; for (c = b.length - 1; 0 <= c; c--) d.test(a.aoData[b[c]]._sFilterRow) || b.splice(c, 1) }
    } function Pa(a, b, c, d) { a = b ? a : Qa(a); c && (a = "^(?=.*?" + h.map(a.match(/"[^"]+"|[^ ]+/g) || [""], function (a) { if ('"' === a.charAt(0)) var b = a.match(/^"(.*)"$/), a = b ? b[1] : a; return a.replace('"', "") }).join(")(?=.*?") + ").*$"); return RegExp(a, d ? "i" : "") } function zb(a) {
        var b = a.aoColumns, c, d, e, f, g, j, i, h, l = m.ext.type.search; c = !1; d = 0; for (f = a.aoData.length; d <
        f; d++) if (h = a.aoData[d], !h._aFilterData) { j = []; e = 0; for (g = b.length; e < g; e++) c = b[e], c.bSearchable ? (i = B(a, d, e, "filter"), l[c.sType] && (i = l[c.sType](i)), null === i && (i = ""), "string" !== typeof i && i.toString && (i = i.toString())) : i = "", i.indexOf && -1 !== i.indexOf("&") && (ua.innerHTML = i, i = Zb ? ua.textContent : ua.innerText), i.replace && (i = i.replace(/[\r\n]/g, "")), j.push(i); h._aFilterData = j; h._sFilterRow = j.join("  "); c = !0 } return c
    } function Ab(a) { return { search: a.sSearch, smart: a.bSmart, regex: a.bRegex, caseInsensitive: a.bCaseInsensitive } }
    function Bb(a) { return { sSearch: a.search, bSmart: a.smart, bRegex: a.regex, bCaseInsensitive: a.caseInsensitive } } function sb(a) { var b = a.sTableId, c = a.aanFeatures.i, d = h("<div/>", { "class": a.oClasses.sInfo, id: !c ? b + "_info" : null }); c || (a.aoDrawCallback.push({ fn: Cb, sName: "information" }), d.attr("role", "status").attr("aria-live", "polite"), h(a.nTable).attr("aria-describedby", b + "_info")); return d[0] } function Cb(a) {
        var b = a.aanFeatures.i; if (0 !== b.length) {
            var c = a.oLanguage, d = a._iDisplayStart + 1, e = a.fnDisplayEnd(), f = a.fnRecordsTotal(),
            g = a.fnRecordsDisplay(), j = g ? c.sInfo : c.sInfoEmpty; g !== f && (j += " " + c.sInfoFiltered); j += c.sInfoPostFix; j = Db(a, j); c = c.fnInfoCallback; null !== c && (j = c.call(a.oInstance, a, d, e, f, g, j)); h(b).html(j)
        }
    } function Db(a, b) {
        var c = a.fnFormatNumber, d = a._iDisplayStart + 1, e = a._iDisplayLength, f = a.fnRecordsDisplay(), g = -1 === e; return b.replace(/_START_/g, c.call(a, d)).replace(/_END_/g, c.call(a, a.fnDisplayEnd())).replace(/_MAX_/g, c.call(a, a.fnRecordsTotal())).replace(/_TOTAL_/g, c.call(a, f)).replace(/_PAGE_/g, c.call(a, g ? 1 : Math.ceil(d /
        e))).replace(/_PAGES_/g, c.call(a, g ? 1 : Math.ceil(f / e)))
    } function ga(a) {
        var b, c, d = a.iInitDisplayStart, e = a.aoColumns, f; c = a.oFeatures; var g = a.bDeferLoading; if (a.bInitialised) {
            nb(a); kb(a); ea(a, a.aoHeader); ea(a, a.aoFooter); C(a, !0); c.bAutoWidth && Fa(a); b = 0; for (c = e.length; b < c; b++) f = e[b], f.sWidth && (f.nTh.style.width = x(f.sWidth)); u(a, null, "preInit", [a]); T(a); e = y(a); if ("ssp" != e || g) "ajax" == e ? ra(a, [], function (c) { var f = sa(a, c); for (b = 0; b < f.length; b++) N(a, f[b]); a.iInitDisplayStart = d; T(a); C(a, !1); ta(a, c) }, a) : (C(a, !1),
            ta(a))
        } else setTimeout(function () { ga(a) }, 200)
    } function ta(a, b) { a._bInitComplete = !0; (b || a.oInit.aaData) && Y(a); u(a, null, "plugin-init", [a, b]); u(a, "aoInitComplete", "init", [a, b]) } function Ra(a, b) { var c = parseInt(b, 10); a._iDisplayLength = c; Sa(a); u(a, null, "length", [a, c]) } function ob(a) {
        for (var b = a.oClasses, c = a.sTableId, d = a.aLengthMenu, e = h.isArray(d[0]), f = e ? d[0] : d, d = e ? d[1] : d, e = h("<select/>", { name: c + "_length", "aria-controls": c, "class": b.sLengthSelect }), g = 0, j = f.length; g < j; g++) e[0][g] = new Option(d[g], f[g]); var i =
        h("<div><label/></div>").addClass(b.sLength); a.aanFeatures.l || (i[0].id = c + "_length"); i.children().append(a.oLanguage.sLengthMenu.replace("_MENU_", e[0].outerHTML)); h("select", i).val(a._iDisplayLength).bind("change.DT", function () { Ra(a, h(this).val()); O(a) }); h(a.nTable).bind("length.dt.DT", function (b, c, d) { a === c && h("select", i).val(d) }); return i[0]
    } function tb(a) {
        var b = a.sPaginationType, c = m.ext.pager[b], d = "function" === typeof c, e = function (a) { O(a) }, b = h("<div/>").addClass(a.oClasses.sPaging + b)[0], f = a.aanFeatures;
        d || c.fnInit(a, b, e); f.p || (b.id = a.sTableId + "_paginate", a.aoDrawCallback.push({ fn: function (a) { if (d) { var b = a._iDisplayStart, i = a._iDisplayLength, h = a.fnRecordsDisplay(), l = -1 === i, b = l ? 0 : Math.ceil(b / i), i = l ? 1 : Math.ceil(h / i), h = c(b, i), k, l = 0; for (k = f.p.length; l < k; l++) Na(a, "pageButton")(a, f.p[l], l, h, b, i) } else c.fnUpdate(a, e) }, sName: "pagination" })); return b
    } function Ta(a, b, c) {
        var d = a._iDisplayStart, e = a._iDisplayLength, f = a.fnRecordsDisplay(); 0 === f || -1 === e ? d = 0 : "number" === typeof b ? (d = b * e, d > f && (d = 0)) : "first" == b ? d = 0 :
        "previous" == b ? (d = 0 <= e ? d - e : 0, 0 > d && (d = 0)) : "next" == b ? d + e < f && (d += e) : "last" == b ? d = Math.floor((f - 1) / e) * e : L(a, 0, "Unknown paging action: " + b, 5); b = a._iDisplayStart !== d; a._iDisplayStart = d; b && (u(a, null, "page", [a]), c && O(a)); return b
    } function qb(a) { return h("<div/>", { id: !a.aanFeatures.r ? a.sTableId + "_processing" : null, "class": a.oClasses.sProcessing }).html(a.oLanguage.sProcessing).insertBefore(a.nTable)[0] } function C(a, b) {
        a.oFeatures.bProcessing && h(a.aanFeatures.r).css("display", b ? "block" : "none"); u(a, null, "processing",
        [a, b])
    } function rb(a) {
        var b = h(a.nTable); b.attr("role", "grid"); var c = a.oScroll; if ("" === c.sX && "" === c.sY) return a.nTable; var d = c.sX, e = c.sY, f = a.oClasses, g = b.children("caption"), j = g.length ? g[0]._captionSide : null, i = h(b[0].cloneNode(!1)), n = h(b[0].cloneNode(!1)), l = b.children("tfoot"); l.length || (l = null); i = h("<div/>", { "class": f.sScrollWrapper }).append(h("<div/>", { "class": f.sScrollHead }).css({ overflow: "hidden", position: "relative", border: 0, width: d ? !d ? null : x(d) : "100%" }).append(h("<div/>", { "class": f.sScrollHeadInner }).css({
            "box-sizing": "content-box",
            width: c.sXInner || "100%"
        }).append(i.removeAttr("id").css("margin-left", 0).append("top" === j ? g : null).append(b.children("thead"))))).append(h("<div/>", { "class": f.sScrollBody }).css({ position: "relative", overflow: "auto", width: !d ? null : x(d) }).append(b)); l && i.append(h("<div/>", { "class": f.sScrollFoot }).css({ overflow: "hidden", border: 0, width: d ? !d ? null : x(d) : "100%" }).append(h("<div/>", { "class": f.sScrollFootInner }).append(n.removeAttr("id").css("margin-left", 0).append("bottom" === j ? g : null).append(b.children("tfoot")))));
        var b = i.children(), k = b[0], f = b[1], t = l ? b[2] : null; if (d) h(f).on("scroll.DT", function () { var a = this.scrollLeft; k.scrollLeft = a; l && (t.scrollLeft = a) }); h(f).css(e && c.bCollapse ? "max-height" : "height", e); a.nScrollHead = k; a.nScrollBody = f; a.nScrollFoot = t; a.aoDrawCallback.push({ fn: ka, sName: "scrolling" }); return i[0]
    } function ka(a) {
        var b = a.oScroll, c = b.sX, d = b.sXInner, e = b.sY, b = b.iBarWidth, f = h(a.nScrollHead), g = f[0].style, j = f.children("div"), i = j[0].style, n = j.children("table"), j = a.nScrollBody, l = h(j), q = j.style, t = h(a.nScrollFoot).children("div"),
        m = t.children("table"), o = h(a.nTHead), F = h(a.nTable), p = F[0], r = p.style, u = a.nTFoot ? h(a.nTFoot) : null, Eb = a.oBrowser, Ua = Eb.bScrollOversize, s = G(a.aoColumns, "nTh"), P, v, w, y, z = [], A = [], B = [], C = [], D, E = function (a) { a = a.style; a.paddingTop = "0"; a.paddingBottom = "0"; a.borderTopWidth = "0"; a.borderBottomWidth = "0"; a.height = 0 }; v = j.scrollHeight > j.clientHeight; if (a.scrollBarVis !== v && a.scrollBarVis !== k) a.scrollBarVis = v, Y(a); else {
            a.scrollBarVis = v; F.children("thead, tfoot").remove(); u && (w = u.clone().prependTo(F), P = u.find("tr"), w =
            w.find("tr")); y = o.clone().prependTo(F); o = o.find("tr"); v = y.find("tr"); y.find("th, td").removeAttr("tabindex"); c || (q.width = "100%", f[0].style.width = "100%"); h.each(qa(a, y), function (b, c) { D = Z(a, b); c.style.width = a.aoColumns[D].sWidth }); u && J(function (a) { a.style.width = "" }, w); f = F.outerWidth(); if ("" === c) { r.width = "100%"; if (Ua && (F.find("tbody").height() > j.offsetHeight || "scroll" == l.css("overflow-y"))) r.width = x(F.outerWidth() - b); f = F.outerWidth() } else "" !== d && (r.width = x(d), f = F.outerWidth()); J(E, v); J(function (a) {
                B.push(a.innerHTML);
                z.push(x(h(a).css("width")))
            }, v); J(function (a, b) { if (h.inArray(a, s) !== -1) a.style.width = z[b] }, o); h(v).height(0); u && (J(E, w), J(function (a) { C.push(a.innerHTML); A.push(x(h(a).css("width"))) }, w), J(function (a, b) { a.style.width = A[b] }, P), h(w).height(0)); J(function (a, b) { a.innerHTML = '<div class="dataTables_sizing" style="height:0;overflow:hidden;">' + B[b] + "</div>"; a.style.width = z[b] }, v); u && J(function (a, b) {
                a.innerHTML = '<div class="dataTables_sizing" style="height:0;overflow:hidden;">' + C[b] + "</div>"; a.style.width =
                A[b]
            }, w); if (F.outerWidth() < f) { P = j.scrollHeight > j.offsetHeight || "scroll" == l.css("overflow-y") ? f + b : f; if (Ua && (j.scrollHeight > j.offsetHeight || "scroll" == l.css("overflow-y"))) r.width = x(P - b); ("" === c || "" !== d) && L(a, 1, "Possible column misalignment", 6) } else P = "100%"; q.width = x(P); g.width = x(P); u && (a.nScrollFoot.style.width = x(P)); !e && Ua && (q.height = x(p.offsetHeight + b)); c = F.outerWidth(); n[0].style.width = x(c); i.width = x(c); d = F.height() > j.clientHeight || "scroll" == l.css("overflow-y"); e = "padding" + (Eb.bScrollbarLeft ? "Left" :
            "Right"); i[e] = d ? b + "px" : "0px"; u && (m[0].style.width = x(c), t[0].style.width = x(c), t[0].style[e] = d ? b + "px" : "0px"); F.children("colgroup").insertBefore(F.children("thead")); l.scroll(); if ((a.bSorted || a.bFiltered) && !a._drawHold) j.scrollTop = 0
        }
    } function J(a, b, c) { for (var d = 0, e = 0, f = b.length, g, j; e < f;) { g = b[e].firstChild; for (j = c ? c[e].firstChild : null; g;) 1 === g.nodeType && (c ? a(g, j, d) : a(g, d), d++), g = g.nextSibling, j = c ? j.nextSibling : null; e++ } } function Fa(a) {
        var b = a.nTable, c = a.aoColumns, d = a.oScroll, e = d.sY, f = d.sX, g = d.sXInner,
        j = c.length, i = la(a, "bVisible"), n = h("th", a.nTHead), l = b.getAttribute("width"), k = b.parentNode, t = !1, m, o, p = a.oBrowser, d = p.bScrollOversize; (m = b.style.width) && -1 !== m.indexOf("%") && (l = m); for (m = 0; m < i.length; m++) o = c[i[m]], null !== o.sWidth && (o.sWidth = Fb(o.sWidthOrig, k), t = !0); if (d || !t && !f && !e && j == aa(a) && j == n.length) for (m = 0; m < j; m++) i = Z(a, m), null !== i && (c[i].sWidth = x(n.eq(m).width())); else {
            j = h(b).clone().css("visibility", "hidden").removeAttr("id"); j.find("tbody tr").remove(); var r = h("<tr/>").appendTo(j.find("tbody"));
            j.find("thead, tfoot").remove(); j.append(h(a.nTHead).clone()).append(h(a.nTFoot).clone()); j.find("tfoot th, tfoot td").css("width", ""); n = qa(a, j.find("thead")[0]); for (m = 0; m < i.length; m++) o = c[i[m]], n[m].style.width = null !== o.sWidthOrig && "" !== o.sWidthOrig ? x(o.sWidthOrig) : "", o.sWidthOrig && f && h(n[m]).append(h("<div/>").css({ width: o.sWidthOrig, margin: 0, padding: 0, border: 0, height: 1 })); if (a.aoData.length) for (m = 0; m < i.length; m++) t = i[m], o = c[t], h(Gb(a, t)).clone(!1).append(o.sContentPadding).appendTo(r); h("[name]",
            j).removeAttr("name"); o = h("<div/>").css(f || e ? { position: "absolute", top: 0, left: 0, height: 1, right: 0, overflow: "hidden" } : {}).append(j).appendTo(k); f && g ? j.width(g) : f ? (j.css("width", "auto"), j.removeAttr("width"), j.width() < k.clientWidth && l && j.width(k.clientWidth)) : e ? j.width(k.clientWidth) : l && j.width(l); for (m = e = 0; m < i.length; m++) k = h(n[m]), g = k.outerWidth() - k.width(), k = p.bBounding ? Math.ceil(n[m].getBoundingClientRect().width) : k.outerWidth(), e += k, c[i[m]].sWidth = x(k - g); b.style.width = x(e); o.remove()
        } l && (b.style.width =
        x(l)); if ((l || f) && !a._reszEvt) b = function () { h(D).bind("resize.DT-" + a.sInstance, Oa(function () { Y(a) })) }, d ? setTimeout(b, 1E3) : b(), a._reszEvt = !0
    } function Fb(a, b) { if (!a) return 0; var c = h("<div/>").css("width", x(a)).appendTo(b || I.body), d = c[0].offsetWidth; c.remove(); return d } function Gb(a, b) { var c = Hb(a, b); if (0 > c) return null; var d = a.aoData[c]; return !d.nTr ? h("<td/>").html(B(a, c, b, "display"))[0] : d.anCells[b] } function Hb(a, b) {
        for (var c, d = -1, e = -1, f = 0, g = a.aoData.length; f < g; f++) c = B(a, f, b, "display") + "", c = c.replace($b,
        ""), c = c.replace(/&nbsp;/g, " "), c.length > d && (d = c.length, e = f); return e
    } function x(a) { return null === a ? "0px" : "number" == typeof a ? 0 > a ? "0px" : a + "px" : a.match(/\d$/) ? a + "px" : a } function V(a) {
        var b, c, d = [], e = a.aoColumns, f, g, j, i; b = a.aaSortingFixed; c = h.isPlainObject(b); var n = []; f = function (a) { a.length && !h.isArray(a[0]) ? n.push(a) : h.merge(n, a) }; h.isArray(b) && f(b); c && b.pre && f(b.pre); f(a.aaSorting); c && b.post && f(b.post); for (a = 0; a < n.length; a++) {
            i = n[a][0]; f = e[i].aDataSort; b = 0; for (c = f.length; b < c; b++) g = f[b], j = e[g].sType ||
            "string", n[a]._idx === k && (n[a]._idx = h.inArray(n[a][1], e[g].asSorting)), d.push({ src: i, col: g, dir: n[a][1], index: n[a]._idx, type: j, formatter: m.ext.type.order[j + "-pre"] })
        } return d
    } function mb(a) {
        var b, c, d = [], e = m.ext.type.order, f = a.aoData, g = 0, j, i = a.aiDisplayMaster, h; Ga(a); h = V(a); b = 0; for (c = h.length; b < c; b++) j = h[b], j.formatter && g++, Ib(a, j.col); if ("ssp" != y(a) && 0 !== h.length) {
            b = 0; for (c = i.length; b < c; b++) d[i[b]] = b; g === h.length ? i.sort(function (a, b) {
                var c, e, g, j, i = h.length, k = f[a]._aSortData, m = f[b]._aSortData; for (g =
                0; g < i; g++) if (j = h[g], c = k[j.col], e = m[j.col], c = c < e ? -1 : c > e ? 1 : 0, 0 !== c) return "asc" === j.dir ? c : -c; c = d[a]; e = d[b]; return c < e ? -1 : c > e ? 1 : 0
            }) : i.sort(function (a, b) { var c, g, j, i, k = h.length, m = f[a]._aSortData, p = f[b]._aSortData; for (j = 0; j < k; j++) if (i = h[j], c = m[i.col], g = p[i.col], i = e[i.type + "-" + i.dir] || e["string-" + i.dir], c = i(c, g), 0 !== c) return c; c = d[a]; g = d[b]; return c < g ? -1 : c > g ? 1 : 0 })
        } a.bSorted = !0
    } function Jb(a) {
        for (var b, c, d = a.aoColumns, e = V(a), a = a.oLanguage.oAria, f = 0, g = d.length; f < g; f++) {
            c = d[f]; var j = c.asSorting; b = c.sTitle.replace(/<.*?>/g,
            ""); var i = c.nTh; i.removeAttribute("aria-sort"); c.bSortable && (0 < e.length && e[0].col == f ? (i.setAttribute("aria-sort", "asc" == e[0].dir ? "ascending" : "descending"), c = j[e[0].index + 1] || j[0]) : c = j[0], b += "asc" === c ? a.sSortAscending : a.sSortDescending); i.setAttribute("aria-label", b)
        }
    } function Va(a, b, c, d) {
        var e = a.aaSorting, f = a.aoColumns[b].asSorting, g = function (a, b) { var c = a._idx; c === k && (c = h.inArray(a[1], f)); return c + 1 < f.length ? c + 1 : b ? null : 0 }; "number" === typeof e[0] && (e = a.aaSorting = [e]); c && a.oFeatures.bSortMulti ? (c = h.inArray(b,
        G(e, "0")), -1 !== c ? (b = g(e[c], !0), null === b && 1 === e.length && (b = 0), null === b ? e.splice(c, 1) : (e[c][1] = f[b], e[c]._idx = b)) : (e.push([b, f[0], 0]), e[e.length - 1]._idx = 0)) : e.length && e[0][0] == b ? (b = g(e[0]), e.length = 1, e[0][1] = f[b], e[0]._idx = b) : (e.length = 0, e.push([b, f[0]]), e[0]._idx = 0); T(a); "function" == typeof d && d(a)
    } function Ma(a, b, c, d) { var e = a.aoColumns[c]; Wa(b, {}, function (b) { !1 !== e.bSortable && (a.oFeatures.bProcessing ? (C(a, !0), setTimeout(function () { Va(a, c, b.shiftKey, d); "ssp" !== y(a) && C(a, !1) }, 0)) : Va(a, c, b.shiftKey, d)) }) }
    function va(a) { var b = a.aLastSort, c = a.oClasses.sSortColumn, d = V(a), e = a.oFeatures, f, g; if (e.bSort && e.bSortClasses) { e = 0; for (f = b.length; e < f; e++) g = b[e].src, h(G(a.aoData, "anCells", g)).removeClass(c + (2 > e ? e + 1 : 3)); e = 0; for (f = d.length; e < f; e++) g = d[e].src, h(G(a.aoData, "anCells", g)).addClass(c + (2 > e ? e + 1 : 3)) } a.aLastSort = d } function Ib(a, b) {
        var c = a.aoColumns[b], d = m.ext.order[c.sSortDataType], e; d && (e = d.call(a.oInstance, a, b, $(a, b))); for (var f, g = m.ext.type.order[c.sType + "-pre"], j = 0, i = a.aoData.length; j < i; j++) if (c = a.aoData[j],
        c._aSortData || (c._aSortData = []), !c._aSortData[b] || d) f = d ? e[j] : B(a, j, b, "sort"), c._aSortData[b] = g ? g(f) : f
    } function wa(a) {
        if (a.oFeatures.bStateSave && !a.bDestroying) {
            var b = { time: +new Date, start: a._iDisplayStart, length: a._iDisplayLength, order: h.extend(!0, [], a.aaSorting), search: Ab(a.oPreviousSearch), columns: h.map(a.aoColumns, function (b, d) { return { visible: b.bVisible, search: Ab(a.aoPreSearchCols[d]) } }) }; u(a, "aoStateSaveParams", "stateSaveParams", [a, b]); a.oSavedState = b; a.fnStateSaveCallback.call(a.oInstance, a,
            b)
        }
    } function Kb(a) {
        var b, c, d = a.aoColumns; if (a.oFeatures.bStateSave) {
            var e = a.fnStateLoadCallback.call(a.oInstance, a); if (e && e.time && (b = u(a, "aoStateLoadParams", "stateLoadParams", [a, e]), -1 === h.inArray(!1, b) && (b = a.iStateDuration, !(0 < b && e.time < +new Date - 1E3 * b) && d.length === e.columns.length))) {
                a.oLoadedState = h.extend(!0, {}, e); e.start !== k && (a._iDisplayStart = e.start, a.iInitDisplayStart = e.start); e.length !== k && (a._iDisplayLength = e.length); e.order !== k && (a.aaSorting = [], h.each(e.order, function (b, c) {
                    a.aaSorting.push(c[0] >=
                    d.length ? [0, c[1]] : c)
                })); e.search !== k && h.extend(a.oPreviousSearch, Bb(e.search)); b = 0; for (c = e.columns.length; b < c; b++) { var f = e.columns[b]; f.visible !== k && (d[b].bVisible = f.visible); f.search !== k && h.extend(a.aoPreSearchCols[b], Bb(f.search)) } u(a, "aoStateLoaded", "stateLoaded", [a, e])
            }
        }
    } function xa(a) { var b = m.settings, a = h.inArray(a, G(b, "nTable")); return -1 !== a ? b[a] : null } function L(a, b, c, d) {
        c = "DataTables warning: " + (a ? "table id=" + a.sTableId + " - " : "") + c; d && (c += ". For more information about this error, please see http://datatables.net/tn/" +
        d); if (b) D.console && console.log && console.log(c); else if (b = m.ext, b = b.sErrMode || b.errMode, a && u(a, null, "error", [a, d, c]), "alert" == b) alert(c); else { if ("throw" == b) throw Error(c); "function" == typeof b && b(a, d, c) }
    } function E(a, b, c, d) { h.isArray(c) ? h.each(c, function (c, d) { h.isArray(d) ? E(a, b, d[0], d[1]) : E(a, b, d) }) : (d === k && (d = c), b[c] !== k && (a[d] = b[c])) } function Lb(a, b, c) {
        var d, e; for (e in b) b.hasOwnProperty(e) && (d = b[e], h.isPlainObject(d) ? (h.isPlainObject(a[e]) || (a[e] = {}), h.extend(!0, a[e], d)) : a[e] = c && "data" !== e && "aaData" !==
        e && h.isArray(d) ? d.slice() : d); return a
    } function Wa(a, b, c) { h(a).bind("click.DT", b, function (b) { a.blur(); c(b) }).bind("keypress.DT", b, function (a) { 13 === a.which && (a.preventDefault(), c(a)) }).bind("selectstart.DT", function () { return !1 }) } function z(a, b, c, d) { c && a[b].push({ fn: c, sName: d }) } function u(a, b, c, d) { var e = []; b && (e = h.map(a[b].slice().reverse(), function (b) { return b.fn.apply(a.oInstance, d) })); null !== c && (b = h.Event(c + ".dt"), h(a.nTable).trigger(b, d), e.push(b.result)); return e } function Sa(a) {
        var b = a._iDisplayStart,
        c = a.fnDisplayEnd(), d = a._iDisplayLength; b >= c && (b = c - d); b -= b % d; if (-1 === d || 0 > b) b = 0; a._iDisplayStart = b
    } function Na(a, b) { var c = a.renderer, d = m.ext.renderer[b]; return h.isPlainObject(c) && c[b] ? d[c[b]] || d._ : "string" === typeof c ? d[c] || d._ : d._ } function y(a) { return a.oFeatures.bServerSide ? "ssp" : a.ajax || a.sAjaxSource ? "ajax" : "dom" } function ya(a, b) {
        var c = [], c = Mb.numbers_length, d = Math.floor(c / 2); b <= c ? c = W(0, b) : a <= d ? (c = W(0, c - 2), c.push("ellipsis"), c.push(b - 1)) : (a >= b - 1 - d ? c = W(b - (c - 2), b) : (c = W(a - d + 2, a + d - 1), c.push("ellipsis"),
        c.push(b - 1)), c.splice(0, 0, "ellipsis"), c.splice(0, 0, 0)); c.DT_el = "span"; return c
    } function db(a) { h.each({ num: function (b) { return za(b, a) }, "num-fmt": function (b) { return za(b, a, Xa) }, "html-num": function (b) { return za(b, a, Aa) }, "html-num-fmt": function (b) { return za(b, a, Aa, Xa) } }, function (b, c) { v.type.order[b + a + "-pre"] = c; b.match(/^html\-/) && (v.type.search[b + a] = v.type.search.html) }) } function Nb(a) {
        return function () {
            var b = [xa(this[m.ext.iApiIndex])].concat(Array.prototype.slice.call(arguments)); return m.ext.internal[a].apply(this,
            b)
        }
    } var m = function (a) {
        this.$ = function (a, b) { return this.api(!0).$(a, b) }; this._ = function (a, b) { return this.api(!0).rows(a, b).data() }; this.api = function (a) { return a ? new r(xa(this[v.iApiIndex])) : new r(this) }; this.fnAddData = function (a, b) { var c = this.api(!0), d = h.isArray(a) && (h.isArray(a[0]) || h.isPlainObject(a[0])) ? c.rows.add(a) : c.row.add(a); (b === k || b) && c.draw(); return d.flatten().toArray() }; this.fnAdjustColumnSizing = function (a) {
            var b = this.api(!0).columns.adjust(), c = b.settings()[0], d = c.oScroll; a === k || a ? b.draw(!1) :
            ("" !== d.sX || "" !== d.sY) && ka(c)
        }; this.fnClearTable = function (a) { var b = this.api(!0).clear(); (a === k || a) && b.draw() }; this.fnClose = function (a) { this.api(!0).row(a).child.hide() }; this.fnDeleteRow = function (a, b, c) { var d = this.api(!0), a = d.rows(a), e = a.settings()[0], h = e.aoData[a[0][0]]; a.remove(); b && b.call(this, e, h); (c === k || c) && d.draw(); return h }; this.fnDestroy = function (a) { this.api(!0).destroy(a) }; this.fnDraw = function (a) { this.api(!0).draw(a) }; this.fnFilter = function (a, b, c, d, e, h) {
            e = this.api(!0); null === b || b === k ? e.search(a,
            c, d, h) : e.column(b).search(a, c, d, h); e.draw()
        }; this.fnGetData = function (a, b) { var c = this.api(!0); if (a !== k) { var d = a.nodeName ? a.nodeName.toLowerCase() : ""; return b !== k || "td" == d || "th" == d ? c.cell(a, b).data() : c.row(a).data() || null } return c.data().toArray() }; this.fnGetNodes = function (a) { var b = this.api(!0); return a !== k ? b.row(a).node() : b.rows().nodes().flatten().toArray() }; this.fnGetPosition = function (a) {
            var b = this.api(!0), c = a.nodeName.toUpperCase(); return "TR" == c ? b.row(a).index() : "TD" == c || "TH" == c ? (a = b.cell(a).index(),
            [a.row, a.columnVisible, a.column]) : null
        }; this.fnIsOpen = function (a) { return this.api(!0).row(a).child.isShown() }; this.fnOpen = function (a, b, c) { return this.api(!0).row(a).child(b, c).show().child()[0] }; this.fnPageChange = function (a, b) { var c = this.api(!0).page(a); (b === k || b) && c.draw(!1) }; this.fnSetColumnVis = function (a, b, c) { a = this.api(!0).column(a).visible(b); (c === k || c) && a.columns.adjust().draw() }; this.fnSettings = function () { return xa(this[v.iApiIndex]) }; this.fnSort = function (a) { this.api(!0).order(a).draw() }; this.fnSortListener =
        function (a, b, c) { this.api(!0).order.listener(a, b, c) }; this.fnUpdate = function (a, b, c, d, e) { var h = this.api(!0); c === k || null === c ? h.row(b).data(a) : h.cell(b, c).data(a); (e === k || e) && h.columns.adjust(); (d === k || d) && h.draw(); return 0 }; this.fnVersionCheck = v.fnVersionCheck; var b = this, c = a === k, d = this.length; c && (a = {}); this.oApi = this.internal = v.internal; for (var e in m.ext.internal) e && (this[e] = Nb(e)); this.each(function () {
            var e = {}, e = 1 < d ? Lb(e, a, !0) : a, g = 0, j, i = this.getAttribute("id"), n = !1, l = m.defaults, q = h(this); if ("table" !=
            this.nodeName.toLowerCase()) L(null, 0, "Non-table node initialisation (" + this.nodeName + ")", 2); else {
                eb(l); fb(l.column); K(l, l, !0); K(l.column, l.column, !0); K(l, h.extend(e, q.data())); var t = m.settings, g = 0; for (j = t.length; g < j; g++) {
                    var p = t[g]; if (p.nTable == this || p.nTHead.parentNode == this || p.nTFoot && p.nTFoot.parentNode == this) {
                        g = e.bRetrieve !== k ? e.bRetrieve : l.bRetrieve; if (c || g) return p.oInstance; if (e.bDestroy !== k ? e.bDestroy : l.bDestroy) { p.oInstance.fnDestroy(); break } else {
                            L(p, 0, "Cannot reinitialise DataTable", 3);
                            return
                        }
                    } if (p.sTableId == this.id) { t.splice(g, 1); break }
                } if (null === i || "" === i) this.id = i = "DataTables_Table_" + m.ext._unique++; var o = h.extend(!0, {}, m.models.oSettings, { sDestroyWidth: q[0].style.width, sInstance: i, sTableId: i }); o.nTable = this; o.oApi = b.internal; o.oInit = e; t.push(o); o.oInstance = 1 === b.length ? b : q.dataTable(); eb(e); e.oLanguage && Da(e.oLanguage); e.aLengthMenu && !e.iDisplayLength && (e.iDisplayLength = h.isArray(e.aLengthMenu[0]) ? e.aLengthMenu[0][0] : e.aLengthMenu[0]); e = Lb(h.extend(!0, {}, l), e); E(o.oFeatures,
                e, "bPaginate bLengthChange bFilter bSort bSortMulti bInfo bProcessing bAutoWidth bSortClasses bServerSide bDeferRender".split(" ")); E(o, e, ["asStripeClasses", "ajax", "fnServerData", "fnFormatNumber", "sServerMethod", "aaSorting", "aaSortingFixed", "aLengthMenu", "sPaginationType", "sAjaxSource", "sAjaxDataProp", "iStateDuration", "sDom", "bSortCellsTop", "iTabIndex", "fnStateLoadCallback", "fnStateSaveCallback", "renderer", "searchDelay", "rowId", ["iCookieDuration", "iStateDuration"], ["oSearch", "oPreviousSearch"], ["aoSearchCols",
                "aoPreSearchCols"], ["iDisplayLength", "_iDisplayLength"], ["bJQueryUI", "bJUI"]]); E(o.oScroll, e, [["sScrollX", "sX"], ["sScrollXInner", "sXInner"], ["sScrollY", "sY"], ["bScrollCollapse", "bCollapse"]]); E(o.oLanguage, e, "fnInfoCallback"); z(o, "aoDrawCallback", e.fnDrawCallback, "user"); z(o, "aoServerParams", e.fnServerParams, "user"); z(o, "aoStateSaveParams", e.fnStateSaveParams, "user"); z(o, "aoStateLoadParams", e.fnStateLoadParams, "user"); z(o, "aoStateLoaded", e.fnStateLoaded, "user"); z(o, "aoRowCallback", e.fnRowCallback,
                "user"); z(o, "aoRowCreatedCallback", e.fnCreatedRow, "user"); z(o, "aoHeaderCallback", e.fnHeaderCallback, "user"); z(o, "aoFooterCallback", e.fnFooterCallback, "user"); z(o, "aoInitComplete", e.fnInitComplete, "user"); z(o, "aoPreDrawCallback", e.fnPreDrawCallback, "user"); o.rowIdFn = Q(e.rowId); gb(o); i = o.oClasses; e.bJQueryUI ? (h.extend(i, m.ext.oJUIClasses, e.oClasses), e.sDom === l.sDom && "lfrtip" === l.sDom && (o.sDom = '<"H"lfr>t<"F"ip>'), o.renderer) ? h.isPlainObject(o.renderer) && !o.renderer.header && (o.renderer.header = "jqueryui") :
                o.renderer = "jqueryui" : h.extend(i, m.ext.classes, e.oClasses); q.addClass(i.sTable); o.iInitDisplayStart === k && (o.iInitDisplayStart = e.iDisplayStart, o._iDisplayStart = e.iDisplayStart); null !== e.iDeferLoading && (o.bDeferLoading = !0, g = h.isArray(e.iDeferLoading), o._iRecordsDisplay = g ? e.iDeferLoading[0] : e.iDeferLoading, o._iRecordsTotal = g ? e.iDeferLoading[1] : e.iDeferLoading); var r = o.oLanguage; h.extend(!0, r, e.oLanguage); "" !== r.sUrl && (h.ajax({
                    dataType: "json", url: r.sUrl, success: function (a) {
                        Da(a); K(l.oLanguage, a); h.extend(true,
                        r, a); ga(o)
                    }, error: function () { ga(o) }
                }), n = !0); null === e.asStripeClasses && (o.asStripeClasses = [i.sStripeOdd, i.sStripeEven]); var g = o.asStripeClasses, v = q.children("tbody").find("tr").eq(0); -1 !== h.inArray(!0, h.map(g, function (a) { return v.hasClass(a) })) && (h("tbody tr", this).removeClass(g.join(" ")), o.asDestroyStripes = g.slice()); t = []; g = this.getElementsByTagName("thead"); 0 !== g.length && (da(o.aoHeader, g[0]), t = qa(o)); if (null === e.aoColumns) { p = []; g = 0; for (j = t.length; g < j; g++) p.push(null) } else p = e.aoColumns; g = 0; for (j =
                p.length; g < j; g++) Ea(o, t ? t[g] : null); ib(o, e.aoColumnDefs, p, function (a, b) { ja(o, a, b) }); if (v.length) { var s = function (a, b) { return a.getAttribute("data-" + b) !== null ? b : null }; h(v[0]).children("th, td").each(function (a, b) { var c = o.aoColumns[a]; if (c.mData === a) { var d = s(b, "sort") || s(b, "order"), e = s(b, "filter") || s(b, "search"); if (d !== null || e !== null) { c.mData = { _: a + ".display", sort: d !== null ? a + ".@data-" + d : k, type: d !== null ? a + ".@data-" + d : k, filter: e !== null ? a + ".@data-" + e : k }; ja(o, a) } } }) } var w = o.oFeatures; e.bStateSave && (w.bStateSave =
                !0, Kb(o, e), z(o, "aoDrawCallback", wa, "state_save")); if (e.aaSorting === k) { t = o.aaSorting; g = 0; for (j = t.length; g < j; g++) t[g][1] = o.aoColumns[g].asSorting[0] } va(o); w.bSort && z(o, "aoDrawCallback", function () { if (o.bSorted) { var a = V(o), b = {}; h.each(a, function (a, c) { b[c.src] = c.dir }); u(o, null, "order", [o, a, b]); Jb(o) } }); z(o, "aoDrawCallback", function () { (o.bSorted || y(o) === "ssp" || w.bDeferRender) && va(o) }, "sc"); g = q.children("caption").each(function () { this._captionSide = q.css("caption-side") }); j = q.children("thead"); 0 === j.length &&
                (j = h("<thead/>").appendTo(this)); o.nTHead = j[0]; j = q.children("tbody"); 0 === j.length && (j = h("<tbody/>").appendTo(this)); o.nTBody = j[0]; j = q.children("tfoot"); if (0 === j.length && 0 < g.length && ("" !== o.oScroll.sX || "" !== o.oScroll.sY)) j = h("<tfoot/>").appendTo(this); 0 === j.length || 0 === j.children().length ? q.addClass(i.sNoFooter) : 0 < j.length && (o.nTFoot = j[0], da(o.aoFooter, o.nTFoot)); if (e.aaData) for (g = 0; g < e.aaData.length; g++) N(o, e.aaData[g]); else (o.bDeferLoading || "dom" == y(o)) && ma(o, h(o.nTBody).children("tr")); o.aiDisplay =
                o.aiDisplayMaster.slice(); o.bInitialised = !0; !1 === n && ga(o)
            }
        }); b = null; return this
    }, v, r, p, s, Ya = {}, Ob = /[\r\n]/g, Aa = /<.*?>/g, ac = /^[\w\+\-]/, bc = /[\w\+\-]$/, cc = RegExp("(\\/|\\.|\\*|\\+|\\?|\\||\\(|\\)|\\[|\\]|\\{|\\}|\\\\|\\$|\\^|\\-)", "g"), Xa = /[',$���%\u2009\u202F\u20BD\u20a9\u20BArfk]/gi, M = function (a) { return !a || !0 === a || "-" === a ? !0 : !1 }, Pb = function (a) { var b = parseInt(a, 10); return !isNaN(b) && isFinite(a) ? b : null }, Qb = function (a, b) {
        Ya[b] || (Ya[b] = RegExp(Qa(b), "g")); return "string" === typeof a && "." !== b ? a.replace(/\./g,
        "").replace(Ya[b], ".") : a
    }, Za = function (a, b, c) { var d = "string" === typeof a; if (M(a)) return !0; b && d && (a = Qb(a, b)); c && d && (a = a.replace(Xa, "")); return !isNaN(parseFloat(a)) && isFinite(a) }, Rb = function (a, b, c) { return M(a) ? !0 : !(M(a) || "string" === typeof a) ? null : Za(a.replace(Aa, ""), b, c) ? !0 : null }, G = function (a, b, c) { var d = [], e = 0, f = a.length; if (c !== k) for (; e < f; e++) a[e] && a[e][b] && d.push(a[e][b][c]); else for (; e < f; e++) a[e] && d.push(a[e][b]); return d }, ha = function (a, b, c, d) {
        var e = [], f = 0, g = b.length; if (d !== k) for (; f < g; f++) a[b[f]][c] &&
        e.push(a[b[f]][c][d]); else for (; f < g; f++) e.push(a[b[f]][c]); return e
    }, W = function (a, b) { var c = [], d; b === k ? (b = 0, d = a) : (d = b, b = a); for (var e = b; e < d; e++) c.push(e); return c }, Sb = function (a) { for (var b = [], c = 0, d = a.length; c < d; c++) a[c] && b.push(a[c]); return b }, pa = function (a) { var b = [], c, d, e = a.length, f, g = 0; d = 0; a: for (; d < e; d++) { c = a[d]; for (f = 0; f < g; f++) if (b[f] === c) continue a; b.push(c); g++ } return b }; m.util = {
        throttle: function (a, b) {
            var c = b !== k ? b : 200, d, e; return function () {
                var b = this, g = +new Date, h = arguments; d && g < d + c ? (clearTimeout(e),
                e = setTimeout(function () { d = k; a.apply(b, h) }, c)) : (d = g, a.apply(b, h))
            }
        }, escapeRegex: function (a) { return a.replace(cc, "\\$1") }
    }; var A = function (a, b, c) { a[b] !== k && (a[c] = a[b]) }, ba = /\[.*?\]$/, U = /\(\)$/, Qa = m.util.escapeRegex, ua = h("<div>")[0], Zb = ua.textContent !== k, $b = /<.*?>/g, Oa = m.util.throttle, Tb = [], w = Array.prototype, dc = function (a) {
        var b, c, d = m.settings, e = h.map(d, function (a) { return a.nTable }); if (a) {
            if (a.nTable && a.oApi) return [a]; if (a.nodeName && "table" === a.nodeName.toLowerCase()) return b = h.inArray(a, e), -1 !== b ? [d[b]] :
            null; if (a && "function" === typeof a.settings) return a.settings().toArray(); "string" === typeof a ? c = h(a) : a instanceof h && (c = a)
        } else return []; if (c) return c.map(function () { b = h.inArray(this, e); return -1 !== b ? d[b] : null }).toArray()
    }; r = function (a, b) { if (!(this instanceof r)) return new r(a, b); var c = [], d = function (a) { (a = dc(a)) && (c = c.concat(a)) }; if (h.isArray(a)) for (var e = 0, f = a.length; e < f; e++) d(a[e]); else d(a); this.context = pa(c); b && h.merge(this, b); this.selector = { rows: null, cols: null, opts: null }; r.extend(this, this, Tb) };
    m.Api = r; h.extend(r.prototype, {
        any: function () { return 0 !== this.count() }, concat: w.concat, context: [], count: function () { return this.flatten().length }, each: function (a) { for (var b = 0, c = this.length; b < c; b++) a.call(this, this[b], b, this); return this }, eq: function (a) { var b = this.context; return b.length > a ? new r(b[a], this[a]) : null }, filter: function (a) { var b = []; if (w.filter) b = w.filter.call(this, a, this); else for (var c = 0, d = this.length; c < d; c++) a.call(this, this[c], c, this) && b.push(this[c]); return new r(this.context, b) }, flatten: function () {
            var a =
            []; return new r(this.context, a.concat.apply(a, this.toArray()))
        }, join: w.join, indexOf: w.indexOf || function (a, b) { for (var c = b || 0, d = this.length; c < d; c++) if (this[c] === a) return c; return -1 }, iterator: function (a, b, c, d) {
            var e = [], f, g, h, i, n, l = this.context, m, t, p = this.selector; "string" === typeof a && (d = c, c = b, b = a, a = !1); g = 0; for (h = l.length; g < h; g++) {
                var o = new r(l[g]); if ("table" === b) f = c.call(o, l[g], g), f !== k && e.push(f); else if ("columns" === b || "rows" === b) f = c.call(o, l[g], this[g], g), f !== k && e.push(f); else if ("column" === b || "column-rows" ===
                b || "row" === b || "cell" === b) { t = this[g]; "column-rows" === b && (m = Ba(l[g], p.opts)); i = 0; for (n = t.length; i < n; i++) f = t[i], f = "cell" === b ? c.call(o, l[g], f.row, f.column, g, i) : c.call(o, l[g], f, g, i, m), f !== k && e.push(f) }
            } return e.length || d ? (a = new r(l, a ? e.concat.apply([], e) : e), b = a.selector, b.rows = p.rows, b.cols = p.cols, b.opts = p.opts, a) : this
        }, lastIndexOf: w.lastIndexOf || function (a, b) { return this.indexOf.apply(this.toArray.reverse(), arguments) }, length: 0, map: function (a) {
            var b = []; if (w.map) b = w.map.call(this, a, this); else for (var c =
            0, d = this.length; c < d; c++) b.push(a.call(this, this[c], c)); return new r(this.context, b)
        }, pluck: function (a) { return this.map(function (b) { return b[a] }) }, pop: w.pop, push: w.push, reduce: w.reduce || function (a, b) { return hb(this, a, b, 0, this.length, 1) }, reduceRight: w.reduceRight || function (a, b) { return hb(this, a, b, this.length - 1, -1, -1) }, reverse: w.reverse, selector: null, shift: w.shift, sort: w.sort, splice: w.splice, toArray: function () { return w.slice.call(this) }, to$: function () { return h(this) }, toJQuery: function () { return h(this) },
        unique: function () { return new r(this.context, pa(this)) }, unshift: w.unshift
    }); r.extend = function (a, b, c) { if (c.length && b && (b instanceof r || b.__dt_wrapper)) { var d, e, f, g = function (a, b, c) { return function () { var d = b.apply(a, arguments); r.extend(d, d, c.methodExt); return d } }; d = 0; for (e = c.length; d < e; d++) f = c[d], b[f.name] = "function" === typeof f.val ? g(a, f.val, f) : h.isPlainObject(f.val) ? {} : f.val, b[f.name].__dt_wrapper = !0, r.extend(a, b[f.name], f.propExt) } }; r.register = p = function (a, b) {
        if (h.isArray(a)) for (var c = 0, d = a.length; c <
        d; c++) r.register(a[c], b); else for (var e = a.split("."), f = Tb, g, j, c = 0, d = e.length; c < d; c++) { g = (j = -1 !== e[c].indexOf("()")) ? e[c].replace("()", "") : e[c]; var i; a: { i = 0; for (var n = f.length; i < n; i++) if (f[i].name === g) { i = f[i]; break a } i = null } i || (i = { name: g, val: {}, methodExt: [], propExt: [] }, f.push(i)); c === d - 1 ? i.val = b : f = j ? i.methodExt : i.propExt }
    }; r.registerPlural = s = function (a, b, c) {
        r.register(a, c); r.register(b, function () {
            var a = c.apply(this, arguments); return a === this ? this : a instanceof r ? a.length ? h.isArray(a[0]) ? new r(a.context,
            a[0]) : a[0] : k : a
        })
    }; p("tables()", function (a) { var b; if (a) { b = r; var c = this.context; if ("number" === typeof a) a = [c[a]]; else var d = h.map(c, function (a) { return a.nTable }), a = h(d).filter(a).map(function () { var a = h.inArray(this, d); return c[a] }).toArray(); b = new b(a) } else b = this; return b }); p("table()", function (a) { var a = this.tables(a), b = a.context; return b.length ? new r(b[0]) : a }); s("tables().nodes()", "table().node()", function () { return this.iterator("table", function (a) { return a.nTable }, 1) }); s("tables().body()", "table().body()",
    function () { return this.iterator("table", function (a) { return a.nTBody }, 1) }); s("tables().header()", "table().header()", function () { return this.iterator("table", function (a) { return a.nTHead }, 1) }); s("tables().footer()", "table().footer()", function () { return this.iterator("table", function (a) { return a.nTFoot }, 1) }); s("tables().containers()", "table().container()", function () { return this.iterator("table", function (a) { return a.nTableWrapper }, 1) }); p("draw()", function (a) {
        return this.iterator("table", function (b) {
            "page" ===
            a ? O(b) : ("string" === typeof a && (a = "full-hold" === a ? !1 : !0), T(b, !1 === a))
        })
    }); p("page()", function (a) { return a === k ? this.page.info().page : this.iterator("table", function (b) { Ta(b, a) }) }); p("page.info()", function () {
        if (0 === this.context.length) return k; var a = this.context[0], b = a._iDisplayStart, c = a.oFeatures.bPaginate ? a._iDisplayLength : -1, d = a.fnRecordsDisplay(), e = -1 === c; return {
            page: e ? 0 : Math.floor(b / c), pages: e ? 1 : Math.ceil(d / c), start: b, end: a.fnDisplayEnd(), length: c, recordsTotal: a.fnRecordsTotal(), recordsDisplay: d,
            serverSide: "ssp" === y(a)
        }
    }); p("page.len()", function (a) { return a === k ? 0 !== this.context.length ? this.context[0]._iDisplayLength : k : this.iterator("table", function (b) { Ra(b, a) }) }); var Ub = function (a, b, c) { if (c) { var d = new r(a); d.one("draw", function () { c(d.ajax.json()) }) } if ("ssp" == y(a)) T(a, b); else { C(a, !0); var e = a.jqXHR; e && 4 !== e.readyState && e.abort(); ra(a, [], function (c) { na(a); for (var c = sa(a, c), d = 0, e = c.length; d < e; d++) N(a, c[d]); T(a, b); C(a, !1) }) } }; p("ajax.json()", function () { var a = this.context; if (0 < a.length) return a[0].json });
    p("ajax.params()", function () { var a = this.context; if (0 < a.length) return a[0].oAjaxData }); p("ajax.reload()", function (a, b) { return this.iterator("table", function (c) { Ub(c, !1 === b, a) }) }); p("ajax.url()", function (a) { var b = this.context; if (a === k) { if (0 === b.length) return k; b = b[0]; return b.ajax ? h.isPlainObject(b.ajax) ? b.ajax.url : b.ajax : b.sAjaxSource } return this.iterator("table", function (b) { h.isPlainObject(b.ajax) ? b.ajax.url = a : b.ajax = a }) }); p("ajax.url().load()", function (a, b) {
        return this.iterator("table", function (c) {
            Ub(c,
            !1 === b, a)
        })
    }); var $a = function (a, b, c, d, e) { var f = [], g, j, i, n, l, m; i = typeof b; if (!b || "string" === i || "function" === i || b.length === k) b = [b]; i = 0; for (n = b.length; i < n; i++) { j = b[i] && b[i].split ? b[i].split(",") : [b[i]]; l = 0; for (m = j.length; l < m; l++) (g = c("string" === typeof j[l] ? h.trim(j[l]) : j[l])) && g.length && (f = f.concat(g)) } a = v.selector[a]; if (a.length) { i = 0; for (n = a.length; i < n; i++) f = a[i](d, e, f) } return pa(f) }, ab = function (a) {
        a || (a = {}); a.filter && a.search === k && (a.search = a.filter); return h.extend({
            search: "none", order: "current",
            page: "all"
        }, a)
    }, bb = function (a) { for (var b = 0, c = a.length; b < c; b++) if (0 < a[b].length) return a[0] = a[b], a[0].length = 1, a.length = 1, a.context = [a.context[b]], a; a.length = 0; return a }, Ba = function (a, b) {
        var c, d, e, f = [], g = a.aiDisplay; c = a.aiDisplayMaster; var j = b.search; d = b.order; e = b.page; if ("ssp" == y(a)) return "removed" === j ? [] : W(0, c.length); if ("current" == e) { c = a._iDisplayStart; for (d = a.fnDisplayEnd() ; c < d; c++) f.push(g[c]) } else if ("current" == d || "applied" == d) f = "none" == j ? c.slice() : "applied" == j ? g.slice() : h.map(c, function (a) {
            return -1 ===
            h.inArray(a, g) ? a : null
        }); else if ("index" == d || "original" == d) { c = 0; for (d = a.aoData.length; c < d; c++) "none" == j ? f.push(c) : (e = h.inArray(c, g), (-1 === e && "removed" == j || 0 <= e && "applied" == j) && f.push(c)) } return f
    }; p("rows()", function (a, b) {
        a === k ? a = "" : h.isPlainObject(a) && (b = a, a = ""); var b = ab(b), c = this.iterator("table", function (c) {
            var e = b; return $a("row", a, function (a) {
                var b = Pb(a); if (b !== null && !e) return [b]; var j = Ba(c, e); if (b !== null && h.inArray(b, j) !== -1) return [b]; if (!a) return j; if (typeof a === "function") return h.map(j, function (b) {
                    var e =
                    c.aoData[b]; return a(b, e._aData, e.nTr) ? b : null
                }); b = Sb(ha(c.aoData, j, "nTr")); if (a.nodeName) { if (a._DT_RowIndex !== k) return [a._DT_RowIndex]; if (a._DT_CellIndex) return [a._DT_CellIndex.row]; b = h(a).closest("*[data-dt-row]"); return b.length ? [b.data("dt-row")] : [] } if (typeof a === "string" && a.charAt(0) === "#") { j = c.aIds[a.replace(/^#/, "")]; if (j !== k) return [j.idx] } return h(b).filter(a).map(function () { return this._DT_RowIndex }).toArray()
            }, c, e)
        }, 1); c.selector.rows = a; c.selector.opts = b; return c
    }); p("rows().nodes()", function () {
        return this.iterator("row",
        function (a, b) { return a.aoData[b].nTr || k }, 1)
    }); p("rows().data()", function () { return this.iterator(!0, "rows", function (a, b) { return ha(a.aoData, b, "_aData") }, 1) }); s("rows().cache()", "row().cache()", function (a) { return this.iterator("row", function (b, c) { var d = b.aoData[c]; return "search" === a ? d._aFilterData : d._aSortData }, 1) }); s("rows().invalidate()", "row().invalidate()", function (a) { return this.iterator("row", function (b, c) { ca(b, c, a) }) }); s("rows().indexes()", "row().index()", function () {
        return this.iterator("row",
        function (a, b) { return b }, 1)
    }); s("rows().ids()", "row().id()", function (a) { for (var b = [], c = this.context, d = 0, e = c.length; d < e; d++) for (var f = 0, g = this[d].length; f < g; f++) { var h = c[d].rowIdFn(c[d].aoData[this[d][f]]._aData); b.push((!0 === a ? "#" : "") + h) } return new r(c, b) }); s("rows().remove()", "row().remove()", function () {
        var a = this; this.iterator("row", function (b, c, d) {
            var e = b.aoData, f = e[c], g, h, i, n, l; e.splice(c, 1); g = 0; for (h = e.length; g < h; g++) if (i = e[g], l = i.anCells, null !== i.nTr && (i.nTr._DT_RowIndex = g), null !== l) {
                i = 0; for (n =
                l.length; i < n; i++) l[i]._DT_CellIndex.row = g
            } oa(b.aiDisplayMaster, c); oa(b.aiDisplay, c); oa(a[d], c, !1); Sa(b); c = b.rowIdFn(f._aData); c !== k && delete b.aIds[c]
        }); this.iterator("table", function (a) { for (var c = 0, d = a.aoData.length; c < d; c++) a.aoData[c].idx = c }); return this
    }); p("rows.add()", function (a) {
        var b = this.iterator("table", function (b) { var c, f, g, h = []; f = 0; for (g = a.length; f < g; f++) c = a[f], c.nodeName && "TR" === c.nodeName.toUpperCase() ? h.push(ma(b, c)[0]) : h.push(N(b, c)); return h }, 1), c = this.rows(-1); c.pop(); h.merge(c, b);
        return c
    }); p("row()", function (a, b) { return bb(this.rows(a, b)) }); p("row().data()", function (a) { var b = this.context; if (a === k) return b.length && this.length ? b[0].aoData[this[0]]._aData : k; b[0].aoData[this[0]]._aData = a; ca(b[0], this[0], "data"); return this }); p("row().node()", function () { var a = this.context; return a.length && this.length ? a[0].aoData[this[0]].nTr || null : null }); p("row.add()", function (a) {
        a instanceof h && a.length && (a = a[0]); var b = this.iterator("table", function (b) {
            return a.nodeName && "TR" === a.nodeName.toUpperCase() ?
            ma(b, a)[0] : N(b, a)
        }); return this.row(b[0])
    }); var cb = function (a, b) { var c = a.context; if (c.length && (c = c[0].aoData[b !== k ? b : a[0]]) && c._details) c._details.remove(), c._detailsShow = k, c._details = k }, Vb = function (a, b) {
        var c = a.context; if (c.length && a.length) {
            var d = c[0].aoData[a[0]]; if (d._details) {
                (d._detailsShow = b) ? d._details.insertAfter(d.nTr) : d._details.detach(); var e = c[0], f = new r(e), g = e.aoData; f.off("draw.dt.DT_details column-visibility.dt.DT_details destroy.dt.DT_details"); 0 < G(g, "_details").length && (f.on("draw.dt.DT_details",
                function (a, b) { e === b && f.rows({ page: "current" }).eq(0).each(function (a) { a = g[a]; a._detailsShow && a._details.insertAfter(a.nTr) }) }), f.on("column-visibility.dt.DT_details", function (a, b) { if (e === b) for (var c, d = aa(b), f = 0, h = g.length; f < h; f++) c = g[f], c._details && c._details.children("td[colspan]").attr("colspan", d) }), f.on("destroy.dt.DT_details", function (a, b) { if (e === b) for (var c = 0, d = g.length; c < d; c++) g[c]._details && cb(f, c) }))
            }
        }
    }; p("row().child()", function (a, b) {
        var c = this.context; if (a === k) return c.length && this.length ?
        c[0].aoData[this[0]]._details : k; if (!0 === a) this.child.show(); else if (!1 === a) cb(this); else if (c.length && this.length) { var d = c[0], c = c[0].aoData[this[0]], e = [], f = function (a, b) { if (h.isArray(a) || a instanceof h) for (var c = 0, k = a.length; c < k; c++) f(a[c], b); else a.nodeName && "tr" === a.nodeName.toLowerCase() ? e.push(a) : (c = h("<tr><td/></tr>").addClass(b), h("td", c).addClass(b).html(a)[0].colSpan = aa(d), e.push(c[0])) }; f(a, b); c._details && c._details.remove(); c._details = h(e); c._detailsShow && c._details.insertAfter(c.nTr) } return this
    });
    p(["row().child.show()", "row().child().show()"], function () { Vb(this, !0); return this }); p(["row().child.hide()", "row().child().hide()"], function () { Vb(this, !1); return this }); p(["row().child.remove()", "row().child().remove()"], function () { cb(this); return this }); p("row().child.isShown()", function () { var a = this.context; return a.length && this.length ? a[0].aoData[this[0]]._detailsShow || !1 : !1 }); var ec = /^(.+):(name|visIdx|visible)$/, Wb = function (a, b, c, d, e) {
        for (var c = [], d = 0, f = e.length; d < f; d++) c.push(B(a, e[d], b));
        return c
    }; p("columns()", function (a, b) {
        a === k ? a = "" : h.isPlainObject(a) && (b = a, a = ""); var b = ab(b), c = this.iterator("table", function (c) {
            var e = a, f = b, g = c.aoColumns, j = G(g, "sName"), i = G(g, "nTh"); return $a("column", e, function (a) {
                var b = Pb(a); if (a === "") return W(g.length); if (b !== null) return [b >= 0 ? b : g.length + b]; if (typeof a === "function") { var e = Ba(c, f); return h.map(g, function (b, f) { return a(f, Wb(c, f, 0, 0, e), i[f]) ? f : null }) } var k = typeof a === "string" ? a.match(ec) : ""; if (k) switch (k[2]) {
                    case "visIdx": case "visible": b = parseInt(k[1],
                    10); if (b < 0) { var m = h.map(g, function (a, b) { return a.bVisible ? b : null }); return [m[m.length + b]] } return [Z(c, b)]; case "name": return h.map(j, function (a, b) { return a === k[1] ? b : null }); default: return []
                } if (a.nodeName && a._DT_CellIndex) return [a._DT_CellIndex.column]; b = h(i).filter(a).map(function () { return h.inArray(this, i) }).toArray(); if (b.length || !a.nodeName) return b; b = h(a).closest("*[data-dt-column]"); return b.length ? [b.data("dt-column")] : []
            }, c, f)
        }, 1); c.selector.cols = a; c.selector.opts = b; return c
    }); s("columns().header()",
    "column().header()", function () { return this.iterator("column", function (a, b) { return a.aoColumns[b].nTh }, 1) }); s("columns().footer()", "column().footer()", function () { return this.iterator("column", function (a, b) { return a.aoColumns[b].nTf }, 1) }); s("columns().data()", "column().data()", function () { return this.iterator("column-rows", Wb, 1) }); s("columns().dataSrc()", "column().dataSrc()", function () { return this.iterator("column", function (a, b) { return a.aoColumns[b].mData }, 1) }); s("columns().cache()", "column().cache()",
    function (a) { return this.iterator("column-rows", function (b, c, d, e, f) { return ha(b.aoData, f, "search" === a ? "_aFilterData" : "_aSortData", c) }, 1) }); s("columns().nodes()", "column().nodes()", function () { return this.iterator("column-rows", function (a, b, c, d, e) { return ha(a.aoData, e, "anCells", b) }, 1) }); s("columns().visible()", "column().visible()", function (a, b) {
        var c = this.iterator("column", function (b, c) {
            if (a === k) return b.aoColumns[c].bVisible; var f = b.aoColumns, g = f[c], j = b.aoData, i, n, l; if (a !== k && g.bVisible !== a) {
                if (a) {
                    var m =
                    h.inArray(!0, G(f, "bVisible"), c + 1); i = 0; for (n = j.length; i < n; i++) l = j[i].nTr, f = j[i].anCells, l && l.insertBefore(f[c], f[m] || null)
                } else h(G(b.aoData, "anCells", c)).detach(); g.bVisible = a; ea(b, b.aoHeader); ea(b, b.aoFooter); wa(b)
            }
        }); a !== k && (this.iterator("column", function (c, e) { u(c, null, "column-visibility", [c, e, a, b]) }), (b === k || b) && this.columns.adjust()); return c
    }); s("columns().indexes()", "column().index()", function (a) { return this.iterator("column", function (b, c) { return "visible" === a ? $(b, c) : c }, 1) }); p("columns.adjust()",
    function () { return this.iterator("table", function (a) { Y(a) }, 1) }); p("column.index()", function (a, b) { if (0 !== this.context.length) { var c = this.context[0]; if ("fromVisible" === a || "toData" === a) return Z(c, b); if ("fromData" === a || "toVisible" === a) return $(c, b) } }); p("column()", function (a, b) { return bb(this.columns(a, b)) }); p("cells()", function (a, b, c) {
        h.isPlainObject(a) && (a.row === k ? (c = a, a = null) : (c = b, b = null)); h.isPlainObject(b) && (c = b, b = null); if (null === b || b === k) return this.iterator("table", function (b) {
            var d = a, e = ab(c), f =
            b.aoData, g = Ba(b, e), j = Sb(ha(f, g, "anCells")), i = h([].concat.apply([], j)), l, n = b.aoColumns.length, m, p, r, u, v, s; return $a("cell", d, function (a) {
                var c = typeof a === "function"; if (a === null || a === k || c) { m = []; p = 0; for (r = g.length; p < r; p++) { l = g[p]; for (u = 0; u < n; u++) { v = { row: l, column: u }; if (c) { s = f[l]; a(v, B(b, l, u), s.anCells ? s.anCells[u] : null) && m.push(v) } else m.push(v) } } return m } if (h.isPlainObject(a)) return [a]; c = i.filter(a).map(function (a, b) { return { row: b._DT_CellIndex.row, column: b._DT_CellIndex.column } }).toArray(); if (c.length ||
                !a.nodeName) return c; s = h(a).closest("*[data-dt-row]"); return s.length ? [{ row: s.data("dt-row"), column: s.data("dt-column") }] : []
            }, b, e)
        }); var d = this.columns(b, c), e = this.rows(a, c), f, g, j, i, n, l = this.iterator("table", function (a, b) { f = []; g = 0; for (j = e[b].length; g < j; g++) { i = 0; for (n = d[b].length; i < n; i++) f.push({ row: e[b][g], column: d[b][i] }) } return f }, 1); h.extend(l.selector, { cols: b, rows: a, opts: c }); return l
    }); s("cells().nodes()", "cell().node()", function () {
        return this.iterator("cell", function (a, b, c) {
            return (a = a.aoData[b]) &&
            a.anCells ? a.anCells[c] : k
        }, 1)
    }); p("cells().data()", function () { return this.iterator("cell", function (a, b, c) { return B(a, b, c) }, 1) }); s("cells().cache()", "cell().cache()", function (a) { a = "search" === a ? "_aFilterData" : "_aSortData"; return this.iterator("cell", function (b, c, d) { return b.aoData[c][a][d] }, 1) }); s("cells().render()", "cell().render()", function (a) { return this.iterator("cell", function (b, c, d) { return B(b, c, d, a) }, 1) }); s("cells().indexes()", "cell().index()", function () {
        return this.iterator("cell", function (a,
        b, c) { return { row: b, column: c, columnVisible: $(a, c) } }, 1)
    }); s("cells().invalidate()", "cell().invalidate()", function (a) { return this.iterator("cell", function (b, c, d) { ca(b, c, a, d) }) }); p("cell()", function (a, b, c) { return bb(this.cells(a, b, c)) }); p("cell().data()", function (a) { var b = this.context, c = this[0]; if (a === k) return b.length && c.length ? B(b[0], c[0].row, c[0].column) : k; jb(b[0], c[0].row, c[0].column, a); ca(b[0], c[0].row, "data", c[0].column); return this }); p("order()", function (a, b) {
        var c = this.context; if (a === k) return 0 !==
        c.length ? c[0].aaSorting : k; "number" === typeof a ? a = [[a, b]] : a.length && !h.isArray(a[0]) && (a = Array.prototype.slice.call(arguments)); return this.iterator("table", function (b) { b.aaSorting = a.slice() })
    }); p("order.listener()", function (a, b, c) { return this.iterator("table", function (d) { Ma(d, a, b, c) }) }); p("order.fixed()", function (a) { if (!a) { var b = this.context, b = b.length ? b[0].aaSortingFixed : k; return h.isArray(b) ? { pre: b } : b } return this.iterator("table", function (b) { b.aaSortingFixed = h.extend(!0, {}, a) }) }); p(["columns().order()",
    "column().order()"], function (a) { var b = this; return this.iterator("table", function (c, d) { var e = []; h.each(b[d], function (b, c) { e.push([c, a]) }); c.aaSorting = e }) }); p("search()", function (a, b, c, d) { var e = this.context; return a === k ? 0 !== e.length ? e[0].oPreviousSearch.sSearch : k : this.iterator("table", function (e) { e.oFeatures.bFilter && fa(e, h.extend({}, e.oPreviousSearch, { sSearch: a + "", bRegex: null === b ? !1 : b, bSmart: null === c ? !0 : c, bCaseInsensitive: null === d ? !0 : d }), 1) }) }); s("columns().search()", "column().search()", function (a,
    b, c, d) { return this.iterator("column", function (e, f) { var g = e.aoPreSearchCols; if (a === k) return g[f].sSearch; e.oFeatures.bFilter && (h.extend(g[f], { sSearch: a + "", bRegex: null === b ? !1 : b, bSmart: null === c ? !0 : c, bCaseInsensitive: null === d ? !0 : d }), fa(e, e.oPreviousSearch, 1)) }) }); p("state()", function () { return this.context.length ? this.context[0].oSavedState : null }); p("state.clear()", function () { return this.iterator("table", function (a) { a.fnStateSaveCallback.call(a.oInstance, a, {}) }) }); p("state.loaded()", function () {
        return this.context.length ?
        this.context[0].oLoadedState : null
    }); p("state.save()", function () { return this.iterator("table", function (a) { wa(a) }) }); m.versionCheck = m.fnVersionCheck = function (a) { for (var b = m.version.split("."), a = a.split("."), c, d, e = 0, f = a.length; e < f; e++) if (c = parseInt(b[e], 10) || 0, d = parseInt(a[e], 10) || 0, c !== d) return c > d; return !0 }; m.isDataTable = m.fnIsDataTable = function (a) {
        var b = h(a).get(0), c = !1; h.each(m.settings, function (a, e) {
            var f = e.nScrollHead ? h("table", e.nScrollHead)[0] : null, g = e.nScrollFoot ? h("table", e.nScrollFoot)[0] :
            null; if (e.nTable === b || f === b || g === b) c = !0
        }); return c
    }; m.tables = m.fnTables = function (a) { var b = !1; h.isPlainObject(a) && (b = a.api, a = a.visible); var c = h.map(m.settings, function (b) { if (!a || a && h(b.nTable).is(":visible")) return b.nTable }); return b ? new r(c) : c }; m.camelToHungarian = K; p("$()", function (a, b) { var c = this.rows(b).nodes(), c = h(c); return h([].concat(c.filter(a).toArray(), c.find(a).toArray())) }); h.each(["on", "one", "off"], function (a, b) {
        p(b + "()", function () {
            var a = Array.prototype.slice.call(arguments); a[0].match(/\.dt\b/) ||
            (a[0] += ".dt"); var d = h(this.tables().nodes()); d[b].apply(d, a); return this
        })
    }); p("clear()", function () { return this.iterator("table", function (a) { na(a) }) }); p("settings()", function () { return new r(this.context, this.context) }); p("init()", function () { var a = this.context; return a.length ? a[0].oInit : null }); p("data()", function () { return this.iterator("table", function (a) { return G(a.aoData, "_aData") }).flatten() }); p("destroy()", function (a) {
        a = a || !1; return this.iterator("table", function (b) {
            var c = b.nTableWrapper.parentNode,
            d = b.oClasses, e = b.nTable, f = b.nTBody, g = b.nTHead, j = b.nTFoot, i = h(e), f = h(f), k = h(b.nTableWrapper), l = h.map(b.aoData, function (a) { return a.nTr }), p; b.bDestroying = !0; u(b, "aoDestroyCallback", "destroy", [b]); a || (new r(b)).columns().visible(!0); k.unbind(".DT").find(":not(tbody *)").unbind(".DT"); h(D).unbind(".DT-" + b.sInstance); e != g.parentNode && (i.children("thead").detach(), i.append(g)); j && e != j.parentNode && (i.children("tfoot").detach(), i.append(j)); b.aaSorting = []; b.aaSortingFixed = []; va(b); h(l).removeClass(b.asStripeClasses.join(" "));
            h("th, td", g).removeClass(d.sSortable + " " + d.sSortableAsc + " " + d.sSortableDesc + " " + d.sSortableNone); b.bJUI && (h("th span." + d.sSortIcon + ", td span." + d.sSortIcon, g).detach(), h("th, td", g).each(function () { var a = h("div." + d.sSortJUIWrapper, this); h(this).append(a.contents()); a.detach() })); f.children().detach(); f.append(l); g = a ? "remove" : "detach"; i[g](); k[g](); !a && c && (c.insertBefore(e, b.nTableReinsertBefore), i.css("width", b.sDestroyWidth).removeClass(d.sTable), (p = b.asDestroyStripes.length) && f.children().each(function (a) {
                h(this).addClass(b.asDestroyStripes[a %
                p])
            })); c = h.inArray(b, m.settings); -1 !== c && m.settings.splice(c, 1)
        })
    }); h.each(["column", "row", "cell"], function (a, b) { p(b + "s().every()", function (a) { var d = this.selector.opts, e = this; return this.iterator(b, function (f, g, h, i, n) { a.call(e[b](g, "cell" === b ? h : d, "cell" === b ? d : k), g, h, i, n) }) }) }); p("i18n()", function (a, b, c) { var d = this.context[0], a = Q(a)(d.oLanguage); a === k && (a = b); c !== k && h.isPlainObject(a) && (a = a[c] !== k ? a[c] : a._); return a.replace("%d", c) }); m.version = "1.10.12"; m.settings = []; m.models = {}; m.models.oSearch = {
        bCaseInsensitive: !0,
        sSearch: "", bRegex: !1, bSmart: !0
    }; m.models.oRow = { nTr: null, anCells: null, _aData: [], _aSortData: null, _aFilterData: null, _sFilterRow: null, _sRowStripe: "", src: null, idx: -1 }; m.models.oColumn = {
        idx: null, aDataSort: null, asSorting: null, bSearchable: null, bSortable: null, bVisible: null, _sManualType: null, _bAttrSrc: !1, fnCreatedCell: null, fnGetData: null, fnSetData: null, mData: null, mRender: null, nTh: null, nTf: null, sClass: null, sContentPadding: null, sDefaultContent: null, sName: null, sSortDataType: "std", sSortingClass: null, sSortingClassJUI: null,
        sTitle: null, sType: null, sWidth: null, sWidthOrig: null
    }; m.defaults = {
        aaData: null, aaSorting: [[0, "asc"]], aaSortingFixed: [], ajax: null, aLengthMenu: [10, 25, 50, 100], aoColumns: null, aoColumnDefs: null, aoSearchCols: [], asStripeClasses: null, bAutoWidth: !0, bDeferRender: !1, bDestroy: !1, bFilter: !0, bInfo: !0, bJQueryUI: !1, bLengthChange: !0, bPaginate: !0, bProcessing: !1, bRetrieve: !1, bScrollCollapse: !1, bServerSide: !1, bSort: !0, bSortMulti: !0, bSortCellsTop: !1, bSortClasses: !0, bStateSave: !1, fnCreatedRow: null, fnDrawCallback: null, fnFooterCallback: null,
        fnFormatNumber: function (a) { return a.toString().replace(/\B(?=(\d{3})+(?!\d))/g, this.oLanguage.sThousands) }, fnHeaderCallback: null, fnInfoCallback: null, fnInitComplete: null, fnPreDrawCallback: null, fnRowCallback: null, fnServerData: null, fnServerParams: null, fnStateLoadCallback: function (a) { try { return JSON.parse((-1 === a.iStateDuration ? sessionStorage : localStorage).getItem("DataTables_" + a.sInstance + "_" + location.pathname)) } catch (b) { } }, fnStateLoadParams: null, fnStateLoaded: null, fnStateSaveCallback: function (a, b) {
            try {
                (-1 ===
                a.iStateDuration ? sessionStorage : localStorage).setItem("DataTables_" + a.sInstance + "_" + location.pathname, JSON.stringify(b))
            } catch (c) { }
        }, fnStateSaveParams: null, iStateDuration: 7200, iDeferLoading: null, iDisplayLength: 10, iDisplayStart: 0, iTabIndex: 0, oClasses: {}, oLanguage: {
            oAria: { sSortAscending: ": activate to sort column ascending", sSortDescending: ": activate to sort column descending" }, oPaginate: { sFirst: "First", sLast: "Last", sNext: "Next", sPrevious: "Previous" }, sEmptyTable: "No data available in table", sInfo: "Showing _START_ to _END_ of _TOTAL_ entries",
            sInfoEmpty: "Showing 0 to 0 of 0 entries", sInfoFiltered: "(filtered from _MAX_ total entries)", sInfoPostFix: "", sDecimal: "", sThousands: ",", sLengthMenu: "Show _MENU_ entries", sLoadingRecords: "Loading...", sProcessing: "Processing...", sSearch: "Search:", sSearchPlaceholder: "", sUrl: "", sZeroRecords: "No matching records found"
        }, oSearch: h.extend({}, m.models.oSearch), sAjaxDataProp: "data", sAjaxSource: null, sDom: "lfrtip", searchDelay: null, sPaginationType: "simple_numbers", sScrollX: "", sScrollXInner: "", sScrollY: "", sServerMethod: "GET",
        renderer: null, rowId: "DT_RowId"
    }; X(m.defaults); m.defaults.column = { aDataSort: null, iDataSort: -1, asSorting: ["asc", "desc"], bSearchable: !0, bSortable: !0, bVisible: !0, fnCreatedCell: null, mData: null, mRender: null, sCellType: "td", sClass: "", sContentPadding: "", sDefaultContent: null, sName: "", sSortDataType: "std", sTitle: null, sType: null, sWidth: null }; X(m.defaults.column); m.models.oSettings = {
        oFeatures: {
            bAutoWidth: null, bDeferRender: null, bFilter: null, bInfo: null, bLengthChange: null, bPaginate: null, bProcessing: null, bServerSide: null,
            bSort: null, bSortMulti: null, bSortClasses: null, bStateSave: null
        }, oScroll: { bCollapse: null, iBarWidth: 0, sX: null, sXInner: null, sY: null }, oLanguage: { fnInfoCallback: null }, oBrowser: { bScrollOversize: !1, bScrollbarLeft: !1, bBounding: !1, barWidth: 0 }, ajax: null, aanFeatures: [], aoData: [], aiDisplay: [], aiDisplayMaster: [], aIds: {}, aoColumns: [], aoHeader: [], aoFooter: [], oPreviousSearch: {}, aoPreSearchCols: [], aaSorting: null, aaSortingFixed: [], asStripeClasses: null, asDestroyStripes: [], sDestroyWidth: 0, aoRowCallback: [], aoHeaderCallback: [],
        aoFooterCallback: [], aoDrawCallback: [], aoRowCreatedCallback: [], aoPreDrawCallback: [], aoInitComplete: [], aoStateSaveParams: [], aoStateLoadParams: [], aoStateLoaded: [], sTableId: "", nTable: null, nTHead: null, nTFoot: null, nTBody: null, nTableWrapper: null, bDeferLoading: !1, bInitialised: !1, aoOpenRows: [], sDom: null, searchDelay: null, sPaginationType: "two_button", iStateDuration: 0, aoStateSave: [], aoStateLoad: [], oSavedState: null, oLoadedState: null, sAjaxSource: null, sAjaxDataProp: null, bAjaxDataGet: !0, jqXHR: null, json: k, oAjaxData: k,
        fnServerData: null, aoServerParams: [], sServerMethod: null, fnFormatNumber: null, aLengthMenu: null, iDraw: 0, bDrawing: !1, iDrawError: -1, _iDisplayLength: 10, _iDisplayStart: 0, _iRecordsTotal: 0, _iRecordsDisplay: 0, bJUI: null, oClasses: {}, bFiltered: !1, bSorted: !1, bSortCellsTop: null, oInit: null, aoDestroyCallback: [], fnRecordsTotal: function () { return "ssp" == y(this) ? 1 * this._iRecordsTotal : this.aiDisplayMaster.length }, fnRecordsDisplay: function () { return "ssp" == y(this) ? 1 * this._iRecordsDisplay : this.aiDisplay.length }, fnDisplayEnd: function () {
            var a =
            this._iDisplayLength, b = this._iDisplayStart, c = b + a, d = this.aiDisplay.length, e = this.oFeatures, f = e.bPaginate; return e.bServerSide ? !1 === f || -1 === a ? b + d : Math.min(b + a, this._iRecordsDisplay) : !f || c > d || -1 === a ? d : c
        }, oInstance: null, sInstance: null, iTabIndex: 0, nScrollHead: null, nScrollFoot: null, aLastSort: [], oPlugins: {}, rowIdFn: null, rowId: null
    }; m.ext = v = {
        buttons: {}, classes: {}, builder: "-source-", errMode: "alert", feature: [], search: [], selector: { cell: [], column: [], row: [] }, internal: {}, legacy: { ajax: null }, pager: {}, renderer: {
            pageButton: {},
            header: {}
        }, order: {}, type: { detect: [], search: {}, order: {} }, _unique: 0, fnVersionCheck: m.fnVersionCheck, iApiIndex: 0, oJUIClasses: {}, sVersion: m.version
    }; h.extend(v, { afnFiltering: v.search, aTypes: v.type.detect, ofnSearch: v.type.search, oSort: v.type.order, afnSortData: v.order, aoFeatures: v.feature, oApi: v.internal, oStdClasses: v.classes, oPagination: v.pager }); h.extend(m.ext.classes, {
        sTable: "dataTable", sNoFooter: "no-footer", sPageButton: "paginate_button", sPageButtonActive: "current", sPageButtonDisabled: "disabled", sStripeOdd: "odd",
        sStripeEven: "even", sRowEmpty: "dataTables_empty", sWrapper: "dataTables_wrapper", sFilter: "dataTables_filter", sInfo: "dataTables_info", sPaging: "dataTables_paginate paging_", sLength: "dataTables_length", sProcessing: "dataTables_processing", sSortAsc: "sorting_asc", sSortDesc: "sorting_desc", sSortable: "sorting", sSortableAsc: "sorting_asc_disabled", sSortableDesc: "sorting_desc_disabled", sSortableNone: "sorting_disabled", sSortColumn: "sorting_", sFilterInput: "", sLengthSelect: "", sScrollWrapper: "dataTables_scroll", sScrollHead: "dataTables_scrollHead",
        sScrollHeadInner: "dataTables_scrollHeadInner", sScrollBody: "dataTables_scrollBody", sScrollFoot: "dataTables_scrollFoot", sScrollFootInner: "dataTables_scrollFootInner", sHeaderTH: "", sFooterTH: "", sSortJUIAsc: "", sSortJUIDesc: "", sSortJUI: "", sSortJUIAscAllowed: "", sSortJUIDescAllowed: "", sSortJUIWrapper: "", sSortIcon: "", sJUIHeader: "", sJUIFooter: ""
    }); var Ca = "", Ca = "", H = Ca + "ui-state-default", ia = Ca + "css_right ui-icon ui-icon-", Xb = Ca + "fg-toolbar ui-toolbar ui-widget-header ui-helper-clearfix"; h.extend(m.ext.oJUIClasses,
    m.ext.classes, {
        sPageButton: "fg-button ui-button " + H, sPageButtonActive: "ui-state-disabled", sPageButtonDisabled: "ui-state-disabled", sPaging: "dataTables_paginate fg-buttonset ui-buttonset fg-buttonset-multi ui-buttonset-multi paging_", sSortAsc: H + " sorting_asc", sSortDesc: H + " sorting_desc", sSortable: H + " sorting", sSortableAsc: H + " sorting_asc_disabled", sSortableDesc: H + " sorting_desc_disabled", sSortableNone: H + " sorting_disabled", sSortJUIAsc: ia + "triangle-1-n", sSortJUIDesc: ia + "triangle-1-s", sSortJUI: ia + "carat-2-n-s",
        sSortJUIAscAllowed: ia + "carat-1-n", sSortJUIDescAllowed: ia + "carat-1-s", sSortJUIWrapper: "DataTables_sort_wrapper", sSortIcon: "DataTables_sort_icon", sScrollHead: "dataTables_scrollHead " + H, sScrollFoot: "dataTables_scrollFoot " + H, sHeaderTH: H, sFooterTH: H, sJUIHeader: Xb + " ui-corner-tl ui-corner-tr", sJUIFooter: Xb + " ui-corner-bl ui-corner-br"
    }); var Mb = m.ext.pager; h.extend(Mb, {
        simple: function () { return ["previous", "next"] }, full: function () { return ["first", "previous", "next", "last"] }, numbers: function (a, b) {
            return [ya(a,
            b)]
        }, simple_numbers: function (a, b) { return ["previous", ya(a, b), "next"] }, full_numbers: function (a, b) { return ["first", "previous", ya(a, b), "next", "last"] }, _numbers: ya, numbers_length: 7
    }); h.extend(!0, m.ext.renderer, {
        pageButton: {
            _: function (a, b, c, d, e, f) {
                var g = a.oClasses, j = a.oLanguage.oPaginate, i = a.oLanguage.oAria.paginate || {}, k, l, m = 0, p = function (b, d) {
                    var o, r, u, s, v = function (b) { Ta(a, b.data.action, true) }; o = 0; for (r = d.length; o < r; o++) {
                        s = d[o]; if (h.isArray(s)) { u = h("<" + (s.DT_el || "div") + "/>").appendTo(b); p(u, s) } else {
                            k = null;
                            l = ""; switch (s) { case "ellipsis": b.append('<span class="ellipsis">&#x2026;</span>'); break; case "first": k = j.sFirst; l = s + (e > 0 ? "" : " " + g.sPageButtonDisabled); break; case "previous": k = j.sPrevious; l = s + (e > 0 ? "" : " " + g.sPageButtonDisabled); break; case "next": k = j.sNext; l = s + (e < f - 1 ? "" : " " + g.sPageButtonDisabled); break; case "last": k = j.sLast; l = s + (e < f - 1 ? "" : " " + g.sPageButtonDisabled); break; default: k = s + 1; l = e === s ? g.sPageButtonActive : "" } if (k !== null) {
                                u = h("<a>", {
                                    "class": g.sPageButton + " " + l, "aria-controls": a.sTableId, "aria-label": i[s],
                                    "data-dt-idx": m, tabindex: a.iTabIndex, id: c === 0 && typeof s === "string" ? a.sTableId + "_" + s : null
                                }).html(k).appendTo(b); Wa(u, { action: s }, v); m++
                            }
                        }
                    }
                }, r; try { r = h(b).find(I.activeElement).data("dt-idx") } catch (o) { } p(h(b).empty(), d); r && h(b).find("[data-dt-idx=" + r + "]").focus()
            }
        }
    }); h.extend(m.ext.type.detect, [function (a, b) { var c = b.oLanguage.sDecimal; return Za(a, c) ? "num" + c : null }, function (a) {
        if (a && !(a instanceof Date) && (!ac.test(a) || !bc.test(a))) return null; var b = Date.parse(a); return null !== b && !isNaN(b) || M(a) ? "date" :
        null
    }, function (a, b) { var c = b.oLanguage.sDecimal; return Za(a, c, !0) ? "num-fmt" + c : null }, function (a, b) { var c = b.oLanguage.sDecimal; return Rb(a, c) ? "html-num" + c : null }, function (a, b) { var c = b.oLanguage.sDecimal; return Rb(a, c, !0) ? "html-num-fmt" + c : null }, function (a) { return M(a) || "string" === typeof a && -1 !== a.indexOf("<") ? "html" : null }]); h.extend(m.ext.type.search, {
        html: function (a) { return M(a) ? a : "string" === typeof a ? a.replace(Ob, " ").replace(Aa, "") : "" }, string: function (a) {
            return M(a) ? a : "string" === typeof a ? a.replace(Ob,
            " ") : a
        }
    }); var za = function (a, b, c, d) { if (0 !== a && (!a || "-" === a)) return -Infinity; b && (a = Qb(a, b)); a.replace && (c && (a = a.replace(c, "")), d && (a = a.replace(d, ""))); return 1 * a }; h.extend(v.type.order, {
        "date-pre": function (a) { return Date.parse(a) || 0 }, "html-pre": function (a) { return M(a) ? "" : a.replace ? a.replace(/<.*?>/g, "").toLowerCase() : a + "" }, "string-pre": function (a) { return M(a) ? "" : "string" === typeof a ? a.toLowerCase() : !a.toString ? "" : a.toString() }, "string-asc": function (a, b) { return a < b ? -1 : a > b ? 1 : 0 }, "string-desc": function (a,
        b) { return a < b ? 1 : a > b ? -1 : 0 }
    }); db(""); h.extend(!0, m.ext.renderer, {
        header: {
            _: function (a, b, c, d) { h(a.nTable).on("order.dt.DT", function (e, f, g, h) { if (a === f) { e = c.idx; b.removeClass(c.sSortingClass + " " + d.sSortAsc + " " + d.sSortDesc).addClass(h[e] == "asc" ? d.sSortAsc : h[e] == "desc" ? d.sSortDesc : c.sSortingClass) } }) }, jqueryui: function (a, b, c, d) {
                h("<div/>").addClass(d.sSortJUIWrapper).append(b.contents()).append(h("<span/>").addClass(d.sSortIcon + " " + c.sSortingClassJUI)).appendTo(b); h(a.nTable).on("order.dt.DT", function (e,
                f, g, h) { if (a === f) { e = c.idx; b.removeClass(d.sSortAsc + " " + d.sSortDesc).addClass(h[e] == "asc" ? d.sSortAsc : h[e] == "desc" ? d.sSortDesc : c.sSortingClass); b.find("span." + d.sSortIcon).removeClass(d.sSortJUIAsc + " " + d.sSortJUIDesc + " " + d.sSortJUI + " " + d.sSortJUIAscAllowed + " " + d.sSortJUIDescAllowed).addClass(h[e] == "asc" ? d.sSortJUIAsc : h[e] == "desc" ? d.sSortJUIDesc : c.sSortingClassJUI) } })
            }
        }
    }); var Yb = function (a) { return "string" === typeof a ? a.replace(/</g, "&lt;").replace(/>/g, "&gt;").replace(/"/g, "&quot;") : a }; m.render = {
        number: function (a,
        b, c, d, e) { return { display: function (f) { if ("number" !== typeof f && "string" !== typeof f) return f; var g = 0 > f ? "-" : "", h = parseFloat(f); if (isNaN(h)) return Yb(f); f = Math.abs(h); h = parseInt(f, 10); f = c ? b + (f - h).toFixed(c).substring(2) : ""; return g + (d || "") + h.toString().replace(/\B(?=(\d{3})+(?!\d))/g, a) + f + (e || "") } } }, text: function () { return { display: Yb } }
    }; h.extend(m.ext.internal, {
        _fnExternApiFunc: Nb, _fnBuildAjax: ra, _fnAjaxUpdate: lb, _fnAjaxParameters: ub, _fnAjaxUpdateDraw: vb, _fnAjaxDataSrc: sa, _fnAddColumn: Ea, _fnColumnOptions: ja,
        _fnAdjustColumnSizing: Y, _fnVisibleToColumnIndex: Z, _fnColumnIndexToVisible: $, _fnVisbleColumns: aa, _fnGetColumns: la, _fnColumnTypes: Ga, _fnApplyColumnDefs: ib, _fnHungarianMap: X, _fnCamelToHungarian: K, _fnLanguageCompat: Da, _fnBrowserDetect: gb, _fnAddData: N, _fnAddTr: ma, _fnNodeToDataIndex: function (a, b) { return b._DT_RowIndex !== k ? b._DT_RowIndex : null }, _fnNodeToColumnIndex: function (a, b, c) { return h.inArray(c, a.aoData[b].anCells) }, _fnGetCellData: B, _fnSetCellData: jb, _fnSplitObjNotation: Ja, _fnGetObjectDataFn: Q, _fnSetObjectDataFn: R,
        _fnGetDataMaster: Ka, _fnClearTable: na, _fnDeleteIndex: oa, _fnInvalidate: ca, _fnGetRowElements: Ia, _fnCreateTr: Ha, _fnBuildHead: kb, _fnDrawHead: ea, _fnDraw: O, _fnReDraw: T, _fnAddOptionsHtml: nb, _fnDetectHeader: da, _fnGetUniqueThs: qa, _fnFeatureHtmlFilter: pb, _fnFilterComplete: fa, _fnFilterCustom: yb, _fnFilterColumn: xb, _fnFilter: wb, _fnFilterCreateSearch: Pa, _fnEscapeRegex: Qa, _fnFilterData: zb, _fnFeatureHtmlInfo: sb, _fnUpdateInfo: Cb, _fnInfoMacros: Db, _fnInitialise: ga, _fnInitComplete: ta, _fnLengthChange: Ra, _fnFeatureHtmlLength: ob,
        _fnFeatureHtmlPaginate: tb, _fnPageChange: Ta, _fnFeatureHtmlProcessing: qb, _fnProcessingDisplay: C, _fnFeatureHtmlTable: rb, _fnScrollDraw: ka, _fnApplyToChildren: J, _fnCalculateColumnWidths: Fa, _fnThrottle: Oa, _fnConvertToWidth: Fb, _fnGetWidestNode: Gb, _fnGetMaxLenString: Hb, _fnStringToCss: x, _fnSortFlatten: V, _fnSort: mb, _fnSortAria: Jb, _fnSortListener: Va, _fnSortAttachListener: Ma, _fnSortingClasses: va, _fnSortData: Ib, _fnSaveState: wa, _fnLoadState: Kb, _fnSettingsFromNode: xa, _fnLog: L, _fnMap: E, _fnBindAction: Wa, _fnCallbackReg: z,
        _fnCallbackFire: u, _fnLengthOverflow: Sa, _fnRenderer: Na, _fnDataSource: y, _fnRowAttributes: La, _fnCalculateEnd: function () { }
    }); h.fn.dataTable = m; m.$ = h; h.fn.dataTableSettings = m.settings; h.fn.dataTableExt = m.ext; h.fn.DataTable = function (a) { return h(this).dataTable(a).api() }; h.each(m, function (a, b) { h.fn.DataTable[a] = b }); return h.fn.dataTable
});

// Simple Set Clipboard System
// Author: Joseph Huckaby

var ZeroClipboard_TableTools = {
	
	version: "1.0.4-TableTools2",
	clients: {}, // registered upload clients on page, indexed by id
	moviePath: '', // URL to movie
	nextId: 1, // ID of next movie
	
	$: function(thingy) {
		// simple DOM lookup utility function
		if (typeof(thingy) == 'string') thingy = document.getElementById(thingy);
		if (!thingy.addClass) {
			// extend element with a few useful methods
			thingy.hide = function() { this.style.display = 'none'; };
			thingy.show = function() { this.style.display = ''; };
			thingy.addClass = function(name) { this.removeClass(name); this.className += ' ' + name; };
			thingy.removeClass = function(name) {
				this.className = this.className.replace( new RegExp("\\s*" + name + "\\s*"), " ").replace(/^\s+/, '').replace(/\s+$/, '');
			};
			thingy.hasClass = function(name) {
				return !!this.className.match( new RegExp("\\s*" + name + "\\s*") );
			}
		}
		return thingy;
	},
	
	setMoviePath: function(path) {
		// set path to ZeroClipboard.swf
		this.moviePath = path;
	},
	
	dispatch: function(id, eventName, args) {
		// receive event from flash movie, send to client		
		var client = this.clients[id];
		if (client) {
			client.receiveEvent(eventName, args);
		}
	},
	
	register: function(id, client) {
		// register new client to receive events
		this.clients[id] = client;
	},
	
	getDOMObjectPosition: function(obj) {
		// get absolute coordinates for dom element
		var info = {
			left: 0, 
			top: 0, 
			width: obj.width ? obj.width : obj.offsetWidth, 
			height: obj.height ? obj.height : obj.offsetHeight
		};
		
		if ( obj.style.width != "" )
			info.width = obj.style.width.replace("px","");
		
		if ( obj.style.height != "" )
			info.height = obj.style.height.replace("px","");

		while (obj) {
			info.left += obj.offsetLeft;
			info.top += obj.offsetTop;
			obj = obj.offsetParent;
		}

		return info;
	},
	
	Client: function(elem) {
		// constructor for new simple upload client
		this.handlers = {};
		
		// unique ID
		this.id = ZeroClipboard_TableTools.nextId++;
		this.movieId = 'ZeroClipboard_TableToolsMovie_' + this.id;
		
		// register client with singleton to receive flash events
		ZeroClipboard_TableTools.register(this.id, this);
		
		// create movie
		if (elem) this.glue(elem);
	}
};

ZeroClipboard_TableTools.Client.prototype = {
	
	id: 0, // unique ID for us
	ready: false, // whether movie is ready to receive events or not
	movie: null, // reference to movie object
	clipText: '', // text to copy to clipboard
	fileName: '', // default file save name
	action: 'copy', // action to perform
	handCursorEnabled: true, // whether to show hand cursor, or default pointer cursor
	cssEffects: true, // enable CSS mouse effects on dom container
	handlers: null, // user event handlers
	sized: false,
	
	glue: function(elem, title) {
		// glue to DOM element
		// elem can be ID or actual DOM element object
		this.domElement = ZeroClipboard_TableTools.$(elem);
		
		// float just above object, or zIndex 99 if dom element isn't set
		var zIndex = 99;
		if (this.domElement.style.zIndex) {
			zIndex = parseInt(this.domElement.style.zIndex) + 1;
		}
		
		// find X/Y position of domElement
		var box = ZeroClipboard_TableTools.getDOMObjectPosition(this.domElement);
		
		// create floating DIV above element
		this.div = document.createElement('div');
		var style = this.div.style;
		style.position = 'absolute';
		style.left = '0px';
		style.top = '0px';
		style.width = (box.width) + 'px';
		style.height = box.height + 'px';
		style.zIndex = zIndex;
		
		if ( typeof title != "undefined" && title != "" ) {
			this.div.title = title;
		}
		if ( box.width != 0 && box.height != 0 ) {
			this.sized = true;
		}
		
		// style.backgroundColor = '#f00'; // debug
		if ( this.domElement ) {
			this.domElement.appendChild(this.div);
			this.div.innerHTML = this.getHTML( box.width, box.height );
		}
	},
	
	positionElement: function() {
		var box = ZeroClipboard_TableTools.getDOMObjectPosition(this.domElement);
		var style = this.div.style;
		
		style.position = 'absolute';
		//style.left = (this.domElement.offsetLeft)+'px';
		//style.top = this.domElement.offsetTop+'px';
		style.width = box.width + 'px';
		style.height = box.height + 'px';
		
		if ( box.width != 0 && box.height != 0 ) {
			this.sized = true;
		} else {
			return;
		}
		
		var flash = this.div.childNodes[0];
		flash.width = box.width;
		flash.height = box.height;
	},
	
	getHTML: function(width, height) {
		// return HTML for movie
		var html = '';
		var flashvars = 'id=' + this.id + 
			'&width=' + width + 
			'&height=' + height;
			
		if (navigator.userAgent.match(/MSIE/)) {
			// IE gets an OBJECT tag
			var protocol = location.href.match(/^https/i) ? 'https://' : 'http://';
			html += '<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="'+protocol+'download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=10,0,0,0" width="'+width+'" height="'+height+'" id="'+this.movieId+'" align="middle"><param name="allowScriptAccess" value="always" /><param name="allowFullScreen" value="false" /><param name="movie" value="'+ZeroClipboard_TableTools.moviePath+'" /><param name="loop" value="false" /><param name="menu" value="false" /><param name="quality" value="best" /><param name="bgcolor" value="#ffffff" /><param name="flashvars" value="'+flashvars+'"/><param name="wmode" value="transparent"/></object>';
		}
		else {
			// all other browsers get an EMBED tag
			html += '<embed id="'+this.movieId+'" src="'+ZeroClipboard_TableTools.moviePath+'" loop="false" menu="false" quality="best" bgcolor="#ffffff" width="'+width+'" height="'+height+'" name="'+this.movieId+'" align="middle" allowScriptAccess="always" allowFullScreen="false" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" flashvars="'+flashvars+'" wmode="transparent" />';
		}
		return html;
	},
	
	hide: function() {
		// temporarily hide floater offscreen
		if (this.div) {
			this.div.style.left = '-2000px';
		}
	},
	
	show: function() {
		// show ourselves after a call to hide()
		this.reposition();
	},
	
	destroy: function() {
		// destroy control and floater
		if (this.domElement && this.div) {
			this.hide();
			this.div.innerHTML = '';
			
			var body = document.getElementsByTagName('body')[0];
			try { body.removeChild( this.div ); } catch(e) {;}
			
			this.domElement = null;
			this.div = null;
		}
	},
	
	reposition: function(elem) {
		// reposition our floating div, optionally to new container
		// warning: container CANNOT change size, only position
		if (elem) {
			this.domElement = ZeroClipboard_TableTools.$(elem);
			if (!this.domElement) this.hide();
		}
		
		if (this.domElement && this.div) {
			var box = ZeroClipboard_TableTools.getDOMObjectPosition(this.domElement);
			var style = this.div.style;
			style.left = '' + box.left + 'px';
			style.top = '' + box.top + 'px';
		}
	},
	
	clearText: function() {
		// clear the text to be copy / saved
		this.clipText = '';
		if (this.ready) this.movie.clearText();
	},
	
	appendText: function(newText) {
		// append text to that which is to be copied / saved
		this.clipText += newText;
		if (this.ready) { this.movie.appendText(newText) ;}
	},
	
	setText: function(newText) {
		// set text to be copied to be copied / saved
		this.clipText = newText;
		if (this.ready) { this.movie.setText(newText) ;}
	},
	
	setCharSet: function(charSet) {
		// set the character set (UTF16LE or UTF8)
		this.charSet = charSet;
		if (this.ready) { this.movie.setCharSet(charSet) ;}
	},
	
	setBomInc: function(bomInc) {
		// set if the BOM should be included or not
		this.incBom = bomInc;
		if (this.ready) { this.movie.setBomInc(bomInc) ;}
	},
	
	setFileName: function(newText) {
		// set the file name
		this.fileName = newText;
		if (this.ready) this.movie.setFileName(newText);
	},
	
	setAction: function(newText) {
		// set action (save or copy)
		this.action = newText;
		if (this.ready) this.movie.setAction(newText);
	},
	
	addEventListener: function(eventName, func) {
		// add user event listener for event
		// event types: load, queueStart, fileStart, fileComplete, queueComplete, progress, error, cancel
		eventName = eventName.toString().toLowerCase().replace(/^on/, '');
		if (!this.handlers[eventName]) this.handlers[eventName] = [];
		this.handlers[eventName].push(func);
	},
	
	setHandCursor: function(enabled) {
		// enable hand cursor (true), or default arrow cursor (false)
		this.handCursorEnabled = enabled;
		if (this.ready) this.movie.setHandCursor(enabled);
	},
	
	setCSSEffects: function(enabled) {
		// enable or disable CSS effects on DOM container
		this.cssEffects = !!enabled;
	},
	
	receiveEvent: function(eventName, args) {
		// receive event from flash
		eventName = eventName.toString().toLowerCase().replace(/^on/, '');
		
		// special behavior for certain events
		switch (eventName) {
			case 'load':
				// movie claims it is ready, but in IE this isn't always the case...
				// bug fix: Cannot extend EMBED DOM elements in Firefox, must use traditional function
				this.movie = document.getElementById(this.movieId);
				if (!this.movie) {
					var self = this;
					setTimeout( function() { self.receiveEvent('load', null); }, 1 );
					return;
				}
				
				// firefox on pc needs a "kick" in order to set these in certain cases
				if (!this.ready && navigator.userAgent.match(/Firefox/) && navigator.userAgent.match(/Windows/)) {
					var self = this;
					setTimeout( function() { self.receiveEvent('load', null); }, 100 );
					this.ready = true;
					return;
				}
				
				this.ready = true;
				this.movie.clearText();
				this.movie.appendText( this.clipText );
				this.movie.setFileName( this.fileName );
				this.movie.setAction( this.action );
				this.movie.setCharSet( this.charSet );
				this.movie.setBomInc( this.incBom );
				this.movie.setHandCursor( this.handCursorEnabled );
				break;
			
			case 'mouseover':
				if (this.domElement && this.cssEffects) {
					//this.domElement.addClass('hover');
					if (this.recoverActive) this.domElement.addClass('active');
				}
				break;
			
			case 'mouseout':
				if (this.domElement && this.cssEffects) {
					this.recoverActive = false;
					if (this.domElement.hasClass('active')) {
						this.domElement.removeClass('active');
						this.recoverActive = true;
					}
					//this.domElement.removeClass('hover');
				}
				break;
			
			case 'mousedown':
				if (this.domElement && this.cssEffects) {
					this.domElement.addClass('active');
				}
				break;
			
			case 'mouseup':
				if (this.domElement && this.cssEffects) {
					this.domElement.removeClass('active');
					this.recoverActive = false;
				}
				break;
		} // switch eventName
		
		if (this.handlers[eventName]) {
			for (var idx = 0, len = this.handlers[eventName].length; idx < len; idx++) {
				var func = this.handlers[eventName][idx];
			
				if (typeof(func) == 'function') {
					// actual function reference
					func(this, args);
				}
				else if ((typeof(func) == 'object') && (func.length == 2)) {
					// PHP style object + method, i.e. [myObject, 'myMethod']
					func[0][ func[1] ](this, args);
				}
				else if (typeof(func) == 'string') {
					// name of function
					window[func](this, args);
				}
			} // foreach event handler defined
		} // user defined handler for event
	}
	
};





/*
 * File:        TableTools.js
 * Version:     2.1.5
 * Description: Tools and buttons for DataTables
 * Author:      Allan Jardine (www.sprymedia.co.uk)
 * Language:    Javascript
 * License:	    GPL v2 or BSD 3 point style
 * Project:	    DataTables
 * 
 * Copyright 2009-2013 Allan Jardine, all rights reserved.
 *
 * This source file is free software, under either the GPL v2 license or a
 * BSD style license, available at:
 *   http://datatables.net/license_gpl2
 *   http://datatables.net/license_bsd
 */

/* Global scope for TableTools */
var TableTools;

(function($, window, document) {

/** 
 * TableTools provides flexible buttons and other tools for a DataTables enhanced table
 * @class TableTools
 * @constructor
 * @param {Object} oDT DataTables instance
 * @param {Object} oOpts TableTools options
 * @param {String} oOpts.sSwfPath ZeroClipboard SWF path
 * @param {String} oOpts.sRowSelect Row selection options - 'none', 'single' or 'multi'
 * @param {Function} oOpts.fnPreRowSelect Callback function just prior to row selection
 * @param {Function} oOpts.fnRowSelected Callback function just after row selection
 * @param {Function} oOpts.fnRowDeselected Callback function when row is deselected
 * @param {Array} oOpts.aButtons List of buttons to be used
 */
TableTools = function( oDT, oOpts )
{
	/* Santiy check that we are a new instance */
	if ( ! this instanceof TableTools )
	{
		alert( "Warning: TableTools must be initialised with the keyword 'new'" );
	}
	
	
	/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
	 * Public class variables
	 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
	
	/**
	 * @namespace Settings object which contains customisable information for TableTools instance
	 */
	this.s = {
		/**
		 * Store 'this' so the instance can be retrieved from the settings object
		 * @property that
		 * @type	 object
		 * @default  this
		 */
		"that": this,
		
		/** 
		 * DataTables settings objects
		 * @property dt
		 * @type	 object
		 * @default  <i>From the oDT init option</i>
		 */
		"dt": oDT.fnSettings(),
		
		/**
		 * @namespace Print specific information
		 */
		"print": {
			/** 
			 * DataTables draw 'start' point before the printing display was shown
			 *  @property saveStart
			 *  @type	 int
			 *  @default  -1
		 	 */
		  "saveStart": -1,
			
			/** 
			 * DataTables draw 'length' point before the printing display was shown
			 *  @property saveLength
			 *  @type	 int
			 *  @default  -1
		 	 */
		  "saveLength": -1,
		
			/** 
			 * Page scrolling point before the printing display was shown so it can be restored
			 *  @property saveScroll
			 *  @type	 int
			 *  @default  -1
		 	 */
		  "saveScroll": -1,
		
			/** 
			 * Wrapped function to end the print display (to maintain scope)
			 *  @property funcEnd
		 	 *  @type	 Function
			 *  @default  function () {}
		 	 */
		  "funcEnd": function () {}
	  },
	
		/**
		 * A unique ID is assigned to each button in each instance
		 * @property buttonCounter
		 *  @type	 int
		 * @default  0
		 */
	  "buttonCounter": 0,
		
		/**
		 * @namespace Select rows specific information
		 */
		"select": {
			/**
			 * Select type - can be 'none', 'single' or 'multi'
			 * @property type
			 *  @type	 string
			 * @default  ""
			 */
			"type": "",
			
			/**
			 * Array of nodes which are currently selected
			 *  @property selected
			 *  @type	 array
			 *  @default  []
			 */
			"selected": [],
			
			/**
			 * Function to run before the selection can take place. Will cancel the select if the
			 * function returns false
			 *  @property preRowSelect
			 *  @type	 Function
			 *  @default  null
			 */
			"preRowSelect": null,
			
			/**
			 * Function to run when a row is selected
			 *  @property postSelected
			 *  @type	 Function
			 *  @default  null
			 */
			"postSelected": null,
			
			/**
			 * Function to run when a row is deselected
			 *  @property postDeselected
			 *  @type	 Function
			 *  @default  null
			 */
			"postDeselected": null,
			
			/**
			 * Indicate if all rows are selected (needed for server-side processing)
			 *  @property all
			 *  @type	 boolean
			 *  @default  false
			 */
			"all": false,
			
			/**
			 * Class name to add to selected TR nodes
			 *  @property selectedClass
			 *  @type	 String
			 *  @default  ""
			 */
			"selectedClass": ""
		},
		
		/**
		 * Store of the user input customisation object
		 *  @property custom
		 *  @type	 object
		 *  @default  {}
		 */
		"custom": {},
		
		/**
		 * SWF movie path
		 *  @property swfPath
		 *  @type	 string
		 *  @default  ""
		 */
		"swfPath": "",
		
		/**
		 * Default button set
		 *  @property buttonSet
		 *  @type	 array
		 *  @default  []
		 */
		"buttonSet": [],
		
		/**
		 * When there is more than one TableTools instance for a DataTable, there must be a 
		 * master which controls events (row selection etc)
		 *  @property master
		 *  @type	 boolean
		 *  @default  false
		 */
		"master": false,
		
		/**
		 * Tag names that are used for creating collections and buttons
		 *  @namesapce
		 */
		"tags": {}
	};
	
	
	/**
	 * @namespace Common and useful DOM elements for the class instance
	 */
	this.dom = {
		/**
		 * DIV element that is create and all TableTools buttons (and their children) put into
		 *  @property container
		 *  @type	 node
		 *  @default  null
		 */
		"container": null,
		
		/**
		 * The table node to which TableTools will be applied
		 *  @property table
		 *  @type	 node
		 *  @default  null
		 */
		"table": null,
		
		/**
		 * @namespace Nodes used for the print display
		 */
		"print": {
			/**
			 * Nodes which have been removed from the display by setting them to display none
			 *  @property hidden
			 *  @type	 array
		 	 *  @default  []
			 */
		  "hidden": [],
			
			/**
			 * The information display saying telling the user about the print display
			 *  @property message
			 *  @type	 node
		 	 *  @default  null
			 */
		  "message": null
	  },
		
		/**
		 * @namespace Nodes used for a collection display. This contains the currently used collection
		 */
		"collection": {
			/**
			 * The div wrapper containing the buttons in the collection (i.e. the menu)
			 *  @property collection
			 *  @type	 node
		 	 *  @default  null
			 */
			"collection": null,
			
			/**
			 * Background display to provide focus and capture events
			 *  @property background
			 *  @type	 node
		 	 *  @default  null
			 */
			"background": null
		}
	};

	/**
	 * @namespace Name space for the classes that this TableTools instance will use
	 * @extends TableTools.classes
	 */
	this.classes = $.extend( true, {}, TableTools.classes );
	if ( this.s.dt.bJUI )
	{
		$.extend( true, this.classes, TableTools.classes_themeroller );
	}
	
	
	/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
	 * Public class methods
	 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
	
	/**
	 * Retreieve the settings object from an instance
	 *  @method fnSettings
	 *  @returns {object} TableTools settings object
	 */
	this.fnSettings = function () {
		return this.s;
	};
	
	
	/* Constructor logic */
	if ( typeof oOpts == 'undefined' )
	{
		oOpts = {};
	}
	
	this._fnConstruct( oOpts );
	
	return this;
};



TableTools.prototype = {
	/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
	 * Public methods
	 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
	
	/**
	 * Retreieve the settings object from an instance
	 *  @returns {array} List of TR nodes which are currently selected
	 *  @param {boolean} [filtered=false] Get only selected rows which are  
	 *    available given the filtering applied to the table. By default
	 *    this is false -  i.e. all rows, regardless of filtering are 
	      selected.
	 */
	"fnGetSelected": function ( filtered )
	{
		var
			out = [],
			data = this.s.dt.aoData,
			displayed = this.s.dt.aiDisplay,
			i, iLen;

		if ( filtered )
		{
			// Only consider filtered rows
			for ( i=0, iLen=displayed.length ; i<iLen ; i++ )
			{
				if ( data[ displayed[i] ]._DTTT_selected )
				{
					out.push( data[ displayed[i] ].nTr );
				}
			}
		}
		else
		{
			// Use all rows
			for ( i=0, iLen=data.length ; i<iLen ; i++ )
			{
				if ( data[i]._DTTT_selected )
				{
					out.push( data[i].nTr );
				}
			}
		}

		return out;
	},


	/**
	 * Get the data source objects/arrays from DataTables for the selected rows (same as
	 * fnGetSelected followed by fnGetData on each row from the table)
	 *  @returns {array} Data from the TR nodes which are currently selected
	 */
	"fnGetSelectedData": function ()
	{
		var out = [];
		var data=this.s.dt.aoData;
		var i, iLen;

		for ( i=0, iLen=data.length ; i<iLen ; i++ )
		{
			if ( data[i]._DTTT_selected )
			{
				out.push( this.s.dt.oInstance.fnGetData(i) );
			}
		}

		return out;
	},
	
	
	/**
	 * Check to see if a current row is selected or not
	 *  @param {Node} n TR node to check if it is currently selected or not
	 *  @returns {Boolean} true if select, false otherwise
	 */
	"fnIsSelected": function ( n )
	{
		var pos = this.s.dt.oInstance.fnGetPosition( n );
		return (this.s.dt.aoData[pos]._DTTT_selected===true) ? true : false;
	},

	
	/**
	 * Select all rows in the table
	 *  @param {boolean} [filtered=false] Select only rows which are available 
	 *    given the filtering applied to the table. By default this is false - 
	 *    i.e. all rows, regardless of filtering are selected.
	 */
	"fnSelectAll": function ( filtered )
	{
		var s = this._fnGetMasterSettings();
		
		this._fnRowSelect( (filtered === true) ?
			s.dt.aiDisplay :
			s.dt.aoData
		);
	},

	
	/**
	 * Deselect all rows in the table
	 *  @param {boolean} [filtered=false] Deselect only rows which are available 
	 *    given the filtering applied to the table. By default this is false - 
	 *    i.e. all rows, regardless of filtering are deselected.
	 */
	"fnSelectNone": function ( filtered )
	{
		var s = this._fnGetMasterSettings();

		this._fnRowDeselect( this.fnGetSelected(filtered) );
	},

	
	/**
	 * Select row(s)
	 *  @param {node|object|array} n The row(s) to select. Can be a single DOM
	 *    TR node, an array of TR nodes or a jQuery object.
	 */
	"fnSelect": function ( n )
	{
		if ( this.s.select.type == "single" )
		{
			this.fnSelectNone();
			this._fnRowSelect( n );
		}
		else if ( this.s.select.type == "multi" )
		{
			this._fnRowSelect( n );
		}
	},

	
	/**
	 * Deselect row(s)
	 *  @param {node|object|array} n The row(s) to deselect. Can be a single DOM
	 *    TR node, an array of TR nodes or a jQuery object.
	 */
	"fnDeselect": function ( n )
	{
		this._fnRowDeselect( n );
	},
	
	
	/**
	 * Get the title of the document - useful for file names. The title is retrieved from either
	 * the configuration object's 'title' parameter, or the HTML document title
	 *  @param   {Object} oConfig Button configuration object
	 *  @returns {String} Button title
	 */
	"fnGetTitle": function( oConfig )
	{
		var sTitle = "";
		if ( typeof oConfig.sTitle != 'undefined' && oConfig.sTitle !== "" ) {
			sTitle = oConfig.sTitle;
		} else {
			var anTitle = document.getElementsByTagName('title');
			if ( anTitle.length > 0 )
			{
				sTitle = anTitle[0].innerHTML;
			}
		}
		
		/* Strip characters which the OS will object to - checking for UTF8 support in the scripting
		 * engine
		 */
		if ( "\u00A1".toString().length < 4 ) {
			return sTitle.replace(/[^a-zA-Z0-9_\u00A1-\uFFFF\.,\-_ !\(\)]/g, "");
		} else {
			return sTitle.replace(/[^a-zA-Z0-9_\.,\-_ !\(\)]/g, "");
		}
	},
	
	
	/**
	 * Calculate a unity array with the column width by proportion for a set of columns to be
	 * included for a button. This is particularly useful for PDF creation, where we can use the
	 * column widths calculated by the browser to size the columns in the PDF.
	 *  @param   {Object} oConfig Button configuration object
	 *  @returns {Array} Unity array of column ratios
	 */
	"fnCalcColRatios": function ( oConfig )
	{
		var
			aoCols = this.s.dt.aoColumns,
			aColumnsInc = this._fnColumnTargets( oConfig.mColumns ),
			aColWidths = [],
			iWidth = 0, iTotal = 0, i, iLen;
		
		for ( i=0, iLen=aColumnsInc.length ; i<iLen ; i++ )
		{
			if ( aColumnsInc[i] )
			{
				iWidth = aoCols[i].nTh.offsetWidth;
				iTotal += iWidth;
				aColWidths.push( iWidth );
			}
		}
		
		for ( i=0, iLen=aColWidths.length ; i<iLen ; i++ )
		{
			aColWidths[i] = aColWidths[i] / iTotal;
		}
		
		return aColWidths.join('\t');
	},
	
	
	/**
	 * Get the information contained in a table as a string
	 *  @param   {Object} oConfig Button configuration object
	 *  @returns {String} Table data as a string
	 */
	"fnGetTableData": function ( oConfig )
	{
		/* In future this could be used to get data from a plain HTML source as well as DataTables */
		if ( this.s.dt )
		{
			return this._fnGetDataTablesData( oConfig );
		}
	},
	
	
	/**
	 * Pass text to a flash button instance, which will be used on the button's click handler
	 *  @param   {Object} clip Flash button object
	 *  @param   {String} text Text to set
	 */
	"fnSetText": function ( clip, text )
	{
		this._fnFlashSetText( clip, text );
	},
	
	
	/**
	 * Resize the flash elements of the buttons attached to this TableTools instance - this is
	 * useful for when initialising TableTools when it is hidden (display:none) since sizes can't
	 * be calculated at that time.
	 */
	"fnResizeButtons": function ()
	{
		for ( var cli in ZeroClipboard_TableTools.clients )
		{
			if ( cli )
			{
				var client = ZeroClipboard_TableTools.clients[cli];
				if ( typeof client.domElement != 'undefined' &&
					 client.domElement.parentNode )
				{
					client.positionElement();
				}
			}
		}
	},
	
	
	/**
	 * Check to see if any of the ZeroClipboard client's attached need to be resized
	 */
	"fnResizeRequired": function ()
	{
		for ( var cli in ZeroClipboard_TableTools.clients )
		{
			if ( cli )
			{
				var client = ZeroClipboard_TableTools.clients[cli];
				if ( typeof client.domElement != 'undefined' &&
					 client.domElement.parentNode == this.dom.container &&
					 client.sized === false )
				{
					return true;
				}
			}
		}
		return false;
	},
	
	
	/**
	 * Programmatically enable or disable the print view
	 *  @param {boolean} [bView=true] Show the print view if true or not given. If false, then
	 *    terminate the print view and return to normal.
	 *  @param {object} [oConfig={}] Configuration for the print view
	 *  @param {boolean} [oConfig.bShowAll=false] Show all rows in the table if true
	 *  @param {string} [oConfig.sInfo] Information message, displayed as an overlay to the
	 *    user to let them know what the print view is.
	 *  @param {string} [oConfig.sMessage] HTML string to show at the top of the document - will
	 *    be included in the printed document.
	 */
	"fnPrint": function ( bView, oConfig )
	{
		if ( oConfig === undefined )
		{
			oConfig = {};
		}

		if ( bView === undefined || bView )
		{
			this._fnPrintStart( oConfig );
		}
		else
		{
			this._fnPrintEnd();
		}
	},
	
	
	/**
	 * Show a message to the end user which is nicely styled
	 *  @param {string} message The HTML string to show to the user
	 *  @param {int} time The duration the message is to be shown on screen for (mS)
	 */
	"fnInfo": function ( message, time ) {
		var nInfo = document.createElement( "div" );
		nInfo.className = this.classes.print.info;
		nInfo.innerHTML = message;

		document.body.appendChild( nInfo );
		
		setTimeout( function() {
			$(nInfo).fadeOut( "normal", function() {
				document.body.removeChild( nInfo );
			} );
		}, time );
	},
	
	
	
	/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
	 * Private methods (they are of course public in JS, but recommended as private)
	 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
	
	/**
	 * Constructor logic
	 *  @method  _fnConstruct
	 *  @param   {Object} oOpts Same as TableTools constructor
	 *  @returns void
	 *  @private 
	 */
	"_fnConstruct": function ( oOpts )
	{
		var that = this;
		
		this._fnCustomiseSettings( oOpts );
		
		/* Container element */
		this.dom.container = document.createElement( this.s.tags.container );
		this.dom.container.className = this.classes.container;
		
		/* Row selection config */
		if ( this.s.select.type != 'none' )
		{
			this._fnRowSelectConfig();
		}
		
		/* Buttons */
		this._fnButtonDefinations( this.s.buttonSet, this.dom.container );
		
		/* Destructor */
		this.s.dt.aoDestroyCallback.push( {
			"sName": "TableTools",
			"fn": function () {
				$(that.s.dt.nTBody).off( 'click.DTTT_Select', 'tr' );
				$(that.dom.container).empty();
			}
		} );
	},
	
	
	/**
	 * Take the user defined settings and the default settings and combine them.
	 *  @method  _fnCustomiseSettings
	 *  @param   {Object} oOpts Same as TableTools constructor
	 *  @returns void
	 *  @private 
	 */
	"_fnCustomiseSettings": function ( oOpts )
	{
		/* Is this the master control instance or not? */
		if ( typeof this.s.dt._TableToolsInit == 'undefined' )
		{
			this.s.master = true;
			this.s.dt._TableToolsInit = true;
		}
		
		/* We can use the table node from comparisons to group controls */
		this.dom.table = this.s.dt.nTable;
		
		/* Clone the defaults and then the user options */
		this.s.custom = $.extend( {}, TableTools.DEFAULTS, oOpts );
		
		/* Flash file location */
		this.s.swfPath = this.s.custom.sSwfPath;
		if ( typeof ZeroClipboard_TableTools != 'undefined' )
		{
			ZeroClipboard_TableTools.moviePath = this.s.swfPath;
		}
		
		/* Table row selecting */
		this.s.select.type = this.s.custom.sRowSelect;
		this.s.select.preRowSelect = this.s.custom.fnPreRowSelect;
		this.s.select.postSelected = this.s.custom.fnRowSelected;
		this.s.select.postDeselected = this.s.custom.fnRowDeselected;

		// Backwards compatibility - allow the user to specify a custom class in the initialiser
		if ( this.s.custom.sSelectedClass )
		{
			this.classes.select.row = this.s.custom.sSelectedClass;
		}

		this.s.tags = this.s.custom.oTags;

		/* Button set */
		this.s.buttonSet = this.s.custom.aButtons;
	},
	
	
	/**
	 * Take the user input arrays and expand them to be fully defined, and then add them to a given
	 * DOM element
	 *  @method  _fnButtonDefinations
	 *  @param {array} buttonSet Set of user defined buttons
	 *  @param {node} wrapper Node to add the created buttons to
	 *  @returns void
	 *  @private 
	 */
	"_fnButtonDefinations": function ( buttonSet, wrapper )
	{
		var buttonDef;
		
		for ( var i=0, iLen=buttonSet.length ; i<iLen ; i++ )
		{
			if ( typeof buttonSet[i] == "string" )
			{
				if ( typeof TableTools.BUTTONS[ buttonSet[i] ] == 'undefined' )
				{
					alert( "TableTools: Warning - unknown button type: "+buttonSet[i] );
					continue;
				}
				buttonDef = $.extend( {}, TableTools.BUTTONS[ buttonSet[i] ], true );
			}
			else
			{
				if ( typeof TableTools.BUTTONS[ buttonSet[i].sExtends ] == 'undefined' )
				{
					alert( "TableTools: Warning - unknown button type: "+buttonSet[i].sExtends );
					continue;
				}
				var o = $.extend( {}, TableTools.BUTTONS[ buttonSet[i].sExtends ], true );
				buttonDef = $.extend( o, buttonSet[i], true );
			}
			
			wrapper.appendChild( this._fnCreateButton( 
				buttonDef, 
				$(wrapper).hasClass(this.classes.collection.container)
			) );
		}
	},
	
	
	/**
	 * Create and configure a TableTools button
	 *  @method  _fnCreateButton
	 *  @param   {Object} oConfig Button configuration object
	 *  @returns {Node} Button element
	 *  @private 
	 */
	"_fnCreateButton": function ( oConfig, bCollectionButton )
	{
	  var nButton = this._fnButtonBase( oConfig, bCollectionButton );
		
		if ( oConfig.sAction.match(/flash/) )
		{
			this._fnFlashConfig( nButton, oConfig );
		}
		else if ( oConfig.sAction == "text" )
		{
			this._fnTextConfig( nButton, oConfig );
		}
		else if ( oConfig.sAction == "div" )
		{
			this._fnTextConfig( nButton, oConfig );
		}
		else if ( oConfig.sAction == "collection" )
		{
			this._fnTextConfig( nButton, oConfig );
			this._fnCollectionConfig( nButton, oConfig );
		}
		
		return nButton;
	},
	
	
	/**
	 * Create the DOM needed for the button and apply some base properties. All buttons start here
	 *  @method  _fnButtonBase
	 *  @param   {o} oConfig Button configuration object
	 *  @returns {Node} DIV element for the button
	 *  @private 
	 */
	"_fnButtonBase": function ( o, bCollectionButton )
	{
		var sTag, sLiner, sClass;

		if ( bCollectionButton )
		{
			sTag = o.sTag !== "default" ? o.sTag : this.s.tags.collection.button;
			sLiner = o.sLinerTag !== "default" ? o.sLiner : this.s.tags.collection.liner;
			sClass = this.classes.collection.buttons.normal;
		}
		else
		{
			sTag = o.sTag !== "default" ? o.sTag : this.s.tags.button;
			sLiner = o.sLinerTag !== "default" ? o.sLiner : this.s.tags.liner;
			sClass = this.classes.buttons.normal;
		}

		var
		  nButton = document.createElement( sTag ),
		  nSpan = document.createElement( sLiner ),
		  masterS = this._fnGetMasterSettings();
		
		nButton.className = sClass+" "+o.sButtonClass;
		nButton.setAttribute('id', "ToolTables_"+this.s.dt.sInstance+"_"+masterS.buttonCounter );
		nButton.appendChild( nSpan );
		nSpan.innerHTML = o.sButtonText;
		
		masterS.buttonCounter++;
		
		return nButton;
	},
	
	
	/**
	 * Get the settings object for the master instance. When more than one TableTools instance is
	 * assigned to a DataTable, only one of them can be the 'master' (for the select rows). As such,
	 * we will typically want to interact with that master for global properties.
	 *  @method  _fnGetMasterSettings
	 *  @returns {Object} TableTools settings object
	 *  @private 
	 */
	"_fnGetMasterSettings": function ()
	{
		if ( this.s.master )
		{
			return this.s;
		}
		else
		{
			/* Look for the master which has the same DT as this one */
			var instances = TableTools._aInstances;
			for ( var i=0, iLen=instances.length ; i<iLen ; i++ )
			{
				if ( this.dom.table == instances[i].s.dt.nTable )
				{
					return instances[i].s;
				}
			}
		}
	},
	
	
	
	/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
	 * Button collection functions
	 */
	
	/**
	 * Create a collection button, when activated will present a drop down list of other buttons
	 *  @param   {Node} nButton Button to use for the collection activation
	 *  @param   {Object} oConfig Button configuration object
	 *  @returns void
	 *  @private
	 */
	"_fnCollectionConfig": function ( nButton, oConfig )
	{
		var nHidden = document.createElement( this.s.tags.collection.container );
		nHidden.style.display = "none";
		nHidden.className = this.classes.collection.container;
		oConfig._collection = nHidden;
		document.body.appendChild( nHidden );
		
		this._fnButtonDefinations( oConfig.aButtons, nHidden );
	},
	
	
	/**
	 * Show a button collection
	 *  @param   {Node} nButton Button to use for the collection
	 *  @param   {Object} oConfig Button configuration object
	 *  @returns void
	 *  @private
	 */
	"_fnCollectionShow": function ( nButton, oConfig )
	{
		var
			that = this,
			oPos = $(nButton).offset(),
			nHidden = oConfig._collection,
			iDivX = oPos.left,
			iDivY = oPos.top + $(nButton).outerHeight(),
			iWinHeight = $(window).height(), iDocHeight = $(document).height(),
		 	iWinWidth = $(window).width(), iDocWidth = $(document).width();
		
		nHidden.style.position = "absolute";
		nHidden.style.left = iDivX+"px";
		nHidden.style.top = iDivY+"px";
		nHidden.style.display = "block";
		$(nHidden).css('opacity',0);
		
		var nBackground = document.createElement('div');
		nBackground.style.position = "absolute";
		nBackground.style.left = "0px";
		nBackground.style.top = "0px";
		nBackground.style.height = ((iWinHeight>iDocHeight)? iWinHeight : iDocHeight) +"px";
		nBackground.style.width = ((iWinWidth>iDocWidth)? iWinWidth : iDocWidth) +"px";
		nBackground.className = this.classes.collection.background;
		$(nBackground).css('opacity',0);
		
		document.body.appendChild( nBackground );
		document.body.appendChild( nHidden );
		
		/* Visual corrections to try and keep the collection visible */
		var iDivWidth = $(nHidden).outerWidth();
		var iDivHeight = $(nHidden).outerHeight();
		
		if ( iDivX + iDivWidth > iDocWidth )
		{
			nHidden.style.left = (iDocWidth-iDivWidth)+"px";
		}
		
		if ( iDivY + iDivHeight > iDocHeight )
		{
			nHidden.style.top = (iDivY-iDivHeight-$(nButton).outerHeight())+"px";
		}
	
		this.dom.collection.collection = nHidden;
		this.dom.collection.background = nBackground;
		
		/* This results in a very small delay for the end user but it allows the animation to be
		 * much smoother. If you don't want the animation, then the setTimeout can be removed
		 */
		setTimeout( function () {
			$(nHidden).animate({"opacity": 1}, 500);
			$(nBackground).animate({"opacity": 0.25}, 500);
		}, 10 );

		/* Resize the buttons to the Flash contents fit */
		this.fnResizeButtons();
		
		/* Event handler to remove the collection display */
		$(nBackground).click( function () {
			that._fnCollectionHide.call( that, null, null );
		} );
	},
	
	
	/**
	 * Hide a button collection
	 *  @param   {Node} nButton Button to use for the collection
	 *  @param   {Object} oConfig Button configuration object
	 *  @returns void
	 *  @private
	 */
	"_fnCollectionHide": function ( nButton, oConfig )
	{
		if ( oConfig !== null && oConfig.sExtends == 'collection' )
		{
			return;
		}
		
		if ( this.dom.collection.collection !== null )
		{
			$(this.dom.collection.collection).animate({"opacity": 0}, 500, function (e) {
				this.style.display = "none";
			} );
			
			$(this.dom.collection.background).animate({"opacity": 0}, 500, function (e) {
				this.parentNode.removeChild( this );
			} );
			
			this.dom.collection.collection = null;
			this.dom.collection.background = null;
		}
	},
	
	
	
	/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
	 * Row selection functions
	 */
	
	/**
	 * Add event handlers to a table to allow for row selection
	 *  @method  _fnRowSelectConfig
	 *  @returns void
	 *  @private 
	 */
	"_fnRowSelectConfig": function ()
	{
		if ( this.s.master )
		{
			var
				that = this, 
				i, iLen, 
				dt = this.s.dt,
				aoOpenRows = this.s.dt.aoOpenRows;
			
			$(dt.nTable).addClass( this.classes.select.table );
			
			$(dt.nTBody).on( 'click.DTTT_Select', 'tr', function(e) {
				/* Sub-table must be ignored (odd that the selector won't do this with >) */
				if ( this.parentNode != dt.nTBody )
				{
					return;
				}
				
				/* Check that we are actually working with a DataTables controlled row */
				if ( dt.oInstance.fnGetData(this) === null )
				{
				    return;
				}

				if ( that.fnIsSelected( this ) )
				{
					that._fnRowDeselect( this, e );
				}
				else if ( that.s.select.type == "single" )
				{
					that.fnSelectNone();
					that._fnRowSelect( this, e );
				}
				else if ( that.s.select.type == "multi" )
				{
					that._fnRowSelect( this, e );
				}
			} );

			// Bind a listener to the DataTable for when new rows are created.
			// This allows rows to be visually selected when they should be and
			// deferred rendering is used.
			dt.oApi._fnCallbackReg( dt, 'aoRowCreatedCallback', function (tr, data, index) {
				if ( dt.aoData[index]._DTTT_selected ) {
					$(tr).addClass( that.classes.select.row );
				}
			}, 'TableTools-SelectAll' );
		}
	},

	/**
	 * Select rows
	 *  @param   {*} src Rows to select - see _fnSelectData for a description of valid inputs
	 *  @private 
	 */
	"_fnRowSelect": function ( src, e )
	{
		var
			that = this,
			data = this._fnSelectData( src ),
			firstTr = data.length===0 ? null : data[0].nTr,
			anSelected = [],
			i, len;

		// Get all the rows that will be selected
		for ( i=0, len=data.length ; i<len ; i++ )
		{
			if ( data[i].nTr )
			{
				anSelected.push( data[i].nTr );
			}
		}
		
		// User defined pre-selection function
		if ( this.s.select.preRowSelect !== null && !this.s.select.preRowSelect.call(this, e, anSelected, true) )
		{
			return;
		}

		// Mark them as selected
		for ( i=0, len=data.length ; i<len ; i++ )
		{
			data[i]._DTTT_selected = true;

			if ( data[i].nTr )
			{
				$(data[i].nTr).addClass( that.classes.select.row );
			}
		}

		// Post-selection function
		if ( this.s.select.postSelected !== null )
		{
			this.s.select.postSelected.call( this, anSelected );
		}

		TableTools._fnEventDispatch( this, 'select', anSelected, true );
	},

	/**
	 * Deselect rows
	 *  @param   {*} src Rows to deselect - see _fnSelectData for a description of valid inputs
	 *  @private 
	 */
	"_fnRowDeselect": function ( src, e )
	{
		var
			that = this,
			data = this._fnSelectData( src ),
			firstTr = data.length===0 ? null : data[0].nTr,
			anDeselectedTrs = [],
			i, len;

		// Get all the rows that will be deselected
		for ( i=0, len=data.length ; i<len ; i++ )
		{
			if ( data[i].nTr )
			{
				anDeselectedTrs.push( data[i].nTr );
			}
		}

		// User defined pre-selection function
		if ( this.s.select.preRowSelect !== null && !this.s.select.preRowSelect.call(this, e, anDeselectedTrs, false) )
		{
			return;
		}

		// Mark them as deselected
		for ( i=0, len=data.length ; i<len ; i++ )
		{
			data[i]._DTTT_selected = false;

			if ( data[i].nTr )
			{
				$(data[i].nTr).removeClass( that.classes.select.row );
			}
		}

		// Post-deselection function
		if ( this.s.select.postDeselected !== null )
		{
			this.s.select.postDeselected.call( this, anDeselectedTrs );
		}

		TableTools._fnEventDispatch( this, 'select', anDeselectedTrs, false );
	},
	
	/**
	 * Take a data source for row selection and convert it into aoData points for the DT
	 *   @param {*} src Can be a single DOM TR node, an array of TR nodes (including a
	 *     a jQuery object), a single aoData point from DataTables, an array of aoData
	 *     points or an array of aoData indexes
	 *   @returns {array} An array of aoData points
	 */
	"_fnSelectData": function ( src )
	{
		var out = [], pos, i, iLen;

		if ( src.nodeName )
		{
			// Single node
			pos = this.s.dt.oInstance.fnGetPosition( src );
			out.push( this.s.dt.aoData[pos] );
		}
		else if ( typeof src.length !== 'undefined' )
		{
			// jQuery object or an array of nodes, or aoData points
			for ( i=0, iLen=src.length ; i<iLen ; i++ )
			{
				if ( src[i].nodeName )
				{
					pos = this.s.dt.oInstance.fnGetPosition( src[i] );
					out.push( this.s.dt.aoData[pos] );
				}
				else if ( typeof src[i] === 'number' )
				{
					out.push( this.s.dt.aoData[ src[i] ] );
				}
				else
				{
					out.push( src[i] );
				}
			}

			return out;
		}
		else
		{
			// A single aoData point
			out.push( src );
		}

		return out;
	},
	
	
	/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
	 * Text button functions
	 */
	
	/**
	 * Configure a text based button for interaction events
	 *  @method  _fnTextConfig
	 *  @param   {Node} nButton Button element which is being considered
	 *  @param   {Object} oConfig Button configuration object
	 *  @returns void
	 *  @private 
	 */
	"_fnTextConfig": function ( nButton, oConfig )
	{
		var that = this;
		
		if ( oConfig.fnInit !== null )
		{
			oConfig.fnInit.call( this, nButton, oConfig );
		}
		
		if ( oConfig.sToolTip !== "" )
		{
			nButton.title = oConfig.sToolTip;
		}
		
		$(nButton).hover( function () {
			if ( oConfig.fnMouseover !== null )
			{
				oConfig.fnMouseover.call( this, nButton, oConfig, null );
			}
		}, function () {
			if ( oConfig.fnMouseout !== null )
			{
				oConfig.fnMouseout.call( this, nButton, oConfig, null );
			}
		} );
		
		if ( oConfig.fnSelect !== null )
		{
			TableTools._fnEventListen( this, 'select', function (n) {
				oConfig.fnSelect.call( that, nButton, oConfig, n );
			} );
		}
		
		$(nButton).click( function (e) {
			//e.preventDefault();
			
			if ( oConfig.fnClick !== null )
			{
				oConfig.fnClick.call( that, nButton, oConfig, null, e );
			}
			
			/* Provide a complete function to match the behaviour of the flash elements */
			if ( oConfig.fnComplete !== null )
			{
				oConfig.fnComplete.call( that, nButton, oConfig, null, null );
			}
			
			that._fnCollectionHide( nButton, oConfig );
		} );
	},
	
	
	
	/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
	 * Flash button functions
	 */
	
	/**
	 * Configure a flash based button for interaction events
	 *  @method  _fnFlashConfig
	 *  @param   {Node} nButton Button element which is being considered
	 *  @param   {o} oConfig Button configuration object
	 *  @returns void
	 *  @private 
	 */
	"_fnFlashConfig": function ( nButton, oConfig )
	{
		var that = this;
		var flash = new ZeroClipboard_TableTools.Client();
		
		if ( oConfig.fnInit !== null )
		{
			oConfig.fnInit.call( this, nButton, oConfig );
		}
		
		flash.setHandCursor( true );
		
		if ( oConfig.sAction == "flash_save" )
		{
			flash.setAction( 'save' );
			flash.setCharSet( (oConfig.sCharSet=="utf16le") ? 'UTF16LE' : 'UTF8' );
			flash.setBomInc( oConfig.bBomInc );
			flash.setFileName( oConfig.sFileName.replace('*', this.fnGetTitle(oConfig)) );
		}
		else if ( oConfig.sAction == "flash_pdf" )
		{
			flash.setAction( 'pdf' );
			flash.setFileName( oConfig.sFileName.replace('*', this.fnGetTitle(oConfig)) );
		}
		else
		{
			flash.setAction( 'copy' );
		}
		
		flash.addEventListener('mouseOver', function(client) {
			if ( oConfig.fnMouseover !== null )
			{
				oConfig.fnMouseover.call( that, nButton, oConfig, flash );
			}
		} );
		
		flash.addEventListener('mouseOut', function(client) {
			if ( oConfig.fnMouseout !== null )
			{
				oConfig.fnMouseout.call( that, nButton, oConfig, flash );
			}
		} );
		
		flash.addEventListener('mouseDown', function(client) {
			if ( oConfig.fnClick !== null )
			{
				oConfig.fnClick.call( that, nButton, oConfig, flash );
			}
		} );
		
		flash.addEventListener('complete', function (client, text) {
			if ( oConfig.fnComplete !== null )
			{
				oConfig.fnComplete.call( that, nButton, oConfig, flash, text );
			}
			that._fnCollectionHide( nButton, oConfig );
		} );
		
		this._fnFlashGlue( flash, nButton, oConfig.sToolTip );
	},
	
	
	/**
	 * Wait until the id is in the DOM before we "glue" the swf. Note that this function will call
	 * itself (using setTimeout) until it completes successfully
	 *  @method  _fnFlashGlue
	 *  @param   {Object} clip Zero clipboard object
	 *  @param   {Node} node node to glue swf to
	 *  @param   {String} text title of the flash movie
	 *  @returns void
	 *  @private 
	 */
	"_fnFlashGlue": function ( flash, node, text )
	{
		var that = this;
		var id = node.getAttribute('id');
		
		if ( document.getElementById(id) )
		{
			flash.glue( node, text );
		}
		else
		{
			setTimeout( function () {
				that._fnFlashGlue( flash, node, text );
			}, 100 );
		}
	},
	
	
	/**
	 * Set the text for the flash clip to deal with
	 * 
	 * This function is required for large information sets. There is a limit on the 
	 * amount of data that can be transferred between Javascript and Flash in a single call, so
	 * we use this method to build up the text in Flash by sending over chunks. It is estimated
	 * that the data limit is around 64k, although it is undocumented, and appears to be different
	 * between different flash versions. We chunk at 8KiB.
	 *  @method  _fnFlashSetText
	 *  @param   {Object} clip the ZeroClipboard object
	 *  @param   {String} sData the data to be set
	 *  @returns void
	 *  @private 
	 */
	"_fnFlashSetText": function ( clip, sData )
	{
		var asData = this._fnChunkData( sData, 8192 );
		
		clip.clearText();
		for ( var i=0, iLen=asData.length ; i<iLen ; i++ )
		{
			clip.appendText( asData[i] );
		}
	},
	
	
	
	/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
	 * Data retrieval functions
	 */
	
	/**
	 * Convert the mixed columns variable into a boolean array the same size as the columns, which
	 * indicates which columns we want to include
	 *  @method  _fnColumnTargets
	 *  @param   {String|Array} mColumns The columns to be included in data retrieval. If a string
	 *			 then it can take the value of "visible" or "hidden" (to include all visible or
	 *			 hidden columns respectively). Or an array of column indexes
	 *  @returns {Array} A boolean array the length of the columns of the table, which each value
	 *			 indicating if the column is to be included or not
	 *  @private 
	 */
	"_fnColumnTargets": function ( mColumns )
	{
		var aColumns = [];
		var dt = this.s.dt;
		
		if ( typeof mColumns == "object" )
		{
			for ( i=0, iLen=dt.aoColumns.length ; i<iLen ; i++ )
			{
				aColumns.push( false );
			}
			
			for ( i=0, iLen=mColumns.length ; i<iLen ; i++ )
			{
				aColumns[ mColumns[i] ] = true;
			}
		}
		else if ( mColumns == "visible" )
		{
			for ( i=0, iLen=dt.aoColumns.length ; i<iLen ; i++ )
			{
				aColumns.push( dt.aoColumns[i].bVisible ? true : false );
			}
		}
		else if ( mColumns == "hidden" )
		{
			for ( i=0, iLen=dt.aoColumns.length ; i<iLen ; i++ )
			{
				aColumns.push( dt.aoColumns[i].bVisible ? false : true );
			}
		}
		else if ( mColumns == "sortable" )
		{
			for ( i=0, iLen=dt.aoColumns.length ; i<iLen ; i++ )
			{
				aColumns.push( dt.aoColumns[i].bSortable ? true : false );
			}
		}
		else /* all */
		{
			for ( i=0, iLen=dt.aoColumns.length ; i<iLen ; i++ )
			{
				aColumns.push( true );
			}
		}
		
		return aColumns;
	},
	
	
	/**
	 * New line character(s) depend on the platforms
	 *  @method  method
	 *  @param   {Object} oConfig Button configuration object - only interested in oConfig.sNewLine
	 *  @returns {String} Newline character
	 */
	"_fnNewline": function ( oConfig )
	{
		if ( oConfig.sNewLine == "auto" )
		{
			return navigator.userAgent.match(/Windows/) ? "\r\n" : "\n";
		}
		else
		{
			return oConfig.sNewLine;
		}
	},
	
	
	/**
	 * Get data from DataTables' internals and format it for output
	 *  @method  _fnGetDataTablesData
	 *  @param   {Object} oConfig Button configuration object
	 *  @param   {String} oConfig.sFieldBoundary Field boundary for the data cells in the string
	 *  @param   {String} oConfig.sFieldSeperator Field separator for the data cells
	 *  @param   {String} oConfig.sNewline New line options
	 *  @param   {Mixed} oConfig.mColumns Which columns should be included in the output
	 *  @param   {Boolean} oConfig.bHeader Include the header
	 *  @param   {Boolean} oConfig.bFooter Include the footer
	 *  @param   {Boolean} oConfig.bSelectedOnly Include only the selected rows in the output
	 *  @returns {String} Concatenated string of data
	 *  @private 
	 */
	"_fnGetDataTablesData": function ( oConfig )
	{
		var i, iLen, j, jLen;
		var aRow, aData=[], sLoopData='', arr;
		var dt = this.s.dt, tr, child;
		var regex = new RegExp(oConfig.sFieldBoundary, "g"); /* Do it here for speed */
		var aColumnsInc = this._fnColumnTargets( oConfig.mColumns );
		var bSelectedOnly = (typeof oConfig.bSelectedOnly != 'undefined') ? oConfig.bSelectedOnly : false;
		
		/*
		 * Header
		 */
		if ( oConfig.bHeader )
		{
			aRow = [];
			
			for ( i=0, iLen=dt.aoColumns.length ; i<iLen ; i++ )
			{
				if ( aColumnsInc[i] )
				{
					sLoopData = dt.aoColumns[i].sTitle.replace(/\n/g," ").replace( /<.*?>/g, "" ).replace(/^\s+|\s+$/g,"");
					sLoopData = this._fnHtmlDecode( sLoopData );
					
					aRow.push( this._fnBoundData( sLoopData, oConfig.sFieldBoundary, regex ) );
				}
			}

			aData.push( aRow.join(oConfig.sFieldSeperator) );
		}
		
		/*
		 * Body
		 */
		var aDataIndex = dt.aiDisplay;
		var aSelected = this.fnGetSelected();
		if ( this.s.select.type !== "none" && bSelectedOnly && aSelected.length !== 0 )
		{
			aDataIndex = [];
			for ( i=0, iLen=aSelected.length ; i<iLen ; i++ )
			{
				aDataIndex.push( dt.oInstance.fnGetPosition( aSelected[i] ) );
			}
		}
		
		for ( j=0, jLen=aDataIndex.length ; j<jLen ; j++ )
		{
			tr = dt.aoData[ aDataIndex[j] ].nTr;
			aRow = [];
			
			/* Columns */
			for ( i=0, iLen=dt.aoColumns.length ; i<iLen ; i++ )
			{
				if ( aColumnsInc[i] )
				{
					/* Convert to strings (with small optimisation) */
					var mTypeData = dt.oApi._fnGetCellData( dt, aDataIndex[j], i, 'display' );
					if ( oConfig.fnCellRender )
					{
						sLoopData = oConfig.fnCellRender( mTypeData, i, tr, aDataIndex[j] )+"";
					}
					else if ( typeof mTypeData == "string" )
					{
						/* Strip newlines, replace img tags with alt attr. and finally strip html... */
						sLoopData = mTypeData.replace(/\n/g," ");
						sLoopData =
						 	sLoopData.replace(/<img.*?\s+alt\s*=\s*(?:"([^"]+)"|'([^']+)'|([^\s>]+)).*?>/gi,
						 		'$1$2$3');
						sLoopData = sLoopData.replace( /<.*?>/g, "" );
					}
					else
					{
						sLoopData = mTypeData+"";
					}
					
					/* Trim and clean the data */
					sLoopData = sLoopData.replace(/^\s+/, '').replace(/\s+$/, '');
					sLoopData = this._fnHtmlDecode( sLoopData );
					
					/* Bound it and add it to the total data */
					aRow.push( this._fnBoundData( sLoopData, oConfig.sFieldBoundary, regex ) );
				}
			}
      
			aData.push( aRow.join(oConfig.sFieldSeperator) );
      
			/* Details rows from fnOpen */
			if ( oConfig.bOpenRows )
			{
				arr = $.grep(dt.aoOpenRows, function(o) { return o.nParent === tr; });
				
				if ( arr.length === 1 )
				{
					sLoopData = this._fnBoundData( $('td', arr[0].nTr).html(), oConfig.sFieldBoundary, regex );
					aData.push( sLoopData );
				}
			}
		}
		
		/*
		 * Footer
		 */
		if ( oConfig.bFooter && dt.nTFoot !== null )
		{
			aRow = [];
			
			for ( i=0, iLen=dt.aoColumns.length ; i<iLen ; i++ )
			{
				if ( aColumnsInc[i] && dt.aoColumns[i].nTf !== null )
				{
					sLoopData = dt.aoColumns[i].nTf.innerHTML.replace(/\n/g," ").replace( /<.*?>/g, "" );
					sLoopData = this._fnHtmlDecode( sLoopData );
					
					aRow.push( this._fnBoundData( sLoopData, oConfig.sFieldBoundary, regex ) );
				}
			}
			
			aData.push( aRow.join(oConfig.sFieldSeperator) );
		}
		
		_sLastData = aData.join( this._fnNewline(oConfig) );
		return _sLastData;
	},
	
	
	/**
	 * Wrap data up with a boundary string
	 *  @method  _fnBoundData
	 *  @param   {String} sData data to bound
	 *  @param   {String} sBoundary bounding char(s)
	 *  @param   {RegExp} regex search for the bounding chars - constructed outside for efficiency
	 *			 in the loop
	 *  @returns {String} bound data
	 *  @private 
	 */
	"_fnBoundData": function ( sData, sBoundary, regex )
	{
		if ( sBoundary === "" )
		{
			return sData;
		}
		else
		{
			return sBoundary + sData.replace(regex, sBoundary+sBoundary) + sBoundary;
		}
	},
	
	
	/**
	 * Break a string up into an array of smaller strings
	 *  @method  _fnChunkData
	 *  @param   {String} sData data to be broken up
	 *  @param   {Int} iSize chunk size
	 *  @returns {Array} String array of broken up text
	 *  @private 
	 */
	"_fnChunkData": function ( sData, iSize )
	{
		var asReturn = [];
		var iStrlen = sData.length;
		
		for ( var i=0 ; i<iStrlen ; i+=iSize )
		{
			if ( i+iSize < iStrlen )
			{
				asReturn.push( sData.substring( i, i+iSize ) );
			}
			else
			{
				asReturn.push( sData.substring( i, iStrlen ) );
			}
		}
		
		return asReturn;
	},
	
	
	/**
	 * Decode HTML entities
	 *  @method  _fnHtmlDecode
	 *  @param   {String} sData encoded string
	 *  @returns {String} decoded string
	 *  @private 
	 */
	"_fnHtmlDecode": function ( sData )
	{
		if ( sData.indexOf('&') === -1 )
		{
			return sData;
		}
		
		var n = document.createElement('div');

		return sData.replace( /&([^\s]*);/g, function( match, match2 ) {
			if ( match.substr(1, 1) === '#' )
			{
				return String.fromCharCode( Number(match2.substr(1)) );
			}
			else
			{
				n.innerHTML = match;
				return n.childNodes[0].nodeValue;
			}
		} );
	},
	
	
	
	/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
	 * Printing functions
	 */
	
	/**
	 * Show print display
	 *  @method  _fnPrintStart
	 *  @param   {Event} e Event object
	 *  @param   {Object} oConfig Button configuration object
	 *  @returns void
	 *  @private 
	 */
	"_fnPrintStart": function ( oConfig )
	{
	  var that = this;
	  var oSetDT = this.s.dt;
	  
		/* Parse through the DOM hiding everything that isn't needed for the table */
		this._fnPrintHideNodes( oSetDT.nTable );
		
		/* Show the whole table */
		this.s.print.saveStart = oSetDT._iDisplayStart;
		this.s.print.saveLength = oSetDT._iDisplayLength;

		if ( oConfig.bShowAll )
		{
			oSetDT._iDisplayStart = 0;
			oSetDT._iDisplayLength = -1;
			oSetDT.oApi._fnCalculateEnd( oSetDT );
			oSetDT.oApi._fnDraw( oSetDT );
		}
		
		/* Adjust the display for scrolling which might be done by DataTables */
		if ( oSetDT.oScroll.sX !== "" || oSetDT.oScroll.sY !== "" )
		{
			this._fnPrintScrollStart( oSetDT );

			// If the table redraws while in print view, the DataTables scrolling
			// setup would hide the header, so we need to readd it on draw
			$(this.s.dt.nTable).bind('draw.DTTT_Print', function () {
				that._fnPrintScrollStart( oSetDT );
			} );
		}
		
		/* Remove the other DataTables feature nodes - but leave the table! and info div */
		var anFeature = oSetDT.aanFeatures;
		for ( var cFeature in anFeature )
		{
			if ( cFeature != 'i' && cFeature != 't' && cFeature.length == 1 )
			{
				for ( var i=0, iLen=anFeature[cFeature].length ; i<iLen ; i++ )
				{
					this.dom.print.hidden.push( {
						"node": anFeature[cFeature][i],
						"display": "block"
					} );
					anFeature[cFeature][i].style.display = "none";
				}
			}
		}
		
		/* Print class can be used for styling */
		$(document.body).addClass( this.classes.print.body );

		/* Show information message to let the user know what is happening */
		if ( oConfig.sInfo !== "" )
		{
			this.fnInfo( oConfig.sInfo, 3000 );
		}

		/* Add a message at the top of the page */
		if ( oConfig.sMessage )
		{
			this.dom.print.message = document.createElement( "div" );
			this.dom.print.message.className = this.classes.print.message;
			this.dom.print.message.innerHTML = oConfig.sMessage;
			document.body.insertBefore( this.dom.print.message, document.body.childNodes[0] );
		}
		
		/* Cache the scrolling and the jump to the top of the page */
		this.s.print.saveScroll = $(window).scrollTop();
		window.scrollTo( 0, 0 );

		/* Bind a key event listener to the document for the escape key -
		 * it is removed in the callback
		 */
		$(document).bind( "keydown.DTTT", function(e) {
			/* Only interested in the escape key */
			if ( e.keyCode == 27 )
			{
				e.preventDefault();
				that._fnPrintEnd.call( that, e );
			}
		} );
	},
	
	
	/**
	 * Printing is finished, resume normal display
	 *  @method  _fnPrintEnd
	 *  @param   {Event} e Event object
	 *  @returns void
	 *  @private 
	 */
	"_fnPrintEnd": function ( e )
	{
		var that = this;
		var oSetDT = this.s.dt;
		var oSetPrint = this.s.print;
		var oDomPrint = this.dom.print;
		
		/* Show all hidden nodes */
		this._fnPrintShowNodes();
		
		/* Restore DataTables' scrolling */
		if ( oSetDT.oScroll.sX !== "" || oSetDT.oScroll.sY !== "" )
		{
			$(this.s.dt.nTable).unbind('draw.DTTT_Print');

			this._fnPrintScrollEnd();
		}
		
		/* Restore the scroll */
		window.scrollTo( 0, oSetPrint.saveScroll );
		
		/* Drop the print message */
		if ( oDomPrint.message !== null )
		{
			document.body.removeChild( oDomPrint.message );
			oDomPrint.message = null;
		}
		
		/* Styling class */
		$(document.body).removeClass( 'DTTT_Print' );
		
		/* Restore the table length */
		oSetDT._iDisplayStart = oSetPrint.saveStart;
		oSetDT._iDisplayLength = oSetPrint.saveLength;
		oSetDT.oApi._fnCalculateEnd( oSetDT );
		oSetDT.oApi._fnDraw( oSetDT );
		
		$(document).unbind( "keydown.DTTT" );
	},
	
	
	/**
	 * Take account of scrolling in DataTables by showing the full table
	 *  @returns void
	 *  @private 
	 */
	"_fnPrintScrollStart": function ()
	{
		var 
			oSetDT = this.s.dt,
			nScrollHeadInner = oSetDT.nScrollHead.getElementsByTagName('div')[0],
			nScrollHeadTable = nScrollHeadInner.getElementsByTagName('table')[0],
			nScrollBody = oSetDT.nTable.parentNode;

		/* Copy the header in the thead in the body table, this way we show one single table when
		 * in print view. Note that this section of code is more or less verbatim from DT 1.7.0
		 */
		var nTheadSize = oSetDT.nTable.getElementsByTagName('thead');
		if ( nTheadSize.length > 0 )
		{
			oSetDT.nTable.removeChild( nTheadSize[0] );
		}
		
		if ( oSetDT.nTFoot !== null )
		{
			var nTfootSize = oSetDT.nTable.getElementsByTagName('tfoot');
			if ( nTfootSize.length > 0 )
			{
				oSetDT.nTable.removeChild( nTfootSize[0] );
			}
		}
		
		nTheadSize = oSetDT.nTHead.cloneNode(true);
		oSetDT.nTable.insertBefore( nTheadSize, oSetDT.nTable.childNodes[0] );
		
		if ( oSetDT.nTFoot !== null )
		{
			nTfootSize = oSetDT.nTFoot.cloneNode(true);
			oSetDT.nTable.insertBefore( nTfootSize, oSetDT.nTable.childNodes[1] );
		}
		
		/* Now adjust the table's viewport so we can actually see it */
		if ( oSetDT.oScroll.sX !== "" )
		{
			oSetDT.nTable.style.width = $(oSetDT.nTable).outerWidth()+"px";
			nScrollBody.style.width = $(oSetDT.nTable).outerWidth()+"px";
			nScrollBody.style.overflow = "visible";
		}
		
		if ( oSetDT.oScroll.sY !== "" )
		{
			nScrollBody.style.height = $(oSetDT.nTable).outerHeight()+"px";
			nScrollBody.style.overflow = "visible";
		}
	},
	
	
	/**
	 * Take account of scrolling in DataTables by showing the full table. Note that the redraw of
	 * the DataTable that we do will actually deal with the majority of the hard work here
	 *  @returns void
	 *  @private 
	 */
	"_fnPrintScrollEnd": function ()
	{
		var 
			oSetDT = this.s.dt,
			nScrollBody = oSetDT.nTable.parentNode;
		
		if ( oSetDT.oScroll.sX !== "" )
		{
			nScrollBody.style.width = oSetDT.oApi._fnStringToCss( oSetDT.oScroll.sX );
			nScrollBody.style.overflow = "auto";
		}
		
		if ( oSetDT.oScroll.sY !== "" )
		{
			nScrollBody.style.height = oSetDT.oApi._fnStringToCss( oSetDT.oScroll.sY );
			nScrollBody.style.overflow = "auto";
		}
	},
	
	
	/**
	 * Resume the display of all TableTools hidden nodes
	 *  @method  _fnPrintShowNodes
	 *  @returns void
	 *  @private 
	 */
	"_fnPrintShowNodes": function ( )
	{
	  var anHidden = this.dom.print.hidden;
	  
		for ( var i=0, iLen=anHidden.length ; i<iLen ; i++ )
		{
			anHidden[i].node.style.display = anHidden[i].display;
		}
		anHidden.splice( 0, anHidden.length );
	},
	
	
	/**
	 * Hide nodes which are not needed in order to display the table. Note that this function is
	 * recursive
	 *  @method  _fnPrintHideNodes
	 *  @param   {Node} nNode Element which should be showing in a 'print' display
	 *  @returns void
	 *  @private 
	 */
	"_fnPrintHideNodes": function ( nNode )
	{
	  var anHidden = this.dom.print.hidden;
	  
		var nParent = nNode.parentNode;
		var nChildren = nParent.childNodes;
		for ( var i=0, iLen=nChildren.length ; i<iLen ; i++ )
		{
			if ( nChildren[i] != nNode && nChildren[i].nodeType == 1 )
			{
				/* If our node is shown (don't want to show nodes which were previously hidden) */
				var sDisplay = $(nChildren[i]).css("display");
			 	if ( sDisplay != "none" )
				{
					/* Cache the node and it's previous state so we can restore it */
					anHidden.push( {
						"node": nChildren[i],
						"display": sDisplay
					} );
					nChildren[i].style.display = "none";
				}
			}
		}
		
		if ( nParent.nodeName != "BODY" )
		{
			this._fnPrintHideNodes( nParent );
		}
	}
};



/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Static variables
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

/**
 * Store of all instances that have been created of TableTools, so one can look up other (when
 * there is need of a master)
 *  @property _aInstances
 *  @type	 Array
 *  @default  []
 *  @private
 */
TableTools._aInstances = [];


/**
 * Store of all listeners and their callback functions
 *  @property _aListeners
 *  @type	 Array
 *  @default  []
 */
TableTools._aListeners = [];



/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Static methods
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

/**
 * Get an array of all the master instances
 *  @method  fnGetMasters
 *  @returns {Array} List of master TableTools instances
 *  @static
 */
TableTools.fnGetMasters = function ()
{
	var a = [];
	for ( var i=0, iLen=TableTools._aInstances.length ; i<iLen ; i++ )
	{
		if ( TableTools._aInstances[i].s.master )
		{
			a.push( TableTools._aInstances[i] );
		}
	}
	return a;
};

/**
 * Get the master instance for a table node (or id if a string is given)
 *  @method  fnGetInstance
 *  @returns {Object} ID of table OR table node, for which we want the TableTools instance
 *  @static
 */
TableTools.fnGetInstance = function ( node )
{
	if ( typeof node != 'object' )
	{
		node = document.getElementById(node);
	}
	
	for ( var i=0, iLen=TableTools._aInstances.length ; i<iLen ; i++ )
	{
		if ( TableTools._aInstances[i].s.master && TableTools._aInstances[i].dom.table == node )
		{
			return TableTools._aInstances[i];
		}
	}
	return null;
};


/**
 * Add a listener for a specific event
 *  @method  _fnEventListen
 *  @param   {Object} that Scope of the listening function (i.e. 'this' in the caller)
 *  @param   {String} type Event type
 *  @param   {Function} fn Function
 *  @returns void
 *  @private
 *  @static
 */
TableTools._fnEventListen = function ( that, type, fn )
{
	TableTools._aListeners.push( {
		"that": that,
		"type": type,
		"fn": fn
	} );
};
	

/**
 * An event has occurred - look up every listener and fire it off. We check that the event we are
 * going to fire is attached to the same table (using the table node as reference) before firing
 *  @method  _fnEventDispatch
 *  @param   {Object} that Scope of the listening function (i.e. 'this' in the caller)
 *  @param   {String} type Event type
 *  @param   {Node} node Element that the event occurred on (may be null)
 *  @param   {boolean} [selected] Indicate if the node was selected (true) or deselected (false)
 *  @returns void
 *  @private
 *  @static
 */
TableTools._fnEventDispatch = function ( that, type, node, selected )
{
	var listeners = TableTools._aListeners;
	for ( var i=0, iLen=listeners.length ; i<iLen ; i++ )
	{
		if ( that.dom.table == listeners[i].that.dom.table && listeners[i].type == type )
		{
			listeners[i].fn( node, selected );
		}
	}
};






/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Constants
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */



TableTools.buttonBase = {
	// Button base
	"sAction": "text",
	"sTag": "default",
	"sLinerTag": "default",
	"sButtonClass": "DTTT_button_text",
	"sButtonText": "Button text",
	"sTitle": "",
	"sToolTip": "",

	// Common button specific options
	"sCharSet": "utf8",
	"bBomInc": false,
	"sFileName": "*.csv",
	"sFieldBoundary": "",
	"sFieldSeperator": "\t",
	"sNewLine": "auto",
	"mColumns": "all", /* "all", "visible", "hidden" or array of column integers */
	"bHeader": true,
	"bFooter": true,
	"bOpenRows": false,
	"bSelectedOnly": false,

	// Callbacks
	"fnMouseover": null,
	"fnMouseout": null,
	"fnClick": null,
	"fnSelect": null,
	"fnComplete": null,
	"fnInit": null,
	"fnCellRender": null
};


/**
 * @namespace Default button configurations
 */
TableTools.BUTTONS = {
	"csv": $.extend( {}, TableTools.buttonBase, {
		"sAction": "flash_save",
		"sButtonClass": "DTTT_button_csv",
		"sButtonText": "CSV",
		"sFieldBoundary": '"',
		"sFieldSeperator": ",",
		"fnClick": function( nButton, oConfig, flash ) {
			this.fnSetText( flash, this.fnGetTableData(oConfig) );
		}
	} ),

	"xls": $.extend( {}, TableTools.buttonBase, {
		"sAction": "flash_save",
		"sCharSet": "utf16le",
		"bBomInc": true,
		"sButtonClass": "DTTT_button_xls",
		"sButtonText": "Excel",
		"fnClick": function( nButton, oConfig, flash ) {
			this.fnSetText( flash, this.fnGetTableData(oConfig) );
		}
	} ),

	"copy": $.extend( {}, TableTools.buttonBase, {
		"sAction": "flash_copy",
		"sButtonClass": "DTTT_button_copy",
		"sButtonText": "Copy",
		"fnClick": function( nButton, oConfig, flash ) {
			this.fnSetText( flash, this.fnGetTableData(oConfig) );
		},
		"fnComplete": function(nButton, oConfig, flash, text) {
			var
				lines = text.split('\n').length,
				len = this.s.dt.nTFoot === null ? lines-1 : lines-2,
				plural = (len==1) ? "" : "s";
			this.fnInfo( '<h6>Table copied</h6>'+
				'<p>Copied '+len+' row'+plural+' to the clipboard.</p>',
				1500
			);
		}
	} ),

	"pdf": $.extend( {}, TableTools.buttonBase, {
		"sAction": "flash_pdf",
		"sNewLine": "\n",
		"sFileName": "*.pdf",
		"sButtonClass": "DTTT_button_pdf",
		"sButtonText": "PDF",
		"sPdfOrientation": "portrait",
		"sPdfSize": "A4",
		"sPdfMessage": "",
		"fnClick": function( nButton, oConfig, flash ) {
			this.fnSetText( flash, 
				"title:"+ this.fnGetTitle(oConfig) +"\n"+
				"message:"+ oConfig.sPdfMessage +"\n"+
				"colWidth:"+ this.fnCalcColRatios(oConfig) +"\n"+
				"orientation:"+ oConfig.sPdfOrientation +"\n"+
				"size:"+ oConfig.sPdfSize +"\n"+
				"--/TableToolsOpts--\n" +
				this.fnGetTableData(oConfig)
			);
		}
	} ),

	"print": $.extend( {}, TableTools.buttonBase, {
		"sInfo": "<h6>Print view</h6><p>Please use your browser's print function to "+
		  "print this table. Press escape when finished.",
		"sMessage": null,
		"bShowAll": true,
		"sToolTip": "View print view",
		"sButtonClass": "DTTT_button_print",
		"sButtonText": "Print",
		"fnClick": function ( nButton, oConfig ) {
			this.fnPrint( true, oConfig );
		}
	} ),

	"text": $.extend( {}, TableTools.buttonBase ),

	"select": $.extend( {}, TableTools.buttonBase, {
		"sButtonText": "Select button",
		"fnSelect": function( nButton, oConfig ) {
			if ( this.fnGetSelected().length !== 0 ) {
				$(nButton).removeClass( this.classes.buttons.disabled );
			} else {
				$(nButton).addClass( this.classes.buttons.disabled );
			}
		},
		"fnInit": function( nButton, oConfig ) {
			$(nButton).addClass( this.classes.buttons.disabled );
		}
	} ),

	"select_single": $.extend( {}, TableTools.buttonBase, {
		"sButtonText": "Select button",
		"fnSelect": function( nButton, oConfig ) {
			var iSelected = this.fnGetSelected().length;
			if ( iSelected == 1 ) {
				$(nButton).removeClass( this.classes.buttons.disabled );
			} else {
				$(nButton).addClass( this.classes.buttons.disabled );
			}
		},
		"fnInit": function( nButton, oConfig ) {
			$(nButton).addClass( this.classes.buttons.disabled );
		}
	} ),

	"select_all": $.extend( {}, TableTools.buttonBase, {
		"sButtonText": "Select all",
		"fnClick": function( nButton, oConfig ) {
			this.fnSelectAll();
		},
		"fnSelect": function( nButton, oConfig ) {
			if ( this.fnGetSelected().length == this.s.dt.fnRecordsDisplay() ) {
				$(nButton).addClass( this.classes.buttons.disabled );
			} else {
				$(nButton).removeClass( this.classes.buttons.disabled );
			}
		}
	} ),

	"select_none": $.extend( {}, TableTools.buttonBase, {
		"sButtonText": "Deselect all",
		"fnClick": function( nButton, oConfig ) {
			this.fnSelectNone();
		},
		"fnSelect": function( nButton, oConfig ) {
			if ( this.fnGetSelected().length !== 0 ) {
				$(nButton).removeClass( this.classes.buttons.disabled );
			} else {
				$(nButton).addClass( this.classes.buttons.disabled );
			}
		},
		"fnInit": function( nButton, oConfig ) {
			$(nButton).addClass( this.classes.buttons.disabled );
		}
	} ),

	"ajax": $.extend( {}, TableTools.buttonBase, {
		"sAjaxUrl": "/xhr.php",
		"sButtonText": "Ajax button",
		"fnClick": function( nButton, oConfig ) {
			var sData = this.fnGetTableData(oConfig);
			$.ajax( {
				"url": oConfig.sAjaxUrl,
				"data": [
					{ "name": "tableData", "value": sData }
				],
				"success": oConfig.fnAjaxComplete,
				"dataType": "json",
				"type": "POST", 
				"cache": false,
				"error": function () {
					alert( "Error detected when sending table data to server" );
				}
			} );
		},
		"fnAjaxComplete": function( json ) {
			alert( 'Ajax complete' );
		}
	} ),

	"div": $.extend( {}, TableTools.buttonBase, {
		"sAction": "div",
		"sTag": "div",
		"sButtonClass": "DTTT_nonbutton",
		"sButtonText": "Text button"
	} ),

	"collection": $.extend( {}, TableTools.buttonBase, {
		"sAction": "collection",
		"sButtonClass": "DTTT_button_collection",
		"sButtonText": "Collection",
		"fnClick": function( nButton, oConfig ) {
			this._fnCollectionShow(nButton, oConfig);
		}
	} )
};
/*
 *  on* callback parameters:
 *  	1. node - button element
 *  	2. object - configuration object for this button
 *  	3. object - ZeroClipboard reference (flash button only)
 *  	4. string - Returned string from Flash (flash button only - and only on 'complete')
 */



/**
 * @namespace Classes used by TableTools - allows the styles to be override easily.
 *   Note that when TableTools initialises it will take a copy of the classes object
 *   and will use its internal copy for the remainder of its run time.
 */
TableTools.classes = {
	"container": "DTTT_container",
	"buttons": {
		"normal": "DTTT_button",
		"disabled": "DTTT_disabled"
	},
	"collection": {
		"container": "DTTT_collection",
		"background": "DTTT_collection_background",
		"buttons": {
			"normal": "DTTT_button",
			"disabled": "DTTT_disabled"
		}
	},
	"select": {
		"table": "DTTT_selectable",
		"row": "DTTT_selected"
	},
	"print": {
		"body": "DTTT_Print",
		"info": "DTTT_print_info",
		"message": "DTTT_PrintMessage"
	}
};


/**
 * @namespace ThemeRoller classes - built in for compatibility with DataTables' 
 *   bJQueryUI option.
 */
TableTools.classes_themeroller = {
	"container": "DTTT_container ui-buttonset ui-buttonset-multi",
	"buttons": {
		"normal": "DTTT_button ui-button ui-state-default"
	},
	"collection": {
		"container": "DTTT_collection ui-buttonset ui-buttonset-multi"
	}
};


/**
 * @namespace TableTools default settings for initialisation
 */
TableTools.DEFAULTS = {
	"sSwfPath":        "../../assets/js/datatables/copy_csv_xls_pdf.swf",
	"sRowSelect":      "none",
	"sSelectedClass":  null,
	"fnPreRowSelect":  null,
	"fnRowSelected":   null,
	"fnRowDeselected": null,
	"aButtons":        [ "copy", "csv", "xls", "pdf", "print" ],
	"oTags": {
		"container": "div",
		"button": "a", // We really want to use buttons here, but Firefox and IE ignore the
		                 // click on the Flash element in the button (but not mouse[in|out]).
		"liner": "span",
		"collection": {
			"container": "div",
			"button": "a",
			"liner": "span"
		}
	}
};


/**
 * Name of this class
 *  @constant CLASS
 *  @type	 String
 *  @default  TableTools
 */
TableTools.prototype.CLASS = "TableTools";


/**
 * TableTools version
 *  @constant  VERSION
 *  @type	  String
 *  @default   See code
 */
TableTools.VERSION = "2.1.5";
TableTools.prototype.VERSION = TableTools.VERSION;




/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Initialisation
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

/*
 * Register a new feature with DataTables
 */
if ( typeof $.fn.dataTable == "function" &&
	 typeof $.fn.dataTableExt.fnVersionCheck == "function" &&
	 $.fn.dataTableExt.fnVersionCheck('1.9.0') )
{
	$.fn.dataTableExt.aoFeatures.push( {
		"fnInit": function( oDTSettings ) {
			var oOpts = typeof oDTSettings.oInit.oTableTools != 'undefined' ? 
				oDTSettings.oInit.oTableTools : {};
			
			var oTT = new TableTools( oDTSettings.oInstance, oOpts );
			TableTools._aInstances.push( oTT );
			
			return oTT.dom.container;
		},
		"cFeature": "T",
		"sFeature": "TableTools"
	} );
}
else
{
	alert( "Warning: TableTools 2 requires DataTables 1.9.0 or newer - www.datatables.net/download");
}

$.fn.DataTable.TableTools = TableTools;

})(jQuery, window, document);

/* Set the defaults for DataTables initialisation */
jQuery.extend( true, jQuery.fn.dataTable.defaults, {
	"sDom": "<'row'<'col-xs-6 col-left'l><'col-xs-6 col-right'f>r>t<'row'<'col-xs-6 col-left'i><'col-xs-6 col-right'p>>",
	"sPaginationType": "bootstrap",
	"oLanguage": {
	    "sLengthMenu": "_MENU_ "
		//"sLengthMenu": "_MENU_ records per page"
	}
} );

/* Default class modification */
jQuery.extend( jQuery.fn.dataTableExt.oStdClasses, {
	"sWrapper": "dataTables_wrapper form-inline",
	"sFilterInput": "form-control input-sm",
	"sLengthSelect": "form-control input-sm"
} );


/* API method to get paging information */
jQuery.fn.dataTableExt.oApi.fnPagingInfo = function ( oSettings )
{
	return {
		"iStart":         oSettings._iDisplayStart,
		"iEnd":           oSettings.fnDisplayEnd(),
		"iLength":        oSettings._iDisplayLength,
		"iTotal":         oSettings.fnRecordsTotal(),
		"iFilteredTotal": oSettings.fnRecordsDisplay(),
		"iPage":          oSettings._iDisplayLength === -1 ?
			0 : Math.ceil( oSettings._iDisplayStart / oSettings._iDisplayLength ),
		"iTotalPages":    oSettings._iDisplayLength === -1 ?
			0 : Math.ceil( oSettings.fnRecordsDisplay() / oSettings._iDisplayLength )
	};
};


/* Bootstrap style pagination control */
jQuery.extend( jQuery.fn.dataTableExt.oPagination, {
	"bootstrap": {
		"fnInit": function( oSettings, nPaging, fnDraw ) {
			var oLang = oSettings.oLanguage.oPaginate;
			var fnClickHandler = function ( e ) {
				e.preventDefault();
				if ( oSettings.oApi._fnPageChange(oSettings, e.data.action) ) {
					fnDraw( oSettings );
				}
			};

			jQuery(nPaging).append(
				'<ul class="pagination pagination-sm">'+
					'<li class="prev disabled"><a href="#"><i class="entypo-left-open"></i></a></li>'+
					'<li class="next disabled"><a href="#"><i class="entypo-right-open"></i></a></li>'+
				'</ul>'
			);
			var els = jQuery('a', nPaging);
			jQuery(els[0]).bind( 'click.DT', { action: "previous" }, fnClickHandler );
			jQuery(els[1]).bind( 'click.DT', { action: "next" }, fnClickHandler );
		},

		"fnUpdate": function ( oSettings, fnDraw ) {
			var iListLength = 5;
			var oPaging = oSettings.oInstance.fnPagingInfo();
			var an = oSettings.aanFeatures.p;
			var i, ien, j, sClass, iStart, iEnd, iHalf=Math.floor(iListLength/2);

			if ( oPaging.iTotalPages < iListLength) {
				iStart = 1;
				iEnd = oPaging.iTotalPages;
			}
			else if ( oPaging.iPage <= iHalf ) {
				iStart = 1;
				iEnd = iListLength;
			} else if ( oPaging.iPage >= (oPaging.iTotalPages-iHalf) ) {
				iStart = oPaging.iTotalPages - iListLength + 1;
				iEnd = oPaging.iTotalPages;
			} else {
				iStart = oPaging.iPage - iHalf + 1;
				iEnd = iStart + iListLength - 1;
			}

			for ( i=0, ien=an.length ; i<ien ; i++ ) {
				// Remove the middle elements
				jQuery('li:gt(0)', an[i]).filter(':not(:last)').remove();

				// Add the new list items and their event handlers
				for ( j=iStart ; j<=iEnd ; j++ ) {
					sClass = (j==oPaging.iPage+1) ? 'class="active"' : '';
					jQuery('<li '+sClass+'><a href="#">'+j+'</a></li>')
						.insertBefore( jQuery('li:last', an[i])[0] )
						.bind('click', function (e) {
							e.preventDefault();
							oSettings._iDisplayStart = (parseInt(jQuery('a', this).text(),10)-1) * oPaging.iLength;
							fnDraw( oSettings );
						} );
				}

				// Add / remove disabled classes from the static elements
				if ( oPaging.iPage === 0 ) {
					jQuery('li:first', an[i]).addClass('disabled');
				} else {
					jQuery('li:first', an[i]).removeClass('disabled');
				}

				if ( oPaging.iPage === oPaging.iTotalPages-1 || oPaging.iTotalPages === 0 ) {
					jQuery('li:last', an[i]).addClass('disabled');
				} else {
					jQuery('li:last', an[i]).removeClass('disabled');
				}
			}
		}
	}
} );


/*
 * TableTools Bootstrap compatibility
 * Required TableTools 2.1+
 */
if ( jQuery.fn.DataTable.TableTools ) {
	// Set the classes that TableTools uses to something suitable for Bootstrap
	jQuery.extend( true, jQuery.fn.DataTable.TableTools.classes, {
		"container": "DTTT btn-group",
		"buttons": {
			"normal": "btn btn-white",
			"disabled": "disabled"
		},
		"collection": {
			"container": "DTTT_dropdown dropdown-menu",
			"buttons": {
				"normal": "",
				"disabled": "disabled"
			}
		},
		"print": {
			"info": "DTTT_print_info modal"
		},
		"select": {
			"row": "active"
		}
	} );

	// Have the collection use a bootstrap compatible dropdown
	jQuery.extend( true, jQuery.fn.DataTable.TableTools.DEFAULTS.oTags, {
		"collection": {
			"container": "ul",
			"button": "li",
			"liner": "a"
		}
	} );
}


/*
* File:        jquery.dataTables.columnFilter.js
* Version:     1.5.0.
* Author:      Jovan Popovic 
* http://jquery-datatables-column-filter.googlecode.com/svn/trunk/index.htmls
* http://code.google.com/p/jquery-datatables-column-filter/
* 
* Copyright 2011-2012 Jovan Popovic, all rights reserved.
*
* This source file is free software, under either the GPL v2 license or a
* BSD style license, as supplied with this software.
* 
* This source file is distributed in the hope that it will be useful, but 
* WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
* or FITNESS FOR A PARTICULAR PURPOSE. 
* 
* Parameters:"
* @sPlaceHolder                 String      Place where inline filtering function should be placed ("tfoot", "thead:before", "thead:after"). Default is "tfoot"
* @sRangeSeparator              String      Separator that will be used when range values are sent to the server-side. Default value is "~".
* @sRangeFormat                 string      Default format of the From ... to ... range inputs. Default is From {from} to {to}
* @aoColumns                    Array       Array of the filter settings that will be applied on the columns
*/
(function ($) {


    $.fn.columnFilter = function (options) {

        var asInitVals, i, label, th;

        //var sTableId = "table";
        var sRangeFormat = "From {from} to {to}";
        //Array of the functions that will override sSearch_ parameters
        var afnSearch_ = new Array();
        var aiCustomSearch_Indexes = new Array();

        var oFunctionTimeout = null;

        var fnOnFiltered = function () { };

        function _fnGetColumnValues(oSettings, iColumn, bUnique, bFiltered, bIgnoreEmpty) {
            ///<summary>
            ///Return values in the column
            ///</summary>
            ///<param name="oSettings" type="Object">DataTables settings</param>
            ///<param name="iColumn" type="int">Id of the column</param>
            ///<param name="bUnique" type="bool">Return only distinct values</param>
            ///<param name="bFiltered" type="bool">Return values only from the filtered rows</param>
            ///<param name="bIgnoreEmpty" type="bool">Ignore empty cells</param>

            // check that we have a column id
            if (typeof iColumn == "undefined") return new Array();

            // by default we only wany unique data
            if (typeof bUnique == "undefined") bUnique = true;

            // by default we do want to only look at filtered data
            if (typeof bFiltered == "undefined") bFiltered = true;

            // by default we do not wany to include empty values
            if (typeof bIgnoreEmpty == "undefined") bIgnoreEmpty = true;

            // list of rows which we're going to loop through
            var aiRows;

            // use only filtered rows
            if (bFiltered == true) aiRows = oSettings.aiDisplay;
            // use all rows
            else aiRows = oSettings.aiDisplayMaster; // all row numbers

            // set up data array    
            var asResultData = new Array();

            for (var i = 0, c = aiRows.length; i < c; i++) {
                var iRow = aiRows[i];
                var aData = oTable.fnGetData(iRow);
                var sValue = aData[iColumn];

                // ignore empty values?
                if (bIgnoreEmpty == true && sValue.length == 0) continue;

                // ignore unique values?
                else if (bUnique == true && jQuery.inArray(sValue, asResultData) > -1) continue;

                // else push the value onto the result data array
                else asResultData.push(sValue);
            }

            return asResultData.sort();
        }

        function _fnColumnIndex(iColumnIndex) {
            if (properties.bUseColVis)
                return iColumnIndex;
            else
                return oTable.fnSettings().oApi._fnVisibleToColumnIndex(oTable.fnSettings(), iColumnIndex);
            //return iColumnIndex;
            //return oTable.fnSettings().oApi._fnColumnIndexToVisible(oTable.fnSettings(), iColumnIndex);
        }

        function fnCreateInput(oTable, regex, smart, bIsNumber, iFilterLength, iMaxLenght) {
            var sCSSClass = "text_filter";
            if (bIsNumber)
                sCSSClass = "number_filter";

            label = label.replace(/(^\s*)|(\s*$)/g, "");
            var currentFilter = oTable.fnSettings().aoPreSearchCols[i].sSearch;
            var search_init = 'search_init ';
            var inputvalue = label;
            if (currentFilter != '' && currentFilter != '^') {
                if (bIsNumber && currentFilter.charAt(0) == '^')
                    inputvalue = currentFilter.substr(1); //ignore trailing ^
                else
                    inputvalue = currentFilter;
                search_init = '';
            }

            var input = $('<input type="text" class="' + search_init + sCSSClass + '" value="' + inputvalue + '"/>');
            if (iMaxLenght != undefined && iMaxLenght != -1) {
                input.attr('maxlength', iMaxLenght);
            }
            th.html(input);
            if (bIsNumber)
                th.wrapInner('<span class="filter_column filter_number" />');
            else
                th.wrapInner('<span class="filter_column filter_text" />');

            asInitVals[i] = label;
            var index = i;

            if (bIsNumber && !oTable.fnSettings().oFeatures.bServerSide) {
                input.keyup(function () {
                    /* Filter on the column all numbers that starts with the entered value */
                    oTable.fnFilter('^' + this.value, _fnColumnIndex(index), true, false); //Issue 37
                    fnOnFiltered();
                });
            } else {
                input.keyup(function () {
                    if (oTable.fnSettings().oFeatures.bServerSide && iFilterLength != 0) {
                        //If filter length is set in the server-side processing mode
                        //Check has the user entered at least iFilterLength new characters

                        var currentFilter = oTable.fnSettings().aoPreSearchCols[index].sSearch;
                        var iLastFilterLength = $(this).data("dt-iLastFilterLength");
                        if (typeof iLastFilterLength == "undefined")
                            iLastFilterLength = 0;
                        var iCurrentFilterLength = this.value.length;
                        if (Math.abs(iCurrentFilterLength - iLastFilterLength) < iFilterLength
                        //&& currentFilter.length == 0 //Why this?
                            ) {
                            //Cancel the filtering
                            return;
                        }
                        else {
                            //Remember the current filter length
                            $(this).data("dt-iLastFilterLength", iCurrentFilterLength);
                        }
                    }
                    /* Filter on the column (the index) of this element */
                    oTable.fnFilter(this.value, _fnColumnIndex(index), regex, smart); //Issue 37
                    fnOnFiltered();
                });
            }

            input.focus(function () {
                if ($(this).hasClass("search_init")) {
                    $(this).removeClass("search_init");
                    this.value = "";
                }
            });
            input.blur(function () {
                if (this.value == "") {
                    $(this).addClass("search_init");
                    this.value = asInitVals[index];
                }
            });
        }

        function fnCreateRangeInput(oTable) {

            //var currentFilter = oTable.fnSettings().aoPreSearchCols[i].sSearch;
            th.html(_fnRangeLabelPart(0));
            var sFromId = oTable.attr("id") + '_range_from_' + i;
            var from = $('<input type="text" class="number_range_filter" id="' + sFromId + '" rel="' + i + '"/>');
            th.append(from);
            th.append(_fnRangeLabelPart(1));
            var sToId = oTable.attr("id") + '_range_to_' + i;
            var to = $('<input type="text" class="number_range_filter" id="' + sToId + '" rel="' + i + '"/>');
            th.append(to);
            th.append(_fnRangeLabelPart(2));
            th.wrapInner('<span class="filter_column filter_number_range" />');
            var index = i;
            aiCustomSearch_Indexes.push(i);



            //------------start range filtering function


            /*  Custom filtering function which will filter data in column four between two values
            *   Author:     Allan Jardine, Modified by Jovan Popovic
            */
            //$.fn.dataTableExt.afnFiltering.push(
            oTable.dataTableExt.afnFiltering.push(
            function (oSettings, aData, iDataIndex) {
                if (oTable.attr("id") != oSettings.sTableId)
                    return true;
                // Try to handle missing nodes more gracefully
                if (document.getElementById(sFromId) == null)
                    return true;
                var iMin = document.getElementById(sFromId).value * 1;
                var iMax = document.getElementById(sToId).value * 1;
                var iValue = aData[_fnColumnIndex(index)] == "-" ? 0 : aData[_fnColumnIndex(index)] * 1;
                if (iMin == "" && iMax == "") {
                    return true;
                }
                else if (iMin == "" && iValue <= iMax) {
                    return true;
                }
                else if (iMin <= iValue && "" == iMax) {
                    return true;
                }
                else if (iMin <= iValue && iValue <= iMax) {
                    return true;
                }
                return false;
            }
        );
            //------------end range filtering function



            $('#' + sFromId + ',#' + sToId, th).keyup(function () {

                var iMin = document.getElementById(sFromId).value * 1;
                var iMax = document.getElementById(sToId).value * 1;
                if (iMin != 0 && iMax != 0 && iMin > iMax)
                    return;

                oTable.fnDraw();
                fnOnFiltered();
            });


        }


        function fnCreateDateRangeInput(oTable) {

            var aoFragments = sRangeFormat.split(/[}{]/);

            th.html("");
            //th.html(_fnRangeLabelPart(0));
            var sFromId = oTable.attr("id") + '_range_from_' + i;
            var from = $('<input type="text" placeholder="From" class="date_range_filter" style="margin-bottom:2px;" id="' + sFromId + '" rel="' + i + '"/>');
            from.datepicker();
            //th.append(from);
            //th.append(_fnRangeLabelPart(1));
            var sToId = oTable.attr("id") + '_range_to_' + i;
            var to = $('<input type="text" placeholder="To" class="date_range_filter" id="' + sToId + '" rel="' + i + '"/>');
            //th.append(to);
            //th.append(_fnRangeLabelPart(2));

            for (ti = 0; ti < aoFragments.length; ti++) {
                if (aoFragments[ti] == properties.sDateFromToken) {
                    th.append(from);
                } else {
                    if (aoFragments[ti] == properties.sDateToToken) {
                        th.append(to);
                    } else {
                        th.append(aoFragments[ti]);
                    }
                }
                

            }


            th.wrapInner('<span class="filter_column filter_date_range" />');
            to.datepicker();
            var index = i;
            aiCustomSearch_Indexes.push(i);


            //------------start date range filtering function

            //$.fn.dataTableExt.afnFiltering.push(
            oTable.dataTableExt.afnFiltering.push(
            function (oSettings, aData, iDataIndex) {
                if (oTable.attr("id") != oSettings.sTableId)
                    return true;

                var dStartDate = from.datepicker("getDate");

                var dEndDate = to.datepicker("getDate");

                if (dStartDate == null && dEndDate == null) {
                    return true;
                }

                var dCellDate = null;
                try {
                    if (aData[_fnColumnIndex(index)] == null || aData[_fnColumnIndex(index)] == "")
                        return false;
                    dCellDate = $.datepicker.parseDate(from.datepicker("option", "dateFormat"), aData[_fnColumnIndex(index)]);
                } catch (ex) {
                    console.log(ex);
                    return false;
                }
                if (dCellDate == null)
                    return false;

                
                if (dStartDate == null && dCellDate <= dEndDate) {
                    return true;
                }
                else if (dStartDate <= dCellDate && dEndDate == null) {
                    return true;
                }
                else if (dStartDate <= dCellDate && dCellDate <= dEndDate) {
                    return true;
                }
                return false;
            }
        );
            //------------end date range filtering function

            $('#' + sFromId + ',#' + sToId, th).change(function () {
                oTable.fnDraw();
                fnOnFiltered();
            });


        }

        function fnCreateColumnSelect(oTable, aData, iColumn, nTh, sLabel, bRegex, oSelected, bCaseSensitive) {
            bCaseSensitive = (typeof bCaseSensitive !== 'undefined') ? !bCaseSensitive : true;
            if (aData == null)
                aData = _fnGetColumnValues(oTable.fnSettings(), iColumn, true, false, true);
            var index = iColumn;
            var currentFilter = oTable.fnSettings().aoPreSearchCols[i].sSearch;
            if (currentFilter == null || currentFilter == "")//Issue 81
                currentFilter = oSelected;

            var r = '<select class="search_init select_filter"><option value="" class="search_init">' + sLabel + '</option>';
            var j = 0;
            var iLen = aData.length;
            for (j = 0; j < iLen; j++) {
                if (typeof (aData[j]) != 'object') {
                    var selected = '';
                    if (escape(aData[j]) == currentFilter
                        || escape(aData[j]) == escape(currentFilter)
                        )
                        selected = 'selected '
                    r += '<option ' + selected + ' value="' + escape(aData[j]) + '">' + aData[j] + '</option>';
                }
                else {
                    var selected = '';
                    if (bRegex) {
                        //Do not escape values if they are explicitely set to avoid escaping special characters in the regexp
                        if (aData[j].value == currentFilter) selected = 'selected ';
                        r += '<option ' + selected + 'value="' + aData[j].value + '">' + aData[j].label + '</option>';
                    } else {
                        if (escape(aData[j].value) == currentFilter) selected = 'selected ';
                        r += '<option ' + selected + 'value="' + escape(aData[j].value) + '">' + aData[j].label + '</option>';
                    }
                }
            }

            var select = $(r + '</select>');
            nTh.html(select);
            nTh.wrapInner('<span class="filter_column filter_select" />');
            select.change(function () {
                //var val = $(this).val();
                if ($(this).val() != "") {
                    $(this).removeClass("search_init");
                } else {
                    $(this).addClass("search_init");
                }
                if (bRegex)
                    oTable.fnFilter($(this).val(), iColumn, bRegex, true, true, bCaseSensitive); //Issue 41
                else
                    oTable.fnFilter(unescape($(this).val()), iColumn, bRegex, true, true, bCaseSensitive); //Issue 25
                fnOnFiltered();
            });
            if (currentFilter != null && currentFilter != "")//Issue 81
                oTable.fnFilter(unescape(currentFilter), iColumn);
        }

        function fnCreateSelect(oTable, aData, bRegex, oSelected, bCaseSensitive) {
            var oSettings = oTable.fnSettings();
            if (aData == null && oSettings.sAjaxSource != "" && !oSettings.oFeatures.bServerSide) {
                // Add a function to the draw callback, which will check for the Ajax data having 
                // been loaded. Use a closure for the individual column elements that are used to 
                // built the column filter, since 'i' and 'th' (etc) are locally "global".
                oSettings.aoDrawCallback.push({
                    "fn": (function (iColumn, nTh, sLabel) {
                        return function () {
                            // Only rebuild the select on the second draw - i.e. when the Ajax
                            // data has been loaded.
                            if (oSettings.iDraw == 2 && oSettings.sAjaxSource != null && oSettings.sAjaxSource != "" && !oSettings.oFeatures.bServerSide) {
                                return fnCreateColumnSelect(oTable, null, _fnColumnIndex(iColumn), nTh, sLabel, bRegex, oSelected); //Issue 37
                            }
                        };
                    })(i, th, label),
                    "sName": "column_filter_" + i
                });
            }
            // Regardless of the Ajax state, build the select on first pass
            fnCreateColumnSelect(oTable, aData, _fnColumnIndex(i), th, label, bRegex, oSelected, bCaseSensitive); //Issue 37

        }

        function fnCreateCheckbox(oTable, aData) {

            if (aData == null)
                aData = _fnGetColumnValues(oTable.fnSettings(), i, true, true, true);
            var index = i;

            var r = '', j, iLen = aData.length;

            //clean the string
            var localLabel = label.replace('%', 'Perc').replace("&", "AND").replace("$", "DOL").replace("£", "STERL").replace("@", "AT").replace(/\s/g, "_");
            localLabel = localLabel.replace(/[^a-zA-Z 0-9]+/g, '');
            //clean the string

            //button label override
            var labelBtn = label;
            if (properties.sFilterButtonText != null || properties.sFilterButtonText != undefined) {
                labelBtn = properties.sFilterButtonText;
            }

            var relativeDivWidthToggleSize = 10;
            var numRow = 12; //numero di checkbox per colonna
            var numCol = Math.floor(iLen / numRow);
            if (iLen % numRow > 0) {
                numCol = numCol + 1;
            };

            //count how many column should be generated and split the div size
            var divWidth = 100 / numCol - 2;

            var divWidthToggle = relativeDivWidthToggleSize * numCol;

            if (numCol == 1) {
                divWidth = 20;
            }

            var divRowDef = '<div style="float:left; min-width: ' + divWidth + '%; " >';
            var divClose = '</div>';

            var uniqueId = oTable.attr("id") + localLabel;
            var buttonId = "chkBtnOpen" + uniqueId;
            var checkToggleDiv = uniqueId + "-flt-toggle";
            r += '<button id="' + buttonId + '" class="checkbox_filter" > ' + labelBtn + '</button>'; //filter button witch open dialog
            r += '<div id="' + checkToggleDiv + '" '
                + 'title="' + label + '" '
                + 'class="toggle-check ui-widget-content ui-corner-all"  style="width: ' + (divWidthToggle) + '%; " >'; //dialog div
            //r+= '<div align="center" style="margin-top: 5px; "> <button id="'+buttonId+'Reset" class="checkbox_filter" > reset </button> </div>'; //reset button and its div
            r += divRowDef;

            for (j = 0; j < iLen; j++) {

                //if last check close div
                if (j % numRow == 0 && j != 0) {
                    r += divClose + divRowDef;
                }

                //check button
                r += '<input class="search_init checkbox_filter" type="checkbox" id= "' + aData[j] + '" name= "' + localLabel + '" value="' + aData[j] + '" >' + aData[j] + '<br/>';

                var checkbox = $(r);
                th.html(checkbox);
                th.wrapInner('<span class="filter_column filter_checkbox" />');
                //on every checkbox selection
                checkbox.change(function () {

                    var search = '';
                    var or = '|'; //var for select checks in 'or' into the regex
                    var resSize = $('input:checkbox[name="' + localLabel + '"]:checked').size();
                    $('input:checkbox[name="' + localLabel + '"]:checked').each(function (index) {

                        //search = search + ' ' + $(this).val();
                        //concatenation for selected checks in or
                        if ((index == 0 && resSize == 1)
                                || (index != 0 && index == resSize - 1)) {
                            or = '';
                        }
                        //trim
                        search = search.replace(/^\s+|\s+$/g, "");
                        search = search + $(this).val() + or;
                        or = '|';

                    });

                    for (var jj = 0; jj < iLen; jj++) {
                        if (search != "") {
                            $('#' + aData[jj]).removeClass("search_init");
                        } else {
                            $('#' + aData[jj]).addClass("search_init");
                        }
                    }

                    //execute search
                    oTable.fnFilter(search, index, true, false);
                    fnOnFiltered();
                });
            }

            //filter button
            $('#' + buttonId).button();
            //dialog
            $('#' + checkToggleDiv).dialog({
                //height: 140,
                autoOpen: false,
                //show: "blind",
                hide: "blind",
                buttons: [{
                    text: "Reset",
                    click: function () {
                        //$('#'+buttonId).removeClass("filter_selected"); //LM remove border if filter selected
                        $('input:checkbox[name="' + localLabel + '"]:checked').each(function (index3) {
                            $(this).attr('checked', false);
                            $(this).addClass("search_init");
                        });
                        oTable.fnFilter('', index, true, false);
                        fnOnFiltered();
                        return false;
                    }
                },
                            {
                                text: "Close",
                                click: function () { $(this).dialog("close"); }
                            }
                        ]
            });


            $('#' + buttonId).click(function () {

                $('#' + checkToggleDiv).dialog('open');
                var target = $(this);
                $('#' + checkToggleDiv).dialog("widget").position({ my: 'top',
                    at: 'bottom',
                    of: target
                });

                return false;
            });

            var fnOnFilteredCurrent = fnOnFiltered;

            fnOnFiltered = function () {
                var target = $('#' + buttonId);
                $('#' + checkToggleDiv).dialog("widget").position({ my: 'top',
                    at: 'bottom',
                    of: target
                });
                fnOnFilteredCurrent();
            };
            //reset
            /*
            $('#'+buttonId+"Reset").button();
            $('#'+buttonId+"Reset").click(function(){
            $('#'+buttonId).removeClass("filter_selected"); //LM remove border if filter selected
            $('input:checkbox[name="'+localLabel+'"]:checked').each(function(index3) {
            $(this).attr('checked', false);
            $(this).addClass("search_init");
            });
            oTable.fnFilter('', index, true, false);
            return false;
            }); 
            */
        }




        function _fnRangeLabelPart(iPlace) {
            switch (iPlace) {
                case 0:
                    return sRangeFormat.substring(0, sRangeFormat.indexOf("{from}"));
                case 1:
                    return sRangeFormat.substring(sRangeFormat.indexOf("{from}") + 6, sRangeFormat.indexOf("{to}"));
                default:
                    return sRangeFormat.substring(sRangeFormat.indexOf("{to}") + 4);
            }
        }




        var oTable = this;

        var defaults = {
            sPlaceHolder: "foot",
            sRangeSeparator: "~",
            iFilteringDelay: 500,
            aoColumns: null,
            sRangeFormat: "From {from} to {to}",
            sDateFromToken: "from",
            sDateToToken: "to"
        };

        var properties = $.extend(defaults, options);

        return this.each(function () {

            if (!oTable.fnSettings().oFeatures.bFilter)
                return;
            asInitVals = new Array();

            var aoFilterCells = oTable.fnSettings().aoFooter[0];

            var oHost = oTable.fnSettings().nTFoot; //Before fix for ColVis
            var sFilterRow = "tr"; //Before fix for ColVis

            if (properties.sPlaceHolder == "head:after") {
                var tr = $("tr:first", oTable.fnSettings().nTHead).detach();
                //tr.appendTo($(oTable.fnSettings().nTHead));
                if (oTable.fnSettings().bSortCellsTop) {
                    tr.prependTo($(oTable.fnSettings().nTHead));
                    //tr.appendTo($("thead", oTable));
                    aoFilterCells = oTable.fnSettings().aoHeader[1];
                }
                else {
                    tr.appendTo($(oTable.fnSettings().nTHead));
                    //tr.prependTo($("thead", oTable));
                    aoFilterCells = oTable.fnSettings().aoHeader[0];
                }

                sFilterRow = "tr:last";
                oHost = oTable.fnSettings().nTHead;

            } else if (properties.sPlaceHolder == "head:before") {

                if (oTable.fnSettings().bSortCellsTop) {
                    var tr = $("tr:first", oTable.fnSettings().nTHead).detach();
                    tr.appendTo($(oTable.fnSettings().nTHead));
                    aoFilterCells = oTable.fnSettings().aoHeader[1];
                } else {
                    aoFilterCells = oTable.fnSettings().aoHeader[0];
                }
                /*else {
                //tr.prependTo($("thead", oTable));
                sFilterRow = "tr:first";
                }*/

                sFilterRow = "tr:first";

                oHost = oTable.fnSettings().nTHead;

                
            }

            //$(sFilterRow + " th", oHost).each(function (index) {//bug with ColVis
            $(aoFilterCells).each(function (index) {//fix for ColVis
                i = index;
                var aoColumn = { type: "text",
                    bRegex: false,
                    bSmart: true,
                    iMaxLenght: -1,
                    iFilterLength: 0
                };
                if (properties.aoColumns != null) {
                    if (properties.aoColumns.length < i || properties.aoColumns[i] == null)
                        return;
                    aoColumn = properties.aoColumns[i];
                }
                //label = $(this).text(); //Before fix for ColVis
                label = $($(this)[0].cell).text(); //Fix for ColVis
                if (aoColumn.sSelector == null) {
                    //th = $($(this)[0]);//Before fix for ColVis
                    th = $($(this)[0].cell); //Fix for ColVis
                }
                else {
                    th = $(aoColumn.sSelector);
                    if (th.length == 0)
                        th = $($(this)[0].cell);
                }

                if (aoColumn != null) {
                    if (aoColumn.sRangeFormat != null)
                        sRangeFormat = aoColumn.sRangeFormat;
                    else
                        sRangeFormat = properties.sRangeFormat;
                    switch (aoColumn.type) {
                        case "null":
                            break;
                        case "number":
                            fnCreateInput(oTable, true, false, true, aoColumn.iFilterLength, aoColumn.iMaxLenght);
                            break;
                        case "select":
                            if (aoColumn.bRegex != true)
                                aoColumn.bRegex = false;
                            fnCreateSelect(oTable, aoColumn.values, aoColumn.bRegex, aoColumn.selected, aoColumn.bCaseSensitive);
                            break;
                        case "number-range":
                            fnCreateRangeInput(oTable);
                            break;
                        case "date-range":
                            fnCreateDateRangeInput(oTable);
                            break;
                        case "checkbox":
                            fnCreateCheckbox(oTable, aoColumn.values);
                            break;
                        case "text":
                        default:
                            bRegex = (aoColumn.bRegex == null ? false : aoColumn.bRegex);
                            bSmart = (aoColumn.bSmart == null ? false : aoColumn.bSmart);
                            fnCreateInput(oTable, bRegex, bSmart, false, aoColumn.iFilterLength, aoColumn.iMaxLenght);
                            break;

                    }
                }
            });

            for (j = 0; j < aiCustomSearch_Indexes.length; j++) {
                //var index = aiCustomSearch_Indexes[j];
                var fnSearch_ = function () {
                    var id = oTable.attr("id");
                    return $("#" + id + "_range_from_" + aiCustomSearch_Indexes[j]).val() + properties.sRangeSeparator + $("#" + id + "_range_to_" + aiCustomSearch_Indexes[j]).val()
                }
                afnSearch_.push(fnSearch_);
            }

            if (oTable.fnSettings().oFeatures.bServerSide) {

                var fnServerDataOriginal = oTable.fnSettings().fnServerData;

                oTable.fnSettings().fnServerData = function (sSource, aoData, fnCallback) {

                    for (j = 0; j < aiCustomSearch_Indexes.length; j++) {
                        var index = aiCustomSearch_Indexes[j];

                        for (k = 0; k < aoData.length; k++) {
                            if (aoData[k].name == "sSearch_" + index)
                                aoData[k].value = afnSearch_[j]();
                        }
                    }
                    aoData.push({ "name": "sRangeSeparator", "value": properties.sRangeSeparator });

                    if (fnServerDataOriginal != null) {
                        try {
                            fnServerDataOriginal(sSource, aoData, fnCallback, oTable.fnSettings()); //TODO: See Issue 18
                        } catch (ex) {
                            fnServerDataOriginal(sSource, aoData, fnCallback);
                        }
                    }
                    else {
                        $.getJSON(sSource, aoData, function (json) {
                            fnCallback(json)
                        });
                    }
                };

            }

        });

    };




})(jQuery);
/**
 * @license
 * Lo-Dash 1.3.1 (Custom Build) lodash.com/license
 * Build: `lodash modern -o ./dist/lodash.js`
 * Underscore.js 1.4.4 underscorejs.org/LICENSE
 */
;!function(n){function t(n,t,e){e=(e||0)-1;for(var r=n.length;++e<r;)if(n[e]===t)return e;return-1}function e(n,e){var r=typeof e;if(n=n.k,"boolean"==r||e==h)return n[e];"number"!=r&&"string"!=r&&(r="object");var u="number"==r?e:j+e;return n=n[r]||(n[r]={}),"object"==r?n[u]&&-1<t(n[u],e)?0:-1:n[u]?0:-1}function r(n){var t=this.k,e=typeof n;if("boolean"==e||n==h)t[n]=y;else{"number"!=e&&"string"!=e&&(e="object");var r="number"==e?n:j+n,u=t[e]||(t[e]={});"object"==e?(u[r]||(u[r]=[])).push(n)==this.b.length&&(t[e]=b):u[r]=y
}}function u(n){return n.charCodeAt(0)}function a(n,t){var e=n.m,r=t.m;if(n=n.l,t=t.l,n!==t){if(n>t||typeof n=="undefined")return 1;if(n<t||typeof t=="undefined")return-1}return e<r?-1:1}function o(n){var t=-1,e=n.length,u=l();u["false"]=u["null"]=u["true"]=u.undefined=b;var a=l();for(a.b=n,a.k=u,a.push=r;++t<e;)a.push(n[t]);return u.object===false?(p(a),h):a}function i(n){return"\\"+Q[n]}function f(){return m.pop()||[]}function l(){return d.pop()||{b:h,k:h,l:h,"false":b,m:0,leading:b,maxWait:0,"null":b,number:h,object:h,push:h,string:h,trailing:b,"true":b,undefined:b,n:h}
}function c(n){n.length=0,m.length<C&&m.push(n)}function p(n){var t=n.k;t&&p(t),n.b=n.k=n.l=n.object=n.number=n.string=n.n=h,d.length<C&&d.push(n)}function s(n,t,e){t||(t=0),typeof e=="undefined"&&(e=n?n.length:0);var r=-1;e=e-t||0;for(var u=Array(0>e?0:e);++r<e;)u[r]=n[t+r];return u}function v(r){function m(n){if(!n||ve.call(n)!=V)return b;var t=n.valueOf,e=typeof t=="function"&&(e=fe(t))&&fe(e);return e?n==e||fe(n)==e:it(n)}function d(n,t,e){if(!n||!L[typeof n])return n;t=t&&typeof e=="undefined"?t:tt.createCallback(t,e);
for(var r=-1,u=L[typeof n]&&Se(n),a=u?u.length:0;++r<a&&(e=u[r],!(t(n[e],e,n)===false)););return n}function C(n,t,e){var r;if(!n||!L[typeof n])return n;t=t&&typeof e=="undefined"?t:tt.createCallback(t,e);for(r in n)if(t(n[r],r,n)===false)break;return n}function Q(n,t,e){var r,u=n,a=u;if(!u)return a;for(var o=arguments,i=0,f=typeof e=="number"?2:o.length;++i<f;)if((u=o[i])&&L[typeof u])for(var l=-1,c=L[typeof u]&&Se(u),p=c?c.length:0;++l<p;)r=c[l],"undefined"==typeof a[r]&&(a[r]=u[r]);return a}function X(n,t,e){var r,u=n,a=u;
if(!u)return a;var o=arguments,i=0,f=typeof e=="number"?2:o.length;if(3<f&&"function"==typeof o[f-2])var l=tt.createCallback(o[--f-1],o[f--],2);else 2<f&&"function"==typeof o[f-1]&&(l=o[--f]);for(;++i<f;)if((u=o[i])&&L[typeof u])for(var c=-1,p=L[typeof u]&&Se(u),s=p?p.length:0;++c<s;)r=p[c],a[r]=l?l(a[r],u[r]):u[r];return a}function Z(n){var t,e=[];if(!n||!L[typeof n])return e;for(t in n)le.call(n,t)&&e.push(t);return e}function tt(n){return n&&typeof n=="object"&&!Ee(n)&&le.call(n,"__wrapped__")?n:new et(n)
}function et(n){this.__wrapped__=n}function rt(n,t,e,r){function u(){var r=arguments,l=o?this:t;return a||(n=t[i]),e.length&&(r=r.length?(r=Ce.call(r),f?r.concat(e):e.concat(r)):e),this instanceof u?(l=gt(n.prototype)?ye(n.prototype):{},r=n.apply(l,r),gt(r)?r:l):n.apply(l,r)}var a=vt(n),o=!e,i=t;if(o){var f=r;e=t}else if(!a){if(!r)throw new Yt;t=n}return u}function ut(n){return Ie[n]}function at(){var n=(n=tt.indexOf)===$t?t:n;return n}function ot(n){return function(t,e,r,u){return typeof e!="boolean"&&e!=h&&(u=r,r=u&&u[e]===t?g:e,e=b),r!=h&&(r=tt.createCallback(r,u)),n(t,e,r,u)
}}function it(n){var t,e;return n&&ve.call(n)==V&&(t=n.constructor,!vt(t)||t instanceof t)?(C(n,function(n,t){e=t}),e===g||le.call(n,e)):b}function ft(n){return Ae[n]}function lt(n,t,e,r,u,a){var o=n;if(typeof t!="boolean"&&t!=h&&(r=e,e=t,t=b),typeof e=="function"){if(e=typeof r=="undefined"?e:tt.createCallback(e,r,1),o=e(o),typeof o!="undefined")return o;o=n}if(r=gt(o)){var i=ve.call(o);if(!J[i])return o;var l=Ee(o)}if(!r||!t)return r?l?s(o):X({},o):o;switch(r=xe[i],i){case P:case K:return new r(+o);
case U:case H:return new r(o);case G:return r(o.source,A.exec(o))}i=!u,u||(u=f()),a||(a=f());for(var p=u.length;p--;)if(u[p]==n)return a[p];return o=l?r(o.length):{},l&&(le.call(n,"index")&&(o.index=n.index),le.call(n,"input")&&(o.input=n.input)),u.push(n),a.push(o),(l?wt:d)(n,function(n,r){o[r]=lt(n,t,e,g,u,a)}),i&&(c(u),c(a)),o}function ct(n){var t=[];return C(n,function(n,e){vt(n)&&t.push(e)}),t.sort()}function pt(n){for(var t=-1,e=Se(n),r=e.length,u={};++t<r;){var a=e[t];u[n[a]]=a}return u}function st(n,t,e,r,u,a){var o=e===k;
if(typeof e=="function"&&!o){e=tt.createCallback(e,r,2);var i=e(n,t);if(typeof i!="undefined")return!!i}if(n===t)return 0!==n||1/n==1/t;var l=typeof n,p=typeof t;if(n===n&&(!n||"function"!=l&&"object"!=l)&&(!t||"function"!=p&&"object"!=p))return b;if(n==h||t==h)return n===t;if(p=ve.call(n),l=ve.call(t),p==z&&(p=V),l==z&&(l=V),p!=l)return b;switch(p){case P:case K:return+n==+t;case U:return n!=+n?t!=+t:0==n?1/n==1/t:n==+t;case G:case H:return n==Xt(t)}if(l=p==W,!l){if(le.call(n,"__wrapped__")||le.call(t,"__wrapped__"))return st(n.__wrapped__||n,t.__wrapped__||t,e,r,u,a);
if(p!=V)return b;var p=n.constructor,s=t.constructor;if(p!=s&&(!vt(p)||!(p instanceof p&&vt(s)&&s instanceof s)))return b}for(s=!u,u||(u=f()),a||(a=f()),p=u.length;p--;)if(u[p]==n)return a[p]==t;var v=0,i=y;if(u.push(n),a.push(t),l){if(p=n.length,v=t.length,i=v==n.length,!i&&!o)return i;for(;v--;)if(l=p,s=t[v],o)for(;l--&&!(i=st(n[l],s,e,r,u,a)););else if(!(i=st(n[v],s,e,r,u,a)))break;return i}return C(t,function(t,o,f){return le.call(f,o)?(v++,i=le.call(n,o)&&st(n[o],t,e,r,u,a)):void 0}),i&&!o&&C(n,function(n,t,e){return le.call(e,t)?i=-1<--v:void 0
}),s&&(c(u),c(a)),i}function vt(n){return typeof n=="function"}function gt(n){return!(!n||!L[typeof n])}function yt(n){return typeof n=="number"||ve.call(n)==U}function ht(n){return typeof n=="string"||ve.call(n)==H}function bt(n,t,e){var r=arguments,u=0,a=2;if(!gt(n))return n;if(e===k)var o=r[3],i=r[4],l=r[5];else{var p=y,i=f(),l=f();typeof e!="number"&&(a=r.length),3<a&&"function"==typeof r[a-2]?o=tt.createCallback(r[--a-1],r[a--],2):2<a&&"function"==typeof r[a-1]&&(o=r[--a])}for(;++u<a;)(Ee(r[u])?wt:d)(r[u],function(t,e){var r,u,a=t,f=n[e];
if(t&&((u=Ee(t))||m(t))){for(a=i.length;a--;)if(r=i[a]==t){f=l[a];break}if(!r){var c;o&&(a=o(f,t),c=typeof a!="undefined")&&(f=a),c||(f=u?Ee(f)?f:[]:m(f)?f:{}),i.push(t),l.push(f),c||(f=bt(f,t,k,o,i,l))}}else o&&(a=o(f,t),typeof a=="undefined"&&(a=t)),typeof a!="undefined"&&(f=a);n[e]=f});return p&&(c(i),c(l)),n}function mt(n){for(var t=-1,e=Se(n),r=e.length,u=Mt(r);++t<r;)u[t]=n[e[t]];return u}function dt(n,t,e){var r=-1,u=at(),a=n?n.length:0,o=b;return e=(0>e?_e(0,a+e):e)||0,a&&typeof a=="number"?o=-1<(ht(n)?n.indexOf(t,e):u(n,t,e)):d(n,function(n){return++r<e?void 0:!(o=n===t)
}),o}function _t(n,t,e){var r=y;t=tt.createCallback(t,e),e=-1;var u=n?n.length:0;if(typeof u=="number")for(;++e<u&&(r=!!t(n[e],e,n)););else d(n,function(n,e,u){return r=!!t(n,e,u)});return r}function kt(n,t,e){var r=[];t=tt.createCallback(t,e),e=-1;var u=n?n.length:0;if(typeof u=="number")for(;++e<u;){var a=n[e];t(a,e,n)&&r.push(a)}else d(n,function(n,e,u){t(n,e,u)&&r.push(n)});return r}function jt(n,t,e){t=tt.createCallback(t,e),e=-1;var r=n?n.length:0;if(typeof r!="number"){var u;return d(n,function(n,e,r){return t(n,e,r)?(u=n,b):void 0
}),u}for(;++e<r;){var a=n[e];if(t(a,e,n))return a}}function wt(n,t,e){var r=-1,u=n?n.length:0;if(t=t&&typeof e=="undefined"?t:tt.createCallback(t,e),typeof u=="number")for(;++r<u&&t(n[r],r,n)!==false;);else d(n,t);return n}function Ct(n,t,e){var r=-1,u=n?n.length:0;if(t=tt.createCallback(t,e),typeof u=="number")for(var a=Mt(u);++r<u;)a[r]=t(n[r],r,n);else a=[],d(n,function(n,e,u){a[++r]=t(n,e,u)});return a}function xt(n,t,e){var r=-1/0,a=r;if(!t&&Ee(n)){e=-1;for(var o=n.length;++e<o;){var i=n[e];i>a&&(a=i)
}}else t=!t&&ht(n)?u:tt.createCallback(t,e),wt(n,function(n,e,u){e=t(n,e,u),e>r&&(r=e,a=n)});return a}function Ot(n,t){var e=-1,r=n?n.length:0;if(typeof r=="number")for(var u=Mt(r);++e<r;)u[e]=n[e][t];return u||Ct(n,t)}function Et(n,t,e,r){if(!n)return e;var u=3>arguments.length;t=tt.createCallback(t,r,4);var a=-1,o=n.length;if(typeof o=="number")for(u&&(e=n[++a]);++a<o;)e=t(e,n[a],a,n);else d(n,function(n,r,a){e=u?(u=b,n):t(e,n,r,a)});return e}function St(n,t,e,r){var u=n?n.length:0,a=3>arguments.length;
if(typeof u!="number")var o=Se(n),u=o.length;return t=tt.createCallback(t,r,4),wt(n,function(r,i,f){i=o?o[--u]:--u,e=a?(a=b,n[i]):t(e,n[i],i,f)}),e}function It(n,t,e){var r;t=tt.createCallback(t,e),e=-1;var u=n?n.length:0;if(typeof u=="number")for(;++e<u&&!(r=t(n[e],e,n)););else d(n,function(n,e,u){return!(r=t(n,e,u))});return!!r}function At(n){var r=-1,u=at(),a=n?n.length:0,i=ae.apply(Zt,Ce.call(arguments,1)),f=[],l=a>=w&&u===t;if(l){var c=o(i);c?(u=e,i=c):l=b}for(;++r<a;)c=n[r],0>u(i,c)&&f.push(c);
return l&&p(i),f}function Nt(n,t,e){if(n){var r=0,u=n.length;if(typeof t!="number"&&t!=h){var a=-1;for(t=tt.createCallback(t,e);++a<u&&t(n[a],a,n);)r++}else if(r=t,r==h||e)return n[0];return s(n,0,ke(_e(0,r),u))}}function $t(n,e,r){if(typeof r=="number"){var u=n?n.length:0;r=0>r?_e(0,u+r):r||0}else if(r)return r=Ft(n,e),n[r]===e?r:-1;return n?t(n,e,r):-1}function Bt(n,t,e){if(typeof t!="number"&&t!=h){var r=0,u=-1,a=n?n.length:0;for(t=tt.createCallback(t,e);++u<a&&t(n[u],u,n);)r++}else r=t==h||e?1:_e(0,t);
return s(n,r)}function Ft(n,t,e,r){var u=0,a=n?n.length:u;for(e=e?tt.createCallback(e,r,1):Wt,t=e(t);u<a;)r=u+a>>>1,e(n[r])<t?u=r+1:a=r;return u}function Rt(n){for(var t=-1,e=n?xt(Ot(n,"length")):0,r=Mt(0>e?0:e);++t<e;)r[t]=Ot(n,t);return r}function Tt(n,t){for(var e=-1,r=n?n.length:0,u={};++e<r;){var a=n[e];t?u[a]=t[e]:u[a[0]]=a[1]}return u}function qt(n,t){return Oe.fastBind||ge&&2<arguments.length?ge.call.apply(ge,arguments):rt(n,t,Ce.call(arguments,2))}function Dt(n,t,e){function r(){ue(s),ue(v),l=0,s=v=h
}function u(){var t=g&&(!m||1<l);r(),t&&(p!==false&&(c=new Vt),i=n.apply(f,o))}function a(){r(),(g||p!==t)&&(c=new Vt,i=n.apply(f,o))}var o,i,f,l=0,c=0,p=b,s=h,v=h,g=y;if(t=_e(0,t||0),e===y)var m=y,g=b;else gt(e)&&(m=e.leading,p="maxWait"in e&&_e(t,e.maxWait||0),g="trailing"in e?e.trailing:g);return function(){if(o=arguments,f=this,l++,ue(v),p===false)m&&2>l&&(i=n.apply(f,o));else{var e=new Vt;!s&&!m&&(c=e);var r=p-(e-c);0<r?s||(s=se(a,r)):(ue(s),s=h,c=e,i=n.apply(f,o))}return t!==p&&(v=se(u,t)),i}}function zt(n){var t=Ce.call(arguments,1);
return se(function(){n.apply(g,t)},1)}function Wt(n){return n}function Pt(n){wt(ct(n),function(t){var e=tt[t]=n[t];tt.prototype[t]=function(){var n=this.__wrapped__,t=[n];return ce.apply(t,arguments),t=e.apply(tt,t),n&&typeof n=="object"&&n===t?this:new et(t)}})}function Kt(){return this.__wrapped__}r=r?nt.defaults(n.Object(),r,nt.pick(n,D)):n;var Mt=r.Array,Ut=r.Boolean,Vt=r.Date,Gt=r.Function,Ht=r.Math,Jt=r.Number,Lt=r.Object,Qt=r.RegExp,Xt=r.String,Yt=r.TypeError,Zt=[],ne=Lt.prototype,te=r._,ee=Qt("^"+Xt(ne.valueOf).replace(/[.*+?^${}()|[\]\\]/g,"\\$&").replace(/valueOf|for [^\]]+/g,".+?")+"$"),re=Ht.ceil,ue=r.clearTimeout,ae=Zt.concat,oe=Ht.floor,ie=Gt.prototype.toString,fe=ee.test(fe=Lt.getPrototypeOf)&&fe,le=ne.hasOwnProperty,ce=Zt.push,pe=r.setImmediate,se=r.setTimeout,ve=ne.toString,ge=ee.test(ge=ve.bind)&&ge,ye=ee.test(ye=Lt.create)&&ye,he=ee.test(he=Mt.isArray)&&he,be=r.isFinite,me=r.isNaN,de=ee.test(de=Lt.keys)&&de,_e=Ht.max,ke=Ht.min,je=r.parseInt,we=Ht.random,Ce=Zt.slice,Ht=ee.test(r.attachEvent),Ht=ge&&!/\n|true/.test(ge+Ht),xe={};
xe[W]=Mt,xe[P]=Ut,xe[K]=Vt,xe[M]=Gt,xe[V]=Lt,xe[U]=Jt,xe[G]=Qt,xe[H]=Xt,et.prototype=tt.prototype;var Oe=tt.support={};Oe.fastBind=ge&&!Ht,tt.templateSettings={escape:/<%-([\s\S]+?)%>/g,evaluate:/<%([\s\S]+?)%>/g,interpolate:N,variable:"",imports:{_:tt}};var Ee=he,Se=de?function(n){return gt(n)?de(n):[]}:Z,Ie={"&":"&amp;","<":"&lt;",">":"&gt;",'"':"&quot;","'":"&#39;"},Ae=pt(Ie),Ut=ot(function $e(n,t,e){for(var r=-1,u=n?n.length:0,a=[];++r<u;){var o=n[r];e&&(o=e(o,r,n)),Ee(o)?ce.apply(a,t?o:$e(o)):a.push(o)
}return a}),Ne=ot(function(n,r,u){var a=-1,i=at(),l=n?n.length:0,s=[],v=!r&&l>=w&&i===t,g=u||v?f():s;if(v){var y=o(g);y?(i=e,g=y):(v=b,g=u?g:(c(g),s))}for(;++a<l;){var y=n[a],h=u?u(y,a,n):y;(r?!a||g[g.length-1]!==h:0>i(g,h))&&((u||v)&&g.push(h),s.push(y))}return v?(c(g.b),p(g)):u&&c(g),s});return Ht&&Y&&typeof pe=="function"&&(zt=qt(pe,r)),pe=8==je(B+"08")?je:function(n,t){return je(ht(n)?n.replace(F,""):n,t||0)},tt.after=function(n,t){return 1>n?t():function(){return 1>--n?t.apply(this,arguments):void 0
}},tt.assign=X,tt.at=function(n){for(var t=-1,e=ae.apply(Zt,Ce.call(arguments,1)),r=e.length,u=Mt(r);++t<r;)u[t]=n[e[t]];return u},tt.bind=qt,tt.bindAll=function(n){for(var t=1<arguments.length?ae.apply(Zt,Ce.call(arguments,1)):ct(n),e=-1,r=t.length;++e<r;){var u=t[e];n[u]=qt(n[u],n)}return n},tt.bindKey=function(n,t){return rt(n,t,Ce.call(arguments,2),k)},tt.compact=function(n){for(var t=-1,e=n?n.length:0,r=[];++t<e;){var u=n[t];u&&r.push(u)}return r},tt.compose=function(){var n=arguments;return function(){for(var t=arguments,e=n.length;e--;)t=[n[e].apply(this,t)];
return t[0]}},tt.countBy=function(n,t,e){var r={};return t=tt.createCallback(t,e),wt(n,function(n,e,u){e=Xt(t(n,e,u)),le.call(r,e)?r[e]++:r[e]=1}),r},tt.createCallback=function(n,t,e){if(n==h)return Wt;var r=typeof n;if("function"!=r){if("object"!=r)return function(t){return t[n]};var u=Se(n);return function(t){for(var e=u.length,r=b;e--&&(r=st(t[u[e]],n[u[e]],k)););return r}}return typeof t=="undefined"||$&&!$.test(ie.call(n))?n:1===e?function(e){return n.call(t,e)}:2===e?function(e,r){return n.call(t,e,r)
}:4===e?function(e,r,u,a){return n.call(t,e,r,u,a)}:function(e,r,u){return n.call(t,e,r,u)}},tt.debounce=Dt,tt.defaults=Q,tt.defer=zt,tt.delay=function(n,t){var e=Ce.call(arguments,2);return se(function(){n.apply(g,e)},t)},tt.difference=At,tt.filter=kt,tt.flatten=Ut,tt.forEach=wt,tt.forIn=C,tt.forOwn=d,tt.functions=ct,tt.groupBy=function(n,t,e){var r={};return t=tt.createCallback(t,e),wt(n,function(n,e,u){e=Xt(t(n,e,u)),(le.call(r,e)?r[e]:r[e]=[]).push(n)}),r},tt.initial=function(n,t,e){if(!n)return[];
var r=0,u=n.length;if(typeof t!="number"&&t!=h){var a=u;for(t=tt.createCallback(t,e);a--&&t(n[a],a,n);)r++}else r=t==h||e?1:t||r;return s(n,0,ke(_e(0,u-r),u))},tt.intersection=function(n){for(var r=arguments,u=r.length,a=-1,i=f(),l=-1,s=at(),v=n?n.length:0,g=[],y=f();++a<u;){var h=r[a];i[a]=s===t&&(h?h.length:0)>=w&&o(a?r[a]:y)}n:for(;++l<v;){var b=i[0],h=n[l];if(0>(b?e(b,h):s(y,h))){for(a=u,(b||y).push(h);--a;)if(b=i[a],0>(b?e(b,h):s(r[a],h)))continue n;g.push(h)}}for(;u--;)(b=i[u])&&p(b);return c(i),c(y),g
},tt.invert=pt,tt.invoke=function(n,t){var e=Ce.call(arguments,2),r=-1,u=typeof t=="function",a=n?n.length:0,o=Mt(typeof a=="number"?a:0);return wt(n,function(n){o[++r]=(u?t:n[t]).apply(n,e)}),o},tt.keys=Se,tt.map=Ct,tt.max=xt,tt.memoize=function(n,t){function e(){var r=e.cache,u=j+(t?t.apply(this,arguments):arguments[0]);return le.call(r,u)?r[u]:r[u]=n.apply(this,arguments)}return e.cache={},e},tt.merge=bt,tt.min=function(n,t,e){var r=1/0,a=r;if(!t&&Ee(n)){e=-1;for(var o=n.length;++e<o;){var i=n[e];
i<a&&(a=i)}}else t=!t&&ht(n)?u:tt.createCallback(t,e),wt(n,function(n,e,u){e=t(n,e,u),e<r&&(r=e,a=n)});return a},tt.omit=function(n,t,e){var r=at(),u=typeof t=="function",a={};if(u)t=tt.createCallback(t,e);else var o=ae.apply(Zt,Ce.call(arguments,1));return C(n,function(n,e,i){(u?!t(n,e,i):0>r(o,e))&&(a[e]=n)}),a},tt.once=function(n){var t,e;return function(){return t?e:(t=y,e=n.apply(this,arguments),n=h,e)}},tt.pairs=function(n){for(var t=-1,e=Se(n),r=e.length,u=Mt(r);++t<r;){var a=e[t];u[t]=[a,n[a]]
}return u},tt.partial=function(n){return rt(n,Ce.call(arguments,1))},tt.partialRight=function(n){return rt(n,Ce.call(arguments,1),h,k)},tt.pick=function(n,t,e){var r={};if(typeof t!="function")for(var u=-1,a=ae.apply(Zt,Ce.call(arguments,1)),o=gt(n)?a.length:0;++u<o;){var i=a[u];i in n&&(r[i]=n[i])}else t=tt.createCallback(t,e),C(n,function(n,e,u){t(n,e,u)&&(r[e]=n)});return r},tt.pluck=Ot,tt.range=function(n,t,e){n=+n||0,e=+e||1,t==h&&(t=n,n=0);var r=-1;t=_e(0,re((t-n)/e));for(var u=Mt(t);++r<t;)u[r]=n,n+=e;
return u},tt.reject=function(n,t,e){return t=tt.createCallback(t,e),kt(n,function(n,e,r){return!t(n,e,r)})},tt.rest=Bt,tt.shuffle=function(n){var t=-1,e=n?n.length:0,r=Mt(typeof e=="number"?e:0);return wt(n,function(n){var e=oe(we()*(++t+1));r[t]=r[e],r[e]=n}),r},tt.sortBy=function(n,t,e){var r=-1,u=n?n.length:0,o=Mt(typeof u=="number"?u:0);for(t=tt.createCallback(t,e),wt(n,function(n,e,u){var a=o[++r]=l();a.l=t(n,e,u),a.m=r,a.n=n}),u=o.length,o.sort(a);u--;)n=o[u],o[u]=n.n,p(n);return o},tt.tap=function(n,t){return t(n),n
},tt.throttle=function(n,t,e){var r=y,u=y;return e===false?r=b:gt(e)&&(r="leading"in e?e.leading:r,u="trailing"in e?e.trailing:u),e=l(),e.leading=r,e.maxWait=t,e.trailing=u,n=Dt(n,t,e),p(e),n},tt.times=function(n,t,e){n=-1<(n=+n)?n:0;var r=-1,u=Mt(n);for(t=tt.createCallback(t,e,1);++r<n;)u[r]=t(r);return u},tt.toArray=function(n){return n&&typeof n.length=="number"?s(n):mt(n)},tt.transform=function(n,t,e,r){var u=Ee(n);return t=tt.createCallback(t,r,4),e==h&&(u?e=[]:(r=n&&n.constructor,e=gt(r&&r.prototype)?ye(r&&r.prototype):{})),(u?wt:d)(n,function(n,r,u){return t(e,n,r,u)
}),e},tt.union=function(n){return Ee(n)||(arguments[0]=n?Ce.call(n):Zt),Ne(ae.apply(Zt,arguments))},tt.uniq=Ne,tt.unzip=Rt,tt.values=mt,tt.where=kt,tt.without=function(n){return At(n,Ce.call(arguments,1))},tt.wrap=function(n,t){return function(){var e=[n];return ce.apply(e,arguments),t.apply(this,e)}},tt.zip=function(n){return n?Rt(arguments):[]},tt.zipObject=Tt,tt.collect=Ct,tt.drop=Bt,tt.each=wt,tt.extend=X,tt.methods=ct,tt.object=Tt,tt.select=kt,tt.tail=Bt,tt.unique=Ne,Pt(tt),tt.chain=tt,tt.prototype.chain=function(){return this
},tt.clone=lt,tt.cloneDeep=function(n,t,e){return lt(n,y,t,e)},tt.contains=dt,tt.escape=function(n){return n==h?"":Xt(n).replace(T,ut)},tt.every=_t,tt.find=jt,tt.findIndex=function(n,t,e){var r=-1,u=n?n.length:0;for(t=tt.createCallback(t,e);++r<u;)if(t(n[r],r,n))return r;return-1},tt.findKey=function(n,t,e){var r;return t=tt.createCallback(t,e),d(n,function(n,e,u){return t(n,e,u)?(r=e,b):void 0}),r},tt.has=function(n,t){return n?le.call(n,t):b},tt.identity=Wt,tt.indexOf=$t,tt.isArguments=function(n){return ve.call(n)==z
},tt.isArray=Ee,tt.isBoolean=function(n){return n===y||n===false||ve.call(n)==P},tt.isDate=function(n){return n?typeof n=="object"&&ve.call(n)==K:b},tt.isElement=function(n){return n?1===n.nodeType:b},tt.isEmpty=function(n){var t=y;if(!n)return t;var e=ve.call(n),r=n.length;return e==W||e==H||e==z||e==V&&typeof r=="number"&&vt(n.splice)?!r:(d(n,function(){return t=b}),t)},tt.isEqual=st,tt.isFinite=function(n){return be(n)&&!me(parseFloat(n))},tt.isFunction=vt,tt.isNaN=function(n){return yt(n)&&n!=+n
},tt.isNull=function(n){return n===h},tt.isNumber=yt,tt.isObject=gt,tt.isPlainObject=m,tt.isRegExp=function(n){return n?typeof n=="object"&&ve.call(n)==G:b},tt.isString=ht,tt.isUndefined=function(n){return typeof n=="undefined"},tt.lastIndexOf=function(n,t,e){var r=n?n.length:0;for(typeof e=="number"&&(r=(0>e?_e(0,r+e):ke(e,r-1))+1);r--;)if(n[r]===t)return r;return-1},tt.mixin=Pt,tt.noConflict=function(){return r._=te,this},tt.parseInt=pe,tt.random=function(n,t){n==h&&t==h&&(t=1),n=+n||0,t==h?(t=n,n=0):t=+t||0;
var e=we();return n%1||t%1?n+ke(e*(t-n+parseFloat("1e-"+((e+"").length-1))),t):n+oe(e*(t-n+1))},tt.reduce=Et,tt.reduceRight=St,tt.result=function(n,t){var e=n?n[t]:g;return vt(e)?n[t]():e},tt.runInContext=v,tt.size=function(n){var t=n?n.length:0;return typeof t=="number"?t:Se(n).length},tt.some=It,tt.sortedIndex=Ft,tt.template=function(n,t,e){var r=tt.templateSettings;n||(n=""),e=Q({},e,r);var u,a=Q({},e.imports,r.imports),r=Se(a),a=mt(a),o=0,f=e.interpolate||R,l="__p+='",f=Qt((e.escape||R).source+"|"+f.source+"|"+(f===N?I:R).source+"|"+(e.evaluate||R).source+"|$","g");
n.replace(f,function(t,e,r,a,f,c){return r||(r=a),l+=n.slice(o,c).replace(q,i),e&&(l+="'+__e("+e+")+'"),f&&(u=y,l+="';"+f+";__p+='"),r&&(l+="'+((__t=("+r+"))==null?'':__t)+'"),o=c+t.length,t}),l+="';\n",f=e=e.variable,f||(e="obj",l="with("+e+"){"+l+"}"),l=(u?l.replace(x,""):l).replace(O,"$1").replace(E,"$1;"),l="function("+e+"){"+(f?"":e+"||("+e+"={});")+"var __t,__p='',__e=_.escape"+(u?",__j=Array.prototype.join;function print(){__p+=__j.call(arguments,'')}":";")+l+"return __p}";try{var c=Gt(r,"return "+l).apply(g,a)
}catch(p){throw p.source=l,p}return t?c(t):(c.source=l,c)},tt.unescape=function(n){return n==h?"":Xt(n).replace(S,ft)},tt.uniqueId=function(n){var t=++_;return Xt(n==h?"":n)+t},tt.all=_t,tt.any=It,tt.detect=jt,tt.findWhere=jt,tt.foldl=Et,tt.foldr=St,tt.include=dt,tt.inject=Et,d(tt,function(n,t){tt.prototype[t]||(tt.prototype[t]=function(){var t=[this.__wrapped__];return ce.apply(t,arguments),n.apply(tt,t)})}),tt.first=Nt,tt.last=function(n,t,e){if(n){var r=0,u=n.length;if(typeof t!="number"&&t!=h){var a=u;
for(t=tt.createCallback(t,e);a--&&t(n[a],a,n);)r++}else if(r=t,r==h||e)return n[u-1];return s(n,_e(0,u-r))}},tt.take=Nt,tt.head=Nt,d(tt,function(n,t){tt.prototype[t]||(tt.prototype[t]=function(t,e){var r=n(this.__wrapped__,t,e);return t==h||e&&typeof t!="function"?r:new et(r)})}),tt.VERSION="1.3.1",tt.prototype.toString=function(){return Xt(this.__wrapped__)},tt.prototype.value=Kt,tt.prototype.valueOf=Kt,wt(["join","pop","shift"],function(n){var t=Zt[n];tt.prototype[n]=function(){return t.apply(this.__wrapped__,arguments)
}}),wt(["push","reverse","sort","unshift"],function(n){var t=Zt[n];tt.prototype[n]=function(){return t.apply(this.__wrapped__,arguments),this}}),wt(["concat","slice","splice"],function(n){var t=Zt[n];tt.prototype[n]=function(){return new et(t.apply(this.__wrapped__,arguments))}}),tt}var g,y=!0,h=null,b=!1,m=[],d=[],_=0,k={},j=+new Date+"",w=75,C=40,x=/\b__p\+='';/g,O=/\b(__p\+=)''\+/g,E=/(__e\(.*?\)|\b__t\))\+'';/g,S=/&(?:amp|lt|gt|quot|#39);/g,I=/\$\{([^\\}]*(?:\\.[^\\}]*)*)\}/g,A=/\w*$/,N=/<%=([\s\S]+?)%>/g,$=($=/\bthis\b/)&&$.test(v)&&$,B=" \t\x0B\f\xa0\ufeff\n\r\u2028\u2029\u1680\u180e\u2000\u2001\u2002\u2003\u2004\u2005\u2006\u2007\u2008\u2009\u200a\u202f\u205f\u3000",F=RegExp("^["+B+"]*0+(?=.$)"),R=/($^)/,T=/[&<>"']/g,q=/['\n\r\t\u2028\u2029\\]/g,D="Array Boolean Date Function Math Number Object RegExp String _ attachEvent clearTimeout isFinite isNaN parseInt setImmediate setTimeout".split(" "),z="[object Arguments]",W="[object Array]",P="[object Boolean]",K="[object Date]",M="[object Function]",U="[object Number]",V="[object Object]",G="[object RegExp]",H="[object String]",J={};
J[M]=b,J[z]=J[W]=J[P]=J[K]=J[U]=J[V]=J[G]=J[H]=y;var L={"boolean":b,"function":y,object:y,number:b,string:b,undefined:b},Q={"\\":"\\","'":"'","\n":"n","\r":"r","\t":"t","\u2028":"u2028","\u2029":"u2029"},X=L[typeof exports]&&exports,Y=L[typeof module]&&module&&module.exports==X&&module,Z=L[typeof global]&&global;!Z||Z.global!==Z&&Z.window!==Z||(n=Z);var nt=v();typeof define=="function"&&typeof define.amd=="object"&&define.amd?(n._=nt, define(function(){return nt})):X&&!X.nodeType?Y?(Y.exports=nt)._=nt:X._=nt:n._=nt
}(this);
/**
 * File:        datatables.responsive.js
 * Version:     0.1.3
 * Author:      Seen Sai Yang
 * Info:        https://github.com/Comanche/datatables-responsive
 *
 * Copyright 2013 Seen Sai Yang, all rights reserved.
 *
 * This source file is free software, under either the GPL v2 license or a
 * BSD style license.
 *
 * This source file is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
 * or FITNESS FOR A PARTICULAR PURPOSE. See the license files for details.
 *
 * You should have received a copy of the GNU General Public License and the
 * BSD license along with this program.  These licenses are also available at:
 *     https://raw.github.com/Comanche/datatables-responsive/master/license-gpl2.txt
 *     https://raw.github.com/Comanche/datatables-responsive/master/license-bsd.txt
 */

'use strict';

/**
 * Constructor for responsive datables helper.
 *
 * This helper class makes datatables responsive to the window size.
 *
 * The parameter, breakpoints, is an object for each breakpoint key/value pair
 * with the following format: { breakpoint_name: pixel_width_at_breakpoint }.
 *
 * An example is as follows:
 *
 *     {
 *         tablet: 1024,
 *         phone: 480
 *     }
 *
 * These breakpoint name may be used as possible values for the data-hide
 * attribute.  The data-hide attribute is optional and may be defined for each
 * th element in the table header.
 *
 * The parameter, options, is an object of options supported by the responsive
 * helper.  The following options are supported:
 *
 *     {
 *          hideEmptyColumnsInRowDetail - Boolean, default: false.
 *     }
 *
 * @param {Object|string} tableSelector jQuery wrapped set or selector for
 *                                      datatables container element.
 * @param {Object} breakpoints          Object defining the responsive
 *                                      breakpoint for datatables.
 * @param {Object} options              Object of options.
 */
function ResponsiveDatatablesHelper(tableSelector, breakpoints, options) {
    if (typeof tableSelector === 'string') {
        this.tableElement = jQuery(tableSelector);
    } else {
        this.tableElement = tableSelector;
    }

    // State of column indexes and which are shown or hidden.
    this.columnIndexes = [];
    this.columnsShownIndexes = [];
    this.columnsHiddenIndexes = [];

    // Index of the th in the header tr that stores where the attribute
    //     data-class="expand"
    // is defined.
    this.expandColumn = undefined;

    // Stores the break points defined in the table header.
    // Each th in the header tr may contain an optional attribute like
    //     data-hide="phone,tablet"
    // These attributes and the breakpoints object will be used to create this
    // object.
    this.breakpoints = {
        /**
         * We will be generating data in the following format:
         *     phone : {
         *         lowerLimit   : undefined,
         *         upperLimit   : 320,
         *         columnsToHide: []
         *     },
         *     tablet: {
         *         lowerLimit   : 320,
         *         upperLimit   : 724,
         *         columnsToHide: []
         *     }
         */
    };

    // Store default options
    this.options = {
        hideEmptyColumnsInRowDetail: false
    };

    // Expand icon template
    this.expandIconTemplate = '<span class="responsiveExpander"></span>';

    // Row template
    this.rowTemplate = '<tr class="row-detail"><td><ul><!--column item--></ul></td></tr>';
    this.rowLiTemplate = '<li><span class="columnTitle"><!--column title--></span>: <span class="columnValue"><!--column value--></span></li>';

    // Responsive behavior on/off flag
    this.disabled = true;

    // Skip next windows width change flag
    this.skipNextWindowsWidthChange = false;

    // Initialize settings
    this.init(breakpoints, options);
}

/**
 * Responsive datatables helper init function.
 * Builds breakpoint limits for columns and begins to listen to window resize
 * event.
 *
 * See constructor for the breakpoints parameter.
 *
 * @param {Object} breakpoints
 * @param {Object} options
 */
ResponsiveDatatablesHelper.prototype.init = function (breakpoints, options) {
    // Add the 'always' breakpoint
    breakpoints['always'] = Infinity;

    /** Generate breakpoints in the format we need. ***************************/
    // First, we need to create a sorted array of the breakpoints given.
    var breakpointsSorted = [];
    _.each(breakpoints, function (value, key) {
        breakpointsSorted.push({
            name         : key,
            upperLimit   : value,
            columnsToHide: []
        });
    });
    breakpointsSorted = _.sortBy(breakpointsSorted, 'upperLimit');

    // Set lower and upper limits for each breakpoint.
    var lowerLimit = undefined;
    _.each(breakpointsSorted, function (value) {
        value.lowerLimit = lowerLimit;
        lowerLimit = value.upperLimit;
    });

    // Add the default breakpoint which shows all (has no upper limit).
    breakpointsSorted.push({
        name         : 'default',
        lowerLimit   : lowerLimit,
        upperLimit   : undefined,
        columnsToHide: []
    });

    // Copy the sorted breakpoint array into the breakpoints object using the
    // name as the key.
    for (var i = 0, l = breakpointsSorted.length; i < l; i++) {
        this.breakpoints[breakpointsSorted[i].name] = breakpointsSorted[i];
    }

    /** Create range of possible column indexes *******************************/
    // Get all visible column indexes
    var columns = this.tableElement.fnSettings().aoColumns;
    for (var i = 0, l = columns.length; i < l; i++) {
        if (columns[i].bVisible) {
            this.columnIndexes.push(i)
        }
    }

    // We need the range of possible column indexes to calculate the columns
    // to show:
    //     Columns to show = all columns - columns to hide
    var headerColumns = this.tableElement.fnSettings().aoColumns;
    // Filter for only visible columns.
    headerColumns = _.filter(headerColumns, function (col) {
        return col.bVisible;
    });

    /** Add columns into breakpoints respectively *****************************/
    // Read column headers' attributes and get needed info
    _.each(headerColumns, function (col, index) {
        // Get the column with the attribute data-class="expand" so we know
        // where to display the expand icon.
        if (jQuery(col.nTh).attr('data-class') === 'expand') {
            this.expandColumn = this.columnIndexes[index];
        }

        // The data-hide attribute has the breakpoints that this column
        // is associated with.
        // If it's defined, get the data-hide attribute and sort this
        // column into the appropriate breakpoint's columnsToHide array.
        var dataHide = jQuery(col.nTh).attr('data-hide');
        if (dataHide !== undefined) {
            var splitBreakingPoints = dataHide.split(/,\s*/);
            _.each(splitBreakingPoints, function (e) {
                if (this.breakpoints[e] !== undefined) {
                    // Translate visible column index to internal column index.
                    this.breakpoints[e].columnsToHide.push(this.columnIndexes[index]);
                }
            }, this);
        }
    }, this);

    // Enable responsive behavior.
    this.disable(false);

    // Extend options
    _.extend(this.options, options);
};

/**
 * Sets or removes window resize handler.
 *
 * @param {Boolean} bindFlag
 */
ResponsiveDatatablesHelper.prototype.setWindowsResizeHandler = function(bindFlag) {
    if (bindFlag === undefined) {
        bindFlag = true;
    }

    if (bindFlag) {
        var that = this;
        jQuery(window).bind("resize", function () {
            that.respond();
        });
    } else {
        jQuery(window).unbind("resize");
    }
}

/**
 * Respond window size change.  This helps make datatables responsive.
 */
ResponsiveDatatablesHelper.prototype.respond = function () {
    if (this.disabled) {
        return;
    }
    var that = this;

    // Get new windows width
    var newWindowWidth = jQuery(window).width();
    var updatedHiddenColumnsCount = 0;

    // Loop through breakpoints to see which columns need to be shown/hidden.
    var newColumnsToHide = [];
    _.each(this.breakpoints, function (element) {
        if ((!element.lowerLimit || newWindowWidth > element.lowerLimit) && (!element.upperLimit || newWindowWidth <= element.upperLimit)) {
            newColumnsToHide = element.columnsToHide;
        }
    }, this);

    // Find out if a column show/hide should happen.
    // Skip column show/hide if this window width change follows immediately
    // after a previous column show/hide.  This will help prevent a loop.
    var columnShowHide = false;
    if (!this.skipNextWindowsWidthChange) {
        // Check difference in length
        if (this.columnsHiddenIndexes.length !== newColumnsToHide.length) {
            // Difference in length
            columnShowHide = true;
        } else {
            // Same length but check difference in values
            var d1 = _.difference(this.columnsHiddenIndexes, newColumnsToHide).length;
            var d2 = _.difference(newColumnsToHide, this.columnsHiddenIndexes).length;
            columnShowHide = d1 + d2 > 0;
        }
    }

    if (columnShowHide) {
        // Showing/hiding a column at breakpoint may cause a windows width
        // change.  Let's flag to skip the column show/hide that may be
        // caused by the next windows width change.
        this.skipNextWindowsWidthChange = true;
        this.columnsHiddenIndexes = newColumnsToHide;
        this.columnsShownIndexes = _.difference(this.columnIndexes, this.columnsHiddenIndexes);
        this.showHideColumns();
        updatedHiddenColumnsCount = this.columnsHiddenIndexes.length;
        this.skipNextWindowsWidthChange = false;
    }


    // We don't skip this part.
    // If one or more columns have been hidden, add the has-columns-hidden class to table.
    // This class will show what state the table is in.
    if (this.columnsHiddenIndexes.length) {
        this.tableElement.addClass('has-columns-hidden');

        // Show details for each row that is tagged with the class .detail-show.
        jQuery('tr.detail-show', this.tableElement).each(function (index, element) {
            var tr = jQuery(element);
            if (tr.next('.row-detail').length === 0) {
                ResponsiveDatatablesHelper.prototype.showRowDetail(that, tr);
            }
        });
    } else {
        this.tableElement.removeClass('has-columns-hidden');
        jQuery('tr.row-detail').each(function (event) {
            ResponsiveDatatablesHelper.prototype.hideRowDetail(that, jQuery(this).prev());
        });
    }
};

/**
 * Show/hide datatables columns.
 */
ResponsiveDatatablesHelper.prototype.showHideColumns = function () {
    // Calculate the columns to show
    // Show columns that may have been previously hidden.
    for (var i = 0, l = this.columnsShownIndexes.length; i < l; i++) {
        this.tableElement.fnSetColumnVis(this.columnsShownIndexes[i], true, false);
    }

    // Hide columns that may have been previously shown.
    for (var i = 0, l = this.columnsHiddenIndexes.length; i < l; i++) {
        this.tableElement.fnSetColumnVis(this.columnsHiddenIndexes[i], false, false);
    }

    // Rebuild details to reflect shown/hidden column changes.
    var that = this;
    jQuery('tr.row-detail').each(function () {
        ResponsiveDatatablesHelper.prototype.hideRowDetail(that, jQuery(this).prev());
    });
    if (this.tableElement.hasClass('has-columns-hidden')) {
        jQuery('tr.detail-show', this.tableElement).each(function (index, element) {
            ResponsiveDatatablesHelper.prototype.showRowDetail(that, jQuery(element));
        });
    }
};

/**
 * Create the expand icon on the column with the data-class="expand" attribute
 * defined for it's header.
 *
 * @param {Object} tr table row object
 */
ResponsiveDatatablesHelper.prototype.createExpandIcon = function (tr) {
    if (this.disabled) {
        return;
    }

    // Get the td for tr with the same index as the th in the header tr
    // that has the data-class="expand" attribute defined.
    var tds = jQuery('td', tr);
    var that = this;
    // Loop through tds and create an expand icon on the td that has a column
    // index equal to the expand column given.
    for (var i = 0, l = tds.length; i < l; i++) {
        var td = tds[i];
        var tdIndex = that.tableElement.fnGetPosition(td)[2];
        td = jQuery(td);
        if (tdIndex === that.expandColumn) {
            // Create expand icon if there isn't one already.
            if (jQuery('span.responsiveExpander', td).length == 0) {
                td.prepend(that.expandIconTemplate);

                // Respond to click event on expander icon.
                td.on('click', 'span.responsiveExpander', {responsiveDatatablesHelperInstance: that}, that.showRowDetailEventHandler);
            }
            break;
        }
    }
};

/**
 * Show row detail event handler.
 *
 * This handler is used to handle the click event of the expand icon defined in
 * the table row data element.
 *
 * @param {Object} event jQuery event object
 */
ResponsiveDatatablesHelper.prototype.showRowDetailEventHandler = function (event) {
    if (this.disabled) {
        return;
    }

    // Get the parent tr of which this td belongs to.
    var tr = jQuery(this).closest('tr');

    // Show/hide row details
    if (tr.hasClass('detail-show')) {
        ResponsiveDatatablesHelper.prototype.hideRowDetail(event.data.responsiveDatatablesHelperInstance, tr);
    } else {
        ResponsiveDatatablesHelper.prototype.showRowDetail(event.data.responsiveDatatablesHelperInstance, tr);
    }

    tr.toggleClass('detail-show');

    // Prevent click event from bubbling up to higher-level DOM elements.
    event.stopPropagation();
};

/**
 * Show row details.
 *
 * @param {ResponsiveDatatablesHelper} responsiveDatatablesHelperInstance instance of ResponsiveDatatablesHelper
 * @param {Object}                     tr                                 jQuery wrapped set
 */
ResponsiveDatatablesHelper.prototype.showRowDetail = function (responsiveDatatablesHelperInstance, tr) {
    // Get column because we need their titles.
    var tableContainer = responsiveDatatablesHelperInstance.tableElement;
    var columns = tableContainer.fnSettings().aoColumns;

    // Create the new tr.
    var newTr = jQuery(responsiveDatatablesHelperInstance.rowTemplate);

    // Get the ul that we'll insert li's into.
    var ul = jQuery('ul', newTr);

    // Loop through hidden columns and create an li for each of them.
    _.each(responsiveDatatablesHelperInstance.columnsHiddenIndexes, function (index) {
        // Get row td
        var rowIndex = tableContainer.fnGetPosition(tr[0]);
        var td = tableContainer.fnGetTds(rowIndex)[index];

        // Don't create li if contents are empty (depends on hideEmptyColumnsInRowDetail option).
        if (!responsiveDatatablesHelperInstance.options.hideEmptyColumnsInRowDetail || td.innerHTML.trim().length) {
            var li = jQuery(responsiveDatatablesHelperInstance.rowLiTemplate);
            jQuery('.columnTitle', li).html(columns[index].sTitle);
            var rowHtml = jQuery(td).contents().clone();
            jQuery('.columnValue', li).html(rowHtml);

            // Copy index to data attribute, so we'll know where to put the value when the tr.row-detail is removed.
            li.attr('data-column', index);

            // Copy td class to new li.
            var tdClass = jQuery(td).attr('class');
            if (tdClass !== 'undefined' && tdClass !== false && tdClass !== '') {
                      li.addClass(tdClass)
            }

            ul.append(li);
        }
    });

    // Create tr colspan attribute.
    var colspan = responsiveDatatablesHelperInstance.columnIndexes.length - responsiveDatatablesHelperInstance.columnsHiddenIndexes.length;
    newTr.find('> td').attr('colspan', colspan);

    // Append the new tr after the current tr.
    tr.after(newTr);
};

/**
 * Hide row details.
 *
 * @param {ResponsiveDatatablesHelper} responsiveDatatablesHelperInstance instance of ResponsiveDatatablesHelper
 * @param {Object}                     tr                                 jQuery wrapped set
 */
ResponsiveDatatablesHelper.prototype.hideRowDetail = function (responsiveDatatablesHelperInstance, tr) {

    // If the value of an input has changed, we need to copy its state back to the DataTables object
    // so that value will persist when the tr.row-detail is removed.
    tr.next('.row-detail').find('li').each(function () {
        var tableContainer = responsiveDatatablesHelperInstance.tableElement;
        var aoData = tableContainer.fnSettings().aoData;
        var rowIndex = tableContainer.fnGetPosition(tr[0]);
        var column = jQuery(this).attr('data-column');
        var td = jQuery(this).find('span.columnValue').contents();
        aoData[rowIndex]._anHidden[column] = jQuery(aoData[rowIndex]._anHidden[column]).empty().append(td)[0];
    });
    tr.next('.row-detail').remove();
};

/**
 * Enable/disable responsive behavior and restores changes made.
 *
 * @param {Boolean} disable, default is true
 */
ResponsiveDatatablesHelper.prototype.disable = function (disable) {
    this.disabled = (disable === undefined) || disable;

    if (this.disabled) {
        // Remove windows resize handler.
        this.setWindowsResizeHandler(false);

        // Remove all trs that have row details.
        jQuery('tbody tr.row-detail', this.tableElement).remove();

        // Remove all trs that are marked to have row details shown.
        jQuery('tbody tr', this.tableElement).removeClass('detail-show');

        // Remove all expander icons.
        jQuery('tbody tr span.responsiveExpander', this.tableElement).remove();

        this.columnsHiddenIndexes = [];
        this.columnsShownIndexes = this.columnIndexes;
        this.showHideColumns();
        this.tableElement.removeClass('has-columns-hidden');

        this.tableElement.off('click', 'span.responsiveExpander', this.showRowDetailEventHandler);
    } else {
        // Add windows resize handler.
        this.setWindowsResizeHandler();
    }
}

/**
 * Get an array of TD nodes from DataTables for a given row, including any column elements which are hidden.
 *
 * Author: Allan Jardine
 * http://datatables.net/plug-ins/api
 *
 * @param {Object} oSettings DataTables settings object
 * @param {node}   mTr       TR node or aoData index
 */
jQuery.fn.dataTableExt.oApi.fnGetTds = function (oSettings, mTr)
{
    var anTds = [];
    var anVisibleTds = [];
    var iCorrector = 0;
    var nTd, iColumn, iColumns;

    /* Take either a TR node or aoData index as the mTr property */
    var iRow = (typeof mTr == 'object') ?
        oSettings.oApi._fnNodeToDataIndex(oSettings, mTr) : mTr;
    var nTr = oSettings.aoData[iRow].nTr;

    /* Get an array of the visible TD elements */
    for (iColumn=0, iColumns=nTr.childNodes.length; iColumn<iColumns ; iColumn++) {
        nTd = nTr.childNodes[iColumn];
        if (nTd.nodeName.toUpperCase() == "TD") {
            anVisibleTds.push( nTd );
        }
    }

    /* Construct and array of the combined elements */
    for (iColumn=0, iColumns=oSettings.aoColumns.length; iColumn<iColumns ; iColumn++) {
        if (oSettings.aoColumns[iColumn].bVisible) {
            anTds.push( anVisibleTds[iColumn-iCorrector] );
        }
        else {
            anTds.push( oSettings.aoData[iRow]._anHidden[iColumn] );
            iCorrector++;
        }
    }

    return anTds;
};

/*
Copyright 2012 Igor Vaynberg

Version: 3.5.3 Timestamp: Wed Aug 19 21:55:46 EDT 2015

This software is licensed under the Apache License, Version 2.0 (the "Apache License") or the GNU
General Public License version 2 (the "GPL License"). You may choose either license to govern your
use of this software only upon the condition that you accept all of the terms of either the Apache
License or the GPL License.

You may obtain a copy of the Apache License and the GPL License at:

    http://www.apache.org/licenses/LICENSE-2.0
    http://www.gnu.org/licenses/gpl-2.0.html

Unless required by applicable law or agreed to in writing, software distributed under the
Apache License or the GPL License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
CONDITIONS OF ANY KIND, either express or implied. See the Apache License and the GPL License for
the specific language governing permissions and limitations under the Apache License and the GPL License.
*/
(function ($) {
    if(typeof $.fn.each2 == "undefined") {
        $.extend($.fn, {
            /*
            * 4-10 times faster .each replacement
            * use it carefully, as it overrides jQuery context of element on each iteration
            */
            each2 : function (c) {
                var j = $([0]), i = -1, l = this.length;
                while (
                    ++i < l
                    && (j.context = j[0] = this[i])
                    && c.call(j[0], i, j) !== false //"this"=DOM, i=index, j=jQuery object
                );
                return this;
            }
        });
    }
})(jQuery);

(function ($, undefined) {
    "use strict";
    /*global document, window, jQuery, console */

    if (window.Select2 !== undefined) {
        return;
    }

    var AbstractSelect2, SingleSelect2, MultiSelect2, nextUid, sizer,
        lastMousePosition={x:0,y:0}, $document, scrollBarDimensions,

    KEY = {
        TAB: 9,
        ENTER: 13,
        ESC: 27,
        SPACE: 32,
        LEFT: 37,
        UP: 38,
        RIGHT: 39,
        DOWN: 40,
        SHIFT: 16,
        CTRL: 17,
        ALT: 18,
        PAGE_UP: 33,
        PAGE_DOWN: 34,
        HOME: 36,
        END: 35,
        BACKSPACE: 8,
        DELETE: 46,
        isArrow: function (k) {
            k = k.which ? k.which : k;
            switch (k) {
            case KEY.LEFT:
            case KEY.RIGHT:
            case KEY.UP:
            case KEY.DOWN:
                return true;
            }
            return false;
        },
        isControl: function (e) {
            var k = e.which;
            switch (k) {
            case KEY.SHIFT:
            case KEY.CTRL:
            case KEY.ALT:
                return true;
            }

            if (e.metaKey) return true;

            return false;
        },
        isFunctionKey: function (k) {
            k = k.which ? k.which : k;
            return k >= 112 && k <= 123;
        }
    },
    MEASURE_SCROLLBAR_TEMPLATE = "<div class='select2-measure-scrollbar'></div>",

    DIACRITICS = {"\u24B6":"A","\uFF21":"A","\u00C0":"A","\u00C1":"A","\u00C2":"A","\u1EA6":"A","\u1EA4":"A","\u1EAA":"A","\u1EA8":"A","\u00C3":"A","\u0100":"A","\u0102":"A","\u1EB0":"A","\u1EAE":"A","\u1EB4":"A","\u1EB2":"A","\u0226":"A","\u01E0":"A","\u00C4":"A","\u01DE":"A","\u1EA2":"A","\u00C5":"A","\u01FA":"A","\u01CD":"A","\u0200":"A","\u0202":"A","\u1EA0":"A","\u1EAC":"A","\u1EB6":"A","\u1E00":"A","\u0104":"A","\u023A":"A","\u2C6F":"A","\uA732":"AA","\u00C6":"AE","\u01FC":"AE","\u01E2":"AE","\uA734":"AO","\uA736":"AU","\uA738":"AV","\uA73A":"AV","\uA73C":"AY","\u24B7":"B","\uFF22":"B","\u1E02":"B","\u1E04":"B","\u1E06":"B","\u0243":"B","\u0182":"B","\u0181":"B","\u24B8":"C","\uFF23":"C","\u0106":"C","\u0108":"C","\u010A":"C","\u010C":"C","\u00C7":"C","\u1E08":"C","\u0187":"C","\u023B":"C","\uA73E":"C","\u24B9":"D","\uFF24":"D","\u1E0A":"D","\u010E":"D","\u1E0C":"D","\u1E10":"D","\u1E12":"D","\u1E0E":"D","\u0110":"D","\u018B":"D","\u018A":"D","\u0189":"D","\uA779":"D","\u01F1":"DZ","\u01C4":"DZ","\u01F2":"Dz","\u01C5":"Dz","\u24BA":"E","\uFF25":"E","\u00C8":"E","\u00C9":"E","\u00CA":"E","\u1EC0":"E","\u1EBE":"E","\u1EC4":"E","\u1EC2":"E","\u1EBC":"E","\u0112":"E","\u1E14":"E","\u1E16":"E","\u0114":"E","\u0116":"E","\u00CB":"E","\u1EBA":"E","\u011A":"E","\u0204":"E","\u0206":"E","\u1EB8":"E","\u1EC6":"E","\u0228":"E","\u1E1C":"E","\u0118":"E","\u1E18":"E","\u1E1A":"E","\u0190":"E","\u018E":"E","\u24BB":"F","\uFF26":"F","\u1E1E":"F","\u0191":"F","\uA77B":"F","\u24BC":"G","\uFF27":"G","\u01F4":"G","\u011C":"G","\u1E20":"G","\u011E":"G","\u0120":"G","\u01E6":"G","\u0122":"G","\u01E4":"G","\u0193":"G","\uA7A0":"G","\uA77D":"G","\uA77E":"G","\u24BD":"H","\uFF28":"H","\u0124":"H","\u1E22":"H","\u1E26":"H","\u021E":"H","\u1E24":"H","\u1E28":"H","\u1E2A":"H","\u0126":"H","\u2C67":"H","\u2C75":"H","\uA78D":"H","\u24BE":"I","\uFF29":"I","\u00CC":"I","\u00CD":"I","\u00CE":"I","\u0128":"I","\u012A":"I","\u012C":"I","\u0130":"I","\u00CF":"I","\u1E2E":"I","\u1EC8":"I","\u01CF":"I","\u0208":"I","\u020A":"I","\u1ECA":"I","\u012E":"I","\u1E2C":"I","\u0197":"I","\u24BF":"J","\uFF2A":"J","\u0134":"J","\u0248":"J","\u24C0":"K","\uFF2B":"K","\u1E30":"K","\u01E8":"K","\u1E32":"K","\u0136":"K","\u1E34":"K","\u0198":"K","\u2C69":"K","\uA740":"K","\uA742":"K","\uA744":"K","\uA7A2":"K","\u24C1":"L","\uFF2C":"L","\u013F":"L","\u0139":"L","\u013D":"L","\u1E36":"L","\u1E38":"L","\u013B":"L","\u1E3C":"L","\u1E3A":"L","\u0141":"L","\u023D":"L","\u2C62":"L","\u2C60":"L","\uA748":"L","\uA746":"L","\uA780":"L","\u01C7":"LJ","\u01C8":"Lj","\u24C2":"M","\uFF2D":"M","\u1E3E":"M","\u1E40":"M","\u1E42":"M","\u2C6E":"M","\u019C":"M","\u24C3":"N","\uFF2E":"N","\u01F8":"N","\u0143":"N","\u00D1":"N","\u1E44":"N","\u0147":"N","\u1E46":"N","\u0145":"N","\u1E4A":"N","\u1E48":"N","\u0220":"N","\u019D":"N","\uA790":"N","\uA7A4":"N","\u01CA":"NJ","\u01CB":"Nj","\u24C4":"O","\uFF2F":"O","\u00D2":"O","\u00D3":"O","\u00D4":"O","\u1ED2":"O","\u1ED0":"O","\u1ED6":"O","\u1ED4":"O","\u00D5":"O","\u1E4C":"O","\u022C":"O","\u1E4E":"O","\u014C":"O","\u1E50":"O","\u1E52":"O","\u014E":"O","\u022E":"O","\u0230":"O","\u00D6":"O","\u022A":"O","\u1ECE":"O","\u0150":"O","\u01D1":"O","\u020C":"O","\u020E":"O","\u01A0":"O","\u1EDC":"O","\u1EDA":"O","\u1EE0":"O","\u1EDE":"O","\u1EE2":"O","\u1ECC":"O","\u1ED8":"O","\u01EA":"O","\u01EC":"O","\u00D8":"O","\u01FE":"O","\u0186":"O","\u019F":"O","\uA74A":"O","\uA74C":"O","\u01A2":"OI","\uA74E":"OO","\u0222":"OU","\u24C5":"P","\uFF30":"P","\u1E54":"P","\u1E56":"P","\u01A4":"P","\u2C63":"P","\uA750":"P","\uA752":"P","\uA754":"P","\u24C6":"Q","\uFF31":"Q","\uA756":"Q","\uA758":"Q","\u024A":"Q","\u24C7":"R","\uFF32":"R","\u0154":"R","\u1E58":"R","\u0158":"R","\u0210":"R","\u0212":"R","\u1E5A":"R","\u1E5C":"R","\u0156":"R","\u1E5E":"R","\u024C":"R","\u2C64":"R","\uA75A":"R","\uA7A6":"R","\uA782":"R","\u24C8":"S","\uFF33":"S","\u1E9E":"S","\u015A":"S","\u1E64":"S","\u015C":"S","\u1E60":"S","\u0160":"S","\u1E66":"S","\u1E62":"S","\u1E68":"S","\u0218":"S","\u015E":"S","\u2C7E":"S","\uA7A8":"S","\uA784":"S","\u24C9":"T","\uFF34":"T","\u1E6A":"T","\u0164":"T","\u1E6C":"T","\u021A":"T","\u0162":"T","\u1E70":"T","\u1E6E":"T","\u0166":"T","\u01AC":"T","\u01AE":"T","\u023E":"T","\uA786":"T","\uA728":"TZ","\u24CA":"U","\uFF35":"U","\u00D9":"U","\u00DA":"U","\u00DB":"U","\u0168":"U","\u1E78":"U","\u016A":"U","\u1E7A":"U","\u016C":"U","\u00DC":"U","\u01DB":"U","\u01D7":"U","\u01D5":"U","\u01D9":"U","\u1EE6":"U","\u016E":"U","\u0170":"U","\u01D3":"U","\u0214":"U","\u0216":"U","\u01AF":"U","\u1EEA":"U","\u1EE8":"U","\u1EEE":"U","\u1EEC":"U","\u1EF0":"U","\u1EE4":"U","\u1E72":"U","\u0172":"U","\u1E76":"U","\u1E74":"U","\u0244":"U","\u24CB":"V","\uFF36":"V","\u1E7C":"V","\u1E7E":"V","\u01B2":"V","\uA75E":"V","\u0245":"V","\uA760":"VY","\u24CC":"W","\uFF37":"W","\u1E80":"W","\u1E82":"W","\u0174":"W","\u1E86":"W","\u1E84":"W","\u1E88":"W","\u2C72":"W","\u24CD":"X","\uFF38":"X","\u1E8A":"X","\u1E8C":"X","\u24CE":"Y","\uFF39":"Y","\u1EF2":"Y","\u00DD":"Y","\u0176":"Y","\u1EF8":"Y","\u0232":"Y","\u1E8E":"Y","\u0178":"Y","\u1EF6":"Y","\u1EF4":"Y","\u01B3":"Y","\u024E":"Y","\u1EFE":"Y","\u24CF":"Z","\uFF3A":"Z","\u0179":"Z","\u1E90":"Z","\u017B":"Z","\u017D":"Z","\u1E92":"Z","\u1E94":"Z","\u01B5":"Z","\u0224":"Z","\u2C7F":"Z","\u2C6B":"Z","\uA762":"Z","\u24D0":"a","\uFF41":"a","\u1E9A":"a","\u00E0":"a","\u00E1":"a","\u00E2":"a","\u1EA7":"a","\u1EA5":"a","\u1EAB":"a","\u1EA9":"a","\u00E3":"a","\u0101":"a","\u0103":"a","\u1EB1":"a","\u1EAF":"a","\u1EB5":"a","\u1EB3":"a","\u0227":"a","\u01E1":"a","\u00E4":"a","\u01DF":"a","\u1EA3":"a","\u00E5":"a","\u01FB":"a","\u01CE":"a","\u0201":"a","\u0203":"a","\u1EA1":"a","\u1EAD":"a","\u1EB7":"a","\u1E01":"a","\u0105":"a","\u2C65":"a","\u0250":"a","\uA733":"aa","\u00E6":"ae","\u01FD":"ae","\u01E3":"ae","\uA735":"ao","\uA737":"au","\uA739":"av","\uA73B":"av","\uA73D":"ay","\u24D1":"b","\uFF42":"b","\u1E03":"b","\u1E05":"b","\u1E07":"b","\u0180":"b","\u0183":"b","\u0253":"b","\u24D2":"c","\uFF43":"c","\u0107":"c","\u0109":"c","\u010B":"c","\u010D":"c","\u00E7":"c","\u1E09":"c","\u0188":"c","\u023C":"c","\uA73F":"c","\u2184":"c","\u24D3":"d","\uFF44":"d","\u1E0B":"d","\u010F":"d","\u1E0D":"d","\u1E11":"d","\u1E13":"d","\u1E0F":"d","\u0111":"d","\u018C":"d","\u0256":"d","\u0257":"d","\uA77A":"d","\u01F3":"dz","\u01C6":"dz","\u24D4":"e","\uFF45":"e","\u00E8":"e","\u00E9":"e","\u00EA":"e","\u1EC1":"e","\u1EBF":"e","\u1EC5":"e","\u1EC3":"e","\u1EBD":"e","\u0113":"e","\u1E15":"e","\u1E17":"e","\u0115":"e","\u0117":"e","\u00EB":"e","\u1EBB":"e","\u011B":"e","\u0205":"e","\u0207":"e","\u1EB9":"e","\u1EC7":"e","\u0229":"e","\u1E1D":"e","\u0119":"e","\u1E19":"e","\u1E1B":"e","\u0247":"e","\u025B":"e","\u01DD":"e","\u24D5":"f","\uFF46":"f","\u1E1F":"f","\u0192":"f","\uA77C":"f","\u24D6":"g","\uFF47":"g","\u01F5":"g","\u011D":"g","\u1E21":"g","\u011F":"g","\u0121":"g","\u01E7":"g","\u0123":"g","\u01E5":"g","\u0260":"g","\uA7A1":"g","\u1D79":"g","\uA77F":"g","\u24D7":"h","\uFF48":"h","\u0125":"h","\u1E23":"h","\u1E27":"h","\u021F":"h","\u1E25":"h","\u1E29":"h","\u1E2B":"h","\u1E96":"h","\u0127":"h","\u2C68":"h","\u2C76":"h","\u0265":"h","\u0195":"hv","\u24D8":"i","\uFF49":"i","\u00EC":"i","\u00ED":"i","\u00EE":"i","\u0129":"i","\u012B":"i","\u012D":"i","\u00EF":"i","\u1E2F":"i","\u1EC9":"i","\u01D0":"i","\u0209":"i","\u020B":"i","\u1ECB":"i","\u012F":"i","\u1E2D":"i","\u0268":"i","\u0131":"i","\u24D9":"j","\uFF4A":"j","\u0135":"j","\u01F0":"j","\u0249":"j","\u24DA":"k","\uFF4B":"k","\u1E31":"k","\u01E9":"k","\u1E33":"k","\u0137":"k","\u1E35":"k","\u0199":"k","\u2C6A":"k","\uA741":"k","\uA743":"k","\uA745":"k","\uA7A3":"k","\u24DB":"l","\uFF4C":"l","\u0140":"l","\u013A":"l","\u013E":"l","\u1E37":"l","\u1E39":"l","\u013C":"l","\u1E3D":"l","\u1E3B":"l","\u017F":"l","\u0142":"l","\u019A":"l","\u026B":"l","\u2C61":"l","\uA749":"l","\uA781":"l","\uA747":"l","\u01C9":"lj","\u24DC":"m","\uFF4D":"m","\u1E3F":"m","\u1E41":"m","\u1E43":"m","\u0271":"m","\u026F":"m","\u24DD":"n","\uFF4E":"n","\u01F9":"n","\u0144":"n","\u00F1":"n","\u1E45":"n","\u0148":"n","\u1E47":"n","\u0146":"n","\u1E4B":"n","\u1E49":"n","\u019E":"n","\u0272":"n","\u0149":"n","\uA791":"n","\uA7A5":"n","\u01CC":"nj","\u24DE":"o","\uFF4F":"o","\u00F2":"o","\u00F3":"o","\u00F4":"o","\u1ED3":"o","\u1ED1":"o","\u1ED7":"o","\u1ED5":"o","\u00F5":"o","\u1E4D":"o","\u022D":"o","\u1E4F":"o","\u014D":"o","\u1E51":"o","\u1E53":"o","\u014F":"o","\u022F":"o","\u0231":"o","\u00F6":"o","\u022B":"o","\u1ECF":"o","\u0151":"o","\u01D2":"o","\u020D":"o","\u020F":"o","\u01A1":"o","\u1EDD":"o","\u1EDB":"o","\u1EE1":"o","\u1EDF":"o","\u1EE3":"o","\u1ECD":"o","\u1ED9":"o","\u01EB":"o","\u01ED":"o","\u00F8":"o","\u01FF":"o","\u0254":"o","\uA74B":"o","\uA74D":"o","\u0275":"o","\u01A3":"oi","\u0223":"ou","\uA74F":"oo","\u24DF":"p","\uFF50":"p","\u1E55":"p","\u1E57":"p","\u01A5":"p","\u1D7D":"p","\uA751":"p","\uA753":"p","\uA755":"p","\u24E0":"q","\uFF51":"q","\u024B":"q","\uA757":"q","\uA759":"q","\u24E1":"r","\uFF52":"r","\u0155":"r","\u1E59":"r","\u0159":"r","\u0211":"r","\u0213":"r","\u1E5B":"r","\u1E5D":"r","\u0157":"r","\u1E5F":"r","\u024D":"r","\u027D":"r","\uA75B":"r","\uA7A7":"r","\uA783":"r","\u24E2":"s","\uFF53":"s","\u00DF":"s","\u015B":"s","\u1E65":"s","\u015D":"s","\u1E61":"s","\u0161":"s","\u1E67":"s","\u1E63":"s","\u1E69":"s","\u0219":"s","\u015F":"s","\u023F":"s","\uA7A9":"s","\uA785":"s","\u1E9B":"s","\u24E3":"t","\uFF54":"t","\u1E6B":"t","\u1E97":"t","\u0165":"t","\u1E6D":"t","\u021B":"t","\u0163":"t","\u1E71":"t","\u1E6F":"t","\u0167":"t","\u01AD":"t","\u0288":"t","\u2C66":"t","\uA787":"t","\uA729":"tz","\u24E4":"u","\uFF55":"u","\u00F9":"u","\u00FA":"u","\u00FB":"u","\u0169":"u","\u1E79":"u","\u016B":"u","\u1E7B":"u","\u016D":"u","\u00FC":"u","\u01DC":"u","\u01D8":"u","\u01D6":"u","\u01DA":"u","\u1EE7":"u","\u016F":"u","\u0171":"u","\u01D4":"u","\u0215":"u","\u0217":"u","\u01B0":"u","\u1EEB":"u","\u1EE9":"u","\u1EEF":"u","\u1EED":"u","\u1EF1":"u","\u1EE5":"u","\u1E73":"u","\u0173":"u","\u1E77":"u","\u1E75":"u","\u0289":"u","\u24E5":"v","\uFF56":"v","\u1E7D":"v","\u1E7F":"v","\u028B":"v","\uA75F":"v","\u028C":"v","\uA761":"vy","\u24E6":"w","\uFF57":"w","\u1E81":"w","\u1E83":"w","\u0175":"w","\u1E87":"w","\u1E85":"w","\u1E98":"w","\u1E89":"w","\u2C73":"w","\u24E7":"x","\uFF58":"x","\u1E8B":"x","\u1E8D":"x","\u24E8":"y","\uFF59":"y","\u1EF3":"y","\u00FD":"y","\u0177":"y","\u1EF9":"y","\u0233":"y","\u1E8F":"y","\u00FF":"y","\u1EF7":"y","\u1E99":"y","\u1EF5":"y","\u01B4":"y","\u024F":"y","\u1EFF":"y","\u24E9":"z","\uFF5A":"z","\u017A":"z","\u1E91":"z","\u017C":"z","\u017E":"z","\u1E93":"z","\u1E95":"z","\u01B6":"z","\u0225":"z","\u0240":"z","\u2C6C":"z","\uA763":"z","\u0386":"\u0391","\u0388":"\u0395","\u0389":"\u0397","\u038A":"\u0399","\u03AA":"\u0399","\u038C":"\u039F","\u038E":"\u03A5","\u03AB":"\u03A5","\u038F":"\u03A9","\u03AC":"\u03B1","\u03AD":"\u03B5","\u03AE":"\u03B7","\u03AF":"\u03B9","\u03CA":"\u03B9","\u0390":"\u03B9","\u03CC":"\u03BF","\u03CD":"\u03C5","\u03CB":"\u03C5","\u03B0":"\u03C5","\u03C9":"\u03C9","\u03C2":"\u03C3"};

    $document = $(document);

    nextUid=(function() { var counter=1; return function() { return counter++; }; }());


    function reinsertElement(element) {
        var placeholder = $(document.createTextNode(''));

        element.before(placeholder);
        placeholder.before(element);
        placeholder.remove();
    }

    function stripDiacritics(str) {
        // Used 'uni range + named function' from http://jsperf.com/diacritics/18
        function match(a) {
            return DIACRITICS[a] || a;
        }

        return str.replace(/[^\u0000-\u007E]/g, match);
    }

    function indexOf(value, array) {
        var i = 0, l = array.length;
        for (; i < l; i = i + 1) {
            if (equal(value, array[i])) return i;
        }
        return -1;
    }

    function measureScrollbar () {
        var $template = $( MEASURE_SCROLLBAR_TEMPLATE );
        $template.appendTo(document.body);

        var dim = {
            width: $template.width() - $template[0].clientWidth,
            height: $template.height() - $template[0].clientHeight
        };
        $template.remove();

        return dim;
    }

    /**
     * Compares equality of a and b
     * @param a
     * @param b
     */
    function equal(a, b) {
        if (a === b) return true;
        if (a === undefined || b === undefined) return false;
        if (a === null || b === null) return false;
        // Check whether 'a' or 'b' is a string (primitive or object).
        // The concatenation of an empty string (+'') converts its argument to a string's primitive.
        if (a.constructor === String) return a+'' === b+''; // a+'' - in case 'a' is a String object
        if (b.constructor === String) return b+'' === a+''; // b+'' - in case 'b' is a String object
        return false;
    }

    /**
     * Splits the string into an array of values, transforming each value. An empty array is returned for nulls or empty
     * strings
     * @param string
     * @param separator
     */
    function splitVal(string, separator, transform) {
        var val, i, l;
        if (string === null || string.length < 1) return [];
        val = string.split(separator);
        for (i = 0, l = val.length; i < l; i = i + 1) val[i] = transform(val[i]);
        return val;
    }

    function getSideBorderPadding(element) {
        return element.outerWidth(false) - element.width();
    }

    function installKeyUpChangeEvent(element) {
        var key="keyup-change-value";
        element.on("keydown", function () {
            if ($.data(element, key) === undefined) {
                $.data(element, key, element.val());
            }
        });
        element.on("keyup", function () {
            var val= $.data(element, key);
            if (val !== undefined && element.val() !== val) {
                $.removeData(element, key);
                element.trigger("keyup-change");
            }
        });
    }


    /**
     * filters mouse events so an event is fired only if the mouse moved.
     *
     * filters out mouse events that occur when mouse is stationary but
     * the elements under the pointer are scrolled.
     */
    function installFilteredMouseMove(element) {
        element.on("mousemove", function (e) {
            var lastpos = lastMousePosition;
            if (lastpos === undefined || lastpos.x !== e.pageX || lastpos.y !== e.pageY) {
                $(e.target).trigger("mousemove-filtered", e);
            }
        });
    }

    /**
     * Debounces a function. Returns a function that calls the original fn function only if no invocations have been made
     * within the last quietMillis milliseconds.
     *
     * @param quietMillis number of milliseconds to wait before invoking fn
     * @param fn function to be debounced
     * @param ctx object to be used as this reference within fn
     * @return debounced version of fn
     */
    function debounce(quietMillis, fn, ctx) {
        ctx = ctx || undefined;
        var timeout;
        return function () {
            var args = arguments;
            window.clearTimeout(timeout);
            timeout = window.setTimeout(function() {
                fn.apply(ctx, args);
            }, quietMillis);
        };
    }

    function installDebouncedScroll(threshold, element) {
        var notify = debounce(threshold, function (e) { element.trigger("scroll-debounced", e);});
        element.on("scroll", function (e) {
            if (indexOf(e.target, element.get()) >= 0) notify(e);
        });
    }

    function focus($el) {
        if ($el[0] === document.activeElement) return;

        /* set the focus in a 0 timeout - that way the focus is set after the processing
            of the current event has finished - which seems like the only reliable way
            to set focus */
        window.setTimeout(function() {
            var el=$el[0], pos=$el.val().length, range;

            $el.focus();

            /* make sure el received focus so we do not error out when trying to manipulate the caret.
                sometimes modals or others listeners may steal it after its set */
            var isVisible = (el.offsetWidth > 0 || el.offsetHeight > 0);
            if (isVisible && el === document.activeElement) {

                /* after the focus is set move the caret to the end, necessary when we val()
                    just before setting focus */
                if(el.setSelectionRange)
                {
                    el.setSelectionRange(pos, pos);
                }
                else if (el.createTextRange) {
                    range = el.createTextRange();
                    range.collapse(false);
                    range.select();
                }
            }
        }, 0);
    }

    function getCursorInfo(el) {
        el = $(el)[0];
        var offset = 0;
        var length = 0;
        if ('selectionStart' in el) {
            offset = el.selectionStart;
            length = el.selectionEnd - offset;
        } else if ('selection' in document) {
            el.focus();
            var sel = document.selection.createRange();
            length = document.selection.createRange().text.length;
            sel.moveStart('character', -el.value.length);
            offset = sel.text.length - length;
        }
        return { offset: offset, length: length };
    }

    function killEvent(event) {
        event.preventDefault();
        event.stopPropagation();
    }
    function killEventImmediately(event) {
        event.preventDefault();
        event.stopImmediatePropagation();
    }

    function measureTextWidth(e) {
        if (!sizer){
            var style = e[0].currentStyle || window.getComputedStyle(e[0], null);
            sizer = $(document.createElement("div")).css({
                position: "absolute",
                left: "-10000px",
                top: "-10000px",
                display: "none",
                fontSize: style.fontSize,
                fontFamily: style.fontFamily,
                fontStyle: style.fontStyle,
                fontWeight: style.fontWeight,
                letterSpacing: style.letterSpacing,
                textTransform: style.textTransform,
                whiteSpace: "nowrap"
            });
            sizer.attr("class","select2-sizer");
            $(document.body).append(sizer);
        }
        sizer.text(e.val());
        return sizer.width();
    }

    function syncCssClasses(dest, src, adapter) {
        var classes, replacements = [], adapted;

        classes = $.trim(dest.attr("class"));

        if (classes) {
            classes = '' + classes; // for IE which returns object

            $(classes.split(/\s+/)).each2(function() {
                if (this.indexOf("select2-") === 0) {
                    replacements.push(this);
                }
            });
        }

        classes = $.trim(src.attr("class"));

        if (classes) {
            classes = '' + classes; // for IE which returns object

            $(classes.split(/\s+/)).each2(function() {
                if (this.indexOf("select2-") !== 0) {
                    adapted = adapter(this);

                    if (adapted) {
                        replacements.push(adapted);
                    }
                }
            });
        }

        dest.attr("class", replacements.join(" "));
    }


    function markMatch(text, term, markup, escapeMarkup) {
        var match=stripDiacritics(text.toUpperCase()).indexOf(stripDiacritics(term.toUpperCase())),
            tl=term.length;

        if (match<0) {
            markup.push(escapeMarkup(text));
            return;
        }

        markup.push(escapeMarkup(text.substring(0, match)));
        markup.push("<span class='select2-match'>");
        markup.push(escapeMarkup(text.substring(match, match + tl)));
        markup.push("</span>");
        markup.push(escapeMarkup(text.substring(match + tl, text.length)));
    }

    function defaultEscapeMarkup(markup) {
        var replace_map = {
            '\\': '&#92;',
            '&': '&amp;',
            '<': '&lt;',
            '>': '&gt;',
            '"': '&quot;',
            "'": '&#39;',
            "/": '&#47;'
        };

        return String(markup).replace(/[&<>"'\/\\]/g, function (match) {
            return replace_map[match];
        });
    }

    /**
     * Produces an ajax-based query function
     *
     * @param options object containing configuration parameters
     * @param options.params parameter map for the transport ajax call, can contain such options as cache, jsonpCallback, etc. see $.ajax
     * @param options.transport function that will be used to execute the ajax request. must be compatible with parameters supported by $.ajax
     * @param options.url url for the data
     * @param options.data a function(searchTerm, pageNumber, context) that should return an object containing query string parameters for the above url.
     * @param options.dataType request data type: ajax, jsonp, other datatypes supported by jQuery's $.ajax function or the transport function if specified
     * @param options.quietMillis (optional) milliseconds to wait before making the ajaxRequest, helps debounce the ajax function if invoked too often
     * @param options.results a function(remoteData, pageNumber, query) that converts data returned form the remote request to the format expected by Select2.
     *      The expected format is an object containing the following keys:
     *      results array of objects that will be used as choices
     *      more (optional) boolean indicating whether there are more results available
     *      Example: {results:[{id:1, text:'Red'},{id:2, text:'Blue'}], more:true}
     */
    function ajax(options) {
        var timeout, // current scheduled but not yet executed request
            handler = null,
            quietMillis = options.quietMillis || 100,
            ajaxUrl = options.url,
            self = this;

        return function (query) {
            window.clearTimeout(timeout);
            timeout = window.setTimeout(function () {
                var data = options.data, // ajax data function
                    url = ajaxUrl, // ajax url string or function
                    transport = options.transport || $.fn.select2.ajaxDefaults.transport,
                    // deprecated - to be removed in 4.0  - use params instead
                    deprecated = {
                        type: options.type || 'GET', // set type of request (GET or POST)
                        cache: options.cache || false,
                        jsonpCallback: options.jsonpCallback||undefined,
                        dataType: options.dataType||"json"
                    },
                    params = $.extend({}, $.fn.select2.ajaxDefaults.params, deprecated);

                data = data ? data.call(self, query.term, query.page, query.context) : null;
                url = (typeof url === 'function') ? url.call(self, query.term, query.page, query.context) : url;

                if (handler && typeof handler.abort === "function") { handler.abort(); }

                if (options.params) {
                    if ($.isFunction(options.params)) {
                        $.extend(params, options.params.call(self));
                    } else {
                        $.extend(params, options.params);
                    }
                }

                $.extend(params, {
                    url: url,
                    dataType: options.dataType,
                    data: data,
                    success: function (data) {
                        // TODO - replace query.page with query so users have access to term, page, etc.
                        // added query as third paramter to keep backwards compatibility
                        var results = options.results(data, query.page, query);
                        query.callback(results);
                    },
                    error: function(jqXHR, textStatus, errorThrown){
                        var results = {
                            hasError: true,
                            jqXHR: jqXHR,
                            textStatus: textStatus,
                            errorThrown: errorThrown
                        };

                        query.callback(results);
                    }
                });
                handler = transport.call(self, params);
            }, quietMillis);
        };
    }

    /**
     * Produces a query function that works with a local array
     *
     * @param options object containing configuration parameters. The options parameter can either be an array or an
     * object.
     *
     * If the array form is used it is assumed that it contains objects with 'id' and 'text' keys.
     *
     * If the object form is used it is assumed that it contains 'data' and 'text' keys. The 'data' key should contain
     * an array of objects that will be used as choices. These objects must contain at least an 'id' key. The 'text'
     * key can either be a String in which case it is expected that each element in the 'data' array has a key with the
     * value of 'text' which will be used to match choices. Alternatively, text can be a function(item) that can extract
     * the text.
     */
    function local(options) {
        var data = options, // data elements
            dataText,
            tmp,
            text = function (item) { return ""+item.text; }; // function used to retrieve the text portion of a data item that is matched against the search

         if ($.isArray(data)) {
            tmp = data;
            data = { results: tmp };
        }

         if ($.isFunction(data) === false) {
            tmp = data;
            data = function() { return tmp; };
        }

        var dataItem = data();
        if (dataItem.text) {
            text = dataItem.text;
            // if text is not a function we assume it to be a key name
            if (!$.isFunction(text)) {
                dataText = dataItem.text; // we need to store this in a separate variable because in the next step data gets reset and data.text is no longer available
                text = function (item) { return item[dataText]; };
            }
        }

        return function (query) {
            var t = query.term, filtered = { results: [] }, process;
            if (t === "") {
                query.callback(data());
                return;
            }

            process = function(datum, collection) {
                var group, attr;
                datum = datum[0];
                if (datum.children) {
                    group = {};
                    for (attr in datum) {
                        if (datum.hasOwnProperty(attr)) group[attr]=datum[attr];
                    }
                    group.children=[];
                    $(datum.children).each2(function(i, childDatum) { process(childDatum, group.children); });
                    if (group.children.length || query.matcher(t, text(group), datum)) {
                        collection.push(group);
                    }
                } else {
                    if (query.matcher(t, text(datum), datum)) {
                        collection.push(datum);
                    }
                }
            };

            $(data().results).each2(function(i, datum) { process(datum, filtered.results); });
            query.callback(filtered);
        };
    }

    // TODO javadoc
    function tags(data) {
        var isFunc = $.isFunction(data);
        return function (query) {
            var t = query.term, filtered = {results: []};
            var result = isFunc ? data(query) : data;
            if ($.isArray(result)) {
                $(result).each(function () {
                    var isObject = this.text !== undefined,
                        text = isObject ? this.text : this;
                    if (t === "" || query.matcher(t, text)) {
                        filtered.results.push(isObject ? this : {id: this, text: this});
                    }
                });
                query.callback(filtered);
            }
        };
    }

    /**
     * Checks if the formatter function should be used.
     *
     * Throws an error if it is not a function. Returns true if it should be used,
     * false if no formatting should be performed.
     *
     * @param formatter
     */
    function checkFormatter(formatter, formatterName) {
        if ($.isFunction(formatter)) return true;
        if (!formatter) return false;
        if (typeof(formatter) === 'string') return true;
        throw new Error(formatterName +" must be a string, function, or falsy value");
    }

  /**
   * Returns a given value
   * If given a function, returns its output
   *
   * @param val string|function
   * @param context value of "this" to be passed to function
   * @returns {*}
   */
    function evaluate(val, context) {
        if ($.isFunction(val)) {
            var args = Array.prototype.slice.call(arguments, 2);
            return val.apply(context, args);
        }
        return val;
    }

    function countResults(results) {
        var count = 0;
        $.each(results, function(i, item) {
            if (item.children) {
                count += countResults(item.children);
            } else {
                count++;
            }
        });
        return count;
    }

    /**
     * Default tokenizer. This function uses breaks the input on substring match of any string from the
     * opts.tokenSeparators array and uses opts.createSearchChoice to create the choice object. Both of those
     * two options have to be defined in order for the tokenizer to work.
     *
     * @param input text user has typed so far or pasted into the search field
     * @param selection currently selected choices
     * @param selectCallback function(choice) callback tho add the choice to selection
     * @param opts select2's opts
     * @return undefined/null to leave the current input unchanged, or a string to change the input to the returned value
     */
    function defaultTokenizer(input, selection, selectCallback, opts) {
        var original = input, // store the original so we can compare and know if we need to tell the search to update its text
            dupe = false, // check for whether a token we extracted represents a duplicate selected choice
            token, // token
            index, // position at which the separator was found
            i, l, // looping variables
            separator; // the matched separator

        if (!opts.createSearchChoice || !opts.tokenSeparators || opts.tokenSeparators.length < 1) return undefined;

        while (true) {
            index = -1;

            for (i = 0, l = opts.tokenSeparators.length; i < l; i++) {
                separator = opts.tokenSeparators[i];
                index = input.indexOf(separator);
                if (index >= 0) break;
            }

            if (index < 0) break; // did not find any token separator in the input string, bail

            token = input.substring(0, index);
            input = input.substring(index + separator.length);

            if (token.length > 0) {
                token = opts.createSearchChoice.call(this, token, selection);
                if (token !== undefined && token !== null && opts.id(token) !== undefined && opts.id(token) !== null) {
                    dupe = false;
                    for (i = 0, l = selection.length; i < l; i++) {
                        if (equal(opts.id(token), opts.id(selection[i]))) {
                            dupe = true; break;
                        }
                    }

                    if (!dupe) selectCallback(token);
                }
            }
        }

        if (original!==input) return input;
    }

    function cleanupJQueryElements() {
        var self = this;

        $.each(arguments, function (i, element) {
            self[element].remove();
            self[element] = null;
        });
    }

    /**
     * Creates a new class
     *
     * @param superClass
     * @param methods
     */
    function clazz(SuperClass, methods) {
        var constructor = function () {};
        constructor.prototype = new SuperClass;
        constructor.prototype.constructor = constructor;
        constructor.prototype.parent = SuperClass.prototype;
        constructor.prototype = $.extend(constructor.prototype, methods);
        return constructor;
    }

    AbstractSelect2 = clazz(Object, {

        // abstract
        bind: function (func) {
            var self = this;
            return function () {
                func.apply(self, arguments);
            };
        },

        // abstract
        init: function (opts) {
            var results, search, resultsSelector = ".select2-results";

            // prepare options
            this.opts = opts = this.prepareOpts(opts);

            this.id=opts.id;

            // destroy if called on an existing component
            if (opts.element.data("select2") !== undefined &&
                opts.element.data("select2") !== null) {
                opts.element.data("select2").destroy();
            }

            this.container = this.createContainer();

            this.liveRegion = $('.select2-hidden-accessible');
            if (this.liveRegion.length == 0) {
                this.liveRegion = $("<span>", {
                        role: "status",
                        "aria-live": "polite"
                    })
                    .addClass("select2-hidden-accessible")
                    .appendTo(document.body);
            }

            this.containerId="s2id_"+(opts.element.attr("id") || "autogen"+nextUid());
            this.containerEventName= this.containerId
                .replace(/([.])/g, '_')
                .replace(/([;&,\-\.\+\*\~':"\!\^#$%@\[\]\(\)=>\|])/g, '\\$1');
            this.container.attr("id", this.containerId);

            this.container.attr("title", opts.element.attr("title"));

            this.body = $(document.body);

            syncCssClasses(this.container, this.opts.element, this.opts.adaptContainerCssClass);

            this.container.attr("style", opts.element.attr("style"));
            this.container.css(evaluate(opts.containerCss, this.opts.element));
            this.container.addClass(evaluate(opts.containerCssClass, this.opts.element));

            this.elementTabIndex = this.opts.element.attr("tabindex");

            // swap container for the element
            this.opts.element
                .data("select2", this)
                .attr("tabindex", "-1")
                .before(this.container)
                .on("click.select2", killEvent); // do not leak click events

            this.container.data("select2", this);

            this.dropdown = this.container.find(".select2-drop");

            syncCssClasses(this.dropdown, this.opts.element, this.opts.adaptDropdownCssClass);

            this.dropdown.addClass(evaluate(opts.dropdownCssClass, this.opts.element));
            this.dropdown.data("select2", this);
            this.dropdown.on("click", killEvent);

            this.results = results = this.container.find(resultsSelector);
            this.search = search = this.container.find("input.select2-input");

            this.queryCount = 0;
            this.resultsPage = 0;
            this.context = null;

            // initialize the container
            this.initContainer();

            this.container.on("click", killEvent);

            installFilteredMouseMove(this.results);

            this.dropdown.on("mousemove-filtered", resultsSelector, this.bind(this.highlightUnderEvent));
            this.dropdown.on("touchstart touchmove touchend", resultsSelector, this.bind(function (event) {
                this._touchEvent = true;
                this.highlightUnderEvent(event);
            }));
            this.dropdown.on("touchmove", resultsSelector, this.bind(this.touchMoved));
            this.dropdown.on("touchstart touchend", resultsSelector, this.bind(this.clearTouchMoved));

            // Waiting for a click event on touch devices to select option and hide dropdown
            // otherwise click will be triggered on an underlying element
            this.dropdown.on('click', this.bind(function (event) {
                if (this._touchEvent) {
                    this._touchEvent = false;
                    this.selectHighlighted();
                }
            }));

            installDebouncedScroll(80, this.results);
            this.dropdown.on("scroll-debounced", resultsSelector, this.bind(this.loadMoreIfNeeded));

            // do not propagate change event from the search field out of the component
            $(this.container).on("change", ".select2-input", function(e) {e.stopPropagation();});
            $(this.dropdown).on("change", ".select2-input", function(e) {e.stopPropagation();});

            // if jquery.mousewheel plugin is installed we can prevent out-of-bounds scrolling of results via mousewheel
            if ($.fn.mousewheel) {
                results.mousewheel(function (e, delta, deltaX, deltaY) {
                    var top = results.scrollTop();
                    if (deltaY > 0 && top - deltaY <= 0) {
                        results.scrollTop(0);
                        killEvent(e);
                    } else if (deltaY < 0 && results.get(0).scrollHeight - results.scrollTop() + deltaY <= results.height()) {
                        results.scrollTop(results.get(0).scrollHeight - results.height());
                        killEvent(e);
                    }
                });
            }

            installKeyUpChangeEvent(search);
            search.on("keyup-change input paste", this.bind(this.updateResults));
            search.on("focus", function () { search.addClass("select2-focused"); });
            search.on("blur", function () { search.removeClass("select2-focused");});

            this.dropdown.on("mouseup", resultsSelector, this.bind(function (e) {
                if ($(e.target).closest(".select2-result-selectable").length > 0) {
                    this.highlightUnderEvent(e);
                    this.selectHighlighted(e);
                }
            }));

            // trap all mouse events from leaving the dropdown. sometimes there may be a modal that is listening
            // for mouse events outside of itself so it can close itself. since the dropdown is now outside the select2's
            // dom it will trigger the popup close, which is not what we want
            // focusin can cause focus wars between modals and select2 since the dropdown is outside the modal.
            this.dropdown.on("click mouseup mousedown touchstart touchend focusin", function (e) { e.stopPropagation(); });

            this.lastSearchTerm = undefined;

            if ($.isFunction(this.opts.initSelection)) {
                // initialize selection based on the current value of the source element
                this.initSelection();

                // if the user has provided a function that can set selection based on the value of the source element
                // we monitor the change event on the element and trigger it, allowing for two way synchronization
                this.monitorSource();
            }

            if (opts.maximumInputLength !== null) {
                this.search.attr("maxlength", opts.maximumInputLength);
            }

            var disabled = opts.element.prop("disabled");
            if (disabled === undefined) disabled = false;
            this.enable(!disabled);

            var readonly = opts.element.prop("readonly");
            if (readonly === undefined) readonly = false;
            this.readonly(readonly);

            // Calculate size of scrollbar
            scrollBarDimensions = scrollBarDimensions || measureScrollbar();

            this.autofocus = opts.element.prop("autofocus");
            opts.element.prop("autofocus", false);
            if (this.autofocus) this.focus();

            this.search.attr("placeholder", opts.searchInputPlaceholder);
        },

        // abstract
        destroy: function () {
            var element=this.opts.element, select2 = element.data("select2"), self = this;

            this.close();

            if (element.length && element[0].detachEvent && self._sync) {
                element.each(function () {
                    if (self._sync) {
                        this.detachEvent("onpropertychange", self._sync);
                    }
                });
            }
            if (this.propertyObserver) {
                this.propertyObserver.disconnect();
                this.propertyObserver = null;
            }
            this._sync = null;

            if (select2 !== undefined) {
                select2.container.remove();
                select2.liveRegion.remove();
                select2.dropdown.remove();
                element.removeData("select2")
                    .off(".select2");
                if (!element.is("input[type='hidden']")) {
                    element
                        .show()
                        .prop("autofocus", this.autofocus || false);
                    if (this.elementTabIndex) {
                        element.attr({tabindex: this.elementTabIndex});
                    } else {
                        element.removeAttr("tabindex");
                    }
                    element.show();
                } else {
                    element.css("display", "");
                }
            }

            cleanupJQueryElements.call(this,
                "container",
                "liveRegion",
                "dropdown",
                "results",
                "search"
            );
        },

        // abstract
        optionToData: function(element) {
            if (element.is("option")) {
                return {
                    id:element.prop("value"),
                    text:element.text(),
                    element: element.get(),
                    css: element.attr("class"),
                    disabled: element.prop("disabled"),
                    locked: equal(element.attr("locked"), "locked") || equal(element.data("locked"), true)
                };
            } else if (element.is("optgroup")) {
                return {
                    text:element.attr("label"),
                    children:[],
                    element: element.get(),
                    css: element.attr("class")
                };
            }
        },

        // abstract
        prepareOpts: function (opts) {
            var element, select, idKey, ajaxUrl, self = this;

            element = opts.element;

            if (element.get(0).tagName.toLowerCase() === "select") {
                this.select = select = opts.element;
            }

            if (select) {
                // these options are not allowed when attached to a select because they are picked up off the element itself
                $.each(["id", "multiple", "ajax", "query", "createSearchChoice", "initSelection", "data", "tags"], function () {
                    if (this in opts) {
                        throw new Error("Option '" + this + "' is not allowed for Select2 when attached to a <select> element.");
                    }
                });
            }

            opts.debug = opts.debug || $.fn.select2.defaults.debug;

            // Warnings for options renamed/removed in Select2 4.0.0
            // Only when it's enabled through debug mode
            if (opts.debug && console && console.warn) {
                // id was removed
                if (opts.id != null) {
                    console.warn(
                        'Select2: The `id` option has been removed in Select2 4.0.0, ' +
                        'consider renaming your `id` property or mapping the property before your data makes it to Select2. ' +
                        'You can read more at https://select2.github.io/announcements-4.0.html#changed-id'
                    );
                }

                // text was removed
                if (opts.text != null) {
                    console.warn(
                        'Select2: The `text` option has been removed in Select2 4.0.0, ' +
                        'consider renaming your `text` property or mapping the property before your data makes it to Select2. ' +
                        'You can read more at https://select2.github.io/announcements-4.0.html#changed-id'
                    );
                }

                // sortResults was renamed to results
                if (opts.sortResults != null) {
                    console.warn(
                        'Select2: the `sortResults` option has been renamed to `sorter` in Select2 4.0.0. '
                    );
                }

                // selectOnBlur was renamed to selectOnClose
                if (opts.selectOnBlur != null) {
                    console.warn(
                        'Select2: The `selectOnBlur` option has been renamed to `selectOnClose` in Select2 4.0.0.'
                    );
                }

                // ajax.results was renamed to ajax.processResults
                if (opts.ajax != null && opts.ajax.results != null) {
                    console.warn(
                        'Select2: The `ajax.results` option has been renamed to `ajax.processResults` in Select2 4.0.0.'
                    );
                }

                // format* options were renamed to language.*
                if (opts.formatNoResults != null) {
                    console.warn(
                        'Select2: The `formatNoResults` option has been renamed to `language.noResults` in Select2 4.0.0.'
                    );
                }
                if (opts.formatSearching != null) {
                    console.warn(
                        'Select2: The `formatSearching` option has been renamed to `language.searching` in Select2 4.0.0.'
                    );
                }
                if (opts.formatInputTooShort != null) {
                    console.warn(
                        'Select2: The `formatInputTooShort` option has been renamed to `language.inputTooShort` in Select2 4.0.0.'
                    );
                }
                if (opts.formatInputTooLong != null) {
                    console.warn(
                        'Select2: The `formatInputTooLong` option has been renamed to `language.inputTooLong` in Select2 4.0.0.'
                    );
                }
                if (opts.formatLoading != null) {
                    console.warn(
                        'Select2: The `formatLoading` option has been renamed to `language.loadingMore` in Select2 4.0.0.'
                    );
                }
                if (opts.formatSelectionTooBig != null) {
                    console.warn(
                        'Select2: The `formatSelectionTooBig` option has been renamed to `language.maximumSelected` in Select2 4.0.0.'
                    );
                }

                if (opts.element.data('select2Tags')) {
                    console.warn(
                        'Select2: The `data-select2-tags` attribute has been renamed to `data-tags` in Select2 4.0.0.'
                    );
                }
            }

            // Aliasing options renamed in Select2 4.0.0

            // data-select2-tags -> data-tags
            if (opts.element.data('tags') != null) {
                var tagData = opts.element.data('tags');

                // data-tags should actually be a boolean
                if (!$.isArray(tagData)) {
                    tagData = [];
                }

                opts.element.data('select2Tags', tagData);
            }

            // sortResults -> sorter
            if (opts.sorter != null) {
                opts.sortResults = opts.sorter;
            }

            // selectOnBlur -> selectOnClose
            if (opts.selectOnClose != null) {
                opts.selectOnBlur = opts.selectOnClose;
            }

            // ajax.results -> ajax.processResults
            if (opts.ajax != null) {
                if ($.isFunction(opts.ajax.processResults)) {
                    opts.ajax.results = opts.ajax.processResults;
                }
            }

            // Formatters/language options
            if (opts.language != null) {
                var lang = opts.language;

                // formatNoMatches -> language.noMatches
                if ($.isFunction(lang.noMatches)) {
                    opts.formatNoMatches = lang.noMatches;
                }

                // formatSearching -> language.searching
                if ($.isFunction(lang.searching)) {
                    opts.formatSearching = lang.searching;
                }

                // formatInputTooShort -> language.inputTooShort
                if ($.isFunction(lang.inputTooShort)) {
                    opts.formatInputTooShort = lang.inputTooShort;
                }

                // formatInputTooLong -> language.inputTooLong
                if ($.isFunction(lang.inputTooLong)) {
                    opts.formatInputTooLong = lang.inputTooLong;
                }

                // formatLoading -> language.loadingMore
                if ($.isFunction(lang.loadingMore)) {
                    opts.formatLoading = lang.loadingMore;
                }

                // formatSelectionTooBig -> language.maximumSelected
                if ($.isFunction(lang.maximumSelected)) {
                    opts.formatSelectionTooBig = lang.maximumSelected;
                }
            }

            opts = $.extend({}, {
                populateResults: function(container, results, query) {
                    var populate, id=this.opts.id, liveRegion=this.liveRegion;

                    populate=function(results, container, depth) {

                        var i, l, result, selectable, disabled, compound, node, label, innerContainer, formatted;

                        results = opts.sortResults(results, container, query);

                        // collect the created nodes for bulk append
                        var nodes = [];
                        for (i = 0, l = results.length; i < l; i = i + 1) {

                            result=results[i];

                            disabled = (result.disabled === true);
                            selectable = (!disabled) && (id(result) !== undefined);

                            compound=result.children && result.children.length > 0;

                            node=$("<li></li>");
                            node.addClass("select2-results-dept-"+depth);
                            node.addClass("select2-result");
                            node.addClass(selectable ? "select2-result-selectable" : "select2-result-unselectable");
                            if (disabled) { node.addClass("select2-disabled"); }
                            if (compound) { node.addClass("select2-result-with-children"); }
                            node.addClass(self.opts.formatResultCssClass(result));
                            node.attr("role", "presentation");

                            label=$(document.createElement("div"));
                            label.addClass("select2-result-label");
                            label.attr("id", "select2-result-label-" + nextUid());
                            label.attr("role", "option");

                            formatted=opts.formatResult(result, label, query, self.opts.escapeMarkup);
                            if (formatted!==undefined) {
                                label.html(formatted);
                                node.append(label);
                            }


                            if (compound) {
                                innerContainer=$("<ul></ul>");
                                innerContainer.addClass("select2-result-sub");
                                populate(result.children, innerContainer, depth+1);
                                node.append(innerContainer);
                            }

                            node.data("select2-data", result);
                            nodes.push(node[0]);
                        }

                        // bulk append the created nodes
                        container.append(nodes);
                        liveRegion.text(opts.formatMatches(results.length));
                    };

                    populate(results, container, 0);
                }
            }, $.fn.select2.defaults, opts);

            if (typeof(opts.id) !== "function") {
                idKey = opts.id;
                opts.id = function (e) { return e[idKey]; };
            }

            if ($.isArray(opts.element.data("select2Tags"))) {
                if ("tags" in opts) {
                    throw "tags specified as both an attribute 'data-select2-tags' and in options of Select2 " + opts.element.attr("id");
                }
                opts.tags=opts.element.data("select2Tags");
            }

            if (select) {
                opts.query = this.bind(function (query) {
                    var data = { results: [], more: false },
                        term = query.term,
                        children, placeholderOption, process;

                    process=function(element, collection) {
                        var group;
                        if (element.is("option")) {
                            if (query.matcher(term, element.text(), element)) {
                                collection.push(self.optionToData(element));
                            }
                        } else if (element.is("optgroup")) {
                            group=self.optionToData(element);
                            element.children().each2(function(i, elm) { process(elm, group.children); });
                            if (group.children.length>0) {
                                collection.push(group);
                            }
                        }
                    };

                    children=element.children();

                    // ignore the placeholder option if there is one
                    if (this.getPlaceholder() !== undefined && children.length > 0) {
                        placeholderOption = this.getPlaceholderOption();
                        if (placeholderOption) {
                            children=children.not(placeholderOption);
                        }
                    }

                    children.each2(function(i, elm) { process(elm, data.results); });

                    query.callback(data);
                });
                // this is needed because inside val() we construct choices from options and their id is hardcoded
                opts.id=function(e) { return e.id; };
            } else {
                if (!("query" in opts)) {
                    if ("ajax" in opts) {
                        ajaxUrl = opts.element.data("ajax-url");
                        if (ajaxUrl && ajaxUrl.length > 0) {
                            opts.ajax.url = ajaxUrl;
                        }
                        opts.query = ajax.call(opts.element, opts.ajax);
                    } else if ("data" in opts) {
                        opts.query = local(opts.data);
                    } else if ("tags" in opts) {
                        opts.query = tags(opts.tags);
                        if (opts.createSearchChoice === undefined) {
                            opts.createSearchChoice = function (term) { return {id: $.trim(term), text: $.trim(term)}; };
                        }
                        if (opts.initSelection === undefined) {
                            opts.initSelection = function (element, callback) {
                                var data = [];
                                $(splitVal(element.val(), opts.separator, opts.transformVal)).each(function () {
                                    var obj = { id: this, text: this },
                                        tags = opts.tags;
                                    if ($.isFunction(tags)) tags=tags();
                                    $(tags).each(function() { if (equal(this.id, obj.id)) { obj = this; return false; } });
                                    data.push(obj);
                                });

                                callback(data);
                            };
                        }
                    }
                }
            }
            if (typeof(opts.query) !== "function") {
                throw "query function not defined for Select2 " + opts.element.attr("id");
            }

            if (opts.createSearchChoicePosition === 'top') {
                opts.createSearchChoicePosition = function(list, item) { list.unshift(item); };
            }
            else if (opts.createSearchChoicePosition === 'bottom') {
                opts.createSearchChoicePosition = function(list, item) { list.push(item); };
            }
            else if (typeof(opts.createSearchChoicePosition) !== "function")  {
                throw "invalid createSearchChoicePosition option must be 'top', 'bottom' or a custom function";
            }

            return opts;
        },

        /**
         * Monitor the original element for changes and update select2 accordingly
         */
        // abstract
        monitorSource: function () {
            var el = this.opts.element, observer, self = this;

            el.on("change.select2", this.bind(function (e) {
                if (this.opts.element.data("select2-change-triggered") !== true) {
                    this.initSelection();
                }
            }));

            this._sync = this.bind(function () {

                // sync enabled state
                var disabled = el.prop("disabled");
                if (disabled === undefined) disabled = false;
                this.enable(!disabled);

                var readonly = el.prop("readonly");
                if (readonly === undefined) readonly = false;
                this.readonly(readonly);

                if (this.container) {
                    syncCssClasses(this.container, this.opts.element, this.opts.adaptContainerCssClass);
                    this.container.addClass(evaluate(this.opts.containerCssClass, this.opts.element));
                }

                if (this.dropdown) {
                    syncCssClasses(this.dropdown, this.opts.element, this.opts.adaptDropdownCssClass);
                    this.dropdown.addClass(evaluate(this.opts.dropdownCssClass, this.opts.element));
                }

            });

            // IE8-10 (IE9/10 won't fire propertyChange via attachEventListener)
            if (el.length && el[0].attachEvent) {
                el.each(function() {
                    this.attachEvent("onpropertychange", self._sync);
                });
            }

            // safari, chrome, firefox, IE11
            observer = window.MutationObserver || window.WebKitMutationObserver|| window.MozMutationObserver;
            if (observer !== undefined) {
                if (this.propertyObserver) { delete this.propertyObserver; this.propertyObserver = null; }
                this.propertyObserver = new observer(function (mutations) {
                    $.each(mutations, self._sync);
                });
                this.propertyObserver.observe(el.get(0), { attributes:true, subtree:false });
            }
        },

        // abstract
        triggerSelect: function(data) {
            var evt = $.Event("select2-selecting", { val: this.id(data), object: data, choice: data });
            this.opts.element.trigger(evt);
            return !evt.isDefaultPrevented();
        },

        /**
         * Triggers the change event on the source element
         */
        // abstract
        triggerChange: function (details) {

            details = details || {};
            details= $.extend({}, details, { type: "change", val: this.val() });
            // prevents recursive triggering
            this.opts.element.data("select2-change-triggered", true);
            this.opts.element.trigger(details);
            this.opts.element.data("select2-change-triggered", false);

            // some validation frameworks ignore the change event and listen instead to keyup, click for selects
            // so here we trigger the click event manually
            this.opts.element.click();

            // ValidationEngine ignores the change event and listens instead to blur
            // so here we trigger the blur event manually if so desired
            if (this.opts.blurOnChange)
                this.opts.element.blur();
        },

        //abstract
        isInterfaceEnabled: function()
        {
            return this.enabledInterface === true;
        },

        // abstract
        enableInterface: function() {
            var enabled = this._enabled && !this._readonly,
                disabled = !enabled;

            if (enabled === this.enabledInterface) return false;

            this.container.toggleClass("select2-container-disabled", disabled);
            this.close();
            this.enabledInterface = enabled;

            return true;
        },

        // abstract
        enable: function(enabled) {
            if (enabled === undefined) enabled = true;
            if (this._enabled === enabled) return;
            this._enabled = enabled;

            this.opts.element.prop("disabled", !enabled);
            this.enableInterface();
        },

        // abstract
        disable: function() {
            this.enable(false);
        },

        // abstract
        readonly: function(enabled) {
            if (enabled === undefined) enabled = false;
            if (this._readonly === enabled) return;
            this._readonly = enabled;

            this.opts.element.prop("readonly", enabled);
            this.enableInterface();
        },

        // abstract
        opened: function () {
            return (this.container) ? this.container.hasClass("select2-dropdown-open") : false;
        },

        // abstract
        positionDropdown: function() {
            var $dropdown = this.dropdown,
                container = this.container,
                offset = container.offset(),
                height = container.outerHeight(false),
                width = container.outerWidth(false),
                dropHeight = $dropdown.outerHeight(false),
                $window = $(window),
                windowWidth = $window.width(),
                windowHeight = $window.height(),
                viewPortRight = $window.scrollLeft() + windowWidth,
                viewportBottom = $window.scrollTop() + windowHeight,
                dropTop = offset.top + height,
                dropLeft = offset.left,
                enoughRoomBelow = dropTop + dropHeight <= viewportBottom,
                enoughRoomAbove = (offset.top - dropHeight) >= $window.scrollTop(),
                dropWidth = $dropdown.outerWidth(false),
                enoughRoomOnRight = function() {
                    return dropLeft + dropWidth <= viewPortRight;
                },
                enoughRoomOnLeft = function() {
                    return offset.left + viewPortRight + container.outerWidth(false)  > dropWidth;
                },
                aboveNow = $dropdown.hasClass("select2-drop-above"),
                bodyOffset,
                above,
                changeDirection,
                css,
                resultsListNode;

            // always prefer the current above/below alignment, unless there is not enough room
            if (aboveNow) {
                above = true;
                if (!enoughRoomAbove && enoughRoomBelow) {
                    changeDirection = true;
                    above = false;
                }
            } else {
                above = false;
                if (!enoughRoomBelow && enoughRoomAbove) {
                    changeDirection = true;
                    above = true;
                }
            }

            //if we are changing direction we need to get positions when dropdown is hidden;
            if (changeDirection) {
                $dropdown.hide();
                offset = this.container.offset();
                height = this.container.outerHeight(false);
                width = this.container.outerWidth(false);
                dropHeight = $dropdown.outerHeight(false);
                viewPortRight = $window.scrollLeft() + windowWidth;
                viewportBottom = $window.scrollTop() + windowHeight;
                dropTop = offset.top + height;
                dropLeft = offset.left;
                dropWidth = $dropdown.outerWidth(false);
                $dropdown.show();

                // fix so the cursor does not move to the left within the search-textbox in IE
                this.focusSearch();
            }

            if (this.opts.dropdownAutoWidth) {
                resultsListNode = $('.select2-results', $dropdown)[0];
                $dropdown.addClass('select2-drop-auto-width');
                $dropdown.css('width', '');
                // Add scrollbar width to dropdown if vertical scrollbar is present
                dropWidth = $dropdown.outerWidth(false) + (resultsListNode.scrollHeight === resultsListNode.clientHeight ? 0 : scrollBarDimensions.width);
                dropWidth > width ? width = dropWidth : dropWidth = width;
                dropHeight = $dropdown.outerHeight(false);
            }
            else {
                this.container.removeClass('select2-drop-auto-width');
            }

            //console.log("below/ droptop:", dropTop, "dropHeight", dropHeight, "sum", (dropTop+dropHeight)+" viewport bottom", viewportBottom, "enough?", enoughRoomBelow);
            //console.log("above/ offset.top", offset.top, "dropHeight", dropHeight, "top", (offset.top-dropHeight), "scrollTop", this.body.scrollTop(), "enough?", enoughRoomAbove);

            // fix positioning when body has an offset and is not position: static
            if (this.body.css('position') !== 'static') {
                bodyOffset = this.body.offset();
                dropTop -= bodyOffset.top;
                dropLeft -= bodyOffset.left;
            }

            if (!enoughRoomOnRight() && enoughRoomOnLeft()) {
                dropLeft = offset.left + this.container.outerWidth(false) - dropWidth;
            }

            css =  {
                left: dropLeft,
                width: width
            };

            if (above) {
                this.container.addClass("select2-drop-above");
                $dropdown.addClass("select2-drop-above");
                dropHeight = $dropdown.outerHeight(false);
                css.top = offset.top - dropHeight;
                css.bottom = 'auto';
            }
            else {
                css.top = dropTop;
                css.bottom = 'auto';
                this.container.removeClass("select2-drop-above");
                $dropdown.removeClass("select2-drop-above");
            }
            css = $.extend(css, evaluate(this.opts.dropdownCss, this.opts.element));

            $dropdown.css(css);
        },

        // abstract
        shouldOpen: function() {
            var event;

            if (this.opened()) return false;

            if (this._enabled === false || this._readonly === true) return false;

            event = $.Event("select2-opening");
            this.opts.element.trigger(event);
            return !event.isDefaultPrevented();
        },

        // abstract
        clearDropdownAlignmentPreference: function() {
            // clear the classes used to figure out the preference of where the dropdown should be opened
            this.container.removeClass("select2-drop-above");
            this.dropdown.removeClass("select2-drop-above");
        },

        /**
         * Opens the dropdown
         *
         * @return {Boolean} whether or not dropdown was opened. This method will return false if, for example,
         * the dropdown is already open, or if the 'open' event listener on the element called preventDefault().
         */
        // abstract
        open: function () {

            if (!this.shouldOpen()) return false;

            this.opening();

            // Only bind the document mousemove when the dropdown is visible
            $document.on("mousemove.select2Event", function (e) {
                lastMousePosition.x = e.pageX;
                lastMousePosition.y = e.pageY;
            });

            return true;
        },

        /**
         * Performs the opening of the dropdown
         */
        // abstract
        opening: function() {
            var cid = this.containerEventName,
                scroll = "scroll." + cid,
                resize = "resize."+cid,
                orient = "orientationchange."+cid,
                mask;

            this.container.addClass("select2-dropdown-open").addClass("select2-container-active");

            this.clearDropdownAlignmentPreference();

            if(this.dropdown[0] !== this.body.children().last()[0]) {
                this.dropdown.detach().appendTo(this.body);
            }

            // create the dropdown mask if doesn't already exist
            mask = $("#select2-drop-mask");
            if (mask.length === 0) {
                mask = $(document.createElement("div"));
                mask.attr("id","select2-drop-mask").attr("class","select2-drop-mask");
                mask.hide();
                mask.appendTo(this.body);
                mask.on("mousedown touchstart click", function (e) {
                    // Prevent IE from generating a click event on the body
                    reinsertElement(mask);

                    var dropdown = $("#select2-drop"), self;
                    if (dropdown.length > 0) {
                        self=dropdown.data("select2");
                        if (self.opts.selectOnBlur) {
                            self.selectHighlighted({noFocus: true});
                        }
                        self.close();
                        e.preventDefault();
                        e.stopPropagation();
                    }
                });
            }

            // ensure the mask is always right before the dropdown
            if (this.dropdown.prev()[0] !== mask[0]) {
                this.dropdown.before(mask);
            }

            // move the global id to the correct dropdown
            $("#select2-drop").removeAttr("id");
            this.dropdown.attr("id", "select2-drop");

            // show the elements
            mask.show();

            this.positionDropdown();
            this.dropdown.show();
            this.positionDropdown();

            this.dropdown.addClass("select2-drop-active");

            // attach listeners to events that can change the position of the container and thus require
            // the position of the dropdown to be updated as well so it does not come unglued from the container
            var that = this;
            this.container.parents().add(window).each(function () {
                $(this).on(resize+" "+scroll+" "+orient, function (e) {
                    if (that.opened()) that.positionDropdown();
                });
            });


        },

        // abstract
        close: function () {
            if (!this.opened()) return;

            var cid = this.containerEventName,
                scroll = "scroll." + cid,
                resize = "resize."+cid,
                orient = "orientationchange."+cid;

            // unbind event listeners
            this.container.parents().add(window).each(function () { $(this).off(scroll).off(resize).off(orient); });

            this.clearDropdownAlignmentPreference();

            $("#select2-drop-mask").hide();
            this.dropdown.removeAttr("id"); // only the active dropdown has the select2-drop id
            this.dropdown.hide();
            this.container.removeClass("select2-dropdown-open").removeClass("select2-container-active");
            this.results.empty();

            // Now that the dropdown is closed, unbind the global document mousemove event
            $document.off("mousemove.select2Event");

            this.clearSearch();
            this.search.removeClass("select2-active");

            // Remove the aria active descendant for highlighted element
            this.search.removeAttr("aria-activedescendant");
            this.opts.element.trigger($.Event("select2-close"));
        },

        /**
         * Opens control, sets input value, and updates results.
         */
        // abstract
        externalSearch: function (term) {
            this.open();
            this.search.val(term);
            this.updateResults(false);
        },

        // abstract
        clearSearch: function () {

        },

        /**
         * @return {Boolean} Whether or not search value was changed.
         * @private
         */
        prefillNextSearchTerm: function () {
            // initializes search's value with nextSearchTerm (if defined by user)
            // ignore nextSearchTerm if the dropdown is opened by the user pressing a letter
            if(this.search.val() !== "") {
                return false;
            }

            var nextSearchTerm = this.opts.nextSearchTerm(this.data(), this.lastSearchTerm);
            if(nextSearchTerm !== undefined){
                this.search.val(nextSearchTerm);
                this.search.select();
                return true;
            }

            return false;
        },

        //abstract
        getMaximumSelectionSize: function() {
            return evaluate(this.opts.maximumSelectionSize, this.opts.element);
        },

        // abstract
        ensureHighlightVisible: function () {
            var results = this.results, children, index, child, hb, rb, y, more, topOffset;

            index = this.highlight();

            if (index < 0) return;

            if (index == 0) {

                // if the first element is highlighted scroll all the way to the top,
                // that way any unselectable headers above it will also be scrolled
                // into view

                results.scrollTop(0);
                return;
            }

            children = this.findHighlightableChoices().find('.select2-result-label');

            child = $(children[index]);

            topOffset = (child.offset() || {}).top || 0;

            hb = topOffset + child.outerHeight(true);

            // if this is the last child lets also make sure select2-more-results is visible
            if (index === children.length - 1) {
                more = results.find("li.select2-more-results");
                if (more.length > 0) {
                    hb = more.offset().top + more.outerHeight(true);
                }
            }

            rb = results.offset().top + results.outerHeight(false);
            if (hb > rb) {
                results.scrollTop(results.scrollTop() + (hb - rb));
            }
            y = topOffset - results.offset().top;

            // make sure the top of the element is visible
            if (y < 0 && child.css('display') != 'none' ) {
                results.scrollTop(results.scrollTop() + y); // y is negative
            }
        },

        // abstract
        findHighlightableChoices: function() {
            return this.results.find(".select2-result-selectable:not(.select2-disabled):not(.select2-selected)");
        },

        // abstract
        moveHighlight: function (delta) {
            var choices = this.findHighlightableChoices(),
                index = this.highlight();

            while (index > -1 && index < choices.length) {
                index += delta;
                var choice = $(choices[index]);
                if (choice.hasClass("select2-result-selectable") && !choice.hasClass("select2-disabled") && !choice.hasClass("select2-selected")) {
                    this.highlight(index);
                    break;
                }
            }
        },

        // abstract
        highlight: function (index) {
            var choices = this.findHighlightableChoices(),
                choice,
                data;

            if (arguments.length === 0) {
                return indexOf(choices.filter(".select2-highlighted")[0], choices.get());
            }

            if (index >= choices.length) index = choices.length - 1;
            if (index < 0) index = 0;

            this.removeHighlight();

            choice = $(choices[index]);
            choice.addClass("select2-highlighted");

            // ensure assistive technology can determine the active choice
            this.search.attr("aria-activedescendant", choice.find(".select2-result-label").attr("id"));

            this.ensureHighlightVisible();

            this.liveRegion.text(choice.text());

            data = choice.data("select2-data");
            if (data) {
                this.opts.element.trigger({ type: "select2-highlight", val: this.id(data), choice: data });
            }
        },

        removeHighlight: function() {
            this.results.find(".select2-highlighted").removeClass("select2-highlighted");
        },

        touchMoved: function() {
            this._touchMoved = true;
        },

        clearTouchMoved: function() {
          this._touchMoved = false;
        },

        // abstract
        countSelectableResults: function() {
            return this.findHighlightableChoices().length;
        },

        // abstract
        highlightUnderEvent: function (event) {
            var el = $(event.target).closest(".select2-result-selectable");
            if (el.length > 0 && !el.is(".select2-highlighted")) {
                var choices = this.findHighlightableChoices();
                this.highlight(choices.index(el));
            } else if (el.length == 0) {
                // if we are over an unselectable item remove all highlights
                this.removeHighlight();
            }
        },

        // abstract
        loadMoreIfNeeded: function () {
            var results = this.results,
                more = results.find("li.select2-more-results"),
                below, // pixels the element is below the scroll fold, below==0 is when the element is starting to be visible
                page = this.resultsPage + 1,
                self=this,
                term=this.search.val(),
                context=this.context;

            if (more.length === 0) return;
            below = more.offset().top - results.offset().top - results.height();

            if (below <= this.opts.loadMorePadding) {
                more.addClass("select2-active");
                this.opts.query({
                        element: this.opts.element,
                        term: term,
                        page: page,
                        context: context,
                        matcher: this.opts.matcher,
                        callback: this.bind(function (data) {

                    // ignore a response if the select2 has been closed before it was received
                    if (!self.opened()) return;


                    self.opts.populateResults.call(this, results, data.results, {term: term, page: page, context:context});
                    self.postprocessResults(data, false, false);

                    if (data.more===true) {
                        more.detach().appendTo(results).html(self.opts.escapeMarkup(evaluate(self.opts.formatLoadMore, self.opts.element, page+1)));
                        window.setTimeout(function() { self.loadMoreIfNeeded(); }, 10);
                    } else {
                        more.remove();
                    }
                    self.positionDropdown();
                    self.resultsPage = page;
                    self.context = data.context;
                    this.opts.element.trigger({ type: "select2-loaded", items: data });
                })});
            }
        },

        /**
         * Default tokenizer function which does nothing
         */
        tokenize: function() {

        },

        /**
         * @param initial whether or not this is the call to this method right after the dropdown has been opened
         */
        // abstract
        updateResults: function (initial) {
            var search = this.search,
                results = this.results,
                opts = this.opts,
                data,
                self = this,
                input,
                term = search.val(),
                lastTerm = $.data(this.container, "select2-last-term"),
                // sequence number used to drop out-of-order responses
                queryNumber;

            // prevent duplicate queries against the same term
            if (initial !== true && lastTerm && equal(term, lastTerm)) return;

            $.data(this.container, "select2-last-term", term);

            // if the search is currently hidden we do not alter the results
            if (initial !== true && (this.showSearchInput === false || !this.opened())) {
                return;
            }

            function postRender() {
                search.removeClass("select2-active");
                self.positionDropdown();
                if (results.find('.select2-no-results,.select2-selection-limit,.select2-searching').length) {
                    self.liveRegion.text(results.text());
                }
                else {
                    self.liveRegion.text(self.opts.formatMatches(results.find('.select2-result-selectable:not(".select2-selected")').length));
                }
            }

            function render(html) {
                results.html(html);
                postRender();
            }

            queryNumber = ++this.queryCount;

            var maxSelSize = this.getMaximumSelectionSize();
            if (maxSelSize >=1) {
                data = this.data();
                if ($.isArray(data) && data.length >= maxSelSize && checkFormatter(opts.formatSelectionTooBig, "formatSelectionTooBig")) {
                    render("<li class='select2-selection-limit'>" + evaluate(opts.formatSelectionTooBig, opts.element, maxSelSize) + "</li>");
                    return;
                }
            }

            if (search.val().length < opts.minimumInputLength) {
                if (checkFormatter(opts.formatInputTooShort, "formatInputTooShort")) {
                    render("<li class='select2-no-results'>" + evaluate(opts.formatInputTooShort, opts.element, search.val(), opts.minimumInputLength) + "</li>");
                } else {
                    render("");
                }
                if (initial && this.showSearch) this.showSearch(true);
                return;
            }

            if (opts.maximumInputLength && search.val().length > opts.maximumInputLength) {
                if (checkFormatter(opts.formatInputTooLong, "formatInputTooLong")) {
                    render("<li class='select2-no-results'>" + evaluate(opts.formatInputTooLong, opts.element, search.val(), opts.maximumInputLength) + "</li>");
                } else {
                    render("");
                }
                return;
            }

            if (opts.formatSearching && this.findHighlightableChoices().length === 0) {
                render("<li class='select2-searching'>" + evaluate(opts.formatSearching, opts.element) + "</li>");
            }

            search.addClass("select2-active");

            this.removeHighlight();

            // give the tokenizer a chance to pre-process the input
            input = this.tokenize();
            if (input != undefined && input != null) {
                search.val(input);
            }

            this.resultsPage = 1;

            opts.query({
                element: opts.element,
                    term: search.val(),
                    page: this.resultsPage,
                    context: null,
                    matcher: opts.matcher,
                    callback: this.bind(function (data) {
                var def; // default choice

                // ignore old responses
                if (queryNumber != this.queryCount) {
                  return;
                }

                // ignore a response if the select2 has been closed before it was received
                if (!this.opened()) {
                    this.search.removeClass("select2-active");
                    return;
                }

                // handle ajax error
                if(data.hasError !== undefined && checkFormatter(opts.formatAjaxError, "formatAjaxError")) {
                    render("<li class='select2-ajax-error'>" + evaluate(opts.formatAjaxError, opts.element, data.jqXHR, data.textStatus, data.errorThrown) + "</li>");
                    return;
                }

                // save context, if any
                this.context = (data.context===undefined) ? null : data.context;
                // create a default choice and prepend it to the list
                if (this.opts.createSearchChoice && search.val() !== "") {
                    def = this.opts.createSearchChoice.call(self, search.val(), data.results);
                    if (def !== undefined && def !== null && self.id(def) !== undefined && self.id(def) !== null) {
                        if ($(data.results).filter(
                            function () {
                                return equal(self.id(this), self.id(def));
                            }).length === 0) {
                            this.opts.createSearchChoicePosition(data.results, def);
                        }
                    }
                }

                if (data.results.length === 0 && checkFormatter(opts.formatNoMatches, "formatNoMatches")) {
                    render("<li class='select2-no-results'>" + evaluate(opts.formatNoMatches, opts.element, search.val()) + "</li>");
                    if(this.showSearch){
                        this.showSearch(search.val());
                    }
                    return;
                }

                results.empty();
                self.opts.populateResults.call(this, results, data.results, {term: search.val(), page: this.resultsPage, context:null});

                if (data.more === true && checkFormatter(opts.formatLoadMore, "formatLoadMore")) {
                    results.append("<li class='select2-more-results'>" + opts.escapeMarkup(evaluate(opts.formatLoadMore, opts.element, this.resultsPage)) + "</li>");
                    window.setTimeout(function() { self.loadMoreIfNeeded(); }, 10);
                }

                this.postprocessResults(data, initial);

                postRender();

                this.opts.element.trigger({ type: "select2-loaded", items: data });
            })});
        },

        // abstract
        cancel: function () {
            this.close();
        },

        // abstract
        blur: function () {
            // if selectOnBlur == true, select the currently highlighted option
            if (this.opts.selectOnBlur)
                this.selectHighlighted({noFocus: true});

            this.close();
            this.container.removeClass("select2-container-active");
            // synonymous to .is(':focus'), which is available in jquery >= 1.6
            if (this.search[0] === document.activeElement) { this.search.blur(); }
            this.clearSearch();
            this.selection.find(".select2-search-choice-focus").removeClass("select2-search-choice-focus");
        },

        // abstract
        focusSearch: function () {
            focus(this.search);
        },

        // abstract
        selectHighlighted: function (options) {
            if (this._touchMoved) {
              this.clearTouchMoved();
              return;
            }
            var index=this.highlight(),
                highlighted=this.results.find(".select2-highlighted"),
                data = highlighted.closest('.select2-result').data("select2-data");

            if (data) {
                this.highlight(index);
                this.onSelect(data, options);
            } else if (options && options.noFocus) {
                this.close();
            }
        },

        // abstract
        getPlaceholder: function () {
            var placeholderOption;
            return this.opts.element.attr("placeholder") ||
                this.opts.element.attr("data-placeholder") || // jquery 1.4 compat
                this.opts.element.data("placeholder") ||
                this.opts.placeholder ||
                ((placeholderOption = this.getPlaceholderOption()) !== undefined ? placeholderOption.text() : undefined);
        },

        // abstract
        getPlaceholderOption: function() {
            if (this.select) {
                var firstOption = this.select.children('option').first();
                if (this.opts.placeholderOption !== undefined ) {
                    //Determine the placeholder option based on the specified placeholderOption setting
                    return (this.opts.placeholderOption === "first" && firstOption) ||
                           (typeof this.opts.placeholderOption === "function" && this.opts.placeholderOption(this.select));
                } else if ($.trim(firstOption.text()) === "" && firstOption.val() === "") {
                    //No explicit placeholder option specified, use the first if it's blank
                    return firstOption;
                }
            }
        },

        /**
         * Get the desired width for the container element.  This is
         * derived first from option `width` passed to select2, then
         * the inline 'style' on the original element, and finally
         * falls back to the jQuery calculated element width.
         */
        // abstract
        initContainerWidth: function () {
            function resolveContainerWidth() {
                var style, attrs, matches, i, l, attr;

                if (this.opts.width === "off") {
                    return null;
                } else if (this.opts.width === "element"){
                    return this.opts.element.outerWidth(false) === 0 ? 'auto' : this.opts.element.outerWidth(false) + 'px';
                } else if (this.opts.width === "copy" || this.opts.width === "resolve") {
                    // check if there is inline style on the element that contains width
                    style = this.opts.element.attr('style');
                    if (typeof(style) === "string") {
                        attrs = style.split(';');
                        for (i = 0, l = attrs.length; i < l; i = i + 1) {
                            attr = attrs[i].replace(/\s/g, '');
                            matches = attr.match(/^width:(([-+]?([0-9]*\.)?[0-9]+)(px|em|ex|%|in|cm|mm|pt|pc))/i);
                            if (matches !== null && matches.length >= 1)
                                return matches[1];
                        }
                    }

                    if (this.opts.width === "resolve") {
                        // next check if css('width') can resolve a width that is percent based, this is sometimes possible
                        // when attached to input type=hidden or elements hidden via css
                        style = this.opts.element.css('width');
                        if (style.indexOf("%") > 0) return style;

                        // finally, fallback on the calculated width of the element
                        return (this.opts.element.outerWidth(false) === 0 ? 'auto' : this.opts.element.outerWidth(false) + 'px');
                    }

                    return null;
                } else if ($.isFunction(this.opts.width)) {
                    return this.opts.width();
                } else {
                    return this.opts.width;
               }
            };

            var width = resolveContainerWidth.call(this);
            if (width !== null) {
                this.container.css("width", width);
            }
        }
    });

    SingleSelect2 = clazz(AbstractSelect2, {

        // single

        createContainer: function () {
            var container = $(document.createElement("div")).attr({
                "class": "select2-container"
            }).html([
                "<a href='javascript:void(0)' class='select2-choice' tabindex='-1'>",
                "   <span class='select2-chosen'>&#160;</span><abbr class='select2-search-choice-close'></abbr>",
                "   <span class='select2-arrow' role='presentation'><b role='presentation'></b></span>",
                "</a>",
                "<label for='' class='select2-offscreen'></label>",
                "<input class='select2-focusser select2-offscreen' type='text' aria-haspopup='true' role='button' />",
                "<div class='select2-drop select2-display-none'>",
                "   <div class='select2-search'>",
                "       <label for='' class='select2-offscreen'></label>",
                "       <input type='text' autocomplete='off' autocorrect='off' autocapitalize='off' spellcheck='false' class='select2-input' role='combobox' aria-expanded='true'",
                "       aria-autocomplete='list' />",
                "   </div>",
                "   <ul class='select2-results' role='listbox'>",
                "   </ul>",
                "</div>"].join(""));
            return container;
        },

        // single
        enableInterface: function() {
            if (this.parent.enableInterface.apply(this, arguments)) {
                this.focusser.prop("disabled", !this.isInterfaceEnabled());
            }
        },

        // single
        opening: function () {
            var el, range, len;

            if (this.opts.minimumResultsForSearch >= 0) {
                this.showSearch(true);
            }

            this.parent.opening.apply(this, arguments);

            if (this.showSearchInput !== false) {
                // IE appends focusser.val() at the end of field :/ so we manually insert it at the beginning using a range
                // all other browsers handle this just fine

                this.search.val(this.focusser.val());
            }
            if (this.opts.shouldFocusInput(this)) {
                this.search.focus();
                // move the cursor to the end after focussing, otherwise it will be at the beginning and
                // new text will appear *before* focusser.val()
                el = this.search.get(0);
                if (el.createTextRange) {
                    range = el.createTextRange();
                    range.collapse(false);
                    range.select();
                } else if (el.setSelectionRange) {
                    len = this.search.val().length;
                    el.setSelectionRange(len, len);
                }
            }

            this.prefillNextSearchTerm();

            this.focusser.prop("disabled", true).val("");
            this.updateResults(true);
            this.opts.element.trigger($.Event("select2-open"));
        },

        // single
        close: function () {
            if (!this.opened()) return;
            this.parent.close.apply(this, arguments);

            this.focusser.prop("disabled", false);

            if (this.opts.shouldFocusInput(this)) {
                this.focusser.focus();
            }
        },

        // single
        focus: function () {
            if (this.opened()) {
                this.close();
            } else {
                this.focusser.prop("disabled", false);
                if (this.opts.shouldFocusInput(this)) {
                    this.focusser.focus();
                }
            }
        },

        // single
        isFocused: function () {
            return this.container.hasClass("select2-container-active");
        },

        // single
        cancel: function () {
            this.parent.cancel.apply(this, arguments);
            this.focusser.prop("disabled", false);

            if (this.opts.shouldFocusInput(this)) {
                this.focusser.focus();
            }
        },

        // single
        destroy: function() {
            $("label[for='" + this.focusser.attr('id') + "']")
                .attr('for', this.opts.element.attr("id"));
            this.parent.destroy.apply(this, arguments);

            cleanupJQueryElements.call(this,
                "selection",
                "focusser"
            );
        },

        // single
        initContainer: function () {

            var selection,
                container = this.container,
                dropdown = this.dropdown,
                idSuffix = nextUid(),
                elementLabel;

            if (this.opts.minimumResultsForSearch < 0) {
                this.showSearch(false);
            } else {
                this.showSearch(true);
            }

            this.selection = selection = container.find(".select2-choice");

            this.focusser = container.find(".select2-focusser");

            // add aria associations
            selection.find(".select2-chosen").attr("id", "select2-chosen-"+idSuffix);
            this.focusser.attr("aria-labelledby", "select2-chosen-"+idSuffix);
            this.results.attr("id", "select2-results-"+idSuffix);
            this.search.attr("aria-owns", "select2-results-"+idSuffix);

            // rewrite labels from original element to focusser
            this.focusser.attr("id", "s2id_autogen"+idSuffix);

            elementLabel = $("label[for='" + this.opts.element.attr("id") + "']");
            this.opts.element.on('focus.select2', this.bind(function () { this.focus(); }));

            this.focusser.prev()
                .text(elementLabel.text())
                .attr('for', this.focusser.attr('id'));

            // Ensure the original element retains an accessible name
            var originalTitle = this.opts.element.attr("title");
            this.opts.element.attr("title", (originalTitle || elementLabel.text()));

            this.focusser.attr("tabindex", this.elementTabIndex);

            // write label for search field using the label from the focusser element
            this.search.attr("id", this.focusser.attr('id') + '_search');

            this.search.prev()
                .text($("label[for='" + this.focusser.attr('id') + "']").text())
                .attr('for', this.search.attr('id'));

            this.search.on("keydown", this.bind(function (e) {
                if (!this.isInterfaceEnabled()) return;

                // filter 229 keyCodes (input method editor is processing key input)
                if (229 == e.keyCode) return;

                if (e.which === KEY.PAGE_UP || e.which === KEY.PAGE_DOWN) {
                    // prevent the page from scrolling
                    killEvent(e);
                    return;
                }

                switch (e.which) {
                    case KEY.UP:
                    case KEY.DOWN:
                        this.moveHighlight((e.which === KEY.UP) ? -1 : 1);
                        killEvent(e);
                        return;
                    case KEY.ENTER:
                        this.selectHighlighted();
                        killEvent(e);
                        return;
                    case KEY.TAB:
                        this.selectHighlighted({noFocus: true});
                        return;
                    case KEY.ESC:
                        this.cancel(e);
                        killEvent(e);
                        return;
                }
            }));

            this.search.on("blur", this.bind(function(e) {
                // a workaround for chrome to keep the search field focussed when the scroll bar is used to scroll the dropdown.
                // without this the search field loses focus which is annoying
                if (document.activeElement === this.body.get(0)) {
                    window.setTimeout(this.bind(function() {
                        if (this.opened() && this.results && this.results.length > 1) {
                            this.search.focus();
                        }
                    }), 0);
                }
            }));

            this.focusser.on("keydown", this.bind(function (e) {
                if (!this.isInterfaceEnabled()) return;

                if (e.which === KEY.TAB || KEY.isControl(e) || KEY.isFunctionKey(e) || e.which === KEY.ESC) {
                    return;
                }

                if (this.opts.openOnEnter === false && e.which === KEY.ENTER) {
                    killEvent(e);
                    return;
                }

                if (e.which == KEY.DOWN || e.which == KEY.UP
                    || (e.which == KEY.ENTER && this.opts.openOnEnter)) {

                    if (e.altKey || e.ctrlKey || e.shiftKey || e.metaKey) return;

                    this.open();
                    killEvent(e);
                    return;
                }

                if (e.which == KEY.DELETE || e.which == KEY.BACKSPACE) {
                    if (this.opts.allowClear) {
                        this.clear();
                    }
                    killEvent(e);
                    return;
                }
            }));


            installKeyUpChangeEvent(this.focusser);
            this.focusser.on("keyup-change input", this.bind(function(e) {
                if (this.opts.minimumResultsForSearch >= 0) {
                    e.stopPropagation();
                    if (this.opened()) return;
                    this.open();
                }
            }));

            selection.on("mousedown touchstart", "abbr", this.bind(function (e) {
                if (!this.isInterfaceEnabled()) {
                    return;
                }

                this.clear();
                killEventImmediately(e);
                this.close();

                if (this.selection) {
                    this.selection.focus();
                }
            }));

            selection.on("mousedown touchstart", this.bind(function (e) {
                // Prevent IE from generating a click event on the body
                reinsertElement(selection);

                if (!this.container.hasClass("select2-container-active")) {
                    this.opts.element.trigger($.Event("select2-focus"));
                }

                if (this.opened()) {
                    this.close();
                } else if (this.isInterfaceEnabled()) {
                    this.open();
                }

                killEvent(e);
            }));

            dropdown.on("mousedown touchstart", this.bind(function() {
                if (this.opts.shouldFocusInput(this)) {
                    this.search.focus();
                }
            }));

            selection.on("focus", this.bind(function(e) {
                killEvent(e);
            }));

            this.focusser.on("focus", this.bind(function(){
                if (!this.container.hasClass("select2-container-active")) {
                    this.opts.element.trigger($.Event("select2-focus"));
                }
                this.container.addClass("select2-container-active");
            })).on("blur", this.bind(function() {
                if (!this.opened()) {
                    this.container.removeClass("select2-container-active");
                    this.opts.element.trigger($.Event("select2-blur"));
                }
            }));
            this.search.on("focus", this.bind(function(){
                if (!this.container.hasClass("select2-container-active")) {
                    this.opts.element.trigger($.Event("select2-focus"));
                }
                this.container.addClass("select2-container-active");
            }));

            this.initContainerWidth();
            this.opts.element.hide();
            this.setPlaceholder();

        },

        // single
        clear: function(triggerChange) {
            var data=this.selection.data("select2-data");
            if (data) { // guard against queued quick consecutive clicks
                var evt = $.Event("select2-clearing");
                this.opts.element.trigger(evt);
                if (evt.isDefaultPrevented()) {
                    return;
                }
                var placeholderOption = this.getPlaceholderOption();
                this.opts.element.val(placeholderOption ? placeholderOption.val() : "");
                this.selection.find(".select2-chosen").empty();
                this.selection.removeData("select2-data");
                this.setPlaceholder();

                if (triggerChange !== false){
                    this.opts.element.trigger({ type: "select2-removed", val: this.id(data), choice: data });
                    this.triggerChange({removed:data});
                }
            }
        },

        /**
         * Sets selection based on source element's value
         */
        // single
        initSelection: function () {
            var selected;
            if (this.isPlaceholderOptionSelected()) {
                this.updateSelection(null);
                this.close();
                this.setPlaceholder();
            } else {
                var self = this;
                this.opts.initSelection.call(null, this.opts.element, function(selected){
                    if (selected !== undefined && selected !== null) {
                        self.updateSelection(selected);
                        self.close();
                        self.setPlaceholder();
                        self.lastSearchTerm = self.search.val();
                    }
                });
            }
        },

        isPlaceholderOptionSelected: function() {
            var placeholderOption;
            if (this.getPlaceholder() === undefined) return false; // no placeholder specified so no option should be considered
            return ((placeholderOption = this.getPlaceholderOption()) !== undefined && placeholderOption.prop("selected"))
                || (this.opts.element.val() === "")
                || (this.opts.element.val() === undefined)
                || (this.opts.element.val() === null);
        },

        // single
        prepareOpts: function () {
            var opts = this.parent.prepareOpts.apply(this, arguments),
                self=this;

            if (opts.element.get(0).tagName.toLowerCase() === "select") {
                // install the selection initializer
                opts.initSelection = function (element, callback) {
                    var selected = element.find("option").filter(function() { return this.selected && !this.disabled });
                    // a single select box always has a value, no need to null check 'selected'
                    callback(self.optionToData(selected));
                };
            } else if ("data" in opts) {
                // install default initSelection when applied to hidden input and data is local
                opts.initSelection = opts.initSelection || function (element, callback) {
                    var id = element.val();
                    //search in data by id, storing the actual matching item
                    var match = null;
                    opts.query({
                        matcher: function(term, text, el){
                            var is_match = equal(id, opts.id(el));
                            if (is_match) {
                                match = el;
                            }
                            return is_match;
                        },
                        callback: !$.isFunction(callback) ? $.noop : function() {
                            callback(match);
                        }
                    });
                };
            }

            return opts;
        },

        // single
        getPlaceholder: function() {
            // if a placeholder is specified on a single select without a valid placeholder option ignore it
            if (this.select) {
                if (this.getPlaceholderOption() === undefined) {
                    return undefined;
                }
            }

            return this.parent.getPlaceholder.apply(this, arguments);
        },

        // single
        setPlaceholder: function () {
            var placeholder = this.getPlaceholder();

            if (this.isPlaceholderOptionSelected() && placeholder !== undefined) {

                // check for a placeholder option if attached to a select
                if (this.select && this.getPlaceholderOption() === undefined) return;

                this.selection.find(".select2-chosen").html(this.opts.escapeMarkup(placeholder));

                this.selection.addClass("select2-default");

                this.container.removeClass("select2-allowclear");
            }
        },

        // single
        postprocessResults: function (data, initial, noHighlightUpdate) {
            var selected = 0, self = this, showSearchInput = true;

            // find the selected element in the result list

            this.findHighlightableChoices().each2(function (i, elm) {
                if (equal(self.id(elm.data("select2-data")), self.opts.element.val())) {
                    selected = i;
                    return false;
                }
            });

            // and highlight it
            if (noHighlightUpdate !== false) {
                if (initial === true && selected >= 0) {
                    this.highlight(selected);
                } else {
                    this.highlight(0);
                }
            }

            // hide the search box if this is the first we got the results and there are enough of them for search

            if (initial === true) {
                var min = this.opts.minimumResultsForSearch;
                if (min >= 0) {
                    this.showSearch(countResults(data.results) >= min);
                }
            }
        },

        // single
        showSearch: function(showSearchInput) {
            if (this.showSearchInput === showSearchInput) return;

            this.showSearchInput = showSearchInput;

            this.dropdown.find(".select2-search").toggleClass("select2-search-hidden", !showSearchInput);
            this.dropdown.find(".select2-search").toggleClass("select2-offscreen", !showSearchInput);
            //add "select2-with-searchbox" to the container if search box is shown
            $(this.dropdown, this.container).toggleClass("select2-with-searchbox", showSearchInput);
        },

        // single
        onSelect: function (data, options) {

            if (!this.triggerSelect(data)) { return; }

            var old = this.opts.element.val(),
                oldData = this.data();

            this.opts.element.val(this.id(data));
            this.updateSelection(data);

            this.opts.element.trigger({ type: "select2-selected", val: this.id(data), choice: data });

            this.lastSearchTerm = this.search.val();
            this.close();

            if ((!options || !options.noFocus) && this.opts.shouldFocusInput(this)) {
                this.focusser.focus();
            }

            if (!equal(old, this.id(data))) {
                this.triggerChange({ added: data, removed: oldData });
            }
        },

        // single
        updateSelection: function (data) {

            var container=this.selection.find(".select2-chosen"), formatted, cssClass;

            this.selection.data("select2-data", data);

            container.empty();
            if (data !== null) {
                formatted=this.opts.formatSelection(data, container, this.opts.escapeMarkup);
            }
            if (formatted !== undefined) {
                container.append(formatted);
            }
            cssClass=this.opts.formatSelectionCssClass(data, container);
            if (cssClass !== undefined) {
                container.addClass(cssClass);
            }

            this.selection.removeClass("select2-default");

            if (this.opts.allowClear && this.getPlaceholder() !== undefined) {
                this.container.addClass("select2-allowclear");
            }
        },

        // single
        val: function () {
            var val,
                triggerChange = false,
                data = null,
                self = this,
                oldData = this.data();

            if (arguments.length === 0) {
                return this.opts.element.val();
            }

            val = arguments[0];

            if (arguments.length > 1) {
                triggerChange = arguments[1];

                if (this.opts.debug && console && console.warn) {
                    console.warn(
                        'Select2: The second option to `select2("val")` is not supported in Select2 4.0.0. ' +
                        'The `change` event will always be triggered in 4.0.0.'
                    );
                }
            }

            if (this.select) {
                if (this.opts.debug && console && console.warn) {
                    console.warn(
                        'Select2: Setting the value on a <select> using `select2("val")` is no longer supported in 4.0.0. ' +
                        'You can use the `.val(newValue).trigger("change")` method provided by jQuery instead.'
                    );
                }

                this.select
                    .val(val)
                    .find("option").filter(function() { return this.selected }).each2(function (i, elm) {
                        data = self.optionToData(elm);
                        return false;
                    });
                this.updateSelection(data);
                this.setPlaceholder();
                if (triggerChange) {
                    this.triggerChange({added: data, removed:oldData});
                }
            } else {
                // val is an id. !val is true for [undefined,null,'',0] - 0 is legal
                if (!val && val !== 0) {
                    this.clear(triggerChange);
                    return;
                }
                if (this.opts.initSelection === undefined) {
                    throw new Error("cannot call val() if initSelection() is not defined");
                }
                this.opts.element.val(val);
                this.opts.initSelection(this.opts.element, function(data){
                    self.opts.element.val(!data ? "" : self.id(data));
                    self.updateSelection(data);
                    self.setPlaceholder();
                    if (triggerChange) {
                        self.triggerChange({added: data, removed:oldData});
                    }
                });
            }
        },

        // single
        clearSearch: function () {
            this.search.val("");
            this.focusser.val("");
        },

        // single
        data: function(value) {
            var data,
                triggerChange = false;

            if (arguments.length === 0) {
                data = this.selection.data("select2-data");
                if (data == undefined) data = null;
                return data;
            } else {
                if (opts.debug && console && console.warn) {
                    console.warn(
                        'Select2: The `select2("data")` method can no longer set selected values in 4.0.0, ' +
                        'consider using the `.val()` method instead.'
                    );
                }

                if (arguments.length > 1) {
                    triggerChange = arguments[1];
                }
                if (!value) {
                    this.clear(triggerChange);
                } else {
                    data = this.data();
                    this.opts.element.val(!value ? "" : this.id(value));
                    this.updateSelection(value);
                    if (triggerChange) {
                        this.triggerChange({added: value, removed:data});
                    }
                }
            }
        }
    });

    MultiSelect2 = clazz(AbstractSelect2, {

        // multi
        createContainer: function () {
            var container = $(document.createElement("div")).attr({
                "class": "select2-container select2-container-multi"
            }).html([
                "<ul class='select2-choices'>",
                "  <li class='select2-search-field'>",
                "    <label for='' class='select2-offscreen'></label>",
                "    <input type='text' autocomplete='off' autocorrect='off' autocapitalize='off' spellcheck='false' class='select2-input'>",
                "  </li>",
                "</ul>",
                "<div class='select2-drop select2-drop-multi select2-display-none'>",
                "   <ul class='select2-results'>",
                "   </ul>",
                "</div>"].join(""));
            return container;
        },

        // multi
        prepareOpts: function () {
            var opts = this.parent.prepareOpts.apply(this, arguments),
                self=this;

            // TODO validate placeholder is a string if specified
            if (opts.element.get(0).tagName.toLowerCase() === "select") {
                // install the selection initializer
                opts.initSelection = function (element, callback) {

                    var data = [];

                    element.find("option").filter(function() { return this.selected && !this.disabled }).each2(function (i, elm) {
                        data.push(self.optionToData(elm));
                    });
                    callback(data);
                };
            } else if ("data" in opts) {
                // install default initSelection when applied to hidden input and data is local
                opts.initSelection = opts.initSelection || function (element, callback) {
                    var ids = splitVal(element.val(), opts.separator, opts.transformVal);
                    //search in data by array of ids, storing matching items in a list
                    var matches = [];
                    opts.query({
                        matcher: function(term, text, el){
                            var is_match = $.grep(ids, function(id) {
                                return equal(id, opts.id(el));
                            }).length;
                            if (is_match) {
                                matches.push(el);
                            }
                            return is_match;
                        },
                        callback: !$.isFunction(callback) ? $.noop : function() {
                            // reorder matches based on the order they appear in the ids array because right now
                            // they are in the order in which they appear in data array
                            var ordered = [];
                            for (var i = 0; i < ids.length; i++) {
                                var id = ids[i];
                                for (var j = 0; j < matches.length; j++) {
                                    var match = matches[j];
                                    if (equal(id, opts.id(match))) {
                                        ordered.push(match);
                                        matches.splice(j, 1);
                                        break;
                                    }
                                }
                            }
                            callback(ordered);
                        }
                    });
                };
            }

            return opts;
        },

        // multi
        selectChoice: function (choice) {

            var selected = this.container.find(".select2-search-choice-focus");
            if (selected.length && choice && choice[0] == selected[0]) {

            } else {
                if (selected.length) {
                    this.opts.element.trigger("choice-deselected", selected);
                }
                selected.removeClass("select2-search-choice-focus");
                if (choice && choice.length) {
                    this.close();
                    choice.addClass("select2-search-choice-focus");
                    this.opts.element.trigger("choice-selected", choice);
                }
            }
        },

        // multi
        destroy: function() {
            $("label[for='" + this.search.attr('id') + "']")
                .attr('for', this.opts.element.attr("id"));
            this.parent.destroy.apply(this, arguments);

            cleanupJQueryElements.call(this,
                "searchContainer",
                "selection"
            );
        },

        // multi
        initContainer: function () {

            var selector = ".select2-choices", selection;

            this.searchContainer = this.container.find(".select2-search-field");
            this.selection = selection = this.container.find(selector);

            var _this = this;
            this.selection.on("click", ".select2-container:not(.select2-container-disabled) .select2-search-choice:not(.select2-locked)", function (e) {
                _this.search[0].focus();
                _this.selectChoice($(this));
            });

            // rewrite labels from original element to focusser
            this.search.attr("id", "s2id_autogen"+nextUid());

            this.search.prev()
                .text($("label[for='" + this.opts.element.attr("id") + "']").text())
                .attr('for', this.search.attr('id'));
            this.opts.element.on('focus.select2', this.bind(function () { this.focus(); }));

            this.search.on("input paste", this.bind(function() {
                if (this.search.attr('placeholder') && this.search.val().length == 0) return;
                if (!this.isInterfaceEnabled()) return;
                if (!this.opened()) {
                    this.open();
                }
            }));

            this.search.attr("tabindex", this.elementTabIndex);

            this.keydowns = 0;
            this.search.on("keydown", this.bind(function (e) {
                if (!this.isInterfaceEnabled()) return;

                ++this.keydowns;
                var selected = selection.find(".select2-search-choice-focus");
                var prev = selected.prev(".select2-search-choice:not(.select2-locked)");
                var next = selected.next(".select2-search-choice:not(.select2-locked)");
                var pos = getCursorInfo(this.search);

                if (selected.length &&
                    (e.which == KEY.LEFT || e.which == KEY.RIGHT || e.which == KEY.BACKSPACE || e.which == KEY.DELETE || e.which == KEY.ENTER)) {
                    var selectedChoice = selected;
                    if (e.which == KEY.LEFT && prev.length) {
                        selectedChoice = prev;
                    }
                    else if (e.which == KEY.RIGHT) {
                        selectedChoice = next.length ? next : null;
                    }
                    else if (e.which === KEY.BACKSPACE) {
                        if (this.unselect(selected.first())) {
                            this.search.width(10);
                            selectedChoice = prev.length ? prev : next;
                        }
                    } else if (e.which == KEY.DELETE) {
                        if (this.unselect(selected.first())) {
                            this.search.width(10);
                            selectedChoice = next.length ? next : null;
                        }
                    } else if (e.which == KEY.ENTER) {
                        selectedChoice = null;
                    }

                    this.selectChoice(selectedChoice);
                    killEvent(e);
                    if (!selectedChoice || !selectedChoice.length) {
                        this.open();
                    }
                    return;
                } else if (((e.which === KEY.BACKSPACE && this.keydowns == 1)
                    || e.which == KEY.LEFT) && (pos.offset == 0 && !pos.length)) {

                    this.selectChoice(selection.find(".select2-search-choice:not(.select2-locked)").last());
                    killEvent(e);
                    return;
                } else {
                    this.selectChoice(null);
                }

                if (this.opened()) {
                    switch (e.which) {
                    case KEY.UP:
                    case KEY.DOWN:
                        this.moveHighlight((e.which === KEY.UP) ? -1 : 1);
                        killEvent(e);
                        return;
                    case KEY.ENTER:
                        this.selectHighlighted();
                        killEvent(e);
                        return;
                    case KEY.TAB:
                        this.selectHighlighted({noFocus:true});
                        this.close();
                        return;
                    case KEY.ESC:
                        this.cancel(e);
                        killEvent(e);
                        return;
                    }
                }

                if (e.which === KEY.TAB || KEY.isControl(e) || KEY.isFunctionKey(e)
                 || e.which === KEY.BACKSPACE || e.which === KEY.ESC) {
                    return;
                }

                if (e.which === KEY.ENTER) {
                    if (this.opts.openOnEnter === false) {
                        return;
                    } else if (e.altKey || e.ctrlKey || e.shiftKey || e.metaKey) {
                        return;
                    }
                }

                this.open();

                if (e.which === KEY.PAGE_UP || e.which === KEY.PAGE_DOWN) {
                    // prevent the page from scrolling
                    killEvent(e);
                }

                if (e.which === KEY.ENTER) {
                    // prevent form from being submitted
                    killEvent(e);
                }

            }));

            this.search.on("keyup", this.bind(function (e) {
                this.keydowns = 0;
                this.resizeSearch();
            })
            );

            this.search.on("blur", this.bind(function(e) {
                this.container.removeClass("select2-container-active");
                this.search.removeClass("select2-focused");
                this.selectChoice(null);
                if (!this.opened()) this.clearSearch();
                e.stopImmediatePropagation();
                this.opts.element.trigger($.Event("select2-blur"));
            }));

            this.container.on("click", selector, this.bind(function (e) {
                if (!this.isInterfaceEnabled()) return;
                if ($(e.target).closest(".select2-search-choice").length > 0) {
                    // clicked inside a select2 search choice, do not open
                    return;
                }
                this.selectChoice(null);
                this.clearPlaceholder();
                if (!this.container.hasClass("select2-container-active")) {
                    this.opts.element.trigger($.Event("select2-focus"));
                }
                this.open();
                this.focusSearch();
                e.preventDefault();
            }));

            this.container.on("focus", selector, this.bind(function () {
                if (!this.isInterfaceEnabled()) return;
                if (!this.container.hasClass("select2-container-active")) {
                    this.opts.element.trigger($.Event("select2-focus"));
                }
                this.container.addClass("select2-container-active");
                this.dropdown.addClass("select2-drop-active");
                this.clearPlaceholder();
            }));

            this.initContainerWidth();
            this.opts.element.hide();

            // set the placeholder if necessary
            this.clearSearch();
        },

        // multi
        enableInterface: function() {
            if (this.parent.enableInterface.apply(this, arguments)) {
                this.search.prop("disabled", !this.isInterfaceEnabled());
            }
        },

        // multi
        initSelection: function () {
            var data;
            if (this.opts.element.val() === "" && this.opts.element.text() === "") {
                this.updateSelection([]);
                this.close();
                // set the placeholder if necessary
                this.clearSearch();
            }
            if (this.select || this.opts.element.val() !== "") {
                var self = this;
                this.opts.initSelection.call(null, this.opts.element, function(data){
                    if (data !== undefined && data !== null) {
                        self.updateSelection(data);
                        self.close();
                        // set the placeholder if necessary
                        self.clearSearch();
                    }
                });
            }
        },

        // multi
        clearSearch: function () {
            var placeholder = this.getPlaceholder(),
                maxWidth = this.getMaxSearchWidth();

            if (placeholder !== undefined  && this.getVal().length === 0 && this.search.hasClass("select2-focused") === false) {
                this.search.val(placeholder).addClass("select2-default");
                // stretch the search box to full width of the container so as much of the placeholder is visible as possible
                // we could call this.resizeSearch(), but we do not because that requires a sizer and we do not want to create one so early because of a firefox bug, see #944
                this.search.width(maxWidth > 0 ? maxWidth : this.container.css("width"));
            } else {
                this.search.val("").width(10);
            }
        },

        // multi
        clearPlaceholder: function () {
            if (this.search.hasClass("select2-default")) {
                this.search.val("").removeClass("select2-default");
            }
        },

        // multi
        opening: function () {
            this.clearPlaceholder(); // should be done before super so placeholder is not used to search
            this.resizeSearch();

            this.parent.opening.apply(this, arguments);

            this.focusSearch();

            this.prefillNextSearchTerm();
            this.updateResults(true);

            if (this.opts.shouldFocusInput(this)) {
                this.search.focus();
            }
            this.opts.element.trigger($.Event("select2-open"));
        },

        // multi
        close: function () {
            if (!this.opened()) return;
            this.parent.close.apply(this, arguments);
        },

        // multi
        focus: function () {
            this.close();
            this.search.focus();
        },

        // multi
        isFocused: function () {
            return this.search.hasClass("select2-focused");
        },

        // multi
        updateSelection: function (data) {
            var ids = {}, filtered = [], self = this;

            // filter out duplicates
            $(data).each(function () {
                if (!(self.id(this) in ids)) {
                    ids[self.id(this)] = 0;
                    filtered.push(this);
                }
            });

            this.selection.find(".select2-search-choice").remove();
            this.addSelectedChoice(filtered);
            self.postprocessResults();
        },

        // multi
        tokenize: function() {
            var input = this.search.val();
            input = this.opts.tokenizer.call(this, input, this.data(), this.bind(this.onSelect), this.opts);
            if (input != null && input != undefined) {
                this.search.val(input);
                if (input.length > 0) {
                    this.open();
                }
            }

        },

        // multi
        onSelect: function (data, options) {

            if (!this.triggerSelect(data) || data.text === "") { return; }

            this.addSelectedChoice(data);

            this.opts.element.trigger({ type: "selected", val: this.id(data), choice: data });

            // keep track of the search's value before it gets cleared
            this.lastSearchTerm = this.search.val();

            this.clearSearch();
            this.updateResults();

            if (this.select || !this.opts.closeOnSelect) this.postprocessResults(data, false, this.opts.closeOnSelect===true);

            if (this.opts.closeOnSelect) {
                this.close();
                this.search.width(10);
            } else {
                if (this.countSelectableResults()>0) {
                    this.search.width(10);
                    this.resizeSearch();
                    if (this.getMaximumSelectionSize() > 0 && this.val().length >= this.getMaximumSelectionSize()) {
                        // if we reached max selection size repaint the results so choices
                        // are replaced with the max selection reached message
                        this.updateResults(true);
                    } else {
                        // initializes search's value with nextSearchTerm and update search result
                        if (this.prefillNextSearchTerm()) {
                            this.updateResults();
                        }
                    }
                    this.positionDropdown();
                } else {
                    // if nothing left to select close
                    this.close();
                    this.search.width(10);
                }
            }

            // since its not possible to select an element that has already been
            // added we do not need to check if this is a new element before firing change
            this.triggerChange({ added: data });

            if (!options || !options.noFocus)
                this.focusSearch();
        },

        // multi
        cancel: function () {
            this.close();
            this.focusSearch();
        },

        addSelectedChoice: function (data) {
            var val = this.getVal(), self = this;
            $(data).each(function () {
                val.push(self.createChoice(this));
            });
            this.setVal(val);
        },

        createChoice: function (data) {
            var enableChoice = !data.locked,
                enabledItem = $(
                    "<li class='select2-search-choice'>" +
                    "    <div></div>" +
                    "    <a href='#' class='select2-search-choice-close' tabindex='-1'></a>" +
                    "</li>"),
                disabledItem = $(
                    "<li class='select2-search-choice select2-locked'>" +
                    "<div></div>" +
                    "</li>");
            var choice = enableChoice ? enabledItem : disabledItem,
                id = this.id(data),
                formatted,
                cssClass;

            formatted=this.opts.formatSelection(data, choice.find("div"), this.opts.escapeMarkup);
            if (formatted != undefined) {
                choice.find("div").replaceWith($("<div></div>").html(formatted));
            }
            cssClass=this.opts.formatSelectionCssClass(data, choice.find("div"));
            if (cssClass != undefined) {
                choice.addClass(cssClass);
            }

            if(enableChoice){
              choice.find(".select2-search-choice-close")
                  .on("mousedown", killEvent)
                  .on("click dblclick", this.bind(function (e) {
                  if (!this.isInterfaceEnabled()) return;

                  this.unselect($(e.target));
                  this.selection.find(".select2-search-choice-focus").removeClass("select2-search-choice-focus");
                  killEvent(e);
                  this.close();
                  this.focusSearch();
              })).on("focus", this.bind(function () {
                  if (!this.isInterfaceEnabled()) return;
                  this.container.addClass("select2-container-active");
                  this.dropdown.addClass("select2-drop-active");
              }));
            }

            choice.data("select2-data", data);
            choice.insertBefore(this.searchContainer);

            return id;
        },

        // multi
        unselect: function (selected) {
            var val = this.getVal(),
                data,
                index;
            selected = selected.closest(".select2-search-choice");

            if (selected.length === 0) {
                throw "Invalid argument: " + selected + ". Must be .select2-search-choice";
            }

            data = selected.data("select2-data");

            if (!data) {
                // prevent a race condition when the 'x' is clicked really fast repeatedly the event can be queued
                // and invoked on an element already removed
                return;
            }

            var evt = $.Event("select2-removing");
            evt.val = this.id(data);
            evt.choice = data;
            this.opts.element.trigger(evt);

            if (evt.isDefaultPrevented()) {
                return false;
            }

            while((index = indexOf(this.id(data), val)) >= 0) {
                val.splice(index, 1);
                this.setVal(val);
                if (this.select) this.postprocessResults();
            }

            selected.remove();

            this.opts.element.trigger({ type: "select2-removed", val: this.id(data), choice: data });
            this.triggerChange({ removed: data });

            return true;
        },

        // multi
        postprocessResults: function (data, initial, noHighlightUpdate) {
            var val = this.getVal(),
                choices = this.results.find(".select2-result"),
                compound = this.results.find(".select2-result-with-children"),
                self = this;

            choices.each2(function (i, choice) {
                var id = self.id(choice.data("select2-data"));
                if (indexOf(id, val) >= 0) {
                    choice.addClass("select2-selected");
                    // mark all children of the selected parent as selected
                    choice.find(".select2-result-selectable").addClass("select2-selected");
                }
            });

            compound.each2(function(i, choice) {
                // hide an optgroup if it doesn't have any selectable children
                if (!choice.is('.select2-result-selectable')
                    && choice.find(".select2-result-selectable:not(.select2-selected)").length === 0) {
                    choice.addClass("select2-selected");
                }
            });

            if (this.highlight() == -1 && noHighlightUpdate !== false && this.opts.closeOnSelect === true){
                self.highlight(0);
            }

            //If all results are chosen render formatNoMatches
            if(!this.opts.createSearchChoice && !choices.filter('.select2-result:not(.select2-selected)').length > 0){
                if(!data || data && !data.more && this.results.find(".select2-no-results").length === 0) {
                    if (checkFormatter(self.opts.formatNoMatches, "formatNoMatches")) {
                        this.results.append("<li class='select2-no-results'>" + evaluate(self.opts.formatNoMatches, self.opts.element, self.search.val()) + "</li>");
                    }
                }
            }

        },

        // multi
        getMaxSearchWidth: function() {
            return this.selection.width() - getSideBorderPadding(this.search);
        },

        // multi
        resizeSearch: function () {
            var minimumWidth, left, maxWidth, containerLeft, searchWidth,
                sideBorderPadding = getSideBorderPadding(this.search);

            minimumWidth = measureTextWidth(this.search) + 10;

            left = this.search.offset().left;

            maxWidth = this.selection.width();
            containerLeft = this.selection.offset().left;

            searchWidth = maxWidth - (left - containerLeft) - sideBorderPadding;

            if (searchWidth < minimumWidth) {
                searchWidth = maxWidth - sideBorderPadding;
            }

            if (searchWidth < 40) {
                searchWidth = maxWidth - sideBorderPadding;
            }

            if (searchWidth <= 0) {
              searchWidth = minimumWidth;
            }

            this.search.width(Math.floor(searchWidth));
        },

        // multi
        getVal: function () {
            var val;
            if (this.select) {
                val = this.select.val();
                return val === null ? [] : val;
            } else {
                val = this.opts.element.val();
                return splitVal(val, this.opts.separator, this.opts.transformVal);
            }
        },

        // multi
        setVal: function (val) {
            if (this.select) {
                this.select.val(val);
            } else {
                var unique = [], valMap = {};
                // filter out duplicates
                $(val).each(function () {
                    if (!(this in valMap)) {
                        unique.push(this);
                        valMap[this] = 0;
                    }
                });
                this.opts.element.val(unique.length === 0 ? "" : unique.join(this.opts.separator));
            }
        },

        // multi
        buildChangeDetails: function (old, current) {
            var current = current.slice(0),
                old = old.slice(0);

            // remove intersection from each array
            for (var i = 0; i < current.length; i++) {
                for (var j = 0; j < old.length; j++) {
                    if (equal(this.opts.id(current[i]), this.opts.id(old[j]))) {
                        current.splice(i, 1);
                        i--;
                        old.splice(j, 1);
                        break;
                    }
                }
            }

            return {added: current, removed: old};
        },


        // multi
        val: function (val, triggerChange) {
            var oldData, self=this;

            if (arguments.length === 0) {
                return this.getVal();
            }

            oldData=this.data();
            if (!oldData.length) oldData=[];

            // val is an id. !val is true for [undefined,null,'',0] - 0 is legal
            if (!val && val !== 0) {
                this.opts.element.val("");
                this.updateSelection([]);
                this.clearSearch();
                if (triggerChange) {
                    this.triggerChange({added: this.data(), removed: oldData});
                }
                return;
            }

            // val is a list of ids
            this.setVal(val);

            if (this.select) {
                this.opts.initSelection(this.select, this.bind(this.updateSelection));
                if (triggerChange) {
                    this.triggerChange(this.buildChangeDetails(oldData, this.data()));
                }
            } else {
                if (this.opts.initSelection === undefined) {
                    throw new Error("val() cannot be called if initSelection() is not defined");
                }

                this.opts.initSelection(this.opts.element, function(data){
                    var ids=$.map(data, self.id);
                    self.setVal(ids);
                    self.updateSelection(data);
                    self.clearSearch();
                    if (triggerChange) {
                        self.triggerChange(self.buildChangeDetails(oldData, self.data()));
                    }
                });
            }
            this.clearSearch();
        },

        // multi
        onSortStart: function() {
            if (this.select) {
                throw new Error("Sorting of elements is not supported when attached to <select>. Attach to <input type='hidden'/> instead.");
            }

            // collapse search field into 0 width so its container can be collapsed as well
            this.search.width(0);
            // hide the container
            this.searchContainer.hide();
        },

        // multi
        onSortEnd:function() {

            var val=[], self=this;

            // show search and move it to the end of the list
            this.searchContainer.show();
            // make sure the search container is the last item in the list
            this.searchContainer.appendTo(this.searchContainer.parent());
            // since we collapsed the width in dragStarted, we resize it here
            this.resizeSearch();

            // update selection
            this.selection.find(".select2-search-choice").each(function() {
                val.push(self.opts.id($(this).data("select2-data")));
            });
            this.setVal(val);
            this.triggerChange();
        },

        // multi
        data: function(values, triggerChange) {
            var self=this, ids, old;
            if (arguments.length === 0) {
                 return this.selection
                     .children(".select2-search-choice")
                     .map(function() { return $(this).data("select2-data"); })
                     .get();
            } else {
                old = this.data();
                if (!values) { values = []; }
                ids = $.map(values, function(e) { return self.opts.id(e); });
                this.setVal(ids);
                this.updateSelection(values);
                this.clearSearch();
                if (triggerChange) {
                    this.triggerChange(this.buildChangeDetails(old, this.data()));
                }
            }
        }
    });

    $.fn.select2 = function () {

        var args = Array.prototype.slice.call(arguments, 0),
            opts,
            select2,
            method, value, multiple,
            allowedMethods = ["val", "destroy", "opened", "open", "close", "focus", "isFocused", "container", "dropdown", "onSortStart", "onSortEnd", "enable", "disable", "readonly", "positionDropdown", "data", "search"],
            valueMethods = ["opened", "isFocused", "container", "dropdown"],
            propertyMethods = ["val", "data"],
            methodsMap = { search: "externalSearch" };

        this.each(function () {
            if (args.length === 0 || typeof(args[0]) === "object") {
                opts = args.length === 0 ? {} : $.extend({}, args[0]);
                opts.element = $(this);

                if (opts.element.get(0).tagName.toLowerCase() === "select") {
                    multiple = opts.element.prop("multiple");
                } else {
                    multiple = opts.multiple || false;
                    if ("tags" in opts) {opts.multiple = multiple = true;}
                }

                select2 = multiple ? new window.Select2["class"].multi() : new window.Select2["class"].single();
                select2.init(opts);
            } else if (typeof(args[0]) === "string") {

                if (indexOf(args[0], allowedMethods) < 0) {
                    throw "Unknown method: " + args[0];
                }

                value = undefined;
                select2 = $(this).data("select2");
                if (select2 === undefined) return;

                method=args[0];

                if (method === "container") {
                    value = select2.container;
                } else if (method === "dropdown") {
                    value = select2.dropdown;
                } else {
                    if (methodsMap[method]) method = methodsMap[method];

                    value = select2[method].apply(select2, args.slice(1));
                }
                if (indexOf(args[0], valueMethods) >= 0
                    || (indexOf(args[0], propertyMethods) >= 0 && args.length == 1)) {
                    return false; // abort the iteration, ready to return first matched value
                }
            } else {
                throw "Invalid arguments to select2 plugin: " + args;
            }
        });
        return (value === undefined) ? this : value;
    };

    // plugin defaults, accessible to users
    $.fn.select2.defaults = {
        debug: false,
        width: "copy",
        loadMorePadding: 0,
        closeOnSelect: true,
        openOnEnter: true,
        containerCss: {},
        dropdownCss: {},
        containerCssClass: "",
        dropdownCssClass: "",
        formatResult: function(result, container, query, escapeMarkup) {
            var markup=[];
            markMatch(this.text(result), query.term, markup, escapeMarkup);
            return markup.join("");
        },
        transformVal: function(val) {
            return $.trim(val);
        },
        formatSelection: function (data, container, escapeMarkup) {
            return data ? escapeMarkup(this.text(data)) : undefined;
        },
        sortResults: function (results, container, query) {
            return results;
        },
        formatResultCssClass: function(data) {return data.css;},
        formatSelectionCssClass: function(data, container) {return undefined;},
        minimumResultsForSearch: 0,
        minimumInputLength: 0,
        maximumInputLength: null,
        maximumSelectionSize: 0,
        id: function (e) { return e == undefined ? null : e.id; },
        text: function (e) {
          if (e && this.data && this.data.text) {
            if ($.isFunction(this.data.text)) {
              return this.data.text(e);
            } else {
              return e[this.data.text];
            }
          } else {
            return e.text;
          }
        },
        matcher: function(term, text) {
            return stripDiacritics(''+text).toUpperCase().indexOf(stripDiacritics(''+term).toUpperCase()) >= 0;
        },
        separator: ",",
        tokenSeparators: [],
        tokenizer: defaultTokenizer,
        escapeMarkup: defaultEscapeMarkup,
        blurOnChange: false,
        selectOnBlur: false,
        adaptContainerCssClass: function(c) { return c; },
        adaptDropdownCssClass: function(c) { return null; },
        nextSearchTerm: function(selectedObject, currentSearchTerm) { return undefined; },
        searchInputPlaceholder: '',
        createSearchChoicePosition: 'top',
        shouldFocusInput: function (instance) {
            // Attempt to detect touch devices
            var supportsTouchEvents = (('ontouchstart' in window) ||
                                       (navigator.msMaxTouchPoints > 0));

            // Only devices which support touch events should be special cased
            if (!supportsTouchEvents) {
                return true;
            }

            // Never focus the input if search is disabled
            if (instance.opts.minimumResultsForSearch < 0) {
                return false;
            }

            return true;
        }
    };

    $.fn.select2.locales = [];

    $.fn.select2.locales['en'] = {
         formatMatches: function (matches) { if (matches === 1) { return "One result is available, press enter to select it."; } return matches + " results are available, use up and down arrow keys to navigate."; },
         formatNoMatches: function () { return "No matches found"; },
         formatAjaxError: function (jqXHR, textStatus, errorThrown) { return "Loading failed"; },
         formatInputTooShort: function (input, min) { var n = min - input.length; return "Please enter " + n + " or more character" + (n == 1 ? "" : "s"); },
         formatInputTooLong: function (input, max) { var n = input.length - max; return "Please delete " + n + " character" + (n == 1 ? "" : "s"); },
        formatSelectionTooBig: function (limit) { return "You can select only  " + limit + " item" + (limit == 1 ? "" : "s"); },
         formatLoadMore: function (pageNumber) { return "Loading more results…"; },
         formatSearching: function () { return "Searching…"; }
    };

    $.extend($.fn.select2.defaults, $.fn.select2.locales['en']);

    $.fn.select2.ajaxDefaults = {
        transport: $.ajax,
        params: {
            type: "GET",
            cache: false,
            dataType: "json"
        }
    };

    // exports
    window.Select2 = {
        query: {
            ajax: ajax,
            local: local,
            tags: tags
        }, util: {
            debounce: debounce,
            markMatch: markMatch,
            escapeMarkup: defaultEscapeMarkup,
            stripDiacritics: stripDiacritics
        }, "class": {
            "abstract": AbstractSelect2,
            "single": SingleSelect2,
            "multi": MultiSelect2
        }
    };

}(jQuery));