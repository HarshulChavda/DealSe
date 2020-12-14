$(document).ready(function () {
    if (document.URL.toLowerCase().indexOf("admin/index") != -1 || document.URL.toLowerCase().indexOf("home") != -1 || document.URL.toLowerCase().match("vendor$")) 
        $("#lidashboard").addClass("active");
    else if (document.URL.toLowerCase().indexOf("vendoritem") != -1) 
        $("#livendoritem").addClass("active");
    else if (document.URL.toLowerCase().indexOf("vendorproduct") != -1) 
        $("#livendorproduct").addClass("active");
    else if (document.URL.toLowerCase().indexOf("vendorreview") != -1 || document.URL.toLowerCase().indexOf("viewvendorreview") != -1)
        $("#livendorreview").addClass("active"); 
    else if (document.URL.toLowerCase().indexOf("order") != -1)
        $("#liorder").addClass("active");
   
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

$(window).resize(function() {
    equalheight('.tile-stats');
});


jQuery(window).load(function() {
        
    setTimeout( function( ){
        equalheight('.tile-stats');
    }, 300 );
        
});

/* equalheight function */
equalheight = function( container ) {

    var currentTallest = 0,
        currentRowStart = 0,
        rowDivs = new Array(),
        $el,
        topPosition = 0;
    $( container ).each ( function( ) {

        $el = $(this);
        $($el).height('auto')
        topPostion = $el.offset().top;

        if (currentRowStart != topPostion) {
            for (currentDiv = 0 ; currentDiv < rowDivs.length ; currentDiv++) {
                rowDivs[currentDiv].height(currentTallest);
            }
            rowDivs.length = 0; // empty the array
            currentRowStart = topPostion;
            currentTallest = $el.height();
            rowDivs.push($el);
        } else {
            rowDivs.push($el);
            currentTallest = (currentTallest < $el.height()) ? ($el.height()) : (currentTallest);
        }
        for (currentDiv = 0 ; currentDiv < rowDivs.length ; currentDiv++) {
            rowDivs[currentDiv].height(currentTallest);
        }
    });
}

function dashboardnotification() {

    $.ajax({
        url: '/Vendor/Home/getNotifications',
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
                    url: '/Vendor/Home/updateAllNotifications',
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
