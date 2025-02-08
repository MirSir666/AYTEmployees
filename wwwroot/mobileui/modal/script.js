window.openModal= function (id) {
    //var button = event.target
    //var rect = button.getBoundingClientRect()

    var modal = document.getElementById(id);
    if (modal) {
        if (modal && modal.classList.contains('modal')) {
            modal.classList.toggle('active');
        }
        event.preventDefault(); // prevents rewriting url (apps can still use hash values in url)
    }

}
window.closeModal = function (id) {
    var target = event.target
    var modal = document.getElementById(id);
    if (modal) {
        if (modal && modal.classList.contains('modal')) {
            modal.classList.remove('active')
        }
        event.preventDefault(); // prevents rewriting url (apps can still use hash values in url)
    }
   
}
