import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class P12BombNumbers {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<Integer> numbers = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).collect(Collectors.toList());
        int[] infoTokens = Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();

        int specialNumber = infoTokens[0];
        int range = infoTokens[1];

        while (numbers.contains(specialNumber)) {
            int index = numbers.indexOf(specialNumber);

            int leftIndex = index - range;

            if (leftIndex < 0) {
                leftIndex = 0;
            }

            int rightIndex = index + range;

            if (rightIndex  > numbers.size()) {
                rightIndex = numbers.size() - 1;
            }

            numbers.subList(leftIndex, rightIndex + 1).clear();
        }

        int sum = numbers.stream().mapToInt(Integer::intValue).sum();

        System.out.println(sum);
    }
}
