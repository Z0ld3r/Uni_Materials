const sugar = document.querySelector("#sugar")
const szamol = document.querySelector("#szamol")
const output = document.querySelector("#kerulet")


function kerulet(r) {
    return 2 * r * Math.PI;
}





function kattintas() {

    const r = parseFloat(sugar.value)
    const ker = kerulet(r)



    const hibas = isNaN(r)

    sugar.classList.toggle("hibas", hibas)
    if (hibas) {
        output.innerHTML = ""
        return
    }


    output.innerHTML = ker

}

szamol.addEventListener("click", kattintas)