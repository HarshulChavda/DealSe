$(document).ready(function () {

    if (document.URL.toLowerCase().indexOf("admin/index") != -1 || document.URL.toLowerCase().indexOf("home") != -1 || document.URL.toLowerCase().match("admin$")) {
        $("#lidashboard").addClass("active");
    }
    else if (document.URL.toLowerCase().indexOf("homescreenbanner") != -1) {
        $("#lihomescreenbanner").addClass("active");
    }
    else if (document.URL.toLowerCase().indexOf("domain") != -1) {
        $("#lidomain").addClass("active");
    }
    else if (document.URL.toLowerCase().indexOf("colorcode") != -1) {
        $("#licolorcode").addClass("active");
    }
    else if (document.URL.toLowerCase().indexOf("company") != -1) {
        $("#licompany").addClass("active");
    }
    else if (document.URL.toLowerCase().indexOf("productcategory") != -1 || document.URL.toLowerCase().indexOf("productsubcategory") != -1 || document.URL.toLowerCase().indexOf("product") != -1) {
        $("#liproducts").addClass("active");
        $("#liproducts > ul").addClass("active visible");
        if (document.URL.toLowerCase().indexOf("productcategory") != -1)
            $("#liproductcategory").addClass("active");
        else if (document.URL.toLowerCase().indexOf("productsubcategory") != -1)
            $("#liproductsubcategory").addClass("active");
        else if (document.URL.toLowerCase().indexOf("product") != -1)
            $("#liproduct").addClass("active");

    }
    else if (document.URL.toLowerCase().indexOf("user") != -1) {
        $("#liuser").addClass("active");
    }
    else if (document.URL.toLowerCase().indexOf("reportproblem") != -1 || document.URL.toLowerCase().indexOf("reportbug") != -1) {
        $("#lireportproblemandbug").addClass("active");
        $("#lireportproblemandbug > ul").addClass("active visible");
        if (document.URL.toLowerCase().indexOf("reportproblem") != -1)
            $("#lireportproblem").addClass("active");
        else if (document.URL.toLowerCase().indexOf("reportbug") != -1)
            $("#lireportbug").addClass("active");
    }
    else if (document.URL.toLowerCase().indexOf("country") != -1 || document.URL.toLowerCase().indexOf("emailtemplate") != -1 || document.URL.toLowerCase().indexOf("sitesetting") != -1) {
        $("#liothers").addClass("active");
        $("#liothers > ul").addClass("active visible");
        if (document.URL.toLowerCase().indexOf("country") != -1)
            $("#licountry").addClass("active");
        else if (document.URL.toLowerCase().indexOf("emailtemplate") != -1)
            $("#liemailtemplate").addClass("active");
        else if (document.URL.toLowerCase().indexOf("sitesetting") != -1)
            $("#lisitesetting").addClass("active");
    }

    trimmed();

    $('.htmlvalid').on('blur', function (e) {
        var s = $(this).val().replace(/\</g, '');
        s = s.replace(/\>/g, '');
        $(this).val(s);
    });
    $(".numeric").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && ((e.which < 48 && e.which != 43) || e.which > 57)) {
            return false;
        }
    });
    $(".decimal").keypress(function (e) {
        var self = $(this);
        self.val(self.val().replace(/[^0-9\.]/g, ''));
        if ((e.which != 46 || self.val().indexOf('.') != -1) && (e.which < 48 || e.which > 57)) {
            e.preventDefault();
        }
    });
    $(".txtOnly").keydown(function (e) {
        if (e.altKey) {
            e.preventDefault();
        } else {
            var key = e.keyCode;
            if (!((key == 8) || (key == 32) || (key == 46) || (key >= 35 && key <= 40) || (key >= 65 && key <= 90))) {
                e.preventDefault();
            }
        }
    });
});


