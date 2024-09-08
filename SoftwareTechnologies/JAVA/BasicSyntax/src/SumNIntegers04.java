import java.util.Scanner;

public class SumNIntegers04 {

    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);
        int n = Integer.parseInt(input.nextLine());
        long sum =0;

        for (int i = 0; i < n; i++) {
            sum += Integer.parseInt(input.nextLine());
        }

        System.out.printf("Sum = %d", sum);
    }
}
