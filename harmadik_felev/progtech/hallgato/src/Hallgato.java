public class Hallgato {
    private String name;
    private String nationality;
    private double average;

    public Hallgato(){
        this.name = "Placeholder";
        this.nationality = "Placeholder";
        this.average = 0.0;
    }

    public Hallgato(String name, String nationality, double average){
        this.name = name;
        this.nationality = nationality;
        this.average = average;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getNationality() {
        return nationality;
    }

    public void setNationality(String nationality) {
        this.nationality = nationality;
    }

    public double getAverage() {
        return average;
    }

    public void setAverage(double average) {
        this.average = average;
    }
}
