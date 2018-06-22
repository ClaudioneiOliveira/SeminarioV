//Jquery Ready
$(document).ready(function(){

	//Load Data
	var dataTable = $('#editoras_data').DataTable({
		"processing":true,
		"serverSide":false,
		"order":[],
		"ajax":	{
			url:"/api/Editoras",
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
		$('#editora_form')[0].reset();
		$('.modal-title').text("Nova Editora");
		$('#action').val("Add");
		$('#operation').val("Add");
		$('#user_uploaded_image').html('');
	});

	//Edit Button
	$(document).on('click', '.update', function(){
		var editora_id = $(this).attr("id")
		$.ajax({
			url:'api/Editoras/' + editora_id,
			method:"GET",
			dataType:"json",
			success:function(data)
			{
				$('#editora_modal').modal('show');
				$('#editora_nome').val(data.nome);
				$('.modal-title').text("Alterar Editora");
				$('#editora_id').val(editora_id);
				$('#action').val("Edit");
				$('#operation').val("Edit");
			}
		})
	});

	//Delete Record
	$(document).on('click', '.delete', function(){
		if(confirm("Confirma a exclusão do item?")) {
			$.ajax({
				url:'api/Editoras/' + $(this).attr("id"),
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
	$(document).on('submit', '#editora_form', function(event){
		event.preventDefault();
		var editora_id = $("#editora_id").val();
		var editora_nome = $("#editora_nome").val();
		var url = '';
		var type = '';
		var operation = $('#operation').val();
		
		if(operation=='Add') {
			var items = {
				id: 0,
				nome: editora_nome
			}
			url = 'api/Editoras'
			type = 'POST'
		}
		
		if(operation=='Edit') {
			var items = {
				id: editora_id,
				nome: editora_nome
			}
			url = 'api/Editoras/' + editora_id
			type = 'PUT'
		}
		
		if(editora_nome != '') {
			$.ajax({
				url: url,
				type: type,
				dataType: 'json',
				contentType: 'application/json',
				data: JSON.stringify(items),
				success:function(data) {
					$('#editora_form')[0].reset();
					$('#editora_modal').modal('hide');
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