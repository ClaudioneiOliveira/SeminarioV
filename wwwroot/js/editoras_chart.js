let myChart = document.getElementById('editoras_chart').getContext('2d');

// Global Options
Chart.defaults.global.defaultFontFamily = 'Lato';
Chart.defaults.global.defaultFontSize = 18;
Chart.defaults.global.defaultFontColor = '#777';

let myLabels = ['Deitel', 'Packt Publishing', 'Bookman']
let myData = []

$.ajax({
		url:'api/Livros',
		method:"GET",
		dataType:"json",
		success:function(data)
		{
			//Group and Count Editoras 
			var editorasCount = data.reduce(function (r, data) {
				r[data.editora] = ++r[data.editora] || 1;
				return r;
			}, {});
			
			//Creates Chart Array
			$.each(editorasCount, function( key, value ) {
				myData.push(value)
			});
			
			//Draw Chart
			new Chart(myChart, {
				type:'horizontalBar', // bar, horizontalBar, pie, line, doughnut, radar, polarArea
				data:{
					labels:myLabels,
					datasets:[{
					label:'Livros Publicados',
					data:myData,
					backgroundColor:[
						'rgba(255, 99, 132, 0.6)',
						'rgba(54, 162, 235, 0.6)',
						'rgba(255, 206, 86, 0.6)'
					],
						borderWidth:1,
						borderColor:'#777',
						hoverBorderWidth:1,
						hoverBorderColor:'#000'
					}]
				},
				options:{
					title:{
						display:true,
						text:'Maiores Editoras por quantidade de Livros',
						fontSize:25
					},
					legend:{
						display:true,
						position:'right',
						labels:{
						fontColor:'#000'
					}
				},
					layout:{
						padding:{
							left:0,
							right:0,
							bottom:0,
							top:0
						}
					},
					tooltips:{
						enabled:true
					}
				}
			});
		}
	});
	type:'horizontalBar', // bar, horizontalBar, pie, line, doughnut, radar, polarArea
	data:{
		labels:myLabels,
		datasets:[{
		label:'Livros Publicados',
		data:myData,
		backgroundColor:[
			'rgba(255, 99, 132, 0.6)',
			'rgba(54, 162, 235, 0.6)',
			'rgba(255, 206, 86, 0.6)'
		],
			borderWidth:1,
			borderColor:'#777',
			hoverBorderWidth:1,
			hoverBorderColor:'#000'
		}]
	},
	options:{
		title:{
			display:true,
			text:'Maiores Editoras por quantidade de Livros',
			fontSize:25
		},
		legend:{
			display:true,
			position:'right',
			labels:{
			fontColor:'#000'
		}
	},
		layout:{
			padding:{
				left:0,
				right:0,
				bottom:0,
				top:0
			}
		},
		tooltips:{
			enabled:true
		}
	}
});*/