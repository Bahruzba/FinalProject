$('#Find-awesome-deals .owl-carousel').slick({
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

$('#popular-brands .owl-carousel').slick({
    infinite: true,
    slidesToShow: 2,
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

$('#offers .owl-carousel').slick({
    infinite: true,
    slidesToShow: 8,
    slidesToScroll: 1,
    prevArrow: false,
    nextArrow: false,
    autoplay: true,
    autoplaySpeed: 1000,
    infinite: true,
    responsive: [
        {
            breakpoint: 600,
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



    function sliderToRight() {
        sliderText();
        if ($("#slider .show").next().length != 0) {
            $("#slider .show").removeClass("show").next().addClass("show");
        } else {
            $("#slider .show").removeClass("show");
            $(".slider-item:first-child").addClass("show");
        }
    }



  });