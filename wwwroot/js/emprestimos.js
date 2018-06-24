//Jquery Ready
$(document).ready(function(){
	
	//Load Data
	var promiseUsuarios = $.get("api/Usuarios/");
	var promiseLivros = $.get("api/Livros/");
	var promiseEmprestimos = $.get("api/Emprestimo/");
	var dataTable = $('#emprestimos_data');

	$.when(promiseUsuarios, promiseLivros, promiseEmprestimos).done(function(usuarios, livros, emprestimos) {
		
		//Load combo usuarios
		$('#emprestimo_usuarios').append('<option value="0">Selecione</option>')
			$.each(usuarios[0], function(key, val){ 
				$('#emprestimo_usuarios').append('<option value="' + val.id + '">' + val.nome + '</option>');
		});
		
		//Load combo livros
		$('#emprestimo_livros').append('<option value="0">Selecione</option>')
			$.each(livros[0], function(key, val){ 
				$('#emprestimo_livros').append('<option value="' + val.id + '">' + val.nome + '</option>');
		});
		
		//Load table emprestimos
		dataTable.DataTable({
			"processing":true,
			"serverSide":false,
			"order":[],
			data: emprestimos[0],
			columns: [
				{"mRender": function ( data, type, row ) {
						var livro = Lookup(livros[0],row.idLivro)
						return (livro.length > 0) ? livro[0].nome : '';}
				},
				{"mRender": function ( data, type, row ) {
						var usuario = Lookup(usuarios[0],row.idUsuario)
						return (usuario.length > 0) ? usuario[0].nome : '';}
				},
				{"mRender": function ( data, type, row ) {
							return new Date(row.dataRetirada).toLocaleDateString('pt-BR')}
				},
				{"mRender": function ( data, type, row ) {
							return new Date(row.dataPrevistaDevolucao).toLocaleDateString('pt-BR')}
				},
				{"mRender": function ( data, type, row ) {
								var cell = ''
								if(row.dataRealDevolucao!='2000-01-01T00:00:00') {
									cell = new Date(row.dataRealDevolucao).toLocaleDateString('pt-BR')
								}
								return cell
							}
				},
				{"mRender": function ( data, type, row ) {
								var valor = 0
								if(row.dataRealDevolucao!='2000-01-01T00:00:00') {
									valor = multa(new Date(row.dataPrevistaDevolucao), new Date(row.dataRealDevolucao))
								}
								return valor.toLocaleString('pt-BR', {style: 'currency', currency: 'BRL'})
							}
				},
				{"mRender": function ( data, type, row ) {
							return '<button type="button" name="update" id="' + row.id + '" class="btn btn-warning btn-xs update">Devolver</button>';}
				},
				{"mRender": function ( data, type, row ) {
                        return '<button type="button" name="delete" id="' + row.id + '" class="btn btn-danger btn-xs delete">Excluir</button>';}
				}
			]
		});
		
	});
	
	//Lookup by id
	var Lookup = function (arr,id) {
		return arr.filter(function(i) {
			return i.id === id;
		});
	}
	
	//dateDiffInDays (UTC)
	var ms_per_day = 1000 * 60 * 60 * 24;
	function dateDiffInDays(a, b) {

		var utc1 = Date.UTC(a.getFullYear(), a.getMonth(), a.getDate());
		var utc2 = Date.UTC(b.getFullYear(), b.getMonth(), b.getDate());

		return Math.floor((utc2 - utc1) / ms_per_day);
	}
	//dateAddInDays (UTC)
	function dateAddInDays(date, days) {

		var utc1 = Date.UTC(date.getFullYear(), date.getMonth(), date.getDate());
	
		return new Date(Date.now()+days*24*60*60*1000)
	}
	//dateISOFormat (from string dd/mm/yyyy)
	function dateISOFormat(date) {
		var d = date.split('/')
		return d[2] + '/' + d[1] + '/' + d[0];
	}
	
	//Multa
	//R$2,00 por dia de atraso
	function multa(dataPrevistaDevolucao,dataRealDevolucao) {
		return dateDiffInDays(dataPrevistaDevolucao,dataRealDevolucao) * 2
	}
	
	//New Button
	$('#add_button').click(function(){
		$('#emprestimo_form')[0].reset();
		$('#emprestimo_data_retirada').val(new Date().toLocaleDateString('pt-BR'));
		$('#emprestimo_data_prevista_devolucao').val(dateAddInDays(new Date(),10).toLocaleDateString('pt-BR'));
		$('.modal-title').text("Novo Empréstimo");
		$('#action').val("Add");
		$('#operation').val("Add");
	});

	//Edit Button
	$(document).on('click', '.update', function(){
		var emprestimo_id = $(this).attr("id")
		$.ajax({
			url:'api/Emprestimo/' + emprestimo_id,
			method:"GET",
			dataType:"json",
			success:function(data)
			{
				console.table(data)
				$('#emprestimo_modal').modal('show');
				$('#emprestimo_usuarios>[value=' + data.idUsuario + ']').attr("selected", "true");
				$('#emprestimo_livros>[value=' + data.idLivro + ']').attr("selected", "true");
				$('#emprestimo_data_retirada').val(new Date(data.dataRetirada).toLocaleDateString('pt-BR'));
				$('#emprestimo_data_prevista_devolucao').val(new Date(data.dataPrevistaDevolucao).toLocaleDateString('pt-BR'));
				
				var dataRealDevolucao = ''
				if(data.dataRealDevolucao!='2000-01-01T00:00:00') {
					dataRealDevolucao = new Date(data.dataRealDevolucao).toLocaleDateString('pt-BR')
				}
				$('#emprestimo_data_real_devolucao').val(dataRealDevolucao)

				$('.modal-title').text("Devolução (multa por atraso R$2,00 ao dia)");
				$('#emprestimo_id').val(emprestimo_id);
				$('#action').val("Edit");
				$('#operation').val("Edit");
			}
		})
	});

	//Delete Record
	$(document).on('click', '.delete', function(){
		if(confirm("Confirma a exclusão do item?")) {
			$.ajax({
				url:'api/Emprestimo/' + $(this).attr("id"),
				method:"DELETE",
				success:function(data)
				{
					alert('Excluído!')
					document.location.reload(true)
				}
			});
		}
			else
		{
			return false; 
		}
	});
	
	//Create or Update Record
	$(document).on('submit', '#emprestimo_form', function(event){
		event.preventDefault();
		var emprestimo_id = $("#emprestimo_id").val();
		var emprestimo_idLivro = $("#emprestimo_livros").val();
		var emprestimo_idUsuario = $("#emprestimo_usuarios").val();
		var emprestimo_dataRetirada = $("#emprestimo_data_retirada").val();
		var emprestimo_dataPrevistaDevolucao = $("#emprestimo_data_prevista_devolucao").val();
		var emprestimo_dataRealDevolucao = $("#emprestimo_data_real_devolucao").val();
		var url = '';
		var type = '';
		var operation = $('#operation').val();
		
		if(operation=='Add') {
			var items = {
				id: 0,
				idLivro: emprestimo_idLivro,
				idUsuario: emprestimo_idUsuario,
				dataRetirada: dateISOFormat(emprestimo_dataRetirada),
				dataPrevistaDevolucao: dateISOFormat(emprestimo_dataPrevistaDevolucao),
				dataRealDevolucao: '2000-01-01'
			}
			url = 'api/Emprestimo'
			type = 'POST'
		}
		
		if(operation=='Edit') {
			var items = {
				id: emprestimo_id,
				idLivro: emprestimo_idLivro,
				idUsuario: emprestimo_idUsuario,
				dataRetirada: dateISOFormat(emprestimo_dataRetirada),
				dataPrevistaDevolucao: dateISOFormat(emprestimo_dataPrevistaDevolucao),
				dataRealDevolucao: dateISOFormat(emprestimo_dataRealDevolucao)
			}
			url = 'api/Emprestimo/' + emprestimo_id
			type = 'PUT'
		}
		
		$.ajax({
			url: url,
			type: type,
			dataType: 'json',
			contentType: 'application/json',
			data: JSON.stringify(items),
			success:function(data) {
				$('#emprestimo_form')[0].reset();
				$('#emprestimo_modal').modal('hide');
				document.location.reload(true);
			}
		});

	});

});