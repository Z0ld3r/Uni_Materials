package cards;

public final class FaceCard extends Card {
    private final Face face;

    public FaceCard(Suit suit, Face face) {
        super(suit);
        if (face == null) {
            throw new IllegalArgumentException("Face cannot be null.");
        }
        this.face = face;

    }

    public Face getFace() {
        return face;
    }

    @Override
    public String toString() {
        return face + " of " + getSuit();
    }

    @Override
    public int categoryRank() {
        return 1;
    }

    @Override
    public int innerRank() {
        return face.ordinal();
    }

    @Override
    public FaceCard clone() {
        return new FaceCard(getSuit(), face);
    }

}
