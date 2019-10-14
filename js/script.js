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

$(document).on("click", "#body-tab-menu .count-item .plus", function(){
    var count = Number($(this).prev().text());
    $(this).prev().text(count+1);
    if(count>18)
    {
        console.log("sss");
        $(this).attr("disabled","");
    }
})

$(document).on("click", "#body-tab-menu .count-item .minus", function(){
    var count = Number($(this).next().text());
    
    if(count>1){
        $(this).next().text(count-1).next().removeAttr("disabled");
    } else{
        $(this).parent().addClass("d-none");
        $(this).parent().prev().removeClass("d-none");
    }
})


$(document).on("click", "#body-tab-menu .add", function(){
    $(this).addClass("d-none").next().removeClass("d-none");
});



});