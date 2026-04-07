document.getElementById('contactForm').addEventListener('submit', function (e) {
    e.preventDefault();

    // Collect values
    const formData = {
        name: document.getElementById('name').value,
        email: document.getElementById('email').value,
        subject: document.getElementById('subject').value,
        message: document.getElementById('message').value
    };

    // For demonstration, we'll log the data and show an alert
    console.log('Form Data Collected:', formData);

    // Simple visual feedback
    const btn = document.querySelector('.submit-btn');
    const originalText = btn.innerText;

    btn.innerText = 'Sending...';
    btn.style.opacity = '0.7';
    btn.disabled = true;

    // Simulate an API call
    setTimeout(() => {
        alert(`Thank you, ${formData.name}! Your message has been sent.`);
        btn.innerText = originalText;
        btn.style.opacity = '1';
        btn.disabled = false;
        document.getElementById('contactForm').reset();
    }, 1500);
});