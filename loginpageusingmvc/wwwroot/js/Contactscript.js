document.getElementById('contactForm').addEventListener('submit', function (e) {
    e.preventDefault();

    // 1. Collect values from the form
    const formData = {
        name: document.getElementById('name').value,
        email: document.getElementById('email').value,
        subject: document.getElementById('subject').value,
        message: document.getElementById('message').value
    };

    // 2. UI Feedback: Disable button and show "Sending..."
    const btn = document.querySelector('.submit-btn');
    const originalText = btn.innerText;

    btn.innerText = 'Sending...';
    btn.style.opacity = '0.7';
    btn.disabled = true;

    // 3. The API Call
    fetch("/Contact/ContactForm", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData), // Using the object we built above
    })
        .then(response => {
            if (response.ok) {
                // Success Logic
                alert(`Thank you, ${formData.name}! Your message has been sent.`);
                document.getElementById('contactForm').reset();
            } else {
                // Server error logic (e.g., 404 or 500)
                alert('Something went wrong on our end. Please try again later.');
            }
        })
        .catch(error => {
            // Network error logic (e.g., no internet)
            console.error('Error:', error);
            alert('Failed to connect to the server.');
        });

    btn.innerText = "Send";
    btn.disabled = false;
});
