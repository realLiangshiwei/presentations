$(function () {
    // CREATING NEW ITEMS /////////////////////////////////////
    $('#NewItemForm').submit(function(e){
        e.preventDefault();

        var todoText = $('#NewItemText').val();
    
        todoApp.todo.create(todoText).then(function(result){
            $('<li class="list-group-item list-group-item-action" data-id="' + result.id + '">')
                .html('<i class="fa fa-trash-o"></i><b> ' + result.text + '</b>')
                .appendTo($('#TodoList'));
            $('#NewItemText').val('');
        });
    });

    // DELETING ITEMS /////////////////////////////////////////
    $('#TodoList').on('click', 'li i', function(){
        var $li = $(this).parent();
        var id = $li.attr('data-id');

        todoApp.todo.delete(id).then(function(){
            $li.remove();
            abp.notify.info('Deleted the todo item.');
        });
    });
});
