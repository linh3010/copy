<template>
    <div class="navbar">
        <a class="menu-item">
            <div class="menu-icon m-icon m-icon-dashboard"></div>
            <div class="menu-item">Tổng quan</div>
        </a>
        <router-link class="menu-item" to="/employee">
            <div class="menu-icon m-icon m-icon-employee "></div>
            <div class="menu-item">Danh sách nhân viên</div>
        </router-link>
        <router-link class="menu-item" to="/report">
            <div class="menu-icon m-icon m-icon-document"></div>
            <div class="menu-item">Báo cáo</div>
        </router-link>
        <a class="menu-item">
            <div class="menu-icon m-icon m-icon-setting"></div>
            <div class="menu-item">Cài đặt</div>
        </a>
    </div>
</template>
<script>
export default{

}
</script>
<style scoped>
@import url(../../style/css/layout/navbar.css);
@import url(../../style/css/components/icon.css);
</style>