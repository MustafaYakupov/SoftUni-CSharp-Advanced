import java.util.HashMap;
import java.util.Scanner;
import java.util.TreeMap;

public class P19PhonebookUpgrade {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        TreeMap<String, String> phonebook =  new TreeMap<>();
        String input = scanner.nextLine();

        while  (input.equals("END") == false) {

            String[] tokens = input.split("\\s");
            String name = "";
            String phone = "";

            if (input.equals("ListAll")) {
                for (String key : phonebook.keySet()) {
                    System.out.println(key + " -> " + phonebook.get(key));
                }
            }

            if (tokens[0].equals("A")) {
                name = tokens[1];
                phone = tokens[2];

                phonebook.put(name, phone);
            } else if (tokens[0].equals("S")) {
                name = tokens[1];

                if (!phonebook.containsKey(name)) {
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
