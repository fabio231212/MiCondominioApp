

function lineChartGanancias(listaMeses,listaTotales) {
    if ($('#seolinechart1').length) {
        var ctx = document.getElementById("seolinechart1").getContext('2d');
        var chart = new Chart(ctx, {
            // The type of chart we want to create
            type: 'line',
            // The data for our dataset
            data: {
                labels: listaMeses,
                datasets: [{
                    label: "Likes",
                    backgroundColor: "rgba(121, 184, 105, 0.6)",
                    borderColor: '#a9bda4',
                    data: listaTotales,
                }]
            },
            // Configuration options go here
            options: {
                legend: {
                    display: false
                },
                animation: {
                    easing: "easeInOutBack"
                },
                scales: {
                    yAxes: [{
                        display: !1,
                        ticks: {
                            fontColor: "rgba(0,0,0,0.5)",
                            fontStyle: "bold",
                            beginAtZero: !0,
                            maxTicksLimit: 5,
                            padding: 0
                        },
                        gridLines: {
                            drawTicks: !1,
                            display: !1
                        }
                    }],
                    xAxes: [{
                        display: !1,
                        gridLines: {
                            zeroLineColor: "transparent"
                        },
                        ticks: {
                            padding: 0,
                            fontColor: "rgba(0,0,0,0.5)",
                            fontStyle: "bold"
                        }
                    }]
                },
                elements: {
                    line: {
                        tension: 0, // disables bezier curves
                    }
                }
            }
        });
    }
}