document.addEventListener('DOMContentLoaded', () => {
    const cards = document.querySelectorAll('.project-card');

    const observer = new IntersectionObserver((entries) => {
        entries.forEach((entry, index) => {
            if (entry.isIntersecting) {
                // Add a small delay for each card based on its index
                setTimeout(() => {
                    entry.target.classList.add('show');
                }, index * 200);
            }
        });
    }, { threshold: 0.2 });

    cards.forEach(card => observer.observe(card));
});