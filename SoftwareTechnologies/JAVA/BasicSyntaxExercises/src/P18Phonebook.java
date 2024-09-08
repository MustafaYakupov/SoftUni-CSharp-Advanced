import java.util.HashMap;
import java.util.Scanner;

public class P18Phonebook {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        HashMap<String, String> phonebook =  new HashMap<>();
        String input = scanner.nextLine();

        while  (input.equals("END") == false) {

            String[] tokens = input.split("\\s");
            String name = "";
            String phone = "";

            if (tokens[0].equals("A")) {
                name = tokens[1];
                phone = tokens[2];

                phonebook.put(name, phone);
            } else if (tokens[0].equals("S")) {
                name = tokens[1];

                if (!phonebook.containsKey(name)){
                        System.out.printf("Contact %s does not exist.\n", name);
                } else {
                    for (String key : phonebook.keySet()) {
                        if (key.equals(name)) {
                            System.out.println(key + " -> " + phonebook.get(key));
                        }
                    }
                }
            }
            input = scanner.nextLine();
        }
    }
}
