// Call the dataTables jQuery plugin
window.addEventListener('DOMContentLoaded', event => {
    const tables = document.querySelectorAll('table[id="datatablesSimple"]');
    tables.forEach(table => {
        new simpleDatatables.DataTable(table, {
            labels: {
                placeholder: "Tìm kiếm...", // Viết thay thế cho "Search"
                perPage: "Số dòng hiển mỗi trang",
                noRows: "Không có dữ liệu",
                info: "Hiển thị {start} đến {end} của {rows} mục",
                noResults: "Không tìm thấy kết quả phù hợp!",
                infoFiltered: "(lọc từ tổng {rows} mục)"
            }
        });
    });
});