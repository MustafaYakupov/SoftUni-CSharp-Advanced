import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.Scanner;

public class P06CompareCharArrays {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] firstArray = scanner.nextLine().split("\\s");
        String[] secondArray = scanner.nextLine().split("\\s");

        int length = Math.min(firstArray.length, secondArray.length);
        boolean isFirst = false;

        for (int i = 0; i < length; i++) {
            if (firstArray[i] != secondArray[i]) {
                if (firstArray[i].compareTo(secondArray[i]) < 0) {
                    isFirst = true;
                    break;
                } else {
                    break;
                }
            }
        }

        if (isFirst == true) {
            System.out.println(Arrays.toString(firstArray).replaceAll("\\W", ""));
            System.out.println(Arrays.toString(secondArray).replaceAll("\\W", ""));
        } else {
            if (firstArray.length < secondArray.length) {
                System.out.println(Arrays.toString(firstArray).replaceAll("\\W", ""));
                System.out.println(Arrays.toString(secondArray).replaceAll("\\W", ""));
            } else {
                System.out.println(Arrays.toString(secondArray).replaceAll("\\W", ""));
                System.out.println(Arrays.toString(firstArray).replaceAll("\\W", ""));
            }
        }
    }
}
