const myName = document.querySelector("#name")
const myHello = document.querySelector("#hello")
const myOutput = document.querySelector("#output")

function greet() {
    myOutput.innerHTML = myName.value

}

myHello.addEventListener("click", greet)