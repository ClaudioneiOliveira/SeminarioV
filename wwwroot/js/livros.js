//Jquery Ready
$(document).ready(function(){
		
	//Load Data
	var editoras;
	var dataTable;
	
	$.ajax({
		url:'api/Editoras',
		method:"GET",
		dataType:"json",
		success:function(data)
		{
			//load editoras
			editoras = data
			
			//load combo
			$('#livro_editora').append('<option value="0">Selecione</option>')
			$.each(editoras, function(key, val){ 
				$('#livro_editora').append('<option value="' + val.id + '">' + val.nome + '</option>');
			});
			
			//load grid
			dataTable = $('#livros_data').DataTable(tableConfig);
		}
	});
	
	//Lookup by id
	var Lookup = function (arr,id) {
		return arr.filter(function(i) {
			return i.id === id;
		});
	}
	
	//Main table config
	var tableConfig = {
		"processing":true,
		"serverSide":false,
		"order":[],
		"ajax":	{
			url:"/api/Livros",
			dataSrc:''
		},
		columns: [
			{"mRender": function ( data, type, row ) {
						var editora = Lookup(editoras,row.editora)
						return (editora.length > 0) ? editora[0].nome : '';}
            },
			{ data: 'nome' },
			{"mRender": function ( data, type, row ) {
                        return '<button type="button" name="update" id="' + row.id + '" class="btn btn-warning btn-xs update">Editar</button>';}
            },
			{"mRender": function ( data, type, row ) {
                        return '<button type="button" name="delete" id="' + row.id + '" class="btn btn-danger btn-xs delete">Excluir</button>';}
            }
		]
	}
	
	//New Button
	$('#add_button').click(function(){
		$('#livro_form')[0].reset();
		$('.modal-title').text("Novo Livro");
		$('#action').val("Add");
		$('#operation').val("Add");
		$('#user_uploaded_image').html('');
	});

	//Edit Button
	$(document).on('click', '.update', function(){
		var livro_id = $(this).attr("id")
		$.ajax({
			url:'api/Livros/' + livro_id,
			method:"GET",
			dataType:"json",
			success:function(data)
			{
				$('#livro_modal').modal('show');
				$('#livro_nome').val(data.nome);
				$('#livro_isbn').val(data.isbn);
				$('#livro_editora>[value=' + data.editora + ']').attr("selected", "true");
				$('#livro_paginas').val(data.paginas);
				$('#livro_ano').val(data.ano);
				$('#livro_codigo').val(data.codBarras);
				$('#livro_resenha').val(data.resenha);
				$('.modal-title').text("Alterar Livro");
				$('#livro_id').val(livro_id);
				$('#action').val("Edit");
				$('#operation').val("Edit");
			}
		})
	});

	//Delete Record
	$(document).on('click', '.delete', function(){
		if(confirm("Confirma a exclusão do item?")) {
			$.ajax({
				url:'api/Livros/' + $(this).attr("id"),
				method:"DELETE",
				success:function(data)
				{
					alert('Excluído!')
					dataTable.ajax.reload();
				}
			});
		}
			else
		{
			return false; 
		}
	});
	
	//Create or Update Record
	$(document).on('submit', '#livro_form', function(event){
		
		event.preventDefault();
		
		var livro_id = $("#livro_id").val();
		var livro_nome = $("#livro_nome").val();
		var livro_isbn = $("#livro_isbn").val();
		var livro_editora = $("#livro_editora").find('option:selected').val();
		var livro_paginas = $("#livro_paginas").val();
		var livro_ano = $("#livro_ano").val();
		var livro_codigo = $("#livro_codigo").val();
		var livro_resenha = $("#livro_resenha").val();
		var url = '';
		var type = '';
		var operation = $('#operation').val();
		
		if(operation=='Add') {
			var items = {
				id: 0,
				nome: livro_nome,
				isbn: livro_isbn,
				editora: livro_editora,
				paginas: livro_paginas,
				ano: livro_ano,
				codBarras: livro_codigo,
				resenha: livro_resenha
			}
			url = 'api/livros'
			type = 'POST'
		}
		
		if(operation=='Edit') {
			var items = {
				id: livro_id,
				nome: livro_nome,
				isbn: livro_isbn,
				editora: livro_editora,
				paginas: livro_paginas,
				ano: livro_ano,
				codBarras: livro_codigo,
				resenha: livro_resenha
			}
			url = 'api/livros/' + livro_id
			type = 'PUT'
		}
		
		if(livro_nome != '') {
			$.ajax({
				url: url,
				type: type,
				dataType: 'json',
				contentType: 'application/json',
				data: JSON.stringify(items),
				success:function(data) {
					$('#livro_editora>[value="0"]').attr("selected", "true");
					$('#livro_form')[0].reset();
					$('#livro_modal').modal('hide');
					dataTable.ajax.reload();
				}
			});
		}
			else
		{
			alert("Todos os campos são necessários!");
		}
	});

});