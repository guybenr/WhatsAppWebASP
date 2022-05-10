$(function () {
    $('form').submit(e => {
        e.preventDefault();

        const q = $('#search').val();

        $('ul').load('/Reviews/Search?input='+q);
    })
});