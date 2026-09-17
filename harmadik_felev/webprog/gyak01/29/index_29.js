const temps = [3.4, 1.2, -0.7, -2, 20, 6]

// a. Válogasd ki azokat az értékeket, amikor fagyott!
//hagyományos kiválogatás tétel
/*function kivalogat(tempsData, feltetel) {
  const fagy = [];
  for (const t of tempsData) {
    if (feltetel(t)) {
      fagy.push(t);
    }
  }
  return fagy;
}
console.log(`Fagyos hőmérsékletek: ${kivalogat(temps, t => t < 0)}`);*/


// b. Mindegyik hőmérséklet érték végére fűzd oda a C szöveget!
//hagyományos for ciklus
/*for (let i = 0; i < temps.length; i++) {
  temps[i] += " C";
}*/

//Na, itt mi a hiba? javítsuk
/*temps.forEach((elem) => (elem + " C"))
console.log(temps)*/

// c. Add meg a legmagasabb hőmérséklet értéket!

// d. Add meg, hányszor ment a hőmérséklet 20 fok alá!

// e. Döntsd el, van-e 40 fok fölötti érték!

// f. Döntsd el, hogy mindegyik hőmérsékletérték pozitív-e!

// g. Add meg az első olyan értéket, amikor 10 fok fölé ment a hőmérséklet!



