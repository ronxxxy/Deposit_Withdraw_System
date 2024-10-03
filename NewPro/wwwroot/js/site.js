// Show loader on page navigation
window.addEventListener('beforeunload', function () {
    document.querySelector('.loader-mask').style.display = 'block'; // Show loader before leaving the page
});

// Hide loader after page is loaded
window.addEventListener('load', function () {
    document.querySelector('.loader-mask').style.display = 'none'; // Hide loader after content is loaded
});

// Handle link clicks and add 2s delay before page navigation
document.querySelectorAll('a.nav-link').forEach(link => {
    link.addEventListener('click', function (event) {
        event.preventDefault(); // Prevent immediate navigation
        const target = this.getAttribute('href'); // Get the target link
        document.querySelector('.loader-mask').style.display = 'block'; // Show loader
        setTimeout(() => {
            window.location.href = target; // Navigate after 2 seconds
        }, 2000); // Set loader time to 2 seconds
    });
});

// Handle button clicks without showing loader
document.querySelectorAll('button').forEach(button => {
    button.addEventListener('click', function () {
        // No loader functionality for button clicks
        // Add any other button click logic here if needed
    });
});

// Handle form submissions with a 2s delay (if needed)
document.querySelectorAll('form').forEach(form => {
    form.addEventListener('submit', function (event) {
        event.preventDefault(); // Prevent immediate form submission
        document.querySelector('.loader-mask').style.display = 'block'; // Show loader
        const action = this.getAttribute('action'); // Get the form action URL
        setTimeout(() => {
            this.submit(); // Submit form after 2 seconds
        }, 2000); // Set loader time to 2 seconds
    });
});





