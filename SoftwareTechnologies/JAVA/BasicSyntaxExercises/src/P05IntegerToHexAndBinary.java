import java.util.Scanner;

public class P05IntegerToHexAndBinary {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int input = Integer.parseInt(scanner.nextLine());

        String binary = Integer.toString(input, 2);
        String hexademical = Integer.toString(input, 16);

        System.out.println(hexademical.toUpperCase());
        System.out.println(binary);
    }
}
