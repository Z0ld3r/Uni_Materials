package zoo.animal;

public class Panda {
    public String nev;
    public int kor;
    public String country;

    public Panda(String nev, String country) {
        this.nev = nev;
        this.country = country;
        this.kor = 0;
    }

    public Panda(String nev, String country, int kor) {
        this.nev = (kor + " years old foundling from " + country + ".\n");
        this.kor = kor;
        this.country = country;
    }

    public void happyBirthday(int limitYear) {
        kor += 1;
        System.out.println("Hello, I am " + nev + " and I am " + kor + " years old from " + country + ".\n");
        if (kor >= limitYear) {
            System.out.println("I have reached the age of " + limitYear + " and thus have been deported to China.\n");
        }
    }
}
