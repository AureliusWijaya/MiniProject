// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const navbar = document.querySelector('.navbar');
const hamburger = document.querySelector('.navbar-extra');
const navbar2 = document.querySelector('.navbar2');

hamburger.onclick = () => {
    hamburger.classList.toggle('active-menu');
    navbar.classList.toggle('active-nav');
    navbar2.classList.toggle('active-nav2');

}

document.addEventListener('click', function (e) {
    if (!hamburger.contains(e.target) && (!navbar.contains(e.target) && !navbar2.contains(e.target))) {
        navbar.classList.remove('active-nav');
        navbar2.classList.remove('active-nav2');
    }
});

const buttonRegister = document.querySelector(".btnRegister");

function isAlNum(password) {
    if (password.length < 5) {
        return false;
    }

    var isNum = false;
    var isAlpha = false;

    for (var i = 0; i < password.length; i++) {
        if (isNaN(password[i])) {
            isAlpha = true;
        } else {
            isNum = true;
        }
    }
    if (isAlpha == true && isNum == true) {
        return true;
    } else {
        return false;
    }
}

function validateFormRegister(event) {

    var name = document.getElementById("username").value;
    var email = document.getElementById("emailRegister").value;
    var password = document.getElementById("passwordRegister").value;
    var acc = document.getElementById("ConfirmpasswordRegister").value;
    var checkbox = document.getElementById("agree").checked;

    var error_msg_register_email = document.getElementById(
        "error_msg_register_email"
    );
    var error_msg_register_password = document.getElementById(
        "error_msg_register_password"
    );
    var error_msg_register_name = document.getElementById(
        "error_msg_register_name"
    );
    var error_msg_register_acc = document.getElementById(
        "error_msg_register_acc"
    );
    var error_msg_register_ToS = document.getElementById(
        "error_msg_register_ToS"
    );

    let cekPW = 0;
    let cekName = 0;
    let cekAcc = 0;
    let cekEmail = 0;
    let cekToS = 0;

    if (email === "") {
        cekEmail = 0;
        error_msg_register_email.innerText = "email still empty";
    } else if (!email.endsWith("@gmail.com")) {
        cekEmail = 0;
        error_msg_register_email.innerText = "wrong email";
    } else {
        cekEmail = 1;
        error_msg_register_email.innerText = "";
    }

    if (!isAlNum(password) || password.length < 8) {
        cekPW = 0;
        error_msg_register_password.innerText = "password[>=8] minimal 1 AlphaNum";
    } else {
        cekPW = 1;
        error_msg_register_password.innerText = "";
    }
    if (password.localeCompare(acc) != 0) {
        cekAcc = 0;
        error_msg_register_acc.innerText = "password not identical";
    } else {
        cekAcc = 1;
        error_msg_register_acc.innerText = "";
    }

    if (name === "") {
        cekName = 0;
        error_msg_register_name.innerText = "name is empty";
    } else {
        cekName = 1;
        error_msg_register_name.innerText = "";
    }

    if (!checkbox) {
        cekToS = 0;
        error_msg_register_ToS.innerText = "you need agree to ToS";
    } else {
        cekToS = 1;
        error_msg_register_ToS.innerText = "";
    }

    if (cekEmail == 1 && cekPW == 1 && cekName == 1 && cekAcc == 1 && cekToS == 1) {
        event.target.submit();
    }
    else {
        event.preventDefault();
    }


}

const buttonLogin = document.querySelector(".btnLogin");

function validateFormLogin(event) {


    var email = document.getElementById("emailLogin").value;
    var password = document.getElementById("passwordLogin").value;
    var checkbox = document.getElementById("agree").checked;

    var error_msg_login_email = document.getElementById("error_msg_login_email");
    var error_msg_login_password = document.getElementById(
        "error_msg_login_password"
    );

    let cekPW = 0;
    let cekEmail = 0;

    if (email.trim() === "") {
        cekEmail = 0;
        error_msg_login_email.innerText = "email still empty";
    } else if (!email.endsWith("@gmail.com")) {
        cekEmail = 0;
        error_msg_login_email.innerText = "wrong email";
    } else {
        cekEmail = 1;
        error_msg_login_email.innerText = "";
    }

    if (password.trim() === "") {
        cekPW = 0;
        error_msg_login_password.innerText = "empty pw";
    } else {
        cekPW = 1;
        error_msg_login_password.innerText = "";
    }

    var val = 0;
    if (cekEmail === 1 && cekPW === 1) {
        val = 1;
    } else {
        val = 0;
    }

    if (val === 1) {
        event.target.submit();
    }
    else {
        event.preventDefault();
    }

}
