package masodik_felev.prognyelvek(java).harmadik.magic.library;

public class Incantation {
    private String text;
    private int index;

    Incantation(String text, int index) {
        if (text == null) {
            throw new IllegalArgumentException();
        }
    }

    Incantation(Incantation masik) {
        this.index = masik.index;
        this.text = masik.text;
    }

    public int getIndex() {
        return index;
    }

    public String getText() {
        return text;
    }

    public void setIndex(int index) {
        this.index = index;
    }

    public boolean enchant(Incantation otherInc, boolean isPrepend) {
        String[] array = this.text.split("[,\\.\\s]");
        if (array.length > this.index - 1 || this.index < 0) {
            return false;
        }
        if (isPrepend) {
            otherInc.text = array[index - 1] + " " + otherInc.text;
            index++;
        } else {
            otherInc.text = otherInc.text + " " + array[index - 1];
            index--;
        }
        return true;

    }
}
