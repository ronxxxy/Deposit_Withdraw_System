// JavaScript to validate form and show the modal
function validateAndShowModal() {
    const form = document.getElementById('withdrawForm');
    
    // Check if form is valid
    if (form.checkValidity()) {
        // Show the modal
        const modal = new bootstrap.Modal(document.getElementById('confirmModal'));
        modal.show();
        // Add dark background (optional, as Bootstrap handles backdrop automatically)
        document.body.classList.add('modal-backdrop-dark');
    } else {
        // Trigger HTML5 form validation
        form.reportValidity();
    }
}

// Remove dark background when modal closes
document.getElementById('confirmModal').addEventListener('hidden.bs.modal', function () {
    document.body.classList.remove('modal-backdrop-dark');
});
