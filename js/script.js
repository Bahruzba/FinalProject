$('.owl-carousel').slick({
    infinite: true,
    slidesToShow: 5,
    slidesToScroll: 1,
    prevArrow: false,
    nextArrow: false,
    autoplay: true,
    autoplaySpeed: 2000,
    infinite: true,
    responsive: [
        {
            breakpoint: 900,
            settings: {
                slidesToShow: 2,
            }
        },
        {
            breakpoint: 480,
            settings: {
                slidesToShow: 3,
            }
        }
    ]
});

$('.slider').slick({
    infinite: true,
    slidesToShow: 1,
    slidesToScroll: 1,
    prevArrow: false,
    nextArrow: false,
    autoplay: true,
    autoplaySpeed: 2000,
    infinite: true,
    responsive: [
        {
            breakpoint: 900,
            settings: {
                slidesToShow: 3,
            }
        },
        {
            breakpoint: 480,
            settings: {
                slidesToShow: 5,
            }
        }
    ]
});

$('#popular-brands .owl-carouse').slick({
    infinite: true,
    slidesToShow: 4,
    slidesToScroll: 1,
    prevArrow: false,
    nextArrow: false,
    autoplay: true,
    autoplaySpeed: 2000,
    infinite: true,
    responsive: [
        {
            breakpoint: 900,
            settings: {
                slidesToShow: 5,
            }
        },
        {
            breakpoint: 480,
            settings: {
                slidesToShow: 3,
            }
        }
    ]
});

$(document).ready(function () {
    
$(".form form input").on("input", function(){
    var x=Math.round($(this).position().top);
    if($(this).val()==""){
        $(this).prev().animate({top:x+2+"px",fontSize:"12px", opacity:"1"},150);
        return;
    }
    // if($(this).val()==""){
    //     return;
    // }
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

$(document).on("click", "#offers .item .body-tab-menu i", function(){
    $(this).toggleClass("select");
    $("#offers .item .body-tab-menu i").addClass("")
})

//show count item
$(document).on("click", ".add", function(){
    $(this).addClass("d-none").next().removeClass("d-none");
});

//plus item count
$(document).on("click", ".count-item .plus", function(){
    var count = Number($(this).prev().text());
    var max = Number($(this).prev().attr("max"));
    $(this).prev().text(count+1);
    if(count>max-2||count>18)
    {
        $(this).attr("disabled","");
    }
})

//minus item count
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