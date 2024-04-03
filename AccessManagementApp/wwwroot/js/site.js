var uname = document.querySelector("#user_name");
var email = document.querySelector("#email");
var password = document.querySelector("#password");
var new_pass = document.querySelector("#new_pass");
var role = document.querySelector("#role");

var btn = document.querySelector("#submit");
var btn_pass = document.querySelector("#update");
var btn_add = document.querySelector("#add");
var btn_pass = document.querySelector("#update");
var btn_add = document.querySelector("#add");
var respArea = document.querySelector("#resp-area");
let ut;

btn.onclick = function (ev) {
        fetch("/", {
            method: "POST",
            body: JSON.stringify({name: uname.value, email: email.value, password: password.value}),
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(res => res.json())
            .then(response => {
                console.log(response)
                if (response.code === 200) {
                    localStorage.setItem(ut, response.message)
                    console.log(ut)
                    window.location.replace("https://localhost:44397/actions")
                }
                else {
                    Resp(response.message);
                }

            }).catch(error => console.log(error));
}

function Resp(text) {
    respArea.classList.remove("inactive");
    respArea.classList.add("active");
    respArea.innerHTML = text;
}

