import java.util.Scanner;

public class P04VowelOrDigit {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String symbol = scanner.nextLine();

        if (symbol.equals("a") || symbol.equals("e") || symbol.equals("o")  || symbol.equals("u") || symbol.equals("i")) {
            System.out.println("vowel");
        } else if (symbol.matches("\\d")) {
            System.out.println("digit");
        } else {
            System.out.println("other");
        }
    }
}
