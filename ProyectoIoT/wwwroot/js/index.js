$(document).ready(function(){
    $('.secciones ul').hide();
    $('.secciones ul:first').show();


    $('ul.menu li a').click(function(){
        $('.secciones ul').hide();

        var activeTab = $(this).attr('href');
        $(activeTab).show();
        return false;

    });
});