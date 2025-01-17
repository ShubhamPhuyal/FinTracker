window.initializeChart = (canvasId, data, labels) => {
    const ctx = document.getElementById(canvasId).getContext('2d');
    new Chart(ctx, {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: ['#36a2eb', '#ff6384'],
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
        }
    });
};
