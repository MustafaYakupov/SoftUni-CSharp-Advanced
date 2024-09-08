import java.util.Scanner;

public class P14FitStringIn20Chars {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();
        String result = "";

        if (text.length() == 20) {
            result = text;
        } else if (text.length() < 20) {
            int diff = 20 - text.length();
            result = text;

            for (int i = 0; i < diff; i++) {
            result += "*";
            }
        } else if (text.length() > 20) {

            result = text.substring(0, 20);
        }
        System.out.println(result);
    }
}
