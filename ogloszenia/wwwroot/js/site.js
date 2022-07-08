
//Funkcja, która pozwala na wysłanie oferty tylko wtedy, gdy  wprowadzisz nazwę oferty oraz opis 
function EnableDisable() {
    var button = document.getElementById("button");
    var name = document.getElementById("name").value.trim();
    var description = document.getElementById("description").value.trim();
    if (name != "" && description != "") {
        button.disabled = false;
    } else {
        button.disabled = true;
    }
};
//Zwraca nazwę oferty potrzebną do alertu
function GetName() {
    var name = document.getElementById("name").value.trim();
    return name;
}