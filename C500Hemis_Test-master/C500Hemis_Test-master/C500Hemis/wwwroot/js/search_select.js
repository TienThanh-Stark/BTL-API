class search_select {
    msg = "{0} Không hợp lệ";
    input_class = "form-control";
    validate_class = "text-danger";
    IsNULL = false;
    constructor(formid) {
        this.formid = formid;
    }
    run() {
        //Lưu dữ liệu cho select
        var data = {};
        let select = document.querySelectorAll(`#${this.formid} select`);
        //Tìm label
        let labels = document.querySelectorAll(`#${this.formid} label`);
        let label = {};
        for (let i = 0; i < labels.length; ++i) {
            if (labels[i].htmlFor != '') {
                label[labels[i].htmlFor] = labels[i].innerHTML;
            }
        }
        //Xử lý
        for (let i = 0; i < select.length; ++i) {
            if (select[i].id == null) continue;
            select[i].hidden = true;
            if (this.IsNULL) { //NULL option
                let opt = document.createElement("option");
                select[i].insertBefore(opt, select[i].firstElementChild);
                select[i].selectedIndex = 0;
            }
            //Khởi tạo các giá trị cần thiết
            let cr = {}; //Giá trị của select hiện tại
            let idlist = "datalist" + i.toString(); //Id của datalist
            let input = document.createElement("input");
            let datalist = document.createElement("datalist");
            let options = select[i].options; 
            //Cài đặt input
            input.placeholder = "Nhập để tìm kiếm...";
            input.className = `search-input ${this.input_class}`;
            input.setAttribute("list", idlist);
            input.setAttribute("formid", this.formid);
            input.setAttribute("selid", select[i].id);
            input.setAttribute("label", label[select[i].id]);
            input.setAttribute("msg", this.msg);
            input.value = select[i].options[select[i].selectedIndex].text; //Lấy giá trị hiện tại
            input.addEventListener("change", function (e) { //Thêm event cho input
                let formid = e.target.getAttribute("formid");
                let selid = e.target.getAttribute("selid");
                let msg = e.target.getAttribute("msg");
                let label = e.target.getAttribute("label");
                let validate = document.getElementById("Validate_" + selid);
                let value = e.target.value;
                value = value.trim(); 
                //Nếu giá trị không hợp lệ trả về error msg
                if (typeof data[selid][value] !== 'undefined') {
                    document.getElementById(selid).selectedIndex = data[selid][value];
                    validate.innerHTML = "";
                } else {
                    var validator = $(`#${formid}`).validate();
                    var obj = {}; //Nhập sai
                    obj[selid] = msg.replace("{0}", label); //Xây dựng obj in lỗi ra
                    validator.showErrors(obj);
                }
            });
            //Xử lý datalist
            //Khởi tạo giá trị cho cr
            for (let j = 0; j < options.length; ++j) {
                cr[options[j].text] = j;
                let option = document.createElement("option");
                option.value = options[j].text;
                datalist.appendChild(option);
            }
            datalist.id = idlist;
            data[select[i].id] = cr;
            //Thêm vào form
            select[i].after(input, datalist);
        }
        //Xử lý sự kiện submit
        document.getElementById("form").addEventListener("submit", function(e) {
            let input = document.getElementsByClassName("search-input"); //Tìm các input được khởi tạo
            for (let i = 0; i < input.length; ++i) {
                let select_id = input[i].getAttribute("selid");
                let value = input[i].value;
                value = value.trim();
                //Nếu value không đúng dừng quá trình submit
                if (typeof data[select_id][value] === 'undefined') {
                    input[i].focus();
                    e.preventDefault();
                    break;
                }
            }
        });
    }
}