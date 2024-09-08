import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Stream;

public class P11EqualSums {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] arr = Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();

        boolean isFound = false;
        int firstSum = 0;
        int secondSum = 0;

        for (int i = 0; i < arr.length; i++) {

            for (int left = 0; left < i; left++) {
                firstSum += arr[left];
            }

            for (int right = i + 1; right < arr.length; right++) {
                secondSum += arr[right];
            }

            if (firstSum == secondSum) {
                System.out.println(i);
                isFound = true;
                break;
            }
            firstSum = 0;
            secondSum = 0;
        }
        if (!isFound) {
            System.out.println("no");
        }
    }
}
