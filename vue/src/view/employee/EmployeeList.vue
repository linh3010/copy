<template>
    <div class="page-content">
        <div class="m-page-header">
            <div class="m-page-title">Danh sách nhân viên</div>
            <div class="m-page-button">
                <button id="btnAdd" class="m-btn m-btn-icon m-btn-icon-add" title="add" @click="btnAddOnClick">thêm mới nhân viên
                </button>
            </div>
        </div>
        <div class="m-page-toolbar">
            <div class="m-page-toolbar-left" style="display: flex;">
                <input type="text" id="SearchForEmployee" style="width: 200px" class="m-input m-input-icon m-icon-16 m-icon-search"
                    placeholder="Tìm kiếm theo tên,số hồ sơ" @keypress.enter="SearchEmployee">
                <div style="margin-left: 8px;">
                    <select title="tìm kiếm theo phòng ban" name="" id="" class="select-header">
                        <option>Tất cả phòng ban</option>
                        <option>Phòng đào tạo</option>
                    </select>
                </div>
                <div style="margin-left: 8px;">
                    <select title="tìm kiếm theo vi trí" name="" id="" class="select-header">
                        <option>Tất cả vị trí</option>
                        <option>Giám đốc</option>
                        <option>Nhân viên</option>
                    </select>
                </div>
            </div>
            <div class="m-page-toolbar-right">
                <button title="refresh" id="btnRefresh" class="m-btn-refresh"></button>
            </div>
        </div>
        <div class="m-page-grid">
            <table class="m-table">
                <thead>
                    <tr>
                        <th class="text-align-left">Mã nhân viên</th>
                        <th class="text-align-left">Họ và tên</th>
                        <th class="text-align-left">Giới tính</th>
                        <th class="text-align-center">Ngày sinh</th>
                        <th class="text-align-left">Điện thoại</th>
                        <th class="text-align-left">Email</th>
                        <th class="text-align-left">Chức vụ</th>
                        <th class="text-align-left">Phòng ban</th>
                        <th class="text-align-right">Mức lương cơ bản</th>
                        <th class="text-align-left">Tình trạng công việc</th>
                        <th class="text-align-center">Xóa</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="employee in employees" :key="employee.EmployeeId" @dblclick="showDetailDialog(employee)">
                        <th class="text-align-left">{{ employee.employeeCode }}</th>
                        <th class="text-align-left">{{ employee.fullName }}</th>
                        <th class="text-align-left">{{ employee.genderName }}</th>
                        <th class="text-align-center">{{ formatDate(employee.dateOfBirth) }}</th>
                        <th class="text-align-left">{{ employee.phoneNumber }}</th>
                        <th class="text-align-left">{{ employee.email }}</th>
                        <th class="text-align-left">{{ getPositionName(employee.positionId) }}</th>
                        <th class="text-align-left">{{ getDepartmentName(employee.departmentId) }}</th>
                        <th class="text-align-right">{{ employee.salary }}</th>
                        <th class="text-align-left">{{ employee.workStatusName }}</th>
                        <th class="text-align-center"><button title="save" class="m-btn" @click="btnDelOnClick(employee)">Xóa</button></th>
                    </tr>
                </tbody>
            </table>
            <div class="m-paging">
                <div class="m-paging-left">Hiển thị 01-100/200 nhân viên</div>
                <div class="m-paging-center">
                    <button title="first" class="m-btn-first"></button>
                    <button title="previous" class="m-btn-prev"></button>
                    <div class="m-page-number-group">
                        <button title="1" class="m-page-number m-page-number-selected">1</button>
                        <button title="2" class="m-page-number">2</button>
                        <button title="3" class="m-page-number">3</button>
                        <button title="4" class="m-page-number">4</button>
                    </div>
                    <button title="next" class="m-btn-next"></button>
                    <button title="last" class="m-btn-last"></button>
                </div>
                <div class="m-paging-right">10 nhân viên/trang</div>
            </div>
        </div>
        <div class="m-popup" id="puPopUp" v-bind:class="{ isShowPopup: isShowpu }">
            <div class="m-popup-content">
                <div class="m-popup-header">
                    <div class="m-popup-tittle">Xóa nhân viên {{ deletedEmployee.fullName }}</div>
                    <button title="close_delete" class="m-popup-close" @click="btnCloseOnClickPU"></button>
                </div>
                <div class="m-popup-body">
                    <div class="m-popup-icon"><i class="fa-solid fa-circle-exclamation"></i></div>
                    <div class="m-popup-info">Bạn có chắc muốn xóa thông tin về nhân viên {{ deletedEmployee.fullName }} hay không</div>
                </div>
                <div class="m-popup-footer">
                    <button title="cancel_popup" class="m-btn m-popup-cancel" @click="btnCloseOnClickPU">Hủy</button>
                    <button title="delete" class="m-btn m-popup-delete" @keypress.space="focusInput" @click="deleteEmployee(deletedEmployee)">Xóa</button>
                </div>
            </div>
        </div>
        <EmployeeDetail :isShow="isShowDialog" :employeeSelected="employeeSelected" :employeeIdSelected="employeeIdSelected"
            :formMode="formDetailMode" @abc="showEmployeeDetailDialog" />
        <div></div>
    </div>
