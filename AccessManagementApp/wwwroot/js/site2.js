var uname = document.querySelector("#user_name");
var email = document.querySelector("#email");
var password = document.querySelector("#password");
var new_pass = document.querySelector("#new_pass");
var role = document.querySelector("#role");
var btn_pass = document.querySelector("#update");
var btn_add = document.querySelector("#add");
var btn_delete = document.querySelector("#delete");
var respArea = document.querySelector("#resp-area");
var respArea2 = document.querySelector("#resp-area2");


checkRole()

function checkRole() {

    if (localStorage.getItem(ut) == "admin")
        btn_delete.disabled = false;
}

btn_pass.onclick = function (ev) {
    fetch("/actions", {
        method: "PUT",
        body: JSON.stringify({ newp: new_pass.value }),
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(res => res.json())
        .then(response => {
            console.log(response)
            RespArea(respArea,response.message);
        }).catch(error => console.log(error));
}

btn_add.onclick = function (ev) {
    fetch("/actions", {
        method: "POST",
        body: JSON.stringify({ name: uname.value, email: email.value, password: password.value, role: role.value }),
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(res => res.json())
        .then(response => {
            console.log(response)
            RespArea(respArea2,response.message);
        }).catch(error => console.log(error));
}

btn_delete.onclick = function (ev) {
    fetch("/actions", {
        method: "DELETE",
        body: JSON.stringify({ name: uname.value, email: email.value, password: password.value, role: role.value }),
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(res => res.json())
        .then(response => {
            console.log(response)
            RespArea(respArea2, response.message);
        }).catch(error => console.log(error));
}

function RespArea(resp, text) {
    resp.classList.remove("inactive");
    resp.classList.add("active");
    resp.innerHTML = text;
}