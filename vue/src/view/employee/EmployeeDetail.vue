<template>
    <div id="dlgDialogDetail" class="m-dialog" v-bind:class="{ isShowDialog: isShow }">
        <div class="m-dialog-content">
            <div class="m-dialog-header">
                <div class="m-dialog-tittle">
                    THÔNG TIN NHÂN VIÊN
                </div>
                <button title="close_dialog_x" class="m-dialog-close" @click="btnCloseOnClick">
                </button>
            </div>
            <div class="m-dialog-body">
                <div class="m-dialog-avatar">
                    <div class="m-avatar"></div>
                    <div style="font-size: 15px; color: #454545; text-align: center; margin-top: 30px;">(Vui lòng chọn ảnh
                        có định dạng .jpg,
                        .jpeg, .png, .gif)</div>
                </div>
                <div class="m-dialog-info">
                    <div class="m-dialog-info-A">
                        <div class="m-dialog-info-A-tittle">
                            A. THÔNG TIN CHUNG
                            <div class="m-dialog-info-green"></div>
                        </div>
                        <div class="m-dialog-info-A-content">
                            <div class="m-dialog-info-A-content-left">
                                <div style="padding-bottom: 16px;">
                                    <div style="padding: 4px; font-size: 13px;">Mã nhân viên(*)</div>
                                    <input title="Mã nhân viên" type="text" style="width: 270px;" class="m-input"
                                        v-model="employee.employeeCode" ref="detailFocus" id="inputEmployeeCode">
                                </div>
                                <div style="padding-bottom: 16px;">
                                    <div style="padding: 4px; font-size: 13px;">Ngày sinh</div>
                                    <input title="Ngày sinh" type="date" style="width: 270px;" class="m-input"
                                        v-model="employee.dateOfBirth" id="inputDateOfBirth">
                                </div>
                                <div style="padding-bottom: 16px;">
                                    <div style="padding: 4px; font-size: 13px;">Số CMTND/Căn cước(*)</div>
                                    <input title="Số CMTND/Căn cước" type="text" style="width: 270px;" class="m-input"
                                        v-model="employee.identityNumber" id="inputIdentityNumber">
                                </div>
                                <div style="padding-bottom: 16px;">
                                    <div style="padding: 4px; font-size: 13px;">Nơi cấp</div>
                                    <input title="Nơi cấp" type="text" style="width: 270px;" class="m-input"
                                        v-model="employee.identityPlace" id="inputIdentityPlace">
                                </div>
                                <div style="padding-bottom: 16px;">
                                    <div style="padding: 4px; font-size: 13px;">Email</div>
                                    <input title="Email" type="text" style="width: 270px;" class="m-input"
                                        v-model="employee.email" id="inputEmail">
                                </div>
                            </div>
                            <div class="m-dialog-info-A-content-right">
                                <div style="padding-bottom: 16px;">
                                    <div style="padding: 4px; font-size: 13px;">Họ và tên(*)</div>
                                    <input title="Họ và tên" type="text" style="width: 270px;" class="m-input"
                                        v-model="employee.fullName" id="inputFullName">
                                </div>
                                <div style="padding-bottom: 16px;">
                                    <div style="padding: 4px; font-size: 13px;">Giới tính</div>
                                    <select title="Giới tính" style="width: 270px;" class="m-input"
                                        v-model="employee.gender" id="inputGenderName">
                                        <option value=1>Nam</option>
                                        <option value=0>Nữ</option>
                                        <option value=2>Không xác định</option>
                                    </select>
                                </div>
                                <div style="padding-bottom: 16px;">
                                    <div style="padding: 4px; font-size: 13px;">Ngày cấp</div>
                                    <input title="Ngày cấp" type="date" style="width: 270px;" class="m-input"
                                        v-model="employee.identityDate" id="inputIdentityDate">
                                </div>
                                <div style="padding-bottom: 16px; height: 64px;"></div>
                                <div style="padding-bottom: 16px;">
                                    <div style="padding: 4px; font-size: 13px;">Số điện thoại(*)</div>
                                    <input title="Số điện thoại" type="text" style="width: 270px;" class="m-input"
                                        v-model="employee.phoneNumber" id="inputPhoneNumber">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="m-dialog-info-B">
                        <div class="m-dialog-info-B-tittle">
                            B. THÔNG TIN CÔNG VIỆC
                            <div class="m-dialog-info-green"></div>
                            <div class="m-dialog-info-B-content">
                                <div class="m-dialog-info-B-content-left">
                                    <div style="padding-top: 16px;">
                                        <div style="padding: 4px; font-size: 13px;">Vị Trí</div>
                                        <select title="Vị Trí" style="width: 270px;" class="m-input"
                                            v-model="employee.positionName" id="inputPositionName">
                                            <option selected>Giám đốc</option>
                                        </select>
                                    </div>
                                    <div style="padding-top: 16px;">
                                        <div style="padding: 4px; font-size: 13px;">Mã số thuế cá nhân</div>
                                        <input title="Mã số thuế cá nhân" type="text" style="width: 270px;" class="m-input"
                                            v-model="employee.personalTaxCode" id="inputPersonalTaxCode">
                                    </div>
                                    <div style="padding-top: 16px;">
                                        <div style="padding: 4px; font-size: 13px;">Ngày gia nhập công ty</div>
                                        <input title="Ngày gia nhập công ty" type="date" style="width: 270px;"
                                            class="m-input" v-model="employee.joinDate" id="inputJoinDate">
                                    </div>
                                </div>
                                <div class="m-dialog-info-B-content-right">
                                    <div style="padding-top: 16px;">
                                        <div style="padding: 4px; font-size: 13px;">Phòng ban</div>
                                        <select title="Phòng ban" style="width: 270px;" class="m-input"
                                            v-model="employee.departmentName" id="inputDepartmentName">
                                            <option>Phòng nhân sự</option>
                                        </select>
                                    </div>
                                    <div style="padding-top: 16px;">
                                        <div style="padding: 4px; font-size: 13px;">Mức lương cơ bản</div>
                                        <input title="Mức lương cơ bản" type="text"
                                            style="text-align: right;; width: 270px;" class="m-input"
                                            v-model="employee.salary" id="inputSalary">
                                    </div>
                                    <div style="padding-top: 16px;">
                                        <div style="padding: 4px; font-size: 13px;">Tình trạng cơ bản</div>
                                        <select title="Tình trạng cơ bản" style="width: 270px;" class="m-input"
                                            v-model="employee.workStatus" id="inputWorkStatus">
                                            <option value=0>đang nghỉ việc</option>
                                            <option value=1>đang làm việc</option>
                                            <option value=2>đang thử việc</option>
                                            <option value=3>không xác định</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="m-dialog-footer">
                <button title="cancel_dialog" class="m-btn m-dialog-cancel" @click="btnCloseOnClick">Hủy</button>
                <button title="save" class="m-btn m-dialog-save" @keypress.space="focusInput" @click="btnSaveOnClick"><i
                        class="fas fa-save" style="margin-right: 8px;"></i>Lưu</button>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'
