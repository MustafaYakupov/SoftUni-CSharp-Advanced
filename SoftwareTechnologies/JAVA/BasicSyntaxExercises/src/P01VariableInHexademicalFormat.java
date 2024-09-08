import java.util.Scanner;

public class P01VariableInHexademicalFormat {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String hexademical = scanner.nextLine();
        int decimal = Integer.parseInt(hexademical, 16);
        System.out.println(decimal);
    }
}
