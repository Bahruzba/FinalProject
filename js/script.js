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


$(document).ready(function () {
    
$(".form form input").on("input", function(){
    var x=Math.round($(this).position().top);
    if($(this).val()==""){
        $(this).prev().animate({top:x+2+"px",fontSize:"12px", opacity:"1"},150);
        return;
    }
    if($(this).val()==""){
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








    
  });