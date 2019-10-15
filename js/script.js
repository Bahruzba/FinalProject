$('.owl-carousel').slick({
    infinite: true,
    slidesToShow: 6,
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
$(document).on("click", "#body-tab-menu .add", function(){
    $(this).addClass("d-none").next().removeClass("d-none");
});

//plus item count
$(document).on("click", "#body-tab-menu .count-item .plus", function(){
    var count = Number($(this).prev().text());
    $(this).prev().text(count+1);
    if(count>18)
    {
        console.log("sss");
        $(this).attr("disabled","");
    }
})

//minus item count
$(document).on("click", "#body-tab-menu .count-item .minus", function(){
    var count = Number($(this).next().text());
    
    if(count>1){
        $(this).next().text(count-1).next().removeAttr("disabled");
    } else{
        $(this).parent().addClass("d-none");
        $(this).parent().prev().removeClass("d-none");
    }
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


});