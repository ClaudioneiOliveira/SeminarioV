//Jquery Ready
$(document).ready(function(){

	//Load Data
	var dataTable = $('#usuarios_data').DataTable({
		"processing":true,
		"serverSide":false,
		"order":[],
		"ajax":	{
			url:"/api/Usuarios",
			dataSrc:''
		},
		columns: [
			{ data: 'nome' },
			{"mRender": function ( data, type, row ) {
                        return '<button type="button" name="update" id="' + row.id + '" class="btn btn-warning btn-xs update">Editar</button>';}
            },
			{"mRender": function ( data, type, row ) {
                        return '<button type="button" name="delete" id="' + row.id + '" class="btn btn-danger btn-xs delete">Excluir</button>';}
            }
		]
	});
	
	//New Button
	$('#add_button').click(function(){
		$('#usuario_form')[0].reset();
		$('.modal-title').text("Novo Usuário");
		$('#action').val("Add");
		$('#operation').val("Add");
		$('#user_uploaded_image').html('');
	});

	//Edit Button
	$(document).on('click', '.update', function(){
		var usuario_id = $(this).attr("id")
		$.ajax({
			url:'api/Usuarios/' + usuario_id,
			method:"GET",
			dataType:"json",
			success:function(data)
			{
				$('#usuario_modal').modal('show');
				$('#usuario_nome').val(data.nome);
				$('.modal-title').text("Alterar Usuário");
				$('#usuario_id').val(usuario_id);
				$('#action').val("Edit");
				$('#operation').val("Edit");
			}
		})
	});

	//Delete Record
	$(document).on('click', '.delete', function(){
		if(confirm("Confirma a exclusão do item?")) {
			$.ajax({
				url:'api/Usuarios/' + $(this).attr("id"),
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
	$(document).on('submit', '#usuario_form', function(event){
		event.preventDefault();
		var usuario_id = $("#usuario_id").val();
		var usuario_nome = $("#usuario_nome").val();
		var url = '';
		var type = '';
		var operation = $('#operation').val();
		
		if(operation=='Add') {
			var items = {
				id: 0,
				nome: usuario_nome
			}
			url = 'api/Usuarios'
			type = 'POST'
		}
		
		if(operation=='Edit') {
			var items = {
				id: usuario_id,
				nome: usuario_nome
			}
			url = 'api/Usuarios/' + usuario_id
			type = 'PUT'
		}
		
		if(usuario_nome != '') {
			$.ajax({
				url: url,
				type: type,
				dataType: 'json',
				contentType: 'application/json',
				data: JSON.stringify(items),
				success:function(data) {
					$('#usuario_form')[0].reset();
					$('#usuario_modal').modal('hide');
					dataTable.ajax.reload();
				}
			});
		}
			else
		{
			alert("Todos os campos sao necessarios");
		}
	});

});