$('.currency').click(function (event) {

	var $this = $(this);
	var loadingText = 'Carregando...';
	if ($this.html() !== loadingText) {
		$this.data('wait-text', $this.html());
		$this.html(loadingText);
	}

	$.get('Home/GetTaxasDeCambio', { moeda: event.target.value }, function (data, status) {

		if (data.success) {
			var serie = [];
			var categories = [];
			for (var i = 0; i < data.response.length; i++) {
				var dataCambio = Number(new Date(data.response[i].dataCambio));
				var valor = data.response[i].valor;
				serie.push([dataCambio, valor])
				categories.push(dataCambio);
			}

			configureChart(serie, categories);

			setTimeout(function () {
				$this.html($this.data('wait-text'));
			}, 500);
		}
		else {
			alert('Oops! Ocorreu um erro ao recuperar o câmbio. Mensagem: ' + data.response);

			setTimeout(function () {
				$this.html($this.data('wait-text'));
			}, 500);
		}
	});
});

function configureChart(serieData, categoriesData) {
	Highcharts.chart('container', {
		title: {
			text: 'Gráfico de cotações de câmbio - Elo'
		},
		yAxis: {
			title: {
				text: 'Variação em R$'
			}
		},
		xAxis: {
			type: 'datetime',
			tickInterval: 24 * 3600 * 1000,
			tickPositions: categoriesData,
			title: {
				text: 'Período'
			},
			labels: {
				format: '{value:%d/%m}'
			}
		},
		tooltip: {
			xDateFormat: 'Data: %d/%m/%Y',
			valueDecimals: 4,
			valuePrefix: 'R$ ',
		},
		series: [{
			showInLegend: false,
			name: 'Valor',
			data: serieData
		}]
	});
}
