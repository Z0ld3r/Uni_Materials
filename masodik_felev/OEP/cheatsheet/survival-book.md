# 📘 OEP Survival Book – C# ZH-ra

> Minden fontos objektumelvű programozási koncepció egy helyen, kódpéldákkal és UML-kapcsolatokkal.

Ajánlom hogy VSCode-ban nyissátok meg a file-t és ott nyomjatok rá a preview-ra (jobbra a felül a file-októl). (Ha nincs meg a gomb akkor Ctrl+K (pillanatot várj) és utána V)

---

## Tartalomjegyzék

1. [Láthatóság: public, private, protected](#1-láthatóság)
2. [Osztályok, adattagok, getter/setter](#2-osztályok-adattagok-gettersetter)
3. [Konstruktor és base() hívás](#3-konstruktor-és-base-hívás)
4. [static, virtual, abstract, override](#4-static-virtual-abstract-override)
5. [Leszármaztatás és öröklés](#5-leszármaztatás-és-öröklés)
6. [Singleton minta](#6-singleton-minta)
7. [Adatszerkezetek C#-ban](#7-adatszerkezetek-c-ban)
8. [Programozási minták (összegzés, keresés stb.)](#8-programozási-minták)
9. [LINQ](#9-linq)
10. [UML → Kód megfeleltetés](#10-uml--kód-megfeleltetés)
12. [MSTest alapok](#12-mstest-alapok)
13. [Saját Exception létrehozása](#13-saját-exception-létrehozása)
14. [Aszinkron vezérlés – Thread alapok](#14-aszinkron-vezérlés--thread-alapok)
11. [Egyéb UML elemek](#11-egyéb-uml-elemek)

---

## 1. Láthatóság

| Kulcsszó    | Elérhető innen                              |
|-------------|----------------------------------------------|
| `public`    | Bárhonnan                                    |
| `private`   | Csak az adott osztályból                     |
| `protected` | Az osztályból és az összes leszármazottjából |

```csharp
public class Animal
{
    private int hp;           // csak az Animal látja
    protected int damage;     // Animal + leszármazottak látják
    public string Name;       // mindenki látja
}
```

**UML-ben:**
- `+` → public
- `-` → private
- `#` → protected

---

## 2. Osztályok, adattagok, getter/setter

Az adattag **kis betűvel** kezdődik, a getter/setter **nagy betűvel** – külön property-ként.

```csharp
public class Animal
{
    // adattagok (private, kis betűs)
    private int hp;
    private int damage;

    // Getter + Setter property (nagy betűs, külön)
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
}
```

**UML-ben** a getter/setter általában így jelenik meg:
```
- hp : int {getter, setter}
```
Ez azt jelenti, hogy az `hp` adattaghoz van publikus `Hp` getter és setter. (Általában így kéri a feladat, de fontos megnézni a teszteket)

---

## 3. Konstruktor és base() hívás

### Alap konstruktor

```csharp
public class Animal
{
    private int hp;
    private int damage;

    public Animal(int hp, int damage)
    {
        this.hp = hp;
        this.damage = damage;
    }
}
```

### Leszármazott konstruktora – base() hívás

Ha a szülőnek van paraméteres konstruktora, a gyerek a `base()` kulcsszóval hívja meg.

```csharp
public class Dog : Animal
{
    private string breed;

    public Dog(int hp, int damage, string breed) : base(hp, damage)
    {
        this.breed = breed;
    }
}
```

**UML-ben** a konstruktor így néz ki:
```
+ Dog(hp : int, damage : int, breed : string)
```
A `: base(...)` hívás nem jelenik meg az UML-ben, de kódban kötelező, ha a szülőnek nincs paraméter nélküli konstruktora.

---

## 4. static, virtual, abstract, override

### `static`
Az osztályhoz tartozik, nem a példányhoz. Singleton-nál és segédfüggvényeknél használjuk.

```csharp
public class MathHelper
{
    public static int Add(int a, int b) => a + b;
}

// Hívás: példány nélkül
int result = MathHelper.Add(3, 5);
```

### `virtual`
A szülőben definiált metódus, amit a gyerek **felülírhat** (`override`), de nem köteles.

```csharp
public class Animal
{
    public virtual void Attack()
    {
        Console.WriteLine("Generic attack");
    }
}
```

### `override`
A leszármazott felülírja a szülő `virtual` (vagy `abstract`) metódusát.

```csharp
public class Dog : Animal
{
    public override void Attack()
    {
        Console.WriteLine("Dog bites!");
    }
}
```

### `abstract`
- **Abstract metódus:** nincs implementáció, a leszármazottnak kötelező megvalósítani.
- **Abstract osztály:** nem példányosítható, csak örökölhető.

```csharp
public abstract class Shape
{
    public abstract double Area();  // nincs törzs!

    public void Print()             // lehet nem-abstract metódus is
    {
        Console.WriteLine("Area: " + Area());
    }
}

public class Circle : Shape
{
    private double radius;

    public Circle(double radius) { this.radius = radius; }

    public override double Area() => Math.PI * radius * radius;
}
```

**UML-ben:**
- Abstract osztály: `<<abstract>>` sztereotípia vagy dőlt osztálynév
- Abstract metódus: dőlt betű, vagy `{abstract}` megjegyzés
- Virtual metódus: `{virtual}` megjegyzés

```
<<abstract>>
Shape
+ Area() : double {abstract}
+ Print() : void
```

---

## 5. Leszármaztatás és öröklés

```csharp
public class Animal           // szülő (base class)
{
    protected int hp;
    protected int damage;

    public Animal(int hp, int damage)
    {
        this.hp = hp;
        this.damage = damage;
    }

    public virtual void Attack() { /* ... */ }
}

public class Cat : Animal     // gyerek (derived class)
{
    private bool indoor;

    public Cat(int hp, int damage, bool indoor) : base(hp, damage)
    {
        this.indoor = indoor;
    }

    public override void Attack()
    {
        Console.WriteLine("Cat scratches!");
    }
}
```

**UML-ben** az öröklés egy üres háromszögű nyíl a gyerektől a szülő felé:
```
Cat ──▷ Animal
```

### Több szint

```csharp
public class Kitten : Cat
{
    public Kitten(int hp, int damage) : base(hp, damage, true) { }
}
```

### Fontos szabályok

- C#-ban **egyetlen szülőosztályból** lehet örökölni (nincs többszörös öröklés osztályoknál).
- Ha a szülőnek nincs paraméter nélküli konstruktora, a `base(...)` hívás **kötelező**.
- `override` csak `virtual` vagy `abstract` metódusnál használható.

---

## 6. Singleton minta

A Singleton biztosítja, hogy egy osztályból **csak egy példány** létezzen. Az UML-ben `<<singleton>>` sztereotípiával jelölik.

> `sealed class` – nem lehet belőle leszármaztatni.

### 1. változat – lazy inicializálás (null-check)

```csharp
public class GameManager
{
    // Az egyetlen példány (private static)
    private static GameManager instance;

    // Private konstruktor – kívülről nem példányosítható
    private GameManager() { }

    // Publikus elérési pont
    public static GameManager Instance()
    {
        if (instance == null)
            instance = new GameManager();
        return instance;
    }

    // Példa adattag
    private int score = 0;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }
}
```

**Használat:**
```csharp
GameManager.Instance().Score = 100;
int s = GameManager.Instance().Score;
```

### 2. változat – eager inicializálás (readonly, sealed)

```csharp
public sealed class Batman
{
    // Fordításkor létrejön az egyetlen példány
    private static readonly Batman _instance = new Batman();

    // Kétféle szintaxis – válaszd az egyiket:
    public static Batman Instance => _instance;       // property
    // public static Batman Instance() => _instance;  // metódus

    // Példa adattag
    private Allies allies;

    // Privát konstruktor
    private Batman()
    {
        allies = new Allies();
    }
}
```

**Használat:**
```csharp
Batman.Instance.Allies.Lucius();
// Batman.Instance().Allies.Lucius();  // ha metódus változatot használtad
```

**UML jelölés:**
```
<<singleton>>
GameManager
- instance : GameManager
- score : int {getter, setter}
- GameManager()
+ Instance() : GameManager
```

---

## 7. Adatszerkezetek C#-ban

### 7.1 Array (tömb)

Rögzített méretű, gyors indexelés. Ritkán szerepel UML-ben közvetlenül.

```csharp
int[] numbers = new int[5];
numbers[0] = 10;

string[] names = { "Alice", "Bob", "Charlie" };
int len = names.Length;
```

**UML-ben:** `int[]` vagy `string[]` típusként jelenik meg.

---

### 7.2 List\<T\>

Dinamikus méretű lista – a leggyakoribb gyűjtemény.

```csharp
List<string> names = new List<string>();
names.Add("Alice");
names.Add("Bob");
names.Remove("Alice");
names.RemoveAt(0);
int count = names.Count;
bool has = names.Contains("Bob");

// Indexelés
string first = names[0];

// Bejárás
foreach (string name in names)
    Console.WriteLine(name);
```

**UML-ben:** `List<Animal>` vagy `Animal*` (csillag = 0..sok kapcsolat a kompozíciónál).

---

### 7.3 IList\<T\>

Az `IList<T>` egy **interfész** – a `List<T>` ezt valósítja meg. Akkor érdemes használni, ha rugalmasságot szeretnénk (pl. a metódus bármilyen lista-szerű gyűjteményt elfogad).

```csharp
public void PrintAll(IList<string> items)
{
    foreach (string item in items)
        Console.WriteLine(item);
}

// Hívható List<string>-gel:
List<string> myList = new List<string> { "a", "b" };
PrintAll(myList);
```

**Főbb IList metódusok:** `Add`, `Remove`, `RemoveAt`, `Contains`, `Count`, `[]` indexelő.

---

### 7.4 Dictionary\<TKey, TValue\>

Kulcs-érték párok. Gyors keresés kulcs alapján.

```csharp
Dictionary<string, int> scores = new Dictionary<string, int>();
scores["Alice"] = 95;
scores["Bob"] = 80;

// Biztonságos lekérés
if (scores.ContainsKey("Alice"))
    Console.WriteLine(scores["Alice"]);

// Bejárás
foreach (KeyValuePair<string, int> pair in scores)
    Console.WriteLine(pair.Key + ": " + pair.Value);

scores.Remove("Bob");
int count = scores.Count;
```

---

### 7.5 HashSet\<T\>

Egyedi elemek halmaza – nincs duplikált elem, nincs sorrend.

```csharp
HashSet<string> visited = new HashSet<string>();
visited.Add("Forest");
visited.Add("Forest");  // nem kerül be kétszer
bool seen = visited.Contains("Forest");  // true
visited.Remove("Forest");
```

---

### 7.6 Queue\<T\> (sor)

FIFO – First In, First Out. Sorban állás logika.

```csharp
Queue<string> queue = new Queue<string>();
queue.Enqueue("Alice");
queue.Enqueue("Bob");
string next = queue.Dequeue();   // "Alice"
string peek = queue.Peek();      // "Bob" (nem veszi ki)
int count = queue.Count;
```

---

### 7.7 Stack\<T\> (verem)

LIFO – Last In, First Out. Visszavonás logika.

```csharp
Stack<string> stack = new Stack<string>();
stack.Push("Alice");
stack.Push("Bob");
string top = stack.Pop();    // "Bob"
string peek = stack.Peek();  // "Alice" (nem veszi ki)
```

---

### Összefoglaló táblázat

| Típus              | Rendezett | Duplikált | Kulcs alapú | Tipikus használat          |
|--------------------|-----------|-----------|-------------|----------------------------|
| `Array`            | ✅        | ✅        | ❌          | Rögzített méretű adat      |
| `List<T>`          | ✅        | ✅        | ❌          | Dinamikus lista            |
| `Dictionary<K,V>`  | ❌        | ❌ (kulcs)| ✅          | Keresés kulcs alapján      |
| `HashSet<T>`       | ❌        | ❌        | ❌          | Egyediség ellenőrzés       |
| `Queue<T>`         | ✅ (FIFO) | ✅        | ❌          | Sorban feldolgozás         |
| `Stack<T>`         | ✅ (LIFO) | ✅        | ❌          | Visszavonás, mélységkeresés|

---

## 8. Programozási minták

Minden mintánál megmutatjuk a **for ciklusos** és **LINQ-s** megoldást is.

> **Feltételezés:** van egy `List<Animal> animals` listánk, ahol az `Animal`-nak van `Hp` és `Damage` propertye és `Name` stringje.

---

### 8.1 Összegzés

**For ciklussal:**
```csharp
int sum = 0;
foreach (Animal a in animals)
    sum += a.Hp;
```

**LINQ-val:**
```csharp
int sum = animals.Sum(a => a.Hp);
```

**UML-ben:**
```
return SUM a.Hp
a in animals
```

---

### 8.2 Megszámlálás (feltétellel)

**For ciklussal:**
```csharp
int count = 0;
foreach (Animal a in animals)
    if (a.Hp > 50)
        count++;
```

**LINQ-val:**
```csharp
int count = animals.Count(a => a.Hp > 50);
```

**UML-ben:**
```
return SUM 1  a.Hp > 50
a in animals
```

---

### 8.3 Maximum/Minimum keresés

**For ciklussal (max elem visszaadása):**
```csharp
Animal strongest = null;
foreach (Animal a in animals)
    if (strongest == null || a.Damage > strongest.Damage)
        strongest = a;
```

**LINQ-val:**
```csharp
Animal strongest = animals.MaxBy(a => a.Damage);
// vagy régebbi .NET-en:
Animal strongest = animals.OrderByDescending(a => a.Damage).FirstOrDefault();
```

**UML-ben:**
```
return (l,_elem) = MAX a.Damage
a in animals
```

---

### 8.4 Keresés (feltétel szerinti elem)

**For ciklussal:**
```csharp
Animal found = null;
foreach (Animal a in animals)
    if (a.Name == "Rex")
    {
        found = a;
        break;
    }
```

**LINQ-val:**
```csharp
Animal found = animals.FirstOrDefault(a => a.Name == "Rex");
```

**UML-ben:**
```
(t,s) = SEARCH s.Hp > 50
s in animals
```

---

### 8.5 Szűrés (feltételnek megfelelő elemek listája)

**For ciklussal:**
```csharp
List<Animal> weakAnimals = new List<Animal>();
foreach (Animal a in animals)
    if (a.Hp < 20)
        weakAnimals.Add(a);
```

**LINQ-val:**
```csharp
List<Animal> weakAnimals = animals.Where(a => a.Hp < 20).ToList();
```

---

### 8.6 Mind teljesíti-e a feltételt? (Eldöntés)

**For ciklussal:**
```csharp
bool allStrong = true;
foreach (Animal a in animals)
    if (a.Hp <= 0)
    {
        allStrong = false;
        break;
    }
```

**LINQ-val:**
```csharp
bool allStrong = animals.All(a => a.Hp > 0);
bool anyWeak   = animals.Any(a => a.Hp <= 0);
```

---

### 8.7 Legkisebb elem (MinBy)

**For ciklussal:**
```csharp
Animal weakest = null;
foreach (Animal a in animals)
    if (weakest == null || a.Hp < weakest.Hp)
        weakest = a;
```

**LINQ-val:**
```csharp
Animal weakest = animals.MinBy(a => a.Hp);
```

**UML-ben:**
```
return (l,_elem) = MIN s.Rounds
s in simulations
s.BatmanLost
```
(Ez azt jelenti: a `BatmanLost == true` feltételű szimulációk közül a legkisebb `Rounds` értékű.)

---

## 9. LINQ

A LINQ (Language Integrated Query) lehetővé teszi, hogy gyűjteményeken lekérdezéseket írjunk tömören.

### Legfontosabb LINQ metódusok

```csharp
List<Animal> animals = /* ... */;

// Szűrés
animals.Where(a => a.Hp > 0)

// Kiválasztás (transzformáció)
animals.Select(a => a.Name)

// Összegzés
animals.Sum(a => a.Damage)
animals.Count()
animals.Count(a => a.Hp > 50)
animals.Min(a => a.Hp)
animals.Max(a => a.Damage)
animals.Average(a => a.Hp)

// Keresés
animals.FirstOrDefault(a => a.Name == "Rex")  // null ha nincs
animals.Any(a => a.Hp > 100)                  // bool
animals.All(a => a.Hp > 0)                    // bool

// Rendezés
animals.OrderBy(a => a.Hp)
animals.OrderByDescending(a => a.Damage)

// Maximális/minimális elem visszaadása (.NET 6+)
animals.MaxBy(a => a.Damage)
animals.MinBy(a => a.Hp)

// Lista konvertálás
animals.Where(a => a.Hp > 0).ToList()
```

### Láncolás (method chaining)

```csharp
List<string> names = animals
    .Where(a => a.Hp > 50)
    .OrderBy(a => a.Name)
    .Select(a => a.Name)
    .ToList();
```

---

## 10. UML → Kód megfeleltetés

### Osztály diagram elemek

```
<<abstract>>
Animal
- hp : int {getter, setter}
- damage : int {getter}
+ Animal(hp : int, damage : int)
+ TakeDamage(amount : int) : void {virtual}
+ Attack() : void {abstract}
```

**Megfelelő C# kód:**
```csharp
public abstract class Animal
{
    private int hp;
    private int damage;

    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public int Damage
    {
        get { return damage; }
        // nincs setter, mert az UML-ben csak {getter} szerepel
    }

    public Animal(int hp, int damage)
    {
        this.hp = hp;
        this.damage = damage;
    }

    public virtual void TakeDamage(int amount)
    {
        hp -= amount;
    }

    public abstract void Attack();
}
```

---

### Kapcsolatok UML-ben

| UML jel | Jelentés | Kódban |
|---------|----------|--------|
| `──▷`  (üres nyíl) | Öröklés (is-a) | `class Dog : Animal` |
| `- - -▷` (szaggatott üres nyíl) | Megvalósítás (interfész) | `class Dog : IAnimal` |
| `──◆` (teli rombusz) | Kompozíció (erős "részem") | Tagváltozó, konstruktorban `new` |
| `──◇` (üres rombusz) | Aggregáció (gyenge "részem") | Tagváltozó, kívülről kap referenciát |
| `──` (egyszerű vonal) | Asszociáció | Tagváltozó |
| `1`, `*`, `0..1` | Multiplicitás | Egy példány vs. `List<T>` |

### Multiplicitás → kód

```
Kennel "1" ──◆ "*" Dog
```
```csharp
public class Kennel
{
    private List<Dog> dogs = new List<Dog>();  // "*" = lista
}
```

```
Person "0..1" ──◇ "1" House
```
```csharp
public class Person
{
    private House? home;  // 0..1 = lehet null
}
```

---

### Megjegyzés-blokkok (UML note)

A sárga/fehér téglalap megjegyzések pszeudokódot tartalmaznak. Ezeket kell C#-ra fordítani.

**UML megjegyzés:**
```
hp := hp - amount
if hp <= 0
    Simulation.DeleteEnemy(this)
```

**C# kód:**
```csharp
public override void TakeDamage(int amount)
{
    hp -= amount;
    if (hp <= 0)
        simulation.DeleteEnemy(this);
}
```

---

### Sztereotípiák

| UML sztereotípia | Jelentés |
|------------------|----------|
| `<<abstract>>`   | Abstract osztály |
| `<<singleton>>`  | Singleton minta |
| `<<interface>>`  | Interfész |

---

## 11. Egyéb UML elemek

### Interfész megvalósítás

Ha az UML-ben `<<interface>>` látható és szaggatott nyíl mutat rá, az osztálynak meg kell valósítania az interfészt.

```csharp
public interface IAttackable
{
    void TakeDamage(int amount);
    void Attack();
}

public class Dog : Animal, IAttackable
{
    public override void TakeDamage(int amount) { /* ... */ }
    public override void Attack() { /* ... */ }
}
```

---

### Kompozíció (erős kapcsolat)

A komponens az összetett osztály "része" – ha a szülő megszűnik, a gyerek is.

```csharp
public class Kennel
{
    private List<Dog> dogs;

    public Kennel()
    {
        dogs = new List<Dog>();  // a Kennel hozza létre
    }

    public void AddDog(Dog d) => dogs.Add(d);
}
```

**UML-ben:** teli rombusz (`◆`) a szülőnél.

---

### Aggregáció (gyenge kapcsolat)

A komponens a szülőn kívül is létezhet.

```csharp
public class Team
{
    private List<Player> members;  // a Player-ek kívülről érkeznek

    public Team(List<Player> members)
    {
        this.members = members;
    }
}
```

**UML-ben:** üres rombusz (`◇`) a szülőnél.

---

### Nullable típusok (`?`)

Ha egy változó értéke `null` is lehet, a típus után `?`-et írunk.

**Értéktípusoknál** (int, bool, double stb.) alapból nem lehet null – a `?` teszi nullozhatóvá:
```csharp
int? age = null;
bool? isReady = null;

if (age.HasValue)
    Console.WriteLine(age.Value);
```

**Referencia típusoknál** (osztályok) a `?` jelzi, hogy az érték `null` lehet:
```csharp
private Animal? pet;       // lehet null
private string? nickname;  // lehet null

public Animal? FindAnimal(string name)
{
    return animals.FirstOrDefault(a => a.Name == name);
}
```

**UML-ben** a `0..1` multiplicitás felel meg a nullable referenciának:
```
Person "0..1" ──◇ "1" House
```
```csharp
private House? home;  // lehet null, ha a Person hajléktalan
```

**Null-kezelési operátorok:**
```csharp
// Null-conditional (?.)  – csak ha nem null, hívja meg
pet?.Attack();

// Null-coalescing (??) – ha null, adj alapértéket
string name = nickname ?? "Névtelen";

// Null-coalescing assignment (??=) – csak akkor állít be, ha null
nickname ??= "Névtelen";
```

---

### Metódus visszatérési értéke és paraméterei

```
+ MakeSimulation(enemies : Enemy*, id : int, hp : int, damage : int) : void
```

```csharp
public void MakeSimulation(List<Enemy> enemies, int id, int hp, int damage)
{
    // ...
}
```

> Az `Enemy*` az UML-ben azt jelenti: `List<Enemy>` vagy `Enemy[]`.

---

### bool visszatérési érték feltétellel

```
+ StrongestVillain() : bool x Villain
```

Ez egy **tuple** visszatérési értéket jelent:

```csharp
public (bool, Villain) StrongestVillain()
{
    // ...
    return (true, strongest);
}
```

Vagy egyszerűbb esetben `out` paraméterrel:
```csharp
public bool StrongestVillain(out Villain result)
{
    // ...
}
```

---

### Statikus metódus UML-ben

Az **aláhúzott** metódus/adattag statikus:

```
<u>+ Instance() : GameManager</u>
```

```csharp
public static GameManager Instance() { /* ... */ }
```

---

### DeleteEnemy / Remove minta

Amikor az UML-ben látható, hogy egy objektum saját magát törli a listából:

```
hp := hp - amount
if hp <= 0
    Simulation.DeleteEnemy(this)
```

```csharp
// Az Enemy-ben:
public override void TakeDamage(int amount)
{
    hp -= amount;
    if (hp <= 0)
        simulation.DeleteEnemy(this);
}

// A Simulation-ban:
public void DeleteEnemy(Enemy e)
{
    enemies.Remove(e);
}
```

---

### Pszeudokód fordítási gyorsreferencia

| UML pszeudokód | C# |
|----------------|-----|
| `x := y` | `x = y;` |
| `x := x + 1` | `x++;` |
| `if x <= 0` | `if (x <= 0)` |
| `for i in 1..n loop` | `for (int i = 1; i <= n; i++)` |
| `forall p in list loop` | `foreach (var p in list)` |
| `return SUM e.Damage e in list` | `return list.Sum(e => e.Damage);` |
| `return SUM 1 feltétel e in list` | `return list.Count(e => feltétel);` |
| `(l,_) = MAX e.Hp e in list` | `var l = list.MaxBy(e => e.Hp);` |
| `(t,s) = SEARCH s.Hp > 3 s in list` | `var (t,s) = list.First(s => s.Hp > 3);` |
| `list.Add(new X(...))` | `list.Add(new X(...));` |
| `list.Remove(x)` | `list.Remove(x);` |
| `list.RemoveRange(0, amount)` | `list.RemoveRange(0, amount);` |
| `x ⊕ y` | `x.AddRange(y);` vagy `x = x.Concat(y).ToList();` |

---


---

## 12. MSTest alapok

Az MSTest a C# beépített unit tesztelési keretrendszere. A tesztek külön projektben élnek, és az éles kódot ellenőrzik.

### Alapstruktúra

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]                          // jelöli, hogy ez egy tesztosztály
public class AnimalTests
{
    [TestMethod]                     // jelöli, hogy ez egy tesztmetódus
    public void Attack_ReducesHp()
    {
        // Arrange – előkészítés
        Animal a = new Dog(100, 10, "Labrador");

        // Act – végrehajtás
        a.TakeDamage(30);

        // Assert – ellenőrzés
        Assert.AreEqual(70, a.Hp);
    }
}
```

### Assert metódusok

| Assert | Mit ellenőriz | Példa |
|--------|--------------|-------|
| `Assert.AreEqual(expected, actual)` | A két érték egyenlő-e | `Assert.AreEqual(70, a.Hp)` |
| `Assert.AreNotEqual(expected, actual)` | A két érték különböző-e | `Assert.AreNotEqual(0, a.Hp)` |
| `Assert.IsTrue(condition)` | A feltétel igaz-e | `Assert.IsTrue(a.Hp > 0)` |
| `Assert.IsFalse(condition)` | A feltétel hamis-e | `Assert.IsFalse(a.Hp < 0)` |
| `Assert.IsNull(obj)` | Az objektum null-e | `Assert.IsNull(result)` |
| `Assert.IsNotNull(obj)` | Az objektum nem null-e | `Assert.IsNotNull(a)` |
| `Assert.IsInstanceOfType(obj, typeof(T))` | Az objektum adott típusú-e | `Assert.IsInstanceOfType(a, typeof(Dog))` |
| `Assert.ThrowsException<T>(action)` | A kód dob-e adott exceptiont | lásd lent |

### Exception dobásának tesztelése

```csharp
[TestMethod]
public void TakeDamage_NegativeAmount_ThrowsException()
{
    Animal a = new Dog(100, 10, "Labrador");

    Assert.ThrowsException<ArgumentException>(() => a.TakeDamage(-5));
}
```

### Inicializálás és takarítás

```csharp
[TestClass]
public class AnimalTests
{
    private Dog dog;

    [TestInitialize]          // minden teszt ELŐTT lefut
    public void Setup()
    {
        dog = new Dog(100, 10, "Labrador");
    }

    [TestCleanup]             // minden teszt UTÁN lefut
    public void Teardown()
    {
        // erőforrások felszabadítása, ha kell
    }

    [TestMethod]
    public void Hp_StartsAt100()
    {
        Assert.AreEqual(100, dog.Hp);
    }
}
```

### Hibák értelmezése

| Hibaüzenet | Mit jelent | Hogyan javítsd |
|------------|-----------|----------------|
| `Assert.AreEqual failed. Expected:<70> Actual:<100>` | A várt és a kapott érték különbözik | Nézd meg, hogy a metódus valóban módosítja-e az értéket |
| `Assert.IsNotNull failed.` | Null-t kaptál, pedig nem kellett volna | A metódus nem ad vissza objektumot / nem inicializált valami |
| `Assert.IsTrue failed.` | A feltétel hamis lett | Az ellenőrzött állapot nem az, amire számítottál |
| `Assert.ThrowsException failed. No exception thrown.` | Nem dobott exceptiont a kód | A hibakezelés hiányzik az éles kódból |
| `System.NullReferenceException` a tesztben | Egy objektum null, amit használni akartál | `[TestInitialize]`-ban inicializáld az objektumokat |
| `Expected and actual type differ` (IsInstanceOfType) | Rossz típust kaptál vissza | Ellenőrizd az öröklési hierarchiát és a visszatérési típust |

---

## 13. Saját Exception létrehozása

A saját exception osztályok az `Exception` (vagy valamelyik leszármazottja, pl. `ArgumentException`) osztályból öröklnek.

### Alap saját exception

```csharp
public class InsufficientHpException : Exception
{
    // Paraméter nélküli konstruktor
    public InsufficientHpException()
        : base("Not enough HP to perform this action.") { }

    // Üzenettel
    public InsufficientHpException(string message)
        : base(message) { }

    // Üzenettel + belső exception (pl. ha más exceptiont csomagolsz be)
    public InsufficientHpException(string message, Exception inner)
        : base(message, inner) { }
}
```

### Használat – dobás

```csharp
public void Attack(Animal target)
{
    if (hp <= 0)
        throw new InsufficientHpException($"Animal has {hp} HP, cannot attack.");

    target.TakeDamage(damage);
}
```

### Elkapás

```csharp
try
{
    attacker.Attack(target);
}
catch (InsufficientHpException ex)
{
    Console.WriteLine("Hiba: " + ex.Message);
}
catch (Exception ex)           // általános fallback
{
    Console.WriteLine("Ismeretlen hiba: " + ex.Message);
}
finally
{
    // mindig lefut, akár volt exception, akár nem
    Console.WriteLine("Kör vége.");
}
```

### Extra adatot hordozó exception

```csharp
public class EnemyDeadException : Exception
{
    public string EnemyName { get; }
    public int FinalDamage { get; }

    public EnemyDeadException(string enemyName, int finalDamage)
        : base($"{enemyName} meghalt, utolsó sebzés: {finalDamage}")
    {
        EnemyName = enemyName;
        FinalDamage = finalDamage;
    }
}

// Elkapáskor kiolvasható:
catch (EnemyDeadException ex)
{
    Console.WriteLine(ex.EnemyName + " elpusztult!");
    Console.WriteLine("Sebzés volt: " + ex.FinalDamage);
}
```

### MSTest + saját exception

```csharp
[TestMethod]
public void Attack_DeadAnimal_ThrowsInsufficientHpException()
{
    Dog dog = new Dog(0, 10, "Labrador");

    Assert.ThrowsException<InsufficientHpException>(() => dog.Attack(new Cat(50, 5, true)));
}
```

---

## 14. Aszinkron vezérlés – Thread alapok

### Mi az a Thread?

A `Thread` egy párhuzamosan futó végrehajtási szál. Több thread egyszerre fut, egymástól függetlenül.

```csharp
using System.Threading;

Thread t = new Thread(() =>
{
    Console.WriteLine("Párhuzamos szál fut!");
    Thread.Sleep(1000);  // 1 másodpercet vár
    Console.WriteLine("Párhuzamos szál kész.");
});

t.Start();                    // elindítja a szálat
Console.WriteLine("Főszál folytatódik közben.");
t.Join();                     // megvárja, amíg t befejezi
Console.WriteLine("Minden kész.");
```

### Thread.Sleep

```csharp
Thread.Sleep(500);    // 500 ms szünetet tart az aktuális szálban
Thread.Sleep(0);      // azonnal engedi át a vezérlést más szálaknak
```

### lock – versenyfeltétel elkerülése

Ha több szál ugyanazt az adatot módosítja, `lock`-kal védjük a kritikus szakaszt.

```csharp
private static readonly object _lock = new object();
private int counter = 0;

public void Increment()
{
    lock (_lock)          // csak egy szál léphet be egyszerre
    {
        counter++;
    }
}
```

### async / await – aszinkron metódusok

A `Task`-alapú aszinkron programozás az újabb, ajánlott megközelítés (pl. I/O, hálózat).

```csharp
using System.Threading.Tasks;

public async Task<int> FetchDataAsync()
{
    await Task.Delay(1000);   // nem blokkolja a szálat, csak vár
    return 42;
}

// Hívása:
public async Task RunAsync()
{
    int result = await FetchDataAsync();
    Console.WriteLine("Eredmény: " + result);
}
```

### Task.Run – háttérszál indítása

```csharp
Task t = Task.Run(() =>
{
    Console.WriteLine("Háttér munka...");
});

await t;   // megvárja a Task befejezését
```

### Párhuzamos vs. aszinkron – mikor mit?

| Helyzet | Használj |
|---------|----------|
| CPU-intenzív munka (számítás, képfeldolgozás) | `Thread` vagy `Task.Run` |
| I/O várakozás (fájl, hálózat, adatbázis) | `async` / `await` |
| Egyszerű időzítés / alvás | `Thread.Sleep` vagy `await Task.Delay` |
| Több eredmény párhuzamos várakozása | `await Task.WhenAll(t1, t2, t3)` |

```csharp
// Több Task párhuzamos indítása és megvárása
Task t1 = Task.Run(() => DoWork(1));
Task t2 = Task.Run(() => DoWork(2));
await Task.WhenAll(t1, t2);
Console.WriteLine("Mindkettő kész.");
```

---

*Sok sikert a ZH-hoz! 🎯*