function trimmed() {

    function debounce(func, wait, immediate) {
        var timeout;
        return function () {
            var context = this, args = arguments;
            var later = function () {
                timeout = null;
                if (!immediate) func.apply(context, args);
            };
            var callNow = immediate && !timeout;
            clearTimeout(timeout);
            timeout = setTimeout(later, wait);
            if (callNow) func.apply(context, args);
        };
    };

    $('.trimmed').keyup(debounce(function () {
        // the following function will be executed every half second
        if ($(this).val() != null) {
            $(this).val($(this).val().toString().trim());
        }
        var s = $(this).val().replace(/\</g, '');
        s = s.replace(/\>/g, '');
        $(this).val(s);
    }, 1000));

    $('.trimmed').on("change", function (e) {
        if ($(this).val() != null) {
            $(this).val($(this).val().toString().trim());
        }
        var s = $(this).val().replace(/\</g, '');
        s = s.replace(/\>/g, '');
        $(this).val(s);
    });

    $('.trimmedallowtags').keyup(debounce(function () {
        // the following function will be executed every half second
        if ($(this).val() != null) {
            $(this).val($(this).val().toString().trim());
        }
    }, 1000));

    $('.trimmedallowtags').on("change", function (e) {
        if ($(this).val() != null) {
            $(this).val($(this).val().toString().trim());
        }
    });
}

function daterangepickerfunction(id) {
    $(id).trigger('click');
}

$('.sidebar-collapse-icon').click(function () {

    $("#sidebar-collapse").removeAttr("style");

});

function getParams(url) {
    var params = {};
    var parser = document.createElement('a');
    parser.href = url;
    var query = parser.search.substring(1);
    var vars = query.split('&');
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split('=');
        params[pair[0]] = decodeURIComponent(pair[1]);
    }
    return params;
}

function extractNumber(obj, decimalPlaces, allowNegative) {
    var temp = obj.value;

    // avoid changing things if already formatted correctly
    var reg0Str = '[0-9]*';
    if (decimalPlaces > 0) {
        reg0Str += '\\.?[0-9]{0,' + decimalPlaces + '}';
    } else if (decimalPlaces < 0) {
        reg0Str += '\\.?[0-9]*';
    }
    reg0Str = allowNegative ? '^-?' + reg0Str : '^' + reg0Str;
    reg0Str = reg0Str + '$';
    var reg0 = new RegExp(reg0Str);
    if (reg0.test(temp)) return true;

    // first replace all non numbers
    var reg1Str = '[^0-9' + (decimalPlaces != 0 ? '.' : '') + (allowNegative ? '-' : '') + ']';
    var reg1 = new RegExp(reg1Str, 'g');
    temp = temp.replace(reg1, '');

    if (allowNegative) {
        // replace extra negative
        var hasNegative = temp.length > 0 && temp.charAt(0) == '-';
        var reg2 = /-/g;
        temp = temp.replace(reg2, '');
        if (hasNegative) temp = '-' + temp;
    }

    if (decimalPlaces != 0) {
        var reg3 = /\./g;
        var reg3Array = reg3.exec(temp);
        if (reg3Array != null) {
            // keep only first occurrence of .
            //  and the number of places specified by decimalPlaces or the entire string if decimalPlaces < 0
            var reg3Right = temp.substring(reg3Array.index + reg3Array[0].length);
            reg3Right = reg3Right.replace(reg3, '');
            reg3Right = decimalPlaces > 0 ? reg3Right.substring(0, decimalPlaces) : reg3Right;
            temp = temp.substring(0, reg3Array.index) + '.' + reg3Right;
        }
    }

    obj.value = temp;
}
function blockNonNumbers(obj, e, allowDecimal, allowNegative) {
    var key;
    var isCtrl = false;
    var keychar;
    var reg;

    if (window.event) {
        key = e.keyCode;
        isCtrl = window.event.ctrlKey
    }
    else if (e.which) {
        key = e.which;
        isCtrl = e.ctrlKey;
    }

    if (isNaN(key)) return true;

    keychar = String.fromCharCode(key);

    // check for backspace or delete, or if Ctrl was pressed
    if (key == 8 || isCtrl) {
        return true;
    }

    reg = /\d/;
    var isFirstN = allowNegative ? keychar == '-' && obj.value.indexOf('-') == -1 : false;
    var isFirstD = allowDecimal ? keychar == '.' && obj.value.indexOf('.') == -1 : false;

    return isFirstN || isFirstD || reg.test(keychar);
}

$(document).ready(function () {
    //if ($('.match-height').length > 0) {
    //    $('.match-height').matchHeight();
    //}
    matchHeightForDashboardBlock('.dashboard-blocks', '.tile-stats');
});

/* equalheight function */
function matchHeightForDashboardBlock(parentClassName, className) {
    if ($(parentClassName).length > 0) {
        $(parentClassName + ' ' + className).matchHeight({
            byRow: true,
            property: 'height',
            target: null,
            remove: false
        });
    }
}

