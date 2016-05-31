function flashItem(elementId, txt) {
    var id = "availableItems" + elementId;
    document.getElementById(id).innerHTML = txt; 
    id="#"+id;
    $(id).effect("highlight");
    $(id).effect("highlight");
}
