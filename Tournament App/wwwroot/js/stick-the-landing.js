
(function ()
{
    setTimeout(() => {
        const elems = document.querySelectorAll(".stick-the-landing");
        for (let elem of elems) {
            elem.remove();
        }
    }, 500);
})();
