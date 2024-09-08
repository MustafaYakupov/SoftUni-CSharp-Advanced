import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class Largest3Numbers06 {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String[] numsAsText = scanner
                .nextLine()
                .split("\\s");

        int[] numbers = new int[numsAsText.length];

        for (int i = 0; i < numbers.length; i++) {
            numbers[i] = Integer.parseInt(numsAsText[i]);
        }

        Arrays.sort(numbers);

        if (numbers.length >= 3){
            for (int i = numbers.length - 1; i > numbers.length - 4; i--) {
                System.out.println(numbers[i]);
            }
        }
        else {
            for (int i = numbers.length - 1; i >= 0; i--) {
                System.out.println(numbers[i]);
            }
        }

    }
}

