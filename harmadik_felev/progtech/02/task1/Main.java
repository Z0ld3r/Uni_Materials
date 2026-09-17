package task1;

import java.util.List;
import java.util.Optional;
import java.util.Random;
import java.util.function.Predicate;

public class Main {
    public static void main(String[] args) {
        List<Character> characters = List.of(
                new Berserker("Tibor", 200, 50),
                new Defender("Turbo", 200, 50),
                new BlackDragon("asd", 200, 50),
                new MainCharacter("Tata", 300, 60, 3)
        );

        Random rand = new Random();
        Predicate<List<Character>> fightIsOver = fighters ->
                fighters.stream()
                        .filter(Character::isAlive)
                        .count() <= 1;

        do {
            for (int i = 0; i < characters.size(); ++i) {
                if (!characters.get(i).isAlive()) {
                    continue;
                }
                int targetIndex;
                do {
                    targetIndex = rand.nextInt(characters.size());
                } while (targetIndex == i);
                characters.get(i).attack(characters.get(targetIndex));
            }
        } while (!fightIsOver.test(characters));

        Optional<Character> winner = characters.stream()
                .filter(Character::isAlive)
                .findFirst();
        winner.ifPresent(character -> System.out.println(character.getName()));
    }
}

