var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/Admin/ComicBook/GetAll/' },
        "columns": [
                { data: 'title', "width": "20%"},
            { data: 'issue', "width": "5%" },
            { data: 'author', "width": "20%" },
            { data: 'publisher', "width": "15%" },
            { data: 'coverPrice', "width": "8%" },
            { data: 'category.name', "width": "12%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-100 btn-group" role="group">
                        <a href="/admin/comicbook/publish?id=${data}" class="btn btn-secondary mx-2">
                            <i class="bi bi-pencil-square"></i> Edit
                        </a>
                        <a onClick=Delete('/admin/comicbook/delete?id=${data}') class="btn btn-danger mx-2">
                            <i class="bi bi-trash-fill"></i> Delete
                        </a>
                     </div>`
                },
                "width": "20%"
            },
        ],
        columnDefs: [
            {
                targets: 4, // Target the third column (zero-indexed)
                render: function (data, type, row) {
                    // If data is not null or undefined
                    if (data !== null && typeof data !== 'undefined') {
                        // Format the number to 2 decimal places
                        return parseFloat(data).toFixed(2);
                    }
                    return data;
                }
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
            }
            });
        }
    });
}