function dashboardnotification() {
    $.ajax({
        url: '/Admin/Home/getNotifications',
        type: "Get",
        data: {},
        success: function (result) {
            $('#notifications-dropdown-id').html(result);
            $('#notification ul li:first-child').removeClass('notifications dropdown open');
            $('#notification ul li:first-child').addClass('notifications dropdown');

            try {
                if ($.isFunction($.fn.niceScroll)) {
                    var nicescroll_defaults = {
                        cursorcolor: '#d4d4d4',
                        cursorborder: '1px solid #ccc',
                        railpadding: { right: 3 },
                        cursorborderradius: 1,
                        autohidemode: true,
                        sensitiverail: true
                    };

                    public_vars.$body.find('.dropdown .scroller').niceScroll(nicescroll_defaults);

                    $(".dropdown").on("shown.bs.dropdown", function () {
                        $(".scroller").getNiceScroll().resize();
                        $(".scroller").getNiceScroll().show();
                    });

                    var fixed_sidebar = $(".sidebar-menu.fixed");

                    if (fixed_sidebar.length == 1) {
                        var fs_tm = 0;

                        fixed_sidebar.niceScroll({
                            cursorcolor: '#454a54',
                            cursorborder: '1px solid #454a54',
                            railpadding: { right: 3 },
                            railalign: 'right',
                            cursorborderradius: 1
                        });

                        fixed_sidebar.on('click', 'li a', function () {
                            fixed_sidebar.getNiceScroll().resize();
                            fixed_sidebar.getNiceScroll().show();

                            window.clearTimeout(fs_tm);

                            fs_tm = setTimeout(function () {
                                fixed_sidebar.getNiceScroll().resize();
                            }, 500);
                        });
                    }
                }
            } catch (e) {
            }
        },
        error: function () {
            console.log("Error");
        }
    });
}
function markallreadnotification() {
    $.confirm({
        title: 'Confirm!',
        content: 'Are you sure you want to mark all order(s) as read?',
        buttons: {
            confirm: function () {
                $.ajax({
                    url: '/Admin/Home/updateAllNotifications',
                    type: "Post",
                    data: {},
                    success: function () {
                        dashboardnotification();
                    },
                    error: function () {
                        console.log("Error");
                    }
                });
            },
            cancel: function () {
                //return false;
            }
        }
    });
}
function addresponsiveTableDiv(tableID) {
    $(tableID).wrap(function () {
        return "<div class='table-responsive datatable-scroll-margin'></div>";
    });
}

function responsiveTableColumn(tableId) {
    var tbodytrCount = $('' + tableId + ' tbody tr').length;
    var trId = 0;
    var maxHeight = [];
    for (trId; trId < tbodytrCount; trId++) {
        $('' + tableId + '  tbody tr').each(function () {
            $(this).find('td').each(function (idx) {
                if (($(this).height() > maxHeight[idx] || maxHeight[idx] == undefined)) {
                    maxHeight[idx] = $(this).height();
                }
            })
        });
        $('' + tableId + '  tbody tr').eq(trId).find('td').each(function (idy) {
            var existingHeight = $(this).height();
            if (maxHeight[idy] >= existingHeight) {
                $('' + tableId + ' thead th').eq(idy).height(maxHeight[idy]);
                $('' + tableId + ' tbody tr td:nth-of-type(' + (idy + 1) + ')').height(maxHeight[idy]);
            }
            else {
                $('' + tableId + ' thead th').eq(idy).height(existingHeight);
                $('' + tableId + ' tbody tr td:nth-of-type(' + (idy + 1) + ')').height(existingHeight);
            }
        });
    }
}

/*! ============================================================
 * bootstrapSwitch v1.8 by Larentis Mattia @SpiritualGuru
 * http://www.larentis.eu/
 * 
 * Enhanced for radiobuttons by Stein, Peter @BdMdesigN
 * http://www.bdmdesign.org/
 *
 * Project site:
 * http://www.larentis.eu/switch/
 * ============================================================
 * Licensed under the Apache License, Version 2.0
 * http://www.apache.org/licenses/LICENSE-2.0
 * ============================================================ */
