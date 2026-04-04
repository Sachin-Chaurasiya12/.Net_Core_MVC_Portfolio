document.addEventListener("DOMContentLoaded", function () {

    const lineCtx = document.getElementById("lineChart").getContext("2d");
    const pieCtx = document.getElementById("pieChart").getContext("2d");

    new Chart(lineCtx, {
        type: 'line',
        data: {
            labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May'],
            datasets: [{
                label: 'Performance',
                data: [10, 30, 20, 40, 35],
                borderWidth: 2
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            animation: {
                duration: 2000, // 2 seconds for a smooth entrance
                easing: 'easeOutQuart'
            },
            plugins: {
                legend: {
                    display: true,
                    position: 'bottom'
                }
            }
        }
    });

    new Chart(pieCtx, {
        type: 'pie',
        data: {
            labels: ['HTML', 'CSS', 'JS'],
            datasets: [{
                data: [40, 30, 30]
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            animation: {
                duration: 2000, // 2 seconds for a smooth entrance
                easing: 'easeOutQuart'
            },
            plugins: {
                legend: {
                    display: true,
                    position: 'bottom'
                }
            }
        }
    });

});

