import java.util.Scanner;

public class P02BooleanVariable {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();
        boolean bool = Boolean.valueOf(input);

        if (bool) {
            System.out.println("Yes");
        } else {
            System.out.println("No");
        }
    }
}
