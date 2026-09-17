const taskA = document.querySelector('#taskA')
const taskB = document.querySelector('#taskB')
const taskC = document.querySelector('#taskC')
const taskD = document.querySelector('#taskD')
const taskE = document.querySelector('#taskE')

//Ezt még csak jövő héten tanuljuk: Megkeressük a HTML-dokumentumban a taskA/taskB, stb azonosítójú elemet querySelectorral, és eltároljuk a taskA változóban. A kért értékeket  kiírjuk a taskA/taskB azonosítójú HTML-elembe innerHTML segítségével.



// - a. (1 pont) A `taskA` azonosítójú elembe írd ki, hány út mentén található kórház.
taskA.innerHTML = data.roads.filter(road => road.hospital === true).length

// - b. (1 pont) A `taskB` azonosítójú elembe írd ki, hogy van-e napi 100000 autónál nagyobb forgalmat kiszolgáló út!
const bools = data.roads.some(road => road.traffic >= 100000)
if (bools) {
    taskB.innerHTML = "Van"
}
else {
    taskB.innerHTML = "Nincs"
}


// - c. (2 pont) A `taskC` azonosítójú elembe írd ki, milyen típusú út a `Franta utca`.
//     - Feltételezheted, hogy létezik ilyen.
//     - 1 részpont: Csak a típus indexének kiírása.
//     - 2 teljes pont: A típus teljes nevének kiírása.

taskC.innerHTML = data.roadtypes[data.roads.find(road => road.name === "Franta utca").type]

// - d. (3 pont) A `taskD` azonosítójú elembe írd ki, mekkora az átlagos napi forgalom a főutakon (`type: 1`).

let avg = 0
data.roads.map(road => avg = avg + road.traffic)
avg = avg / data.roads.length
taskD.innerHTML = Math.round(avg)

// - e. (3 pont) A `taskE` azonosítójú elembe listázd ki a terek neveit. Egy tér onnan ismerhető fel, hogy a nevében az utolsó szóköz utáni szó a `tér`, és az úttípus *Egyéb* (`type: 3`)

taskE.innerHTML = data.roads.filter(road => road.type === 3 && road.name.endsWith(" tér")).map(road => road.name)