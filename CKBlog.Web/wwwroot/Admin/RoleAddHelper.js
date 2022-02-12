
function selectionchange() {
    var e = document.getElementById("mySelect");
    var str = e.options[e.selectedIndex].value;

    document.getElementById('txt').value = str;
}