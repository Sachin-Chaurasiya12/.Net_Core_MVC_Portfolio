window.onload = function () {
    document.querySelectorAll('.progress-bar').forEach(bar => {
        let value = bar.getAttribute('data-skill');
        bar.style.width = value + "%";
    });
};

// Filter function
function filterSkills(category) {
    let cards = document.querySelectorAll('.skill-card');
    let buttons = document.querySelectorAll('.filter-buttons button');

    buttons.forEach(btn => btn.classList.remove('active'));
    event.target.classList.add('active');

    cards.forEach(card => {
        if (category === 'all' || card.dataset.category === category) {
            card.style.display = 'block';
        } else {
            card.style.display = 'none';
        }
    });
}
    document.addEventListener("DOMContentLoaded", function () {
        const message = document.getElementById("statusMessage");
    if (message) {
        // Set the time limit (e.g., 3000ms = 3 seconds)
        setTimeout(function () {
            message.style.transition = "opacity 0.5s ease";
            message.style.opacity = "0";

            // Remove from layout after fade out
            setTimeout(() => message.remove(), 500);
        }, 3000); 
        }
    });