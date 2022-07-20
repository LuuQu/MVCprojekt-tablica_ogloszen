
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
function GetName() {
    var name = document.getElementById("name").value.trim();
    return name;
}