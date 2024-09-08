import java.util.Scanner;

public class P16URLParser {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();
        String protocol = text.split("://")[0];
        String rightPart = text.split("://")[1];
        String server = rightPart.split("/")[0];
        String resource = rightPart.split(server + "/")[1];

        System.out.printf("[protocol] = \"%s\"\n", protocol);
        System.out.printf("[server] = \"%s\"\n", server);
        System.out.printf("[resource] = \"%s\"\n", resource);
    }
}
