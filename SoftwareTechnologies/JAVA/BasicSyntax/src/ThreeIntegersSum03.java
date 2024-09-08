import java.util.Scanner;

public class ThreeIntegersSum03 {

    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);

        int a = Integer.parseInt(input.next());
        int b = Integer.parseInt(input.next());
        int c = Integer.parseInt(input.next());

        if (a + b == c) {
            System.out.printf("%d + %d = %d", Math.min(a, b), Math.max(a, b), c);
        } else if (a + c == b) {
            System.out.printf("%d + %d = %d", Math.min(a, c), Math.max(a, c), b);
        } else if (b + c == a) {
            System.out.printf("%d + %d = %d", Math.min(c, b), Math.max(c, b), a);
        }
    }
}
