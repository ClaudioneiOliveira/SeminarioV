//Jquery Ready
$(document).ready(function(){
	
	//Load Data
	var dataSet = [];
	var restAPI = "api/Livros";
	$.getJSON( restAPI )
	.done(function( data ) {
		$.each( data, function( i, result ) {
			var newArray = [];
			newArray.push(result.nome);
			newArray.push('<button type="button" name="update" id="' + result.id + '" class="btn btn-warning btn-xs update">Editar</button>');
			newArray.push('<button type="button" name="delete" id="' + result.id + '" class="btn btn-danger btn-xs delete">Excluir</button>');
			dataSet.push(newArray);
		});
		$('#livros_data').DataTable({
			"data": dataSet
		});
	});

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
		$.ajax({
			url:'api/Livros/' + $(this).attr("id"),
			method:"GET",
			dataType:"json",
			success:function(data)
			{
				$('#livro_modal').modal('show');
				$('#livro_nome').val(data.nome);
				$('.modal-title').text("Alterar Livro");
				$('#livro_id').val(livro_id);
				$('#action').val("Edit");
				$('#operation').val("Edit");
			}
		})
	});

	//Delete Button **implementar
	$(document).on('click', '.delete', function(){
		var id = $(this).attr("id");
		if(confirm("Confirma a exclusão?"))
		{
			alert("Excluído!")
		}
		else
		{
			return false; 
		}
	});

	//Edit Save **implementar

	//Novo Save **implementar

});