!function ($) { "use strict"; $.fn['bootstrapSwitch'] = function (method) { var inputSelector = 'input[type!="hidden"]'; var methods = { init: function () { return this.each(function () { var $element = $(this), $div, $switchLeft, $switchRight, $label, $form = $element.closest('form'), myClasses = "", classes = $element.attr('class'), color, moving, onLabel = "ON", offLabel = "OFF", icon = false, textLabel = false; $.each(['switch-mini', 'switch-small', 'switch-large'], function (i, el) { if (classes.indexOf(el) >= 0) myClasses = el }); $element.addClass('has-switch'); if ($element.data('on') !== undefined) color = "switch-" + $element.data('on'); if ($element.data('on-label') !== undefined) onLabel = $element.data('on-label'); if ($element.data('off-label') !== undefined) offLabel = $element.data('off-label'); if ($element.data('label-icon') !== undefined) icon = $element.data('label-icon'); if ($element.data('text-label') !== undefined) textLabel = $element.data('text-label'); $switchLeft = $('<span>').addClass("switch-left").addClass(myClasses).addClass(color).html(onLabel); color = ''; if ($element.data('off') !== undefined) color = "switch-" + $element.data('off'); $switchRight = $('<span>').addClass("switch-right").addClass(myClasses).addClass(color).html(offLabel); $label = $('<label>').html("&nbsp;").addClass(myClasses).attr('for', $element.find(inputSelector).attr('id')); if (icon) { $label.html('<i class="icon ' + icon + '"></i>') } if (textLabel) { $label.html('' + textLabel + '') } $div = $element.find(inputSelector).wrap($('<div>')).parent().data('animated', false); if ($element.data('animated') !== false) $div.addClass('switch-animate').data('animated', true); $div.append($switchLeft).append($label).append($switchRight); $element.find('>div').addClass($element.find(inputSelector).is(':checked') ? 'switch-on' : 'switch-off'); if ($element.find(inputSelector).is(':disabled')) $(this).addClass('deactivate'); var changeStatus = function ($this) { if ($element.parent('label').is('.label-change-switch')) { } else { $this.siblings('label').trigger('mousedown').trigger('mouseup').trigger('click') } }; $element.on('keydown', function (e) { if (e.keyCode === 32) { e.stopImmediatePropagation(); e.preventDefault(); changeStatus($(e.target).find('span:first')) } }); $switchLeft.on('click', function (e) { changeStatus($(this)) }); $switchRight.on('click', function (e) { changeStatus($(this)) }); $element.find(inputSelector).on('change', function (e, skipOnChange) { var $this = $(this), $element = $this.parent(), thisState = $this.is(':checked'), state = $element.is('.switch-off'); e.preventDefault(); $element.css('left', ''); if (state === thisState) { if (thisState) $element.removeClass('switch-off').addClass('switch-on'); else $element.removeClass('switch-on').addClass('switch-off'); if ($element.data('animated') !== false) $element.addClass("switch-animate"); if (typeof skipOnChange === 'boolean' && skipOnChange) return; $element.parent().trigger('switch-change', { 'el': $this, 'value': thisState }) } }); $element.find('label').on('mousedown touchstart', function (e) { var $this = $(this); moving = false; e.preventDefault(); e.stopImmediatePropagation(); $this.closest('div').removeClass('switch-animate'); if ($this.closest('.has-switch').is('.deactivate')) { $this.unbind('click') } else if ($this.closest('.switch-on').parent().is('.radio-no-uncheck')) { $this.unbind('click') } else { $this.on('mousemove touchmove', function (e) { var $element = $(this).closest('.make-switch'), relativeX = (e.pageX || e.originalEvent.targetTouches[0].pageX) - $element.offset().left, percent = (relativeX / $element.width()) * 100, left = 25, right = 75; moving = true; if (percent < left) percent = left; else if (percent > right) percent = right; $element.find('>div').css('left', (percent - right) + "%") }); $this.on('click touchend', function (e) { var $this = $(this), $target = $(e.target), $myRadioCheckBox = $target.siblings('input'); e.stopImmediatePropagation(); e.preventDefault(); $this.unbind('mouseleave'); if (moving) $myRadioCheckBox.prop('checked', !(parseInt($this.parent().css('left')) < -25)); else $myRadioCheckBox.prop("checked", !$myRadioCheckBox.is(":checked")); moving = false; $myRadioCheckBox.trigger('change') }); $this.on('mouseleave', function (e) { var $this = $(this), $myInputBox = $this.siblings('input'); e.preventDefault(); e.stopImmediatePropagation(); $this.unbind('mouseleave'); $this.trigger('mouseup'); $myInputBox.prop('checked', !(parseInt($this.parent().css('left')) < -25)).trigger('change') }); $this.on('mouseup', function (e) { e.stopImmediatePropagation(); e.preventDefault(); $(this).unbind('mousemove') }) } }); if ($form.data('bootstrapSwitch') !== 'injected') { $form.bind('reset', function () { setTimeout(function () { $form.find('.make-switch').each(function () { var $input = $(this).find(inputSelector); $input.prop('checked', $input.is(':checked')).trigger('change') }) }, 1) }); $form.data('bootstrapSwitch', 'injected') } }) }, toggleActivation: function () { var $this = $(this); $this.toggleClass('deactivate'); $this.find(inputSelector).prop('disabled', $this.is('.deactivate')) }, isActive: function () { return !$(this).hasClass('deactivate') }, setActive: function (active) { var $this = $(this); if (active) { $this.removeClass('deactivate'); $this.find(inputSelector).removeAttr('disabled') } else { $this.addClass('deactivate'); $this.find(inputSelector).attr('disabled', 'disabled') } }, toggleState: function (skipOnChange) { var $input = $(this).find(':checkbox'); $input.prop('checked', !$input.is(':checked')).trigger('change', skipOnChange) }, toggleRadioState: function (skipOnChange) { var $radioinput = $(this).find(':radio'); $radioinput.not(':checked').prop('checked', !$radioinput.is(':checked')).trigger('change', skipOnChange) }, toggleRadioStateAllowUncheck: function (uncheck, skipOnChange) { var $radioinput = $(this).find(':radio'); if (uncheck) { $radioinput.not(':checked').trigger('change', skipOnChange) } else { $radioinput.not(':checked').prop('checked', !$radioinput.is(':checked')).trigger('change', skipOnChange) } }, setState: function (value, skipOnChange) { $(this).find(inputSelector).prop('checked', value).trigger('change', skipOnChange) }, setOnLabel: function (value) { var $switchLeft = $(this).find(".switch-left"); $switchLeft.html(value) }, setOffLabel: function (value) { var $switchRight = $(this).find(".switch-right"); $switchRight.html(value) }, setOnClass: function (value) { var $switchLeft = $(this).find(".switch-left"); var color = ''; if (value !== undefined) { if ($(this).attr('data-on') !== undefined) { color = "switch-" + $(this).attr('data-on') } $switchLeft.removeClass(color); color = "switch-" + value; $switchLeft.addClass(color) } }, setOffClass: function (value) { var $switchRight = $(this).find(".switch-right"); var color = ''; if (value !== undefined) { if ($(this).attr('data-off') !== undefined) { color = "switch-" + $(this).attr('data-off') } $switchRight.removeClass(color); color = "switch-" + value; $switchRight.addClass(color) } }, setAnimated: function (value) { var $element = $(this).find(inputSelector).parent(); if (value === undefined) value = false; $element.data('animated', value); $element.attr('data-animated', value); if ($element.data('animated') !== false) { $element.addClass("switch-animate") } else { $element.removeClass("switch-animate") } }, setSizeClass: function (value) { var $element = $(this); var $switchLeft = $element.find(".switch-left"); var $switchRight = $element.find(".switch-right"); var $label = $element.find("label"); $.each(['switch-mini', 'switch-small', 'switch-large'], function (i, el) { if (el !== value) { $switchLeft.removeClass(el); $switchRight.removeClass(el); $label.removeClass(el) } else { $switchLeft.addClass(el); $switchRight.addClass(el); $label.addClass(el) } }) }, status: function () { return $(this).find(inputSelector).is(':checked') }, destroy: function () { var $element = $(this), $div = $element.find('div'), $form = $element.closest('form'), $inputbox; $div.find(':not(input)').remove(); $inputbox = $div.children(); $inputbox.unwrap().unwrap(); $inputbox.unbind('change'); if ($form) { $form.unbind('reset'); $form.removeData('bootstrapSwitch') } return $inputbox } }; if (methods[method]) return methods[method].apply(this, Array.prototype.slice.call(arguments, 1)); else if (typeof method === 'object' || !method) return methods.init.apply(this, arguments); else $.error('Method ' + method + ' does not exist!') } }(jQuery); (function ($) { $(function () { $('.make-switch')['bootstrapSwitch']() }) })(jQuery);