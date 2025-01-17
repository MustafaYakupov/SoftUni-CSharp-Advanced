import java.util.Arrays;
import java.util.Scanner;

public class P07MaxSequenceOfEqualElements {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] val = Arrays.stream(scanner.nextLine().split(" ")).map(Integer::parseInt)
                .mapToInt(i -> i).toArray();

        int count = 0;
        int start = 0;
        int maxCount = 0;

        for (int i = 0; i < val.length - 1; i++) {
            if (val[i] == val[i + 1]) {
                count++;

                if (count > maxCount) {
                    start = i - count;
                    maxCount = count;
                }
            } else {
                count = 0;
            }
        }
        for (int i = start + 1; i <= start + maxCount + 1; i++) {
            System.out.print(val[i] + " ");
        }
    }
}
