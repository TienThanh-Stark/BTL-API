function make_search() {
    var select = document.querySelectorAll("select");
    var data = {};
    for (var i = 0; i < select.length; ++i) {
        select[i].hidden = true;
        let cr = {};
        let idlist = "datalist" + i.toString();
        let input = document.createElement("input");
        let datalist = document.createElement("datalist");
        let options = select[i].options;
        let validate = document.createElement("span");
        input.placeholder = "Nhập để tìm kiếm...";
        input.className = "form-control";
        input.setAttribute("list", idlist);
        input.setAttribute("selid", select[i].id);
        input.value = select[i].options[select[i].selectedIndex].text;
        input.addEventListener("change", function (e) {
            let selid = e.target.getAttribute("selid");
            let validate = document.getElementById("Validate_" + selid);
            if (typeof data[selid][e.target.value] !== 'undefined') {
                document.getElementById(selid).selectedIndex = data[selid][e.target.value];
                validate.innerHTML = "";
            } else {
                validate.innerHTML = validate.getAttribute("msg");
            }
        });
        for (var j = 0; j < options.length; ++j) {
            cr[options[j].text] = j;
            let option = document.createElement("option");
            option.value = options[j].text;
            datalist.appendChild(option);
        }
        datalist.id = idlist;
        data[select[i].id] = cr;
        validate.className = "text-danger";
        validate.id = "Validate_" + select[i].id;
        validate.setAttribute("msg", "Không hợp lệ");
        select[i].after(input, datalist, validate);
    }
}