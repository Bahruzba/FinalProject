
﻿$(document).ready(function () {

     //Owl Carousel
    if ($("#Find-awesome-deals").length != 0)
    {
    $("#Find-awesome-deals .col-md-4 .owl-carousel").owlCarousel({
    autoPlay: true,
    slideSpeed: 300,
    nav: true,
    navText: ["<img src='../Public/img/left.png'>", "<img src='../Public/img/right.png'>"],
    loop: true,
    items: 1
    });

    $("#Find-awesome-deals .mini-slider .owl-carousel").owlCarousel({
        autoPlay: true,
        loop: true,
        nav: true,
        navText: ["<img src='../Public/img/left.png' width='40px' height='40px'>", "<img src = '../Public/img/right.png' width='40px' height = '40px'>"],
        items: 8,
        dods: false
    });

    $("#popular-brands .owl-carousel").owlCarousel({
        items: 4
    });
    }

    if ($("#offer").length != 0) {
    $("#offer .owl-carousel").owlCarousel({
        autoPlay: true,
        loop: true,
        items: 4,
        nav: true,
        navText: ["<img src='../Public/img/left.png'>", "<img src='../Public/img/right.png'>"]
    })
    }

    if ($("#body-tab-menu").length != 0) {
        $(".body-order-online .owl-carousel").owlCarousel({
            autoPlay: true,
            loop: true,
            items: 4,
            nav: true,
            navText: ["<img src='/Public/img/left.png' width='40px' height='40px'>", "<img src = '/Public/img/right.png' width='40px' height = '40px'>"],
        });


        $(".body-gallery .owl-carousel").owlCarousel({
            autoPlay: true,
            loop: true,
            items: 4,
            nav: true,
            navText: ["<img src='/Public/img/left.png' width='40px' height='40px'>", "<img src = '/Public/img/right.png' width='40px' height = '40px'>"],
        });
    }


$(".form form input").on("input", function(){
    var x=Math.round($(this).position().top);
    if($(this).val()==""){
        $(this).prev().animate({top:x+2+"px",fontSize:"12px", opacity:"1"},150);
        return;
    }
    $(this).prev().animate({top:x-12+"px",fontSize:"10px", opacity:"0.7"},150);
});

$(".form form p").click(function(){
    $(this).next().focus();
});

$(".form form input").focus(function(){
    $(".form form input").css("box-shadow", "none");
});

$(document).on("click", "#offers .item .header-tab-menu", function(){
    var heightItem=$(this).next().height()+81;
    if($(this).parent().height()>70){
        $(this).parent().animate({height: "65px"});
        return;
    }
    $("#offers .filters .item").animate({height: "65px"});
    $(this).parents(".item").animate({height: heightItem});
})

$("#offers .more-item").click(function () {
    if (!$("#offers .more-item").hasClass("item-not-found")) {
        $(this).addClass("disabled pl-5").text("Yüklənir");
    }
})

// Sort item in Offers page
$(document).on("click", "#offers .dropdown li", function () {
$("#offers #dropdownMenuButton").text($(this).text()).attr("value", $(this).attr("value"));
$("#offers .mini-slider").next().empty();
if (!$("#offers .more-item").hasClass("item-not-found")) {
    $("#offers .more-item").addClass("disabled pl-5").text("Yüklənir");
}

var restorans = "";
$("#offers [filter=meal] .select").parent().each(function () { restorans += "," + ($(this).attr("id")); });
restorans = restorans.substr(1);
var categories = "";
$("#offers [filter=categoryMeal] .select").parent().each(function () { categories += "," + ($(this).attr("id")); });
categories = categories.substr(1);
var places = "";
$("#offers [filter=place] .select").parent().each(function () { places += "," + ($(this).attr("id")); });
places = places.substr(1);
var kitchens = "";
$("#offers [filter=kitchen] .select").parent().each(function () { kitchens += "," + ($(this).attr("id")); });
kitchens = kitchens.substr(1);

var sort = $(this).attr("value");

$.ajax({
    url: "/Listing/GetFilter",
    type: "POST",
    dataType: "html",
    data: {
        restorans: restorans, categories: categories, places: places, kitchens: kitchens, sort: sort
    },
    success: (function (response) {
        $("#offers .mini-slider").next().html(response);
        $("#offers .more-item").removeClass("disabled pl-5 itepom-not-found").text("Daha çox yüklə...");
        var count1 = $("#offers .mini-slider").next().children(".item-cover").length;
        if (count1 < 9) {
            $("#offers .more-item").addClass("item-not-found").text("Məhsul siyahısı bitti :)");
        }

    }), error: (function (error) {
        console.log(error);
    })
})
})

//Filter Item in offers page
$(document).on("click", "#offers .item .body-tab-menu i", function(){
    $(this).toggleClass("select");
    $("#offers .mini-slider").next().empty();
    if (!$("#offers .more-item").hasClass("item-not-found")) {
        $("#offers .more-item").addClass("disabled pl-5").text("Yüklənir");
    }

    $("#offers #dropdownMenuButton").text("Sırala").attr("value", "");

    var restorans = "";
    $("#offers [filter=meal] .select").parent().each(function () { restorans +="," + ($(this).attr("id")); });
    var categories = "";
    $("#offers [filter=categoryMeal] .select").parent().each(function () { categories += "," +($(this).attr("id")); });
    var places = "";
    $("#offers [filter=place] .select").parent().each(function () { places += "," +($(this).attr("id")); });
    var kitchens = "";
    $("#offers [filter=kitchen] .select").parent().each(function () { kitchens += "," + ($(this).attr("id")); });
    var count = $("#offers .mini-slider").next().children(".item-cover").length;

    restorans = restorans.substr(1);
    categories = categories.substr(1);
    places = places.substr(1);
    kitchens = kitchens.substr(1);
    $.ajax({
        url: "/Listing/GetFilter",
        type: "POST",
        dataType: "html",
        data: {
            restorans: restorans, categories: categories, places: places, kitchens: kitchens
        },
        success: (function (response) {
            $("#offers .mini-slider").next().html(response);
            $("#offers .more-item").removeClass("disabled pl-5 item-not-found").text("Daha çox yüklə...");
            var count1 = $("#offers .mini-slider").next().children(".item-cover").length;
            if (count1 - count < 9 || count1<9) {
                $("#offers .more-item").addClass("item-not-found").text("Məhsul siyahısı bitti :)");
            }

        }), error: (function (error) {
            console.log(error);
        })
    })
})

//For more item im offers page
$(document).on("click", "#offers .more-item", function () {
    var restorans = "";
    $("#offers [filter=meal] .select").parent().each(function () { restorans += "," + ($(this).attr("id")); });
    var categories = "";
    $("#offers [filter=categoryMeal] .select").parent().each(function () { categories += "," + ($(this).attr("id")); });
    var places = "";
    $("#offers [filter=place] .select").parent().each(function () { places += "," + ($(this).attr("id")); });
    var kitchens = "";
    $("#offers [filter=kitchen] .select").parent().each(function () { kitchens += "," + ($(this).attr("id")); });
    var count = $("#offers .mini-slider").next().children(".item-cover").length;
    var sort = $("#offers .dropdown button").attr("value");

    restorans = restorans.substr(1);
    categories = categories.substr(1);
    places = places.substr(1);
    kitchens = kitchens.substr(1);
    $.ajax({
        url: "/listing/getfilter",
        type: "POST",
        dataType: "html",
        data: {
            restorans: restorans, categories: categories, places: places, kitchens: kitchens, count: count, sort: sort
        },
        success: (function (response) {
            $("#offers .mini-slider").next().append(response);
            $("#offers .more-item").removeClass("disabled pl-5 item-not-found").text("Daha çox yüklə...");
            var count1 = $("#offers .mini-slider").next().children(".item-cover").length;
            if (count1 - count < 9 || count1 < 9) {
                $("#offers .more-item").addClass("item-not-found").text("Məhsul siyahısı bitti :)");
            }
        }), error: (function (error) {
            console.log(error);
        })
    })
})

//show count item
$(document).on("click", ".add", function(){
    $(this).addClass("d-none").next().removeClass("d-none");
});

//plus count item 
$(document).on("click", ".count-item .plus", function(){
    var count = Number($(this).prev().text());
    var max = Number($(this).prev().attr("max"));
    $(this).prev().text(count+1);
    if(count>max-2||count>18)
    {
        $(this).attr("disabled","");
    }
})

//minus count item 
$(document).on("click", ".count-item .minus", function(){
    var count = Number($(this).next().text());
    
    if(count>1){
        $(this).next().text(count-1).next().removeAttr("disabled");
    } else{
        $(this).parent().addClass("d-none");
        $(this).parent().prev().removeClass("d-none");
    }
})

//choose addres delivery
$(".choose-address button").click(function(){
    $(".choose-address .item").removeClass("selected");
    $(this).parents(".item").addClass("selected");
})

//choose address name for new address delivery
$("#add-address .item button").click(function(){
    $("#add-address .item button").removeClass('selected');
    $(this).addClass("selected");

}) 

//toggle New address modal
function CloseAddAddress(){
    $("#add-address").animate({
        opacity:0,zIndex:-1
    })
}
$("#add-address .cancel").click(function(){
    CloseAddAddress();
})

$("#add-address .fa-times").click(function(){
    CloseAddAddress();
})

//open add address modal
$(".choose-address .new-address").click(function(){
    $("#add-address").css("z-index","1").animate({
        opacity: 1
    })
})

//open edit address modal
$("#account [tab-body=addresses] .edit").click(function(){
    $("#add-address").css("z-index","1").animate({
        opacity: 1
    })
})

//open edit profile modal
$("#account .my-info small").click(function(){
    $("#edit-profile").css("z-index","1").animate({
        opacity: 1
    })
})

//Close edit profile model
function CloseEditProfile(){
    $("#edit-profile").animate({
        opacity:0,zIndex:-1
    })
}

$("#edit-profile .cancel").click(function(){
    CloseEditProfile();
})

$("#edit-profile .fa-times").click(function(){
    CloseEditProfile();
})

//rating grafic
function Start(){
    var blue ="<div class='blue'></div>";
    $(".body-ratings-reviews .star").append(blue);
    for(var i=1;i<6; i++)
    {
        var a =Number($(".body-ratings-reviews .stars .s"+i+" small").text());
        $(".body-ratings-reviews .stars .s"+i+" .blue").css("width",a+"%").prev().text(a+"%");

    }
}
Start();

//tab menu in restaurant detail
$(document).on("click", "#header-tab-menu [tab-header]", function(){
    $("#header-tab-menu [tab-header]").removeClass("active");
    $(this).addClass("active");
    var tab= $(this).attr("tab-header");
    $("#body-tab-menu [tab-body]").removeClass("active");
    setTimeout(function(){
        $("#body-tab-menu [tab-body]").addClass("d-none");
        $("#body-tab-menu [tab-body="+tab+"]").addClass("active").removeClass("d-none");
    },300);
})

//save cards
$(".choose-payment .fa-check").click(function(){
    $(this).toggleClass("saved");
})

//tab menu in checkout page
$(".choose-payment .header-tab li").click(function(){
    $(".choose-payment .header-tab li").css("background-color","white");
    $(this).css("background-color","#f3f7f8");
    var tab=$(this).attr("tab-header");
    $(".choose-payment .body-tab [body-tab]").addClass("d-none");
    $(".choose-payment .body-tab [body-tab="+tab+"]").removeClass("d-none");
})

// tab menu in account page
$("#account .account .tab-header li").click(function(){
    $("#account .account .tab-header li").css("background-color","white");
    $(this).css("background-color","#f3f7f8");
    var tab=$(this).attr("tab-header");
    $("#account [tab-body]").animate({opacity:"0"}).animate({opacity:1});
    setTimeout(function(){ 
        $("#account [tab-body]").addClass("d-none");
        $("#account [tab-body="+tab+"]").removeClass("d-none");
    }, 400);

})
});