export default {

    // beforeUpdate(){
    //     this.focusInput();
    // },

    methods: {
        /**
         * Định dạng ngày
         * @param {*} dob : ngày tháng
         * Author: BTLINH (26/7/2023)
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
                    dob = `${year}-${month}-${date}`;
                } else {
                    dob = "";
                }
                return dob;
            } catch (error) {
                console.log(error);
            }
        },
        /**
         * Đóng hộp thoại chi tiết nhân viên
         * Author: BTLINH (26/7/2023)
         */
        btnCloseOnClick() {
            this.$emit("abc", false);
            // this.isShow = false;
        },

        vnd(Salary) {
            return Salary + "(VNĐ)";
        },
        
        focusInput() {
            this.$refs.detailFocus.focus();
        },
        /**
         * Thực hiện cất dữ liệu
         * Author: BTLINH(19/08/2023) 
         */
        btnSaveOnClick() {
            var me = this;
            let employeeCode = document.getElementById("inputEmployeeCode");
            let dateOfBirth = document.getElementById("inputDateOfBirth");
            let identityNumber = document.getElementById("inputIdentityNumber");
            // let identityPlace = document.getElementById("inputIdentityPlace");
            let email = document.getElementById("inputEmail");
            let fullName = document.getElementById("inputFullName");
            // let genderName = document.getElementById("inputGenderName");
            let identityDate = document.getElementById("inputIdentityDate");
            let phoneNumber = document.getElementById("inputPhoneNumber");
            // let positionName = document.getElementById("inputPositionName");
            // let personalTaxCode = document.getElementById("inputPersonalTaxCode");
            let joinDate = document.getElementById("inputJoinDate");
            // let departmentName = document.getElementById("inputDepartmentName");
            // let salary = document.getElementById("inputSalary");
            // let workStatus = document.getElementById("inputWorkStatus");

            if (employeeCode == null) {
                alert("mã nhân viên không được để trống");
            }
            if (dateOfBirth != null && dateOfBirth > Date.now) {
                alert("Ngày sinh không được phép vượt quá ngày hiện tại");
            }
            if (identityNumber == null) {
                alert("số CMND/CCCD không được để trống");
            }
            if (!this.ValidateEmail(email)) {
                alert("nhập sai định dạng email");
            }
            if (fullName == null) {
                alert("họ và tên không được để trống");
            }
            if (identityDate != null && identityDate > Date.now) {
                alert("Ngày cấp số CMND/CCCD không được phép vượt quá ngày hiện tại");
            }
            if (phoneNumber == null) {
                alert("số điện thoại không được để trống");
            }
            if (joinDate != null && joinDate > Date.now) {
                alert("Ngày gia nhập không được phép vượt quá ngày hiện tại");
            }
            if (me.formMode == 1) {
                axios.post("http://localhost:8080/api/v1/Employees", me.employee)
                    .then(function (response) {
                        console.log(response);
                        alert("them moi")
                        me.$emit("abc",false);
                    }).catch(function (response) {
                        console.log(response);
                    });
            } else {
                axios.put(`http://localhost:8080/api/v1/Employees/${me.employeeIdSelected}`, me.employee)
                    .then(function (response) {
                        alert("sua")
                        me.$emit("abc",false);
                        console.log(response);
                    }).catch(function (response) {
                        alert(response);
                        console.log(response);
                    });
            }
        },

        /**
         * Thực hiện validate email
         * Author: BTLINH(19/08/2023) 
         */
        ValidateEmail(inputText) {
            var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/; // eslint-disable-line
            if (inputText.value.match(mailformat)) {
                return true;
            }
            else {
                return false;
            }
        }

    },
    props: ["isShow", "employeeSelected", "employeeIdSelected", "formMode"],
    watch: {
        employeeSelected: function (value) {
            this.employee = value;
        },
        /**
         * Lấy thông tin employee
         * Author: BTLINH(19/08/2023) 
         */
        employeeIdSelected: function (value) {
            var me = this;
            if (value) {
                axios.get(`http://localhost:8080/api/v1/Employees/${me.employeeIdSelected}`)
                    .then(function (response) {
                        switch (response.status) {
                            case 200:
                                me.employee = response.data;
                                me.employee.dateOfBirth = me.formatDate(me.employee.dateOfBirth);
                                me.employee.identityDate = me.formatDate(me.employee.identityDate);
                                me.employee.joinDate = me.formatDate(me.employee.joinDate);
                                break;
                            case 201:
                                me.employee = {};
                                break;
                            default:
                                break;
                        }
                    })
                    .catch(function (response) {
                        switch (response.status) {
                            case 400:
                                alert("400");
                                break;
                            case 404:
                                alert("404");
                                break;
                            default:
                                break;
                        }
                    })
                    console.log("1");
            } else {
                me.employee = {};
                axios.get(`http://localhost:8080/api/v1/Employees/NewEmployeeCode`)
                    .then(function (response) {
                        me.employee.EmployeeCode = response.data;
                    })
                    .catch(function (response) {
                        switch (response.status) {
                            case 400:
                                alert("400");
                                break;
                            case 404:
                                alert("404");
                                break;
                            default:
                                break;
                        }
                    })
            }
        }
    },
    data() {
        return {
            //   isShow : false,  
            employee: {},
        };
    },
}
</script>

<style scoped>
@import "../../style/css/components/dialog.css";
@import "../../style/css/main.css";</style>