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