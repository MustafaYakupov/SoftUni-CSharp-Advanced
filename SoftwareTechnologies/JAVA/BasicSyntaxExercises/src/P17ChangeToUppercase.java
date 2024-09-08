import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P17ChangeToUppercase {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String text = scanner.nextLine();
        String pattern = "(<upcase>(.*?)<\\/upcase>)";

        Pattern r = Pattern.compile(pattern);
        Matcher match = r.matcher(text);

        for (int i = 0; i < text.length(); i++) {
            if (match.find()) {
                text = text.replace(match.group(1), match.group(2).toUpperCase());
            }
        }
        System.out.println(text);
    }
}