</template>
<script>
import axios from 'axios'
import EmployeeDetail from './EmployeeDetail.vue'
export default {
    name: "EmployeeList",
    components: {
        EmployeeDetail
    },

    beforeCreate() {
        console.log("beforeCreate");
    },

    created() {
        /*Lấy dữ liệu qua api*/
        try {
            console.log("created");
            var me = this;
            axios.get("http://localhost:8080/api/v1/Employees").then((Response) => {
                console.log(Response.data);
                me.employees = Response.data;
            });
            console.log(me.employees);
        } catch (error) {
            console.log(error);
        }
    },

    beforeMount() {
        console.log("beforeMount");
    },

    mounted() {
        console.log("mounted");
    },

    beforeUnmount() {
        console.log("beforeUnmount");
    },

    unmounted() {
        console.log("unmounted");
    },

    methods: {
        /**
        Định dạng ngày tháng năm sinh
        Author: BTLINH (25/7/2023)
        */
        formatDate(dob) {
            try {
                if (dob) {
                    dob = new Date(dob);
                    let date = dob.getDate();
                    date = date < 10 ? `0${date}` : date;
                    let month = dob.getMonth() + 1;
                    month = month < 10 ? `0${month}` : month;
                    let year = dob.getFullYear();
                    dob = `${date}/${month}/${year}`;
                } else {
                    dob = "";
                }
                return dob;
            } catch (error) {
                console.log(error);
            }
        },
        /**
        Hiển thị hộp thoại thêm mới nhân viên
        Author: BTLINH (25/7/2023)
        */
        btnAddOnClick() {
            this.formDetailMode = 1;
            this.showEmployeeDetailDialog(true);
            this.employeeSelected = {};
            this.employeeIdSelected = null;
            console.log(this.isShowDialog);
        },
        /**
        Hiển thị hộp thoại sửa chữa thông tin nhân viên
        Author: BTLINH (25/7/2023)
        */
        showDetailDialog(employee) {
            this.formDetailMode = 0;
            this.showEmployeeDetailDialog(true);
            this.employeeSelected = employee;
            this.employeeIdSelected = employee.employeeId;
            console.log(this.isShowDialog);
            console.log(employee);
        },
        /**
        Trao đổi trạng thái của isShow với EmployeeDetail property
        Author: BTLINH (25/7/2023)
        */
        showEmployeeDetailDialog(isShow) {
            this.isShowDialog = isShow;
        },
        /**
        Hiển thị hộp thoại xóa nhân viên
        Author: BTLINH (25/7/2023)
        */
        btnDelOnClick(employee){
            this.isShowpu = true;
            this.deletedEmployee = employee;
        },
        /**
        Tắt hộp thoại xóa nhân viên
        Author: BTLINH (25/7/2023)
        */
        btnCloseOnClickPU() {
            this.isShowpu = false;
            this.deletedEmployee = {}
        },
        /**
        Lấy tên phòng ban
        Author: BTLINH (25/7/2023)
        */
        getDepartmentName(departmentId) {
            axios.get(`http://localhost:8080/api/v1/Department/${departmentId}`).then((Response) => {
                console.log(Response.data);
                return Response.data.DepartmentName;
            });
        },
        /**
        Lấy tên vị trí
        Author: BTLINH (25/7/2023)
        */
        getPositionName(positionId) {
            axios.get(`http://localhost:8080/api/v1/Position/${positionId}`).then((Response) => {
                console.log(Response.data);
                return Response.data.PositionName;
            });
        },
        /**
        Xóa nhân viên
        Author: BTLINH (25/7/2023)
        */
        deleteEmployee(employee){
            axios.delete(`http://localhost:8080/api/v1/Employees/${employee.employeeId}`).then((Response) => {
                console.log(Response.data);
                alert("xóa thành công");
                return Response.data;
            });
        },
        /**
        Tìm nhân viên theo tên
        Author: BTLINH (25/7/2023)
        */
        SearchEmployee(){
            var me = this;
            var name = document.getElementById("SearchForEmployee").value;
            axios.get(`http://localhost:8080/api/v1/Employees/search/${name}`).then((Response) => {
                console.log(Response.data);
                console.log(name);
                alert("tìm thành công");
                me.employees = Response.data;
                return Response.data;
            });
        },
    },

    data() {
        return {
            employees: null,
            isShowDialog: false,
            isShowpu: false,
            employeeSelected: {},
            employeeIdSelected: null,
            formDetailMode: 0,
            deletedEmployee: {}
        };
    },

};
</script>

<style scoped>
@import url(../../style/css/page/employee.css);
@import url(../../style/css/main.css);
</style>