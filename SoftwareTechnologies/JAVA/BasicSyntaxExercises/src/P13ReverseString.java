import javax.xml.stream.events.Characters;
import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;
import java.util.stream.Stream;

public class P13ReverseString {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();

       String reversed = new StringBuilder(input).reverse().toString();

        System.out.println(reversed);
    }
}
