import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class P10IndexOfLetters {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String word = scanner.nextLine();

        ArrayList<Character> alphabet = new ArrayList<Character>();

        for (int i = 'a'; i <= 'z'; i++) {
            alphabet.add((char) i);
        }

        for (char letter : word.toCharArray()) {
            System.out.printf("%s -> %s \n", letter, alphabet.indexOf(letter));
        }
    